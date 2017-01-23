using CircularBuffer.Core.Services;
using Buffer = CircularBuffer.Core.Domain.Buffer;
using System.Threading;
using CircularBuffer.Core.Domain;

namespace CircularBuffer.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer(3);
            var bufferService = new BufferService(buffer);

            Thread oThread = new Thread(new ThreadStart(() => bufferService.Write(new Page { Content = "1" })));


            oThread.Start();
           
            // Thread.Sleep(1);

            buffer.ToConsole();
            
            System.Console.ReadLine();
            oThread.Abort();

            bufferService.Write(new Page { Content = "1" });
            buffer.ToConsole();
            System.Console.ReadLine();

        }
    }
}
