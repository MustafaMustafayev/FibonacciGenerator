using System.Diagnostics;
using InterviewTask.Core.Abstract;
using InterviewTask.Core.Enums;
using InterviewTask.DTO.FibonaccDTOs;

namespace InterviewTask.Core.Concrete
{
    public class UtilService : IUtilService
    {
        private readonly IMemoryService _memoryService;

        public UtilService(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }

        public IEnumerable<int> CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            Stopwatch stopwatch = new Stopwatch();
            int indexValue = 0, beforeValue = 0;
            int j = 0;
            bool isPredictableCalculation;

            int[] subSequence = new int[fibonacciGeneratorDTO.LastIndex - fibonacciGeneratorDTO.StartIndex + 1];

            for (int i = fibonacciGeneratorDTO.StartIndex; i <= fibonacciGeneratorDTO.LastIndex; i++, j++)
            {
                if (i == fibonacciGeneratorDTO.StartIndex || (i == 0 || i == 1))
                {
                    isPredictableCalculation = true;
                }
                else
                {
                    isPredictableCalculation = false;
                }

                if (j == 0)
                {
                    stopwatch.Start();
                }

                FindElementByIndex(isPredictableCalculation, i, ref indexValue, ref beforeValue, fibonacciGeneratorDTO.UseCache);

                if (j == 0)
                {
                    stopwatch.Stop();
                    if (stopwatch.ElapsedMilliseconds > fibonacciGeneratorDTO.TimeLimit)
                    {
                        throw new Exception(ECustomException.TimeLimit.ToString());
                    }
                }

                yield return indexValue;
            }
        }

        public async Task<int> FindFibonacci(int index)
        {
            if (index == 0)
            {
                return 0;
            }

            if (index == 1)
            {
                return 1;
            }

            int previousEl = 0, beforeOnePreviousEl = 0;

            Thread threadForPreviousElement = new Thread(async () =>
            {
                previousEl = await FindFibonacci(index - 1);
            });
            threadForPreviousElement.IsBackground = true;
            threadForPreviousElement.Start();
            threadForPreviousElement.Join();

            Thread threadForBeforeOnePreviousEl = new Thread(async () =>
            {
                beforeOnePreviousEl = await FindFibonacci(index - 2);
            });
            threadForBeforeOnePreviousEl.IsBackground = true;
            threadForBeforeOnePreviousEl.Start();
            threadForBeforeOnePreviousEl.Join();

            return await Task.FromResult(previousEl + beforeOnePreviousEl);
        }

        public async Task<int> FindFibonacciNumberByIndexUsingCacheMethodoly(int index, bool useCache)
        {
            if (useCache)
            {
               int? val = _memoryService.GetELementFromCache(index);
               if (!val.HasValue)
               {
                    val = await FindFibonacci(index);
                    _memoryService.SetElementToCache(index, val.Value);
               }

               return val.Value;
            }
            else
            {
                return await FindFibonacci(index);
            }
        }

        private void FindElementByIndex(bool isPredictableCalculation, int index, ref int indexValue, ref int beforeValue, bool useCache)
        {
            if (isPredictableCalculation)
            {
                if (index == 0)
                {
                    beforeValue = 0;
                    indexValue = 0;
                }
                else if (index == 1)
                {
                    beforeValue = 0;
                    indexValue = 1;
                }
                else
                {
                    beforeValue = FindFibonacciNumberByIndexUsingCacheMethodoly(index - 1, useCache).Result;
                    indexValue = beforeValue + FindFibonacciNumberByIndexUsingCacheMethodoly(index - 2, useCache).Result;
                }
            }
            else
            {
                int temp = indexValue;
                indexValue = indexValue + beforeValue;
                beforeValue = temp;
            }
        }
    }
}
