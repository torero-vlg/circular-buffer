﻿using CircularBuffer.Core.Domain;
using CircularBuffer.Core.Exceptions;
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

        [Test(Description = "Простое добавление")]
        public void WriteTest()
        {
            _sut.Write(new Page { Content = "1"});

            Assert.AreEqual("1", _buffer.Pages[0].Content);
        }

        [Test(Description = "Переполнение буфера")]
        public void OverflowExceptionTest()
        {
            _sut.Write(new Page { Content = "1" });
            _sut.Write(new Page { Content = "2" });
            _sut.Write(new Page { Content = "3" });

            Assert.Throws<BufferOverflowException>(() => { _sut.Write(new Page { Content = "4" }); });
            
            Assert.AreEqual("1", _buffer.Pages[0].Content);
            Assert.AreEqual("2", _buffer.Pages[1].Content);
            Assert.AreEqual("3", _buffer.Pages[2].Content);
        }

        [Test(Description = "Простое чтение")]
        public void ReadTest()
        {
            var result = _sut.Read();

            Assert.IsNull(result);
        }
    }
}