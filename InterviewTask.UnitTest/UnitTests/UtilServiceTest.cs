using System.Threading.Tasks;
using InterviewTask.Core.Concrete;
using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.UnitTest.Fixtures;
using InterviewTask.UnitTest.MemberDatas;
using Xunit;

namespace InterviewTask.UnitTest.UnitTests
{
    public class UtilServiceTest : IClassFixture<UtilServiceFixture>
	{
        private readonly UtilService _utilService;

        public UtilServiceTest(UtilServiceFixture utilServiceFixture)
        {
            _utilService = utilServiceFixture.UtilService;
        }

        [Theory]
        [MemberData(nameof(UtilServiceMemberDatas.FindFibonacci), MemberType = typeof(UtilServiceMemberDatas))]
        public async Task FindFibonacci(int index)
        {
            int actual = await _utilService.FindFibonacci(index);
            Assert.Equal(2, actual);
        }

        [Theory]
        [MemberData(nameof(UtilServiceMemberDatas.FindFibonacciNumberByIndexUsingCacheMethodoly), MemberType = typeof(UtilServiceMemberDatas))]
        public async Task FindFibonacciNumberByIndexUsingCacheMethodoly(int index, bool useCache)
        {
            int actual = await _utilService.FindFibonacciNumberByIndexUsingCacheMethodoly(index, useCache);
            Assert.Equal(2, actual);
        }

        [Theory]
        [MemberData(nameof(UtilServiceMemberDatas.CalculateFibonacciSubSequence), MemberType = typeof(UtilServiceMemberDatas))]
        public void CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            var actual = _utilService.CalculateFibonacciSubSequence(fibonacciGeneratorDTO);
            Assert.NotNull(actual);
        }
    }
}