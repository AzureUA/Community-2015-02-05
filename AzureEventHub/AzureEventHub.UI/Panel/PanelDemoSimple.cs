using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using AzureEventHub.Core.Services;
using AzureEventHub.Infrastructure.Services;

namespace AzureEventHub.UI.Panel
{
	public partial class PanelDemoSimple : UserControl
	{
		private readonly List<Thread> _receiverThreads;
		private readonly IMessageServiceAsync<string> _messageService;

		public PanelDemoSimple()
		{
			InitializeComponent();

			_receiverThreads = new List<Thread>();
			_messageService = new AzureEventHubSimpleMessageService();
		}

		private void btnSendMessage_Click(object sender, EventArgs e)
		{
			SendMessages(tbMessage.Text.Trim(), 1);
		}

		private void btnSendMessage10_Click(object sender, EventArgs e)
		{
			SendMessages(tbMessage.Text.Trim(), 10);
		}

		private void btnSendMessage100_Click(object sender, EventArgs e)
		{
			SendMessages(tbMessage.Text.Trim(), 100);
		}

		private void SendMessages(string message, int count)
		{
			switch (count)
			{
				case 0:
					return;
				case 1:
					new Thread(async () => { await _messageService.SendMessage(message); }).Start();
					break;
				default:
					var data = new List<string>();

					for (int i = 0; i < count; i++)
					{
						data.Add(string.Format("{0} #{1}", message, i));
					}

					new Thread(async () => { await _messageService.SendMessageBatch(data); }).Start();
					break;
			}
			tbMessage.Clear();
		}

		private void btnCreateReceiver_Click(object sender, EventArgs e)
		{
			CreateReceivers(1);
		}

		private void btnCreateReceiver10_Click(object sender, EventArgs e)
		{
			CreateReceivers(5);
		}

		private void CreateReceivers(int count)
		{
			for (int i = 0; i < count; i++)
			{
				var worker = new MessageReceiverWorker(_messageService, _receiverThreads.Count + 1);
				worker.OnMessageReceived += delegate(string status)
				{
					var text = rtbMessages.GetPropertyThreadSafe(() => rtbMessages.Text);

					text = string.IsNullOrWhiteSpace(text) ?
						status :
						string.Format("{0}{1}{2}", text, Environment.NewLine, status);

					rtbMessages.SetPropertyThreadSafe(() => rtbMessages.Text, text);
				};

				var thread = new Thread(worker.StartMessageReceiver);
				thread.Start();

				_receiverThreads.Add(thread);

				lbReceiversCount.Text = _receiverThreads.Count.ToString();
			}
		}

		sealed class MessageReceiverWorker
		{
			internal delegate void MessageReceiver(string status);

			internal event MessageReceiver OnMessageReceived;

			private void TriggerOnMessageReceived(string status)
			{
				var handler = OnMessageReceived;
				if (handler != null)
				{
					handler(status);
				}
			}

			private readonly IMessageServiceAsync<string> _messageService;
			private readonly int _receiverNumber;

			public MessageReceiverWorker(IMessageServiceAsync<string> messageService, int receiverNumber)
			{
				_messageService = messageService;
				_receiverNumber = receiverNumber;
			}

			internal async void StartMessageReceiver()
			{
				var oneSecond = new TimeSpan(0, 0, 1);

				while (true)
				{
					var message = await _messageService.ReceiveMessage(oneSecond);

					if (message != null)
					{
						var status = string.Format("worker #{0} received: {1}", _receiverNumber, message);

						TriggerOnMessageReceived(status);
					}
				}
			}
		}
	}
}
