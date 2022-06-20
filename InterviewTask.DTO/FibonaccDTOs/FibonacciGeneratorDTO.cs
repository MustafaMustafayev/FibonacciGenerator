using System.ComponentModel.DataAnnotations;
using InterviewTask.Core.CustomFilters;

namespace InterviewTask.DTO.FibonaccDTOs
{
	public record FibonacciGeneratorDTO
	{
		[Required]
		public int StartIndex { get; set; }
		[Required]
		[ValidateStartAndEndIndex(ErrorMessage = "End index should be grater or equal to start index")]
		public int LastIndex { get; set; }
		[Required]
		public bool UseCache { get; set; }

		// time limit that api should run (in milliseconds)
		[Required]
		public long TimeLimit { get; set; }

		// amount of maximum memory that api should use (in bytes)
		[Required]
		public long MemoryLimit { get; set; }
	}
}