using Common;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    public class MessageReceiver : Transmitter
    {
        public MessageReceiver(string queueName, string connectionString)
            : base(queueName, connectionString)
        {
        }

        public BrokeredMessage Read()
        {
            return _queueClient.Receive(new TimeSpan(0, 1, 0));
        }
    }
}
