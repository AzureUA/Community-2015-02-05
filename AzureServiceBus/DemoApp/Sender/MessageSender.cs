using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ConsoleApplication1
{
    public class MessageSender
    {
        private readonly string _connectionString;
        private readonly QueueClient _queueClient;

        public MessageSender(string queueName, string connectionString)
        {
            _connectionString = connectionString;
            QueueName = queueName;

            ConfigureQueueSettings();
            _queueClient = CreateQueueClient();
        }

        public string QueueName { get; private set; }

        private void ConfigureQueueSettings()
        {
            // Configure Queue Settings
            QueueDescription qd = new QueueDescription(QueueName);
            qd.MaxSizeInMegabytes = 5120;
            qd.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            // Create a new Queue with custom settings
            var namespaceManager =
                NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.CreateQueue(qd);
            }
        }

        private QueueClient CreateQueueClient()
        {
            return QueueClient.CreateFromConnectionString(_connectionString, QueueName);
        }

        public void Send(BrokeredMessage message)
        {
            _queueClient.Send(message);
        }

        public BrokeredMessage Send(string label, object serializableObject = null, IDictionary<string, object> properties = null)
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

            _queueClient.Send(message);

            return message;
        }

        public void SendSpam(string label, string messagePattern, int spamCount = 10)
        {
            for (int i=0; i<spamCount; i++)
            {
                var text = string.Format("{0} - {1}", messagePattern, i);
                Send(label, text);
            }
        }
    }
}
