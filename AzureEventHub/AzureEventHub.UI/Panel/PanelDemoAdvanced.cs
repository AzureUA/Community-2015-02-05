using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureEventHub.Core.Contract;
using AzureEventHub.Core.Services;
using AzureEventHub.Infrastructure.Services;

namespace AzureEventHub.UI.Panel
{
	public partial class PanelDemoAdvanced : UserControl
	{
		private readonly IMessageServiceAsync<SimpleMessage> _messageService;

		private Thread _senderThread;
		private Thread _receiverThread;

		private MessageSerderWorker _senderWorker;
		private MessageReceiverWorker _receiverWorker;

		public PanelDemoAdvanced()
		{
			InitializeComponent();

			_messageService = new AzureEventHubMessageService<SimpleMessage>();

			_senderWorker = new MessageSerderWorker(_messageService);
			_senderThread = new Thread(_senderWorker.StartMessageSender);

			_receiverWorker = new MessageReceiverWorker(_messageService);
			_receiverWorker.OnMessageReceived += SenderWorkerOnOnMessageReceived;

			_receiverThread = new Thread(_receiverWorker.StartMessageReceiver);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			rtbMessages.Clear();

			_senderThread.Start();

			_receiverThread.Start();

			btnStart.Enabled = false;
			btnStop.Enabled = true;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			_senderWorker.RequestStop();
			_senderThread.Abort();

			_receiverWorker.RequestStop();
			_receiverThread.Abort();

			btnStart.Enabled = true;
			btnStop.Enabled = false;
		}

		private void SenderWorkerOnOnMessageReceived(SimpleMessage status)
		{
			var text = rtbMessages.GetPropertyThreadSafe(() => rtbMessages.Text);

			if (!string.IsNullOrWhiteSpace(text))
			{
				text += Environment.NewLine;
			}

			text += string.Format("email: {0}; bet: {1}; lot: {2}", status.EMail, status.Bet, status.Lot);

			rtbMessages.SetPropertyThreadSafe(() => rtbMessages.Text, text);
		}

		sealed class MessageSerderWorker
		{
			private bool stop;

			public void RequestStop()
			{
				stop = true;
			}

			private readonly IMessageServiceAsync<SimpleMessage> _messageService;

			public MessageSerderWorker(IMessageServiceAsync<SimpleMessage> messageService)
			{
				_messageService = messageService;
			}

			internal async void StartMessageSender()
			{
				var rnd = new Random();
				var oneSecond = new TimeSpan(0, 0, 1);

				while (!stop)
				{
					await _messageService.SendMessage(new SimpleMessage
					{
						EMail = "boyko.ant@live.com",
						Bet = (decimal)rnd.NextDouble() * 100,
						Lot = Guid.Empty
					});

					await Task.Delay(oneSecond);
				}
			}
		}

		sealed class MessageReceiverWorker
		{
			private bool stop;

			public void RequestStop()
			{
				stop = true;
			}

			internal delegate void MessageReceiver(SimpleMessage status);

			internal event MessageReceiver OnMessageReceived;

			private void TriggerOnMessageReceived(SimpleMessage status)
			{
				var handler = OnMessageReceived;
				if (handler != null)
				{
					handler(status);
				}
			}

			private readonly IMessageServiceAsync<SimpleMessage> _messageService;

			public MessageReceiverWorker(IMessageServiceAsync<SimpleMessage> messageService)
			{
				_messageService = messageService;
			}

			internal async void StartMessageReceiver()
			{
				var oneSecond = new TimeSpan(0, 0, 1);

				while (!stop)
				{
					var message = await _messageService.ReceiveMessage(oneSecond);

					if (message != null)
					{
						TriggerOnMessageReceived(message);
					}
				}
			}
		}
	}
}
