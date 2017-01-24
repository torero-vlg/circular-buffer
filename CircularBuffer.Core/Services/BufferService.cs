using System;
using CircularBuffer.Core.Domain;
using Buffer = CircularBuffer.Core.Domain.Buffer;
using CircularBuffer.Core.Exceptions;
using System.Threading.Tasks;

namespace CircularBuffer.Core.Services
{
    /// <summary>
    /// Интерфейс работы с буфером
    /// </summary>
    public interface IBufferService
    {
        /// <summary>
        /// Записать в буфер
        /// </summary>
        /// <param name="page"></param>
        void Write(Page page);

        /// <summary>
        /// Прочитать из буфера
        /// </summary>
        Page Read();

        /// <summary>
        /// Запись набора страниц
        /// </summary>
        /// <param name="pages">Набор страниц</param>
        /// <remarks>Запишется столько сколько можно, если останутся незаписанные, то BufferOverflowException</remarks>
        void Write(Page[] pages);

        /// <summary>
        /// Чтение набора страниц
        /// </summary>
        /// <param name="count">Количество страниц, которые должны быть прочитаны</param>
        /// <returns></returns>
        /// <remarks>Если count превышает размер буфера, то вернётсявесь буфер начиная с первого непрочитанного</remarks>
        Page[] Read(int count);
    }

    public class BufferService : IBufferService
    {
        private readonly Buffer _buffer;

        public BufferService(Buffer buffer)
        {
            _buffer = buffer;
        }

        /// <summary>
        /// Записать в буфер
        /// </summary>
        /// <param name="page"></param>
        public void Write(Page page)
        {
            Task taskA = Task.Run(() =>
                {
                    lock (_buffer)
                    {
                        var next = LastWrited() + 1;
                        var index = next == _buffer.Pages.Length ? 0 : next;

                        //начиная с index ищем первый подходящий для записи
                        index = FirstReaded(index);

                        if (_buffer.Pages[index] != null && !_buffer.Pages[index].IsReaded)
                            throw new BufferOverflowException();

                        _buffer.Pages[index] = page;
                    }
                });
        }

        /// <summary>
        /// Прочитать из буфера
        /// </summary>
        public Page Read()
        {
            var next = LastReaded() + 1;
            var index = next == _buffer.Pages.Length ? 0 : next;

            if (_buffer.Pages[index] == null)
                return null;

            _buffer.Pages[index].IsReaded = true;

            return _buffer.Pages[index];
        }

        /// <summary>
        /// Запись набора страниц
        /// </summary>
        /// <param name="pages">Набор страниц</param>
        /// <remarks>Запишется столько сколько можно, если останутся незаписанные, то BufferOverflowException</remarks>
        public void Write(Page[] pages)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Чтение набора страниц
        /// </summary>
        /// <param name="count">Количество страниц, которые должны быть прочитаны</param>
        /// <returns></returns>
        /// <remarks>Если count превышает размер буфера, то вернётсявесь буфер начиная с первого непрочитанного</remarks>
        public Page[] Read(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Индекс последней записанной страницы. Если нет, то -1
        /// </summary>
        /// <returns></returns>
        private int LastWrited()
        {
            var index = -1;

            for (var i = 0; i < _buffer.Pages.Length; i++)
            {
                if (_buffer.Pages[i] == null)
                    continue;

                if (_buffer.Pages[i].IsWrited)
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

            for (var i = 0; i < _buffer.Pages.Length; i++)
            {
                if (_buffer.Pages[i] == null)
                    continue;

                if (_buffer.Pages[i].IsReaded)
                    index = i;
            }

            return index;
        }

        /// <summary>
        /// Индекс первой прочитанной страницы. Если нет, то startIndex
        /// </summary>
        /// <param name="startIndex">Начальный индекс для поиска</param>
        /// <returns></returns>
        private int FirstReaded(int startIndex)
        {
            var index = startIndex;

            for (var i = 0; i < _buffer.Pages.Length; i++)
            {
                if (_buffer.Pages[i] == null)
                    continue;

                if (_buffer.Pages[i].IsReaded)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
