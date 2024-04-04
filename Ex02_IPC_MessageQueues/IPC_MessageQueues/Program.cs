using System;
using System.Messaging;

class Program
{
    static void Main(string[] args)
    {
        var queueName = ".\\Private$\\MyQueue";

        using (var queue = new MessageQueue(queueName))
        {
            queue.Send("Hello from sender!");

            var message = (string)queue.Receive().Body;
            Console.WriteLine(message);
        }
    }
}
