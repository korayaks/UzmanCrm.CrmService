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
        public void Send(string lastMessage)
        {
            var connFactory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            using (var connection = connFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    QueueProducer.Publish(channel, lastMessage);
                }
            }
        }
    }
}
