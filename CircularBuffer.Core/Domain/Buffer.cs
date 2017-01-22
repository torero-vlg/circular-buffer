using System;

namespace CircularBuffer.Core.Domain
{
    public class Buffer
    {
        public Buffer(int size)
        {
            Pages = new Page[size];
        }

        public Page[] Pages { get; set; }

        public void ToConsole()
        {
            for (var i = 0; i < Pages.Length; i++)
            {
                Console.Write($"{(Pages[i] != null ? Pages[i].Content : "''")} ");
            }
            Console.WriteLine();
        }
    }
}
