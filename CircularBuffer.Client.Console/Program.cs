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
                    buffer.Push(new Page { Content = i.ToString() });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            buffer.ToConsole();


            System.Console.ReadLine();
        }
    }
}
