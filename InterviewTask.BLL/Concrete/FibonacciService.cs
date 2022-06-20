using System.Diagnostics;
using InterviewTask.BLL.Abstract;
using InterviewTask.Core.Abstract;
using InterviewTask.Core.CustomFilters;
using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.DTO.ResponseDTOs;

namespace InterviewTask.BLL.Concrete
{
    public class FibonacciService : IFibonacciService
    {
        private readonly IUtilService _utilService;

        public FibonacciService(IUtilService utilService)
        {
            _utilService = utilService;
        }

        public async Task<IDataResult<FibonacciResponseDTO>> CalculateFibonacciSubSequence(FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            ICollection<int> fibonacciNumbers = new List<int>();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken cts = tokenSource.Token;

            Stopwatch stopwatch = new Stopwatch();
            bool memoryLimitIndicator = false;
            stopwatch.Start();

            await Task.Run(
                () =>
                {
                foreach (int el in GetFibonacciNumbers(fibonacciGeneratorDTO, tokenSource.Token))
                {
                        var usedMemory = GC.GetAllocatedBytesForCurrentThread();
                        if (usedMemory > fibonacciGeneratorDTO.MemoryLimit)
                        {
                            memoryLimitIndicator = true;
                            tokenSource.Cancel();
                        }
                        else
                        {
                            fibonacciNumbers.Add(el);
                        }
                }
            }, cts);

            stopwatch.Stop();

            FibonacciResponseDTO fibonacciResponseDTO = new FibonacciResponseDTO();
            fibonacciResponseDTO.SubSequence = fibonacciNumbers;
            fibonacciResponseDTO.Indicator = new IndicatorDTO() { IsTimeLimitOccured = stopwatch.ElapsedMilliseconds > fibonacciGeneratorDTO.TimeLimit, IsMemoryLimitOccured = memoryLimitIndicator };
            return new SuccessDataResult<FibonacciResponseDTO>(fibonacciResponseDTO, Messages.Success);
        }

        private IEnumerable<int> GetFibonacciNumbers(FibonacciGeneratorDTO fibonacciGeneratorDTO, CancellationToken cancellationToken)
        {
            foreach (int el in _utilService.CalculateFibonacciSubSequence(fibonacciGeneratorDTO))
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                yield return el;
            }
        }
    }
}