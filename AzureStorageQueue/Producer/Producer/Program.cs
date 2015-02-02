using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Producer
{
    class Program
    {
        private static string _cloudConnectionString = "DefaultEndpointsProtocol=https;AccountName=communitydemo;AccountKey=i+e7ABm1DJu9+EL8phDuW+sLswYEobOUPVTjgaS3n3O+NTm7URfIAvEI3NBQD70+vqtgdbZMGf60B6ceXdxG0g==";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Retrieve storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_cloudConnectionString);

            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("communitydemoqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();
            int i = 0;
            while (true)
            {
                string messageToSend = string.Format("message #{0}", i);

                // Create a message and add it to the queue.
                CloudQueueMessage message = new CloudQueueMessage(messageToSend);
                queue.AddMessage(message);

                Console.WriteLine("Sent: {0}", messageToSend);

                i++;
                Thread.Sleep(1000);
            }
        }
    }
}
