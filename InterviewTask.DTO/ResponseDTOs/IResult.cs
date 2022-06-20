namespace InterviewTask.DTO.ResponseDTOs
{
	public interface IResult
	{
		bool Success { get; }

		string Message { get; }
	}
}