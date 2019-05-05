using ComputerSystemIntegration.DataRetriver;
using ComputerSystemIntegration.Domain;
using RabbitMQ.Client;
using System;
using System.Threading;

namespace Sender
{
    class Program
    {
        private static Timer timer;
        static void Main(string[] args)
        {
            timer = new Timer(GetData,null,0,10000);
           
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public static void GetData(object o)
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
        }
    }
}
