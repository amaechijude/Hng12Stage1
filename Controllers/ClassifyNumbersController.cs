using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hng12Stage1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClassifyNumbersController : ControllerBase
    {
        [HttpGet("classify-number")]
        public async Task<IActionResult> ClassifyNumber([FromQuery] string number="371")
        {
            bool isDigit = int.TryParse(number, out int num);
            if (!isDigit)
                return BadRequest( new
                {
                    number = "alphabet",
                    error = true
                });

            return Ok( new
            {
                number = num,
                is_prime = IsPrime(num),
                is_perfect = IsPerfect(num),
                properties = GetProperties(num),
                digit_sum = GetDigitSum(num),
                fun_fact = await GetFunFactAsync(number)
            });
        }

        private static bool IsPrime(int num)
        {
            if (num < 2)
                return false;
            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        private static bool IsPerfect(int num)
        {
            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (num % i == 0)
                    sum += i;
            }
            return sum == num;
        }

        private static string[] GetProperties(int num)
        {
            if (IsArmstrong(num))
                return ["armstrong", IsEven(num)];

            return [IsEven(num)];
        }

        private static bool IsArmstrong(int num)
        {
            int sum = 0;
            int temp = num;
            int length = num.ToString().Length;
            while (temp != 0)
            {
                int remainder = temp % 10;
                sum += (int)Math.Pow(remainder, length);
                temp /= 10;
            }
            return sum == num;
        }
        private static string IsEven(int num)
        {
            return num % 2 == 0 ? "even" : "odd";
        }
        private static int GetDigitSum(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        private static async Task<string> GetFunFactAsync(string num)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"http://numbersapi.com/{num}/math");
            return $"{await response.Content.ReadAsStringAsync()}";
        }
    }
}
