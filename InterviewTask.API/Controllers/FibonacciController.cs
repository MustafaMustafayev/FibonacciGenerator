using InterviewTask.API.ActionFilters;
using InterviewTask.BLL.Abstract;
using InterviewTask.Core.CustomFilters;
using InterviewTask.DTO.FibonaccDTOs;
using InterviewTask.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InterviewTask.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogActionFilter))]
    public class FibonacciController : Controller
    {
        private readonly IFibonacciService _fibonacciService;

        public FibonacciController(IFibonacciService fibonacciService)
        {
            _fibonacciService = fibonacciService;
        }

        [SwaggerOperation(Summary = "generate Fibonacci subsequence numbers that is matching the input indexes")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(FibonacciResponseDTO))]
        [HttpPost("CalculateFibonacciSubSequence")]
        public async Task<IActionResult> CalculateFibonacciSubSequence([FromBody] FibonacciGeneratorDTO fibonacciGeneratorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IDataResult<FibonacciResponseDTO> fibonacciResponse = await _fibonacciService.CalculateFibonacciSubSequence(fibonacciGeneratorDTO);
            return Ok(fibonacciResponse);
        }
    }
}