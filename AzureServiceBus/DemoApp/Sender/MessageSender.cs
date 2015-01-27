using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Common;

namespace ConsoleApplication1
{
    public class MessageSender : Transmitter
    {
        private readonly string _connectionString;
        private readonly QueueClient _queueClient;

        public MessageSender(string queueName, string connectionString) : base(queueName, connectionString)
        {
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
