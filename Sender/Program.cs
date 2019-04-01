using ComputerSystemIntegration.DataRetriver;
using ComputerSystemIntegration.Domain;
using RabbitMQ.Client;
using System;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler creawler = new Crawler();
            var news = creawler.Crawl();

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                foreach (var item in news)
                {
                    var body = BinaryConverter.ObjectToByteArray(item);
                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);

                    Console.WriteLine(" [x] Sent {0}", item.Title);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
