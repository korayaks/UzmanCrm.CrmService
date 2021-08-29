using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UzmanCrm.CrmService.Application.Rabbitmq
{
    public static class CreateChannel
    {
        public static IModel CreateModel()
        {
            var connFactory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            var connection = connFactory.CreateConnection();
            var channel = connection.CreateModel();
            return channel;
        }
    }
}
