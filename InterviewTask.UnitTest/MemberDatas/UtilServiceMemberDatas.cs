using System.Collections.Generic;
using InterviewTask.DTO.FibonaccDTOs;

namespace InterviewTask.UnitTest.MemberDatas
{
	public class UtilServiceMemberDatas
	{
		public static IEnumerable<object[]> FindFibonacci()
		{
			yield return new object[] { 3 };
		}

		public static IEnumerable<object[]> FindFibonacciNumberByIndexUsingCacheMethodoly()
		{
			yield return new object[] { 3, true };
		}

		public static IEnumerable<object[]> CalculateFibonacciSubSequence()
		{
			FibonacciGeneratorDTO fibonacciGeneratorDTO = new FibonacciGeneratorDTO()
			{
				StartIndex = 2,
				LastIndex = 5,
				TimeLimit = 24343534,
				MemoryLimit = 67684,
				UseCache = false
			};

			yield return new object[] { fibonacciGeneratorDTO };
		}
	}
}