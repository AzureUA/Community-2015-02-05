using System;
using System.Collections.Generic;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace Sender
{
    public class MessageSender : Transmitter
    {
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
