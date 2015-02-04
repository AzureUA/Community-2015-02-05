using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Consumer
{
    class Program
    {
        private static string _cloudConnectionString = "DefaultEndpointsProtocol=https;AccountName=communitydemo;AccountKey=i+e7ABm1DJu9+EL8phDuW+sLswYEobOUPVTjgaS3n3O+NTm7URfIAvEI3NBQD70+vqtgdbZMGf60B6ceXdxG0g==";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Retrieve storage account from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_cloudConnectionString);

            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("communitydemoqueue");
            while (true)
            {
                // Get the next message
                CloudQueueMessage retrievedMessage = queue.GetMessage();

                if (retrievedMessage != null)
                {
                    //Process the message in less than 30 seconds, and then delete the message
                    queue.DeleteMessage(retrievedMessage);

                    Console.WriteLine("Received: {0}", retrievedMessage.AsString);
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
