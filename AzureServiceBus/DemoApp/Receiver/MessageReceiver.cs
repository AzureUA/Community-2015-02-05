using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    public class MessageReceiver
    {
        private readonly string _connectionString;
        public MessageReceiver(string connectionString, string queueName)
        {
            _connectionString = connectionString;
            QueueName = queueName;
        }

        public string QueueName { get; private set; }
    }
}
