using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hng12Stage1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClassifyNumbersController : ControllerBase
    {
        [HttpGet("classify-number/{number}")]
        public IActionResult ClassifyNumber([FromQuery] string number)
        {
            bool isDigit = int.TryParse(number, out int num);
            if (!isDigit)
                return BadRequest( new
                {
                    number = "alphabet",
                    error = "true"
                });

            return Ok( new
            {
                number,
                is_prime = IsPrime(num),
                is_perfect = IsPerfect(num),
                properties = GetProperties(num),
                digit_sum = GetDigitSum(num),
                fun_fact = GetFunFact(num)
            });
        }

}
}
