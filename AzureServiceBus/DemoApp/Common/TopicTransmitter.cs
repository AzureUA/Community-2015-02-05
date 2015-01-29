using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Common
{
    public abstract class TopicTransmitter<TClient> : BaseTransmitter where TClient : MessageClientEntity
    {
        protected TClient _topicClient;

        protected TopicTransmitter(string topicName, string connectionString) : base(connectionString)
        {
            TopicName = topicName;
        }

        public void Configure()
        {
            ConfigureTopicSettings();
            _topicClient = CreateTopicClient();
        }

        public string TopicName { get; protected set; }

        protected virtual NamespaceManager ConfigureTopicSettings()
        {
            // Configure Queue Settings
            var topicDescription = new TopicDescription(TopicName)
            {
                MaxSizeInMegabytes = 5120,
                DefaultMessageTimeToLive = new TimeSpan(0, 10, 0)
            };

            // Create a new Queue with custom settings
            var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!namespaceManager.TopicExists(TopicName))
            {
                namespaceManager.CreateTopic(topicDescription);
            }

            return namespaceManager;
        }

        protected abstract TClient CreateTopicClient();

    }
}