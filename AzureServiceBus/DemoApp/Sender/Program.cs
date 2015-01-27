#define spam

using Microsoft.ServiceBus;
using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the queue if it does not exist already
            Console.WriteLine("--== Running '{0}' ==--", typeof(Program).Assembly.ToString());

            Console.WriteLine("Retrieving connection string from appConfig");
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            string queueName = CloudConfigurationManager.GetSetting("queueName");
            Console.WriteLine("Queue name to communicate: {0}", queueName);

            var messageSender = new MessageSender(queueName, connectionString);

#if spam

            var spamCount = 10;
            messageSender.SendSpam("Custome label", "Custome message", spamCount);
            Console.WriteLine("Sent {0} messages to queue", spamCount);
#else

            Console.WriteLine("Sending a message to queue ...");
            var message = messageSender.Send("Label", "some string");

            Console.WriteLine("Message was sent.");
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Message details:");
            Console.WriteLine("Id: {0} \nLabel: '{1}' \nBody: '{2}'", message.MessageId, message.Label, message.GetBody<string>());
            Console.WriteLine(new string('-', 10));
#endif
            Console.WriteLine("Exiting application.");
            Console.WriteLine("...");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
