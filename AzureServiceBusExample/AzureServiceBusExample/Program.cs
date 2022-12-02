using AzureServiceBusExample;


while (true)
    await SimpleReceiver.ReceivePeekLockWithoutComplete();

//await TopicSender.SendBatchMessages();
//await SubscriptionReceiver.ReceiveMessages();

//await SimpleSender.Send("This is the first message");

//var i = 1;
//while (true)
//{
//    string ms = "Message number "  + i++;
//    await SimpleSender.Send(ms);
//}

//await SimpleReceiver.ReceivePeekLockWithoutComplete();

//await MessageSender.SendMessage();
//await MessageReciever.ReceiveMessage();
