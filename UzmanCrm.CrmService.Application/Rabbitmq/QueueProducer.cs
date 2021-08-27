using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzmanCrm.CrmService.Application.Rabbitmq
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel, string lastMessage)
        {
            channel.QueueDeclare(queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
            string message = lastMessage;
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: "hello",
                body: body);
        }
    }
}
