using System;
using InterviewTask.Core.Abstract;
using InterviewTask.Core.Concrete;
using Moq;

namespace InterviewTask.UnitTest.Fixtures
{
    public class UtilServiceFixture : IDisposable
    {
        public Mock<IMemoryService> _memoryService;

        public UtilServiceFixture()
        {
            _memoryService = new Mock<IMemoryService>();
        }

        internal UtilService UtilService => new UtilService(_memoryService.Object);

        public void Dispose()
        {
        }
    }
}