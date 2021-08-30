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
             {"x-message-ttl",30000 }//Set ttl (Time-To-Live) 30 sec.
        };
        public static void PublishTwitter(IModel channel, string lastMessage)
        {          
            channel.ExchangeDeclare("social-topic-exchange", ExchangeType.Topic, arguments: ttl);//Declare Exchange name , type, and arguments.
            var body = Encoding.UTF8.GetBytes(lastMessage);//body is a converted lastMessage string to byte array
            channel.BasicPublish("social-topic-exchange", "twitter.update", null, body);//Publish body from social-topic-exchange and routeKey is twitter.update
        }//This routeKey is important, routeKey must starts with "twitter." for going to the Twitter Service
        public static void PublishInstagram(IModel channel, string lastMessage)
        {          
            channel.ExchangeDeclare("social-topic-exchange", ExchangeType.Topic, arguments: ttl);//Declare Exchange name , type, and arguments.
            var body = Encoding.UTF8.GetBytes(lastMessage);//body is a converted lastMessage string to byte array
            channel.BasicPublish("social-topic-exchange", "instagram.update", null, body);//Publish body from social-topic-exchange and routeKey is instagram.update
        }//This routeKey is important, routeKey must starts with "instagram." for going to the Instagram Service
    }
}
