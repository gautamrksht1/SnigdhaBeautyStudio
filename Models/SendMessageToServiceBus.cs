using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace SnigdhaBeautyStudio.Models
{
    public class SendMessageToServiceBus
    {
        public SendMessageToServiceBus() { }

        public async Task<bool> SendMessage(EnquiryViewModel model)
        {
            bool result = false;
            string connString = "Endpoint=sb://snigdhabeautystudio.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=o/gxb9yaDrqqBUhoj+ryvc6vJ7ylTGsYg+ASbMbDbB0=";

            string queueName = "enquiry";

            int maxMessageCount = 3;

            ServiceBusClient client = new ServiceBusClient(connString) ;
            ServiceBusSender sender;

           sender = client.CreateSender(queueName);

            using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
            for (int i = 1; i <= maxMessageCount; i++)
            {
                if (!batch.TryAddMessage(new ServiceBusMessage(JsonConvert.SerializeObject(model))))
                {
                    Console.WriteLine("Error writing to batch");
                }
            }

            try 
            {
                await sender.SendMessagesAsync(batch);
                result = true;
            } 
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
    }
}
