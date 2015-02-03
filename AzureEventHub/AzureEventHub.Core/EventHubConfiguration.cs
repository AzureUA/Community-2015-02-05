namespace AzureEventHub.Core
{
	public static class EventHubConfiguration
	{
		public static readonly string Namespace;
		public static readonly string KeyName;
		public static readonly string KeyValue;
		public static readonly string Path;

		static EventHubConfiguration()
		{
			Namespace = "sb://aboyko-demo.servicebus.windows.net/";
			KeyName = "full-access";
			KeyValue = "ZX9lS3Fvkl/C4BcpHDLPBwWkQbOCD2tn+KjPzho2Ijo=";
			Path = "hub01";
		}
	}
}
