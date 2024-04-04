using System;
using System.IO;
using System.IO.Pipes;

class Program
{
    static void Main(string[] args)
    {
        using (var server = new NamedPipeServerStream("mypipe"))
        using (var client = new NamedPipeClientStream(".", "mypipe", PipeDirection.InOut))
        {
            server.WaitForConnection();
            client.Connect();

            var writer = new StreamWriter(client) { AutoFlush = true };
            var reader = new StreamReader(server);

            writer.WriteLine("Hello from server!");
            Console.WriteLine(reader.ReadLine());

            writer.WriteLine("Hello from client!");
            Console.WriteLine(reader.ReadLine());
        }
    }
}
