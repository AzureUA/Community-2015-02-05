using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureEventHub.Infrastructure.Services;
using Microsoft.ServiceBus.Messaging;

namespace AzureEventHub.Core.Services
{
	public abstract class AzureEventHubMessageServiceBase<T> : IMessageServiceAsync<T>
	{
		protected readonly EventHubClient _client;

		protected readonly int _partitionKey;
		protected readonly string _groupName;

		private EventHubSender _sender;
		private EventHubReceiver _receiver;

		protected EventHubSender Sender
		{
			get { return _sender ?? (_sender = _client.CreatePartitionedSender(_partitionKey.ToString())); }
		}

		protected EventHubReceiver Receiver
		{
			get { return _receiver ?? (_receiver = _client.GetDefaultConsumerGroup().CreateReceiver(_partitionKey.ToString())); }
		}

		protected AzureEventHubMessageServiceBase()
			: this(0, "DefaultGroupName")
		{
		}

		protected AzureEventHubMessageServiceBase(int partitionKey, string groupName)
		{
			_client = EventHubClient.CreateFromConnectionString(
				string.Format("Endpoint={0};SharedAccessKeyName={1};SharedAccessKey={2}",
					EventHubConfiguration.Namespace,
					EventHubConfiguration.KeyName,
					EventHubConfiguration.KeyValue),
				EventHubConfiguration.Path);

			_partitionKey = partitionKey;
			_groupName = groupName;

			//EventHubDescription ehd = new EventHubDescription(EventHubConfiguration.Path);

			//NamespaceManager manager = NamespaceManager.CreateFromConnectionString(GetServiceBusConnectionString()); 

			//manager.CreateEventHubIfNotExistsAsync(ehd.Path).Wait();
			//manager.CreateConsumerGroupIfNotExistsAsync(ehd.Path, _groupName).Wait(); 
		}

		public abstract Task SendMessage(T messageText);
		
		public abstract Task SendMessageBatch(IEnumerable<T> messages);

		public abstract Task<T> ReceiveMessage(TimeSpan timeout);

		//private static string GetServiceBusConnectionString()
		//{
		//	string connectionString = string.Format("Endpoint={0};SharedAccessKeyName={1};SharedAccessKey={2}",
		//			EventHubConfiguration.Namespace,
		//			EventHubConfiguration.KeyName,
		//			EventHubConfiguration.KeyValue);
		//	var builder = new ServiceBusConnectionStringBuilder(connectionString);
		//	builder.TransportType = TransportType.Amqp;

		//	return builder.ToString();
		//} 
	}
}
