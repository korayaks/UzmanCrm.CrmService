using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Rabbitmq;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class RabbitmqService : IRabbitmqService
    {
        private static ConnectionFactory connFactory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
        private static IConnection connection = connFactory.CreateConnection();
        private static IModel _channel = connection.CreateModel();
        public void SendTwitter(string lastMessage)
        {            
            TopicExchangePublisher.PublishTwitter(_channel, lastMessage);
        }
        public void SendInstagram(string lastMessage)
        {
            TopicExchangePublisher.PublishInstagram(_channel, lastMessage);
        }
    }
}
