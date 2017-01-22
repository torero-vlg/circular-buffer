using System;
using CircularBuffer.Core;
using Buffer = CircularBuffer.Core.Buffer;

namespace CircularBuffer.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer(16);

            buffer.ToConsole();


            try
            {
                for (var i = 1; i <= 17; i++)
                    buffer.Write(new Page { Content = i.ToString() });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            buffer.ToConsole();

            var readedPage = buffer.Read();
            System.Console.WriteLine(readedPage.Content);
            buffer.ToConsole();

            readedPage = buffer.Read();
            System.Console.WriteLine(readedPage.Content);
            buffer.ToConsole();

            buffer.Write(new Page { Content = "17" });
            buffer.ToConsole();

            System.Console.ReadLine();
        }
    }
}
