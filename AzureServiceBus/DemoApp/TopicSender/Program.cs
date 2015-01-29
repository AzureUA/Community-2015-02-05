using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace TopicSender
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the queue if it does not exist already
            Console.WriteLine("--== Running '{0}' ==--", typeof(Program).Assembly);

            Console.WriteLine("Retrieving connection string from appConfig ...");
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string topicName = CloudConfigurationManager.GetSetting("topicName");

            Console.WriteLine("Topic to communicate: '{0}'.", topicName);

            Console.WriteLine("Creating instance of '{0}' ...", typeof(TopicMessageSender).Name);
            var sender = new TopicMessageSender(topicName, connectionString);
            sender.Configure();

            Console.WriteLine("Sending a messages to topic ...");
            var msgCount = 10;
            for (int i = 0; i < msgCount; i++)
            {
                sender.SendToTopic(new BrokeredMessage(string.Format("some text, sent to topic - {0}", i)));
            }

            Console.WriteLine("{0} messages were sent.", msgCount);

            Console.WriteLine("Exiting application.");
            Console.WriteLine("...");
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
