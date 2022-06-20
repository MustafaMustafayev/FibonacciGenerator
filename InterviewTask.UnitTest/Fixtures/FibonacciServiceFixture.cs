using System;
using InterviewTask.BLL.Concrete;
using InterviewTask.Core.Abstract;
using Moq;

namespace InterviewTask.UnitTest.Fixtures
{
    public class FibonacciServiceFixture : IDisposable
    {
        public Mock<IUtilService> _utilService;

        public FibonacciServiceFixture()
        {
            _utilService = new Mock<IUtilService>();
        }

        internal FibonacciService FibonacciService => new FibonacciService(_utilService.Object);

        public void Dispose()
        {
        }
    }
}