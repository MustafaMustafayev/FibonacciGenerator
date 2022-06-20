namespace InterviewTask.DTO.FibonaccDTOs
{
	public record FibonacciResponseDTO
	{
		public ICollection<int> SubSequence { get; set; }

		public IndicatorDTO Indicator { get; set; }
	}
}