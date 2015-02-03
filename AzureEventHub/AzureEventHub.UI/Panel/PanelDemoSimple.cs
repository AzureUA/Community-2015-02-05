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
			var message = tbMessage.Text.Trim();

			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			new Thread(async () => { await _messageService.SendMessage(message); }).Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var thread = new Thread(StartMessageReceiver);
			thread.Name = string.Format("Receiver Thread {0}", _receiverThreads.Count + 1);
			thread.Start();
			
			_receiverThreads.Add(thread);

			lbReceiversCount.Text = _receiverThreads.Count.ToString();
		}

		private async void StartMessageReceiver()
		{
			var oneSecond = new TimeSpan(0, 0, 1);

			while (true)
			{
				var message = await _messageService.ReceiveMessage(oneSecond);

				if (message != null)
				{
					var status = string.Format("{0} received: {1}", Thread.CurrentThread.Name, message);
				}

				Thread.Sleep(oneSecond);
			}
		}
	}
}
