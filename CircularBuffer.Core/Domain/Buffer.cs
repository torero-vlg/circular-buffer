namespace CircularBuffer.Core.Domain
{
    /// <summary>
    /// TODO видимость этого класса из других сборок - ?
    /// </summary>
    public class Buffer
    {
        public Buffer(int size)
        {
            Pages = new Page[size];
        }

        public Page[] Pages { get; set; }
    }
}
