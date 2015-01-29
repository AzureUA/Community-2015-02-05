using System;
using Common;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace TopicSubscriber
{
    public class TopicMessageSubscriber : TopicTransmitter<SubscriptionClient>
    {
        ReceiveMode _receiveMode = ReceiveMode.PeekLock;
        public TopicMessageSubscriber(string topicName, string subscriptionName, string connectionString, ReceiveMode receiveMode = ReceiveMode.PeekLock)
            : base(topicName, connectionString)
        {
            _receiveMode = receiveMode;
            SubscriptionName = subscriptionName;
        }

        public string SubscriptionName { get; private set; }

        public BrokeredMessage ReceiveFromSubscription()
        {
            return _topicClient.Receive(new TimeSpan(0, 1, 0));
        }

        protected override SubscriptionClient CreateTopicClient()
        {
            return SubscriptionClient.CreateFromConnectionString(_connectionString, TopicName, SubscriptionName, _receiveMode);
        }

        protected override NamespaceManager ConfigureTopicSettings()
        {
            var manager = base.ConfigureTopicSettings();
            if (!manager.SubscriptionExists(TopicName, SubscriptionName))
            {
                var subscriptionDescr = new SubscriptionDescription(TopicName, SubscriptionName)
                {
                    AutoDeleteOnIdle = new TimeSpan(1, 0, 0)
                };

                manager.CreateSubscription(subscriptionDescr);
            }

            return manager;
        }
    }
}