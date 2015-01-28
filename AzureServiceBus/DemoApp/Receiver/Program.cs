using Microsoft.WindowsAzure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the queue if it does not exist already
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string queueName = CloudConfigurationManager.GetSetting("queueName");

            Console.WriteLine("Creating instance of {0}", typeof(MessageReceiver).Name);
            var receiver = new MessageReceiver(queueName, connectionString);
            receiver.Configure();

            Console.WriteLine("Start receiving messages from queue.");
            Console.WriteLine(new string('-', 10));
            const int processCount = 10;
            for (int i = 1; i <= processCount; i++)
            {
                Console.WriteLine("Retrieving {0}-{1} message ...", i, i == 1 ? "st" : (i == 2?"nd": (i == 3?"rd": "th")));
                var message = receiver.Read();
                if (message != null)
                {
                    Console.WriteLine("Received message with text: '{0}', label: '{1}'", message.GetBody<string>(), message.Label);
//                    message.Complete();
                }
                else
                {
                    Console.WriteLine("Message is null. Stop receiving further messages.");
                    break;
                }
            }
            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Finish receiving messages. And exiting application.");
            Console.WriteLine("...");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
