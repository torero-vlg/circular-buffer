using CircularBuffer.Core.Domain;
using CircularBuffer.Core.Services;
using NUnit.Framework;

namespace CircularBuffer.Core.Tests
{
    [TestFixture]
    public class BufferServiceTests
    {
        private IBufferService _sut;
        private Buffer _buffer;

        [SetUp]
        public void Setup()
        {
            _buffer = new Buffer(3);
            _sut = new BufferService(_buffer);
        }

        [Test]
        public void WriteTest()
        {
            _sut.Write(new Page { Content = "1"});

            Assert.AreEqual("1", _buffer.Pages[0].Content);
        }

        [Test]
        public void ReadTest()
        {
            var result = _sut.Read();

            Assert.IsNull(result);
        }
    }
}
