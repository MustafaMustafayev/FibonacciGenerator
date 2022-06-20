namespace InterviewTask.DTO.ResponseDTOs
{
	public interface IDataResult<T> : IResult
	{
		T Data { get; }
	}
}