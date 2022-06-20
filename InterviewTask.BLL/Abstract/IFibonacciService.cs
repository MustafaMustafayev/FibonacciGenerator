using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.DTO.ResponseDTOs;

namespace InterviewTask.BLL.Abstract
{
	public interface IFibonacciService
	{
	    Task<IDataResult<FibonacciResponseDTO>> CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO);
	}
}