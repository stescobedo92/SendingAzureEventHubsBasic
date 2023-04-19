using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace SendingAzureEventHubBasic
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting our Event Hub Producer");

            string namespaceConnectionString = "Endpoint=sb://resources-events.servicebus.windows.net/;SharedAccessKeyName=sendandreceive;SharedAccessKey=B87i7DCK7Wk7UL52UQ9MgKdLI/GOPvb3t+AEhHRa0Hk=;EntityPath=demoevnethub";
            string eventHubName = "demoevnethub";

            await SendAndEnumerableOfEvents(namespaceConnectionString, eventHubName);
            await SendBatchOfEvents(namespaceConnectionString, eventHubName);

            Console.WriteLine("Sent the events");
        }

        private static async Task SendBatchOfEvents(string namespaceConnectionString, string eventHubName)
        {
            EventHubProducerClient producer = new EventHubProducerClient(namespaceConnectionString, eventHubName);
            
            var batch = await producer.CreateBatchAsync();

            for (int i = 0; i < 10; i++)
            {
                batch.TryAdd(new EventData($"This is event: {i}"));
            }

            await producer.SendAsync(batch);
        }

        private static async Task SendAndEnumerableOfEvents(string namespaceConnectionString, string eventHubName)
        {
            EventHubProducerClient producer = new EventHubProducerClient(namespaceConnectionString, eventHubName);
            List<EventData> events = new List<EventData>();

            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData($"This is event: {i}"));
            }

            await producer.SendAsync(events);
        }
    }
}