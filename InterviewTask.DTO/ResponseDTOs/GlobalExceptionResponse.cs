namespace InterviewTask.DTO.ResponseDTOs
{
	public record GlobalExceptionResponse
	{
		public bool Success { get; set; }

		public string Message { get; set; }
	}
}