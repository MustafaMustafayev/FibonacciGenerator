namespace InterviewTask.DTO.FibonaccDTOs
{
	public record IndicatorDTO
	{
		public bool IsTimeLimitOccured { get; set; }
		public bool IsMemoryLimitOccured { get; set; }
	}
}