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

        public BrokeredMessage Read(int timeoutInMinutes = 1)
        {
            return _queueClient.Receive(new TimeSpan(0, timeoutInMinutes, 0));
        }

        protected override QueueClient CreateQueueClient()
        {
            return QueueClient.CreateFromConnectionString(_connectionString, QueueName, ReceiveMode.ReceiveAndDelete);
        }
    }
}
