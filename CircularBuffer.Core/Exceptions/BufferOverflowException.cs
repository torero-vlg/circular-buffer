using System;

namespace CircularBuffer.Core.Exceptions
{
    public class BufferOverflowException : Exception
    {
        public BufferOverflowException() : base("Буфер заполнен, прочитанных страниц для перезаписи нет")
        {
        }
    }
}
