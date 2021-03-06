﻿namespace CircularBuffer.Core.Domain
{
    public class Page
    {
        /// <summary>
        /// Признак, что страница прочитана
        /// </summary>
        public bool IsReaded { get; set; }

        /// <summary>
        /// Признак, что страница записана
        /// </summary>
        public bool IsWrited => true;

        /// <summary>
        /// Содержимое страницы
        /// </summary>
        public string Content { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}
