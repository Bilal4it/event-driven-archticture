using Azure.Messaging.ServiceBus;

namespace AzureServiceBusExample
{
    internal class SimpleReceiver
    {
        public static async Task ReceivePeekLockWithoutComplete()
        {
            string connectionString = "Endpoint=sb://servicebus48756.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=61W9L89y+Vt5Esn6XChUqt59p2xzMfOJSFGdrw9DyJo=";
            string queueName = "mydataqueue";

            await using var client = new ServiceBusClient(connectionString);

            // The receiver is responsible for reading messages from the queue.

            ServiceBusReceiver receiver = client.CreateReceiver(queueName);
            //Console.WriteLine(receiver.ReceiveMode);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);
        }

        public static async Task ReceivePeekLockWithComplete()
        {
            string connectionString = "Endpoint=sb://servicebus48756.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=61W9L89y+Vt5Esn6XChUqt59p2xzMfOJSFGdrw9DyJo=";
            string queueName = "mydataqueue";

            await using var client = new ServiceBusClient(connectionString);

            // The receiver is responsible for reading messages from the queue.

            ServiceBusReceiver receiver = client.CreateReceiver(queueName);
            //Console.WriteLine(receiver.ReceiveMode);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);

            // process the message 

            await receiver.CompleteMessageAsync(receivedMessage);

        }

        public static async Task ReceiveAndDelete()
        {
            string connectionString = "Endpoint=sb://servicebus48756.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=61W9L89y+Vt5Esn6XChUqt59p2xzMfOJSFGdrw9DyJo=";
            string queueName = "mydataqueue";

            await using var client = new ServiceBusClient(connectionString);

            // The receiver is responsible for reading messages from the queue.
            var d = new ServiceBusReceiverOptions()
            {
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
            };
            ServiceBusReceiver receiver = client.CreateReceiver(queueName,d);
            //Console.WriteLine(receiver.ReceiveMode);

            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);

        }

    }
}
