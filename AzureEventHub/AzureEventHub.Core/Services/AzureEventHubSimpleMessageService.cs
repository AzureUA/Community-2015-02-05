using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace AzureEventHub.Core.Services
{
	public class AzureEventHubSimpleMessageService : AzureEventHubMessageServiceBase<string>
	{
		public async override Task SendMessage(string messageText)
		{
			var data = new EventData(Encoding.UTF8.GetBytes(messageText));

			await Sender.SendAsync(data);
		}

		public async override Task<string> ReceiveMessage(TimeSpan timeout)
		{
			var message = await Receiver.ReceiveAsync(timeout);

			return message == null ? 
				null :
				Encoding.UTF8.GetString(message.GetBytes());
		}
	}
}
