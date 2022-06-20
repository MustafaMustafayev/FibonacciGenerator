namespace InterviewTask.Core.Abstract
{
	public interface IMemoryService
	{
		int? GetELementFromCache(int index);

		void SetElementToCache(int key, int value);

		bool IsMemoryLimitOccured(long memoryLimit);
	}
}