using InterviewTask.DTO.FibonaccDTOs;

namespace InterviewTask.Core.Abstract
{
	public interface IUtilService
	{
		IEnumerable<int> CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO);
	}
}