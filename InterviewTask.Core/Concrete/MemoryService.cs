using InterviewTask.Core.Abstract;
using InterviewTask.Core.Helper;
using Microsoft.Extensions.Caching.Memory;

namespace InterviewTask.Core.Concrete
{
	public class MemoryService : IMemoryService
	{
		private readonly IMemoryCache _memoryCache;
		private readonly MemoryCacheEntryOptions cacheEntryOptions;
		private readonly ConfigSettings _congigSettings;

		public MemoryService(IMemoryCache memoryCache, ConfigSettings configSettings)
		{
			_memoryCache = memoryCache;

			_congigSettings = configSettings;

			cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(_congigSettings.CacheSettings.CacheAbsoluteExpiration))
                    .SetPriority(CacheItemPriority.Normal);
        }

		public int? GetELementFromCache(int index)
        {
            int? val;
            _memoryCache.TryGetValue(index, out val);
            return val;
        }

		public bool IsMemoryLimitOccured(long memoryLimit)
        {
            long usedMemory = GC.GetTotalMemory(false);

            if (usedMemory > memoryLimit)
            {
                return true;
            }

            return false;
        }

		public void SetElementToCache(int key, int value)
        {
            _memoryCache.Set(key, value, cacheEntryOptions);
        }
    }
}