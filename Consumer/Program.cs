using ComputerSystemIntegration.DataAccess.DAL;
using ComputerSystemIntegration.Domain;
using ComputerSystemIntegration.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                var repository = GetRepository();

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var vacancy = (Vacancy)BinaryConverter.ByteArrayToObject(body);
                    
                    repository.AddNew(vacancy);

                    Console.WriteLine(" [x] Received {0}", vacancy);
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public static IRepository GetRepository()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var config = new MongoConfig();
            configuration.GetSection("MongoConnection").Bind(config);

            MapperConfiguration mapperConfig = new MapperConfiguration(c => c.AddProfiles(typeof(IRepository).Assembly));

            return new Repository(config, mapperConfig.CreateMapper());
        }
    }
}
