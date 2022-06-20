using System.Threading.Tasks;
using InterviewTask.BLL.Concrete;
using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.DTO.ResponseDTOs;
using InterviewTask.UnitTest.Fixtures;
using InterviewTask.UnitTest.MemberDatas;
using Xunit;

namespace InterviewTask.UnitTest.UnitTests
{
	public class FibonacciServiceTest : IClassFixture<FibonacciServiceFixture>
    {
        private readonly FibonacciService _fibonaccyService;

        public FibonacciServiceTest(FibonacciServiceFixture fibonacciServiceFixture)
        {
            _fibonaccyService = fibonacciServiceFixture.FibonacciService;
        }

        [Theory]
        [MemberData(nameof(FibonacciServiceMemberData.CalculateFibonacciSubSequence), MemberType = typeof(FibonacciServiceMemberData))]
        public async Task CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            IDataResult<FibonacciResponseDTO> actual = await _fibonaccyService.CalculateFibonacciSubSequence(fibonacciGeneratorDTO);
            Assert.NotNull(actual);
            Assert.Equal("Success", actual.Message);
        }
    }
}