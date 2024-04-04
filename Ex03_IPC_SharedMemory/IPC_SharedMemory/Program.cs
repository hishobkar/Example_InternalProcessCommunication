using System;
using System.IO.MemoryMappedFiles;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        using (var memoryMappedFile = MemoryMappedFile.CreateNew("MyMemoryMappedFile", 100))
        {
            using (var accessor = memoryMappedFile.CreateViewAccessor())
            {
                var message = Encoding.ASCII.GetBytes("Hello from writer!");
                accessor.WriteArray(0, message, 0, message.Length);

                Console.WriteLine("Message written to shared memory.");
                Console.ReadLine();

                var readMessage = new byte[100];
                accessor.ReadArray(0, readMessage, 0, readMessage.Length);
                Console.WriteLine("Message read from shared memory: " + Encoding.ASCII.GetString(readMessage));
            }
        }
    }
}
