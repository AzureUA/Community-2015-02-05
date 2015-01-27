using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Transmitter
    {
        protected readonly string _connectionString;
        protected readonly QueueClient _queueClient;

        protected Transmitter(string queueName, string connectionString)
        {
            _connectionString = connectionString;

            QueueName = queueName;

            ConfigureQueueSettings();
            _queueClient = CreateQueueClient();
        }

        public string QueueName { get; protected set; }

        private void ConfigureQueueSettings()
        {
            // Configure Queue Settings
            QueueDescription qd = new QueueDescription(QueueName);
            qd.MaxSizeInMegabytes = 5120;
            qd.DefaultMessageTimeToLive = new TimeSpan(0, 10, 0);

            // Create a new Queue with custom settings
            var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.CreateQueue(qd);
            }
        }

        private QueueClient CreateQueueClient()
        {
            return QueueClient.CreateFromConnectionString(_connectionString, QueueName);
        }
    }
}
