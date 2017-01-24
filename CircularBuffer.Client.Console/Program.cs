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

            System.Console.WriteLine("Записываем 1..");
            _bufferService.Write(new Page { Content = "1" });
            ToConsole(buffer.Pages);
            System.Console.WriteLine("Для продолжения нажмите <Enter>");
            System.Console.ReadLine();

            ToConsole(buffer.Pages);
            System.Console.ReadLine();
            
            System.Console.WriteLine("Читаем..");
            var page = _bufferService.Read();
            System.Console.WriteLine(page.Content);

            ToConsole(buffer.Pages);
            System.Console.ReadLine();

            System.Console.WriteLine("Записываем 2..");
            _bufferService.Write(new Page { Content = "2" });
            ToConsole(buffer.Pages);
            System.Console.WriteLine("Для продолжения нажмите <Enter>");
            System.Console.ReadLine();
            ToConsole(buffer.Pages);
            System.Console.WriteLine("Для продолжения нажмите <Enter>");
            System.Console.ReadLine();
        }

        public static void ToConsole(Page[] pages)
        {
            for (var i = 0; i < pages.Length; i++)
            {
                System.Console.Write($"{(pages[i] != null ? pages[i].Content : "''")} ");
            }
            System.Console.WriteLine();
        }
    }
}
