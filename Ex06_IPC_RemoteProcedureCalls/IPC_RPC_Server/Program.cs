using System;
using System.Threading.Tasks;
using Grpc.Core;
using Greeter;

class GreeterService : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}

class Program
{
    static void Main(string[] args)
    {
        const int Port = 50051;
        Server server = new Server
        {
            Services = { Greeter.BindService(new GreeterService()) },
            Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        };
        server.Start();
        Console.WriteLine("Greeter server listening on port " + Port);
        Console.WriteLine("Press any key to stop the server...");
        Console.ReadKey();
        server.ShutdownAsync().Wait();
    }
}
