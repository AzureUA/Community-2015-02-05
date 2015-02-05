using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureEventHub.Infrastructure.Services
{
	public interface IMessageServiceAsync<T>
	{
		Task SendMessage(T message);

		Task SendMessageBatch(IEnumerable<T> messages);

		Task<T> ReceiveMessage(TimeSpan timeout);
	}
}
