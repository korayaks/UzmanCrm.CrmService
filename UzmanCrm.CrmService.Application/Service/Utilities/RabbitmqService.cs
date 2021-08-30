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
        private static ConnectionFactory connFactory = new ConnectionFactory { HostName = "localhost", Port = 5672 };//create connection factory
        private static IConnection connection = connFactory.CreateConnection();//create connection
        private static IModel _channel = connection.CreateModel();//create channel
        public void SendTwitter(string lastMessage)//lastMessage is same as with message through to the Controller.
        {            
            TopicExchangePublisher.PublishTwitter(_channel, lastMessage);//publish lastMessage to the Twitter Service
        }
        public void SendInstagram(string lastMessage)
        {
            TopicExchangePublisher.PublishInstagram(_channel, lastMessage);//publish lastMessage to the Instagram Service
        }
    }
}
