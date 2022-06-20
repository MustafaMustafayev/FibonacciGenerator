using System;
using InterviewTask.API.Controllers;
using InterviewTask.BLL.Abstract;
using Moq;

namespace InterviewTask.UnitTest.Fixtures
{
	public class FibonacciControllerFixture : IDisposable
    {
        public Mock<IFibonacciService> _fibonacciService;

        public FibonacciControllerFixture()
        {
            _fibonacciService = new Mock<IFibonacciService>();
        }

        internal FibonacciController FibonacciController => new FibonacciController(_fibonacciService.Object);

        public void Dispose()
        {
        }
    }
}