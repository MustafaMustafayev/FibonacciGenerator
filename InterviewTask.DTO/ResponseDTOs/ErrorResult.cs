namespace InterviewTask.DTO.ResponseDTOs
{
    public record ErrorResult : Result
    {
        public ErrorResult(string message)
               : base(false, message)
        {
        }

        public ErrorResult()
               : base(false)
        {
        }
    }
}