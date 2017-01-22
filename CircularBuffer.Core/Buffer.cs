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

        /// <summary>
        /// Записать в буфер
        /// </summary>
        /// <param name="page"></param>
        public void Write(Page page)
        {
            var next = LastWrited() + 1;
            var index = next == Pages.Length ? 0 : next;

            if (Pages[index] != null && !Pages[index].IsReaded)
                throw new Exception("Ошибка добавления");

            Pages[index] = page;
        }

        /// <summary>
        /// Прочитать из буфера
        /// </summary>
        public Page Read()
        {
            var next = LastReaded() + 1;
            var index = next == Pages.Length ? 0 : next;

            if (Pages[index] == null)
                return null;

            Pages[index].IsReaded = true;

            return Pages[index];
        }

        /// <summary>
        /// Индекс последней записанной страницы. Если нет, то -1
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Индекс последней прочитанной страницы. Если нет, то -1
        /// </summary>
        /// <returns></returns>
        private int LastReaded()
        {
            var index = -1;

            for (var i = 0; i < Pages.Length; i++)
            {
                if (Pages[i] == null)
                    continue;

                if (Pages[i].IsReaded)
                    index = i;
            }

            return index;
        }

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
