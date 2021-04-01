using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("basic-operation/{operation}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operation, string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) || !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid numbers!");
            }

            decimal total; 
            decimal firstNumberDecimal = ConvertToDecimal(firstNumber);
            decimal secondNumberDecimal = ConvertToDecimal(secondNumber);

            switch (operation)
            {
                case "sum":
                    total = firstNumberDecimal + secondNumberDecimal;
                    break;
                case "subtraction":
                    total = firstNumberDecimal - secondNumberDecimal;
                    break;
                case "multiplication":
                    total = firstNumberDecimal * secondNumberDecimal;
                    break;
                case "division":
                    total = firstNumberDecimal / secondNumberDecimal;
                    break;
                case "mean":
                    total = (firstNumberDecimal + secondNumberDecimal) / 2;
                    break;
                default:
                    return BadRequest("Invalid Operation!");
            }

            return Ok(total);
        }
        
        [HttpGet("basic-operation/square-root/{firstNumber}")]
        public IActionResult Get(string firstNumber)
        {
            if (!IsNumeric(firstNumber))
            {
                return BadRequest("Invalid number!");
            }

            decimal firstNumberDecimal = ConvertToDecimal(firstNumber);
            double total = Math.Sqrt((double) firstNumberDecimal); 

            return Ok(total);
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out number);
            
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal number;

            if (decimal.TryParse(strNumber, out number))
            {
                return number;
            }

            return 0;
        }
    }
}
