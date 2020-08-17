using System;
using System.Text;
using NATS.Client;

namespace nats_client
{
    class Program
    {
        static void Main(string[] args)
        {
            using var connection = new ConnectionFactory().CreateConnection();
        

            var orderTabNotificationSub = connection.SubscribeAsync("order_tab_notification", (sender, args ) => {
                Console.WriteLine($"Sender: Favo de mel Application");
                Console.WriteLine($"Nofitification: {args.Message.Subject}");
                Console.WriteLine($"Message:{Encoding.UTF8.GetString(args.Message.Data)}");
                Console.WriteLine();
            });

            orderTabNotificationSub.Start();

            var orderNotificationSub = connection.SubscribeAsync("order_notification", (sender, args ) => {
                Console.WriteLine($"Sender: Favo de mel Application");
                Console.WriteLine($"Nofitification: {args.Message.Subject}");
                Console.WriteLine($"Message:{Encoding.UTF8.GetString(args.Message.Data)}");
                Console.WriteLine();
            });

            orderNotificationSub.Start();

            Console.WriteLine("Starting the listen to notifications");
            Console.WriteLine("To stop, press the key c");
            Console.WriteLine();

            var pressed = Console.ReadKey();
            while (pressed.Key == ConsoleKey.C)
            {
                Console.WriteLine("Pressed the key c, is the command to stop.");    
                break;
            }

            Console.WriteLine("Stopping of listen to notifications");
        }
    }
}
