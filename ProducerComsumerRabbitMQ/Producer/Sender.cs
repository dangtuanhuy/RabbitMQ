using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("DangTuanHuy", false, false, false, null);

                string message = "Getting started with .Net Core RebbitMQ";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "DangTuanHuy", null, body);
                Console.WriteLine("Sent Message {0}....", message);


            }
            Console.WriteLine("Press [enter] to exits the Sender App");
            Console.ReadLine();

        }
    }
}
