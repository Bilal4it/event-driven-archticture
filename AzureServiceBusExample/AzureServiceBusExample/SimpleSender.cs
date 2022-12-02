using Azure.Messaging.ServiceBus;

namespace AzureServiceBusExample
{
    internal class SimpleSender
    {
        public static async Task Send(string msg)
        {
            string connectionString = "Endpoint=sb://servicebus48756.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=61W9L89y+Vt5Esn6XChUqt59p2xzMfOJSFGdrw9DyJo=";
            string queueName = "mydataqueue";

            // Because ServiceBusClient implements IAsyncDisposable, we'll create it 
            // with "await using" so that it is automatically disposed for us.
            await using var client = new ServiceBusClient(connectionString);

            // The sender is responsible for publishing messages to the queue.
            ServiceBusSender sender = client.CreateSender(queueName);
            ServiceBusMessage message = new ServiceBusMessage(msg);

            await sender.SendMessageAsync(message);
        }

    }
}
