using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureEventHub.Infrastructure.Helpers;
using Microsoft.ServiceBus.Messaging;

namespace AzureEventHub.Core.Services
{
	public class AzureEventHubMessageService<T> : AzureEventHubMessageServiceBase<T> where T : class, new()
	{
		public async override Task SendMessage(T message)
		{
			var data = GetEventData(message);

			await Sender.SendAsync(data);
		}

		public async override Task SendMessageBatch(IEnumerable<T> messages)
		{
			var data = messages
				.AsParallel()
				.Select(GetEventData)
				.ToList();

			await Sender.SendBatchAsync(data);
		}

		public async override Task<T> ReceiveMessage(TimeSpan timeout)
		{
			var data = await Receiver.ReceiveAsync(timeout);

			return data == null ?
				null :
				GetMessage(data);
		}

		private EventData GetEventData(T message)
		{
			var data = new EventData();

			foreach (var property in message.CreatePropertyBag())
			{
				data.Properties.Add(property);
			}

			return data;
		}

		private T GetMessage(EventData data)
		{
			var message = data.Properties.GetFromPropertyBag<T>();

			return message;
		}
	}
}
