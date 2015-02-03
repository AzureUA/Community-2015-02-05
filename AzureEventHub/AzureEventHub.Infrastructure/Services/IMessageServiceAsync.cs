using System;
using System.Threading.Tasks;

namespace AzureEventHub.Infrastructure.Services
{
	public interface IMessageServiceAsync<T>
	{
		Task SendMessage(T messageText);

		Task<T> ReceiveMessage(TimeSpan timeout);
	}
}
