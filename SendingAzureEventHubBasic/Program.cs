namespace SendingAzureEventHubBasic
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting our Event Hub Producer");

            string namespaceConnectionString = "Endpoint=sb://resources-events.servicebus.windows.net/;SharedAccessKeyName=sendandreceive;SharedAccessKey=B87i7DCK7Wk7UL52UQ9MgKdLI/GOPvb3t+AEhHRa0Hk=;EntityPath=demoevnethub";
            string eventHubName = "demoevnethub";


        }
    }
}