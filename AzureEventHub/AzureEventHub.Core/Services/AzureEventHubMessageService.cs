using System;
using System.Threading.Tasks;

namespace AzureEventHub.Core.Services
{
	public class AzureEventHubMessageService<T> : AzureEventHubMessageServiceBase<T>
	{
		public override Task SendMessage(T messageText)
		{
			throw new NotImplementedException();
		}

		public override Task<T> ReceiveMessage(TimeSpan timeout)
		{
			throw new NotImplementedException();
		}
	}
}
