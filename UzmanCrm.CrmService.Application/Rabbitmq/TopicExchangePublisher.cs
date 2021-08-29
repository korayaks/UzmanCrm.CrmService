using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzmanCrm.CrmService.Application.Rabbitmq
{
    public static class TopicExchangePublisher
    {
        private static Dictionary<string, object> ttl = new Dictionary<string, object>
        {
             {"x-message-ttl",30000 }
        };
        public static void PublishTwitter(IModel channel, string lastMessage)
        {          
            channel.ExchangeDeclare("social-topic-exchange", ExchangeType.Topic, arguments: ttl);
            var body = Encoding.UTF8.GetBytes(lastMessage);
            channel.BasicPublish("social-topic-exchange", "twitter.update", null, body);
        }
        public static void PublishInstagram(IModel channel, string lastMessage)
        {          
            channel.ExchangeDeclare("social-topic-exchange", ExchangeType.Topic, arguments: ttl);
            var body = Encoding.UTF8.GetBytes(lastMessage);
            channel.BasicPublish("social-topic-exchange", "instagram.update", null, body);
        }
    }
}
