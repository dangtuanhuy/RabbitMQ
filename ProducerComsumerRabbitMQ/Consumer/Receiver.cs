using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("DangTuanHuy", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;

                    var ms = Encoding.UTF8.GetString(body);

                    Console.WriteLine("Recevice Mess {0}", ms);

                };
                channel.BasicConsume("DangTuanHuy", true, consumer);

                Console.WriteLine("Press Enter to Exit");
                Console.ReadLine();
            }
            
        }
    }
}
