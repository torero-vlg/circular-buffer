using System;
using CircularBuffer.Core.Domain;
using CircularBuffer.Core.Services;
using Buffer = CircularBuffer.Core.Domain.Buffer;

namespace CircularBuffer.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer(16);

            var bufferService = new BufferService(buffer);

            buffer.ToConsole();


            try
            {
                for (var i = 1; i <= 17; i++)
                    bufferService.Write(new Page { Content = i.ToString() });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            buffer.ToConsole();

            var readedPage = bufferService.Read();
            System.Console.WriteLine(readedPage.Content);
            buffer.ToConsole();

            readedPage = bufferService.Read();
            System.Console.WriteLine(readedPage.Content);
            buffer.ToConsole();

            bufferService.Write(new Page { Content = "17" });
            buffer.ToConsole();

            System.Console.ReadLine();
        }
    }
}
