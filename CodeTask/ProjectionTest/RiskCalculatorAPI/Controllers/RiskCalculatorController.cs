namespace RiskCalculatorAPI.Controllers
{
    using System;
    using System.Linq;
    using DataValidation;
    using GrowthCalculator;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    [ApiController]
    [Route("[controller]")]
    public class RiskCalculatorController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<RiskCalculatorController> _logger;

        public RiskCalculatorController(ILogger<RiskCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Projection Get([FromQuery]decimal initialInvestment,[FromQuery] decimal monthlyInvestment,[FromQuery] decimal targetValue,[FromQuery] int years,[FromQuery] string riskLevel = "low")
        {
            var risk = ConvertToRiskLevels(riskLevel);
            var calculator = RiskFactory.CreateInstance(risk, new InputValidator());

            return calculator.CalculateGrowth(initialInvestment, monthlyInvestment, targetValue, years);
        }

        private RiskLevels ConvertToRiskLevels(string riskLevel)
        {
            switch (riskLevel.ToLower())
            {
                case "low":
                    return RiskLevels.Low;
                case "medium":
                    return RiskLevels.Medium;
                case "high":
                    return RiskLevels.High;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
