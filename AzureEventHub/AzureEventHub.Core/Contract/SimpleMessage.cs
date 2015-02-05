using System;

namespace AzureEventHub.Core.Contract
{
	public class SimpleMessage
	{
		public string EMail { get; set; }

		public Guid Lot { get; set; }

		public decimal Bet { get; set; }
	}
}
