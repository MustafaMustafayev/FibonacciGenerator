using System.Threading.Tasks;
using FluentAssertions;
using InterviewTask.API.Controllers;
using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.UnitTest.Fixtures;
using InterviewTask.UnitTest.MemberDatas;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InterviewTask.UnitTest.UnitTests
{
	public class FibonacciControllerTest : IClassFixture<FibonacciControllerFixture>
    {
        private readonly FibonacciController _fibonacciController;

        public FibonacciControllerTest(FibonacciControllerFixture fibonacciControllerFixture)
        {
            _fibonacciController = fibonacciControllerFixture.FibonacciController;
        }

        [Theory]
        [MemberData(nameof(FibonacciControllerMemberData.CalculateFibonacciSubSequence), MemberType = typeof(FibonacciControllerMemberData))]
        public async Task CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            var actual = await _fibonacciController.CalculateFibonacciSubSequence(fibonacciGeneratorDTO);
            actual.Should().BeOfType<OkObjectResult>();
        }
    }
}