using System;
using System.Collections.Generic;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace TopicSender
{
    public class TopicMessageSender : TopicTransmitter<TopicClient>
    {
        public TopicMessageSender(string topicName, string connectionString)
            : base(topicName, connectionString)
        {
        }

        public void SendToTopic(BrokeredMessage message)
        {
            _topicClient.Send(message);
        }

        public BrokeredMessage SendToTopic(string label, object serializableObject = null,
            IDictionary<string, object> properties = null)
        {
            var message = new BrokeredMessage(serializableObject)
            {
                MessageId = Guid.NewGuid().ToString(),
                Label = label,
                TimeToLive = new TimeSpan(0, 10, 0)
            };

            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    message.Properties.Add(prop);
                }
            }

            _topicClient.Send(message);

            return message;
        }

        protected override TopicClient CreateTopicClient()
        {
            return TopicClient.CreateFromConnectionString(_connectionString, TopicName);
        }
    }
}