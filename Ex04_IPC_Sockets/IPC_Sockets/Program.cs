using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var server = new TcpListener(IPAddress.Loopback, 12345);
        server.Start();

        using (var client = new TcpClient("localhost", 12345))
        {
            using (var stream = client.GetStream())
            {
                var messageBytes = Encoding.UTF8.GetBytes("Hello from client!");
                stream.Write(messageBytes, 0, messageBytes.Length);

                var buffer = new byte[1024];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine(response);
            }
        }

        server.Stop();
    }
}
