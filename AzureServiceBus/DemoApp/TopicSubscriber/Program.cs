using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;

namespace TopicSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the queue if it does not exist already
            Console.WriteLine("--== Running '{0}' ==--", typeof(Program).Assembly);

            Console.WriteLine("Retrieving connection string from appConfig");
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string topicName = CloudConfigurationManager.GetSetting("topicName");
            string subscriptionName = CloudConfigurationManager.GetSetting("subscriptionName");

            Console.WriteLine("Topic to communicate: '{0}'. Subscription name: '{1}'", topicName, subscriptionName);

            Console.WriteLine("Creating instance of '{0}' ...", typeof(TopicMessageSubscriber).Name);
            var receiver = new TopicMessageSubscriber(topicName, subscriptionName, connectionString);
            receiver.Configure();

            var countToReceive = 10;

            for (int i = 1; i <= countToReceive; i++)
            {
                Console.WriteLine("Retrieving {0}-{1} message ...", i, i == 1 ? "st" : (i == 2 ? "nd" : (i == 3 ? "rd" : "th")));
                var message = receiver.ReceiveFromSubscription();

                if (message != null)
                {
                    Console.WriteLine("Received message with text: '{0}', label: '{1}'", message.GetBody<string>(), message.Label);
                    message.Complete();
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
