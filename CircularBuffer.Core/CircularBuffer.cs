using System;

namespace CircularBuffer.Core
{
    public class Buffer
    {
        public Buffer(int size)
        {
            Pages = new Page[size];
        }

        public Page[] Pages { get; set; }

        public void Push(Page page)
        {
            var index = 0;

            var next = LastWrited() + 1;
            index = next == Pages.Length ? 0 : next;

            if (Pages[index] != null && !Pages[index].IsReaded)
                throw new Exception("Ошибка добавления");

            Pages[index] = page;
        }

        private int LastWrited()
        {
            var index = -1;

            for (var i = 0; i < Pages.Length; i++)
            {
                if (Pages[i] == null)
                    continue;

                if (Pages[i].IsWrited)
                    index = i;
            }

            return index;
        }

        public void ToConsole()
        {
            for (var i = 0; i < Pages.Length; i++)
            {
                //System.Console.WriteLine($"{i} - {(Pages[i] != null ? Pages[i].Content : string.Empty)}");
                System.Console.WriteLine($"{(Pages[i] != null ? Pages[i].Content : string.Empty)}\t");
            }
        }
    }
}
