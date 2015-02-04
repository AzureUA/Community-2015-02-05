using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureEventHub.Core.Services
{
	public class AzureEventHubMessageService<T> : AzureEventHubMessageServiceBase<T>
	{
		public override Task SendMessage(T messageText)
		{
			throw new NotImplementedException();
		}

		public override Task SendMessageBatch(IEnumerable<T> messages)
		{
			throw new NotImplementedException();
		}

		public override Task<T> ReceiveMessage(TimeSpan timeout)
		{
			throw new NotImplementedException();
		}
	}
}
