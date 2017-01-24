using CircularBuffer.Core.Services;
using Buffer = CircularBuffer.Core.Domain.Buffer;
using System.Threading;
using CircularBuffer.Core.Domain;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CircularBuffer.Client.Console
{
    class Program
    {
        private static BufferService _bufferService;


        static void Main(string[] args)
        {
            var buffer = new Buffer(3);
            _bufferService = new BufferService(buffer);

            System.Console.WriteLine("Записываем..");
            _bufferService.Write(new Page { Content = "1" });
            buffer.ToConsole();
            System.Console.ReadLine();

            System.Console.WriteLine("Читаем..");
            var page = _bufferService.Read();
            System.Console.WriteLine(page.Content);

            System.Console.WriteLine("Записываем..");
            _bufferService.Write(new Page { Content = "2" });
            buffer.ToConsole();
            System.Console.ReadLine();

            buffer.ToConsole();
            System.Console.ReadLine();
        }
    }
}
