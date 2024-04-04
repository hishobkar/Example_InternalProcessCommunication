using System;
using Grpc.Core;
using Greeter;

class Program
{
    static void Main(string[] args)
    {
        const string target = "localhost:50051";
        Channel channel = new Channel(target, ChannelCredentials.Insecure);
        var client = new Greeter.GreeterClient(channel);

        string user = "world";
        var reply = client.SayHello(new HelloRequest { Name = user });
        Console.WriteLine("Greeting: " + reply.Message);

        channel.ShutdownAsync().Wait();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
