namespace RiskCalcukatorIntegrationTests
{
    using DataValidation;
    using GrowthCalculator;
    using Models;
    using NUnit.Framework;
    using System;
    using TechTalk.SpecFlow;
    [Binding]
    public sealed class IntegrationTestsDefinition
    {
        private IGrowthRisk _growthRisk;
        private decimal _initialInvestment;
        private decimal _monthlyInvestment;
        private decimal _target;
        private int _years;
        private Projection _projection;
        [Given(@"I want to calculate (.*)")]
        public void GivenIWantToCalculate(string riskType)
        {
            const string expectedLow = "low";
            const string expectedMedium = "medium";
            const string expectedHigh = "high";
            var level = (riskType.ToLower()) switch
            {
                expectedLow => RiskLevels.Low,
                expectedMedium => RiskLevels.Medium,
                expectedHigh => RiskLevels.High,
                _ => throw new ArgumentOutOfRangeException(),
            };
            _growthRisk = RiskFactory.CreateInstance(level, new InputValidator());
        }

        [Given(@"I give '(.*)' investment of (.*)")]
        public void GivenIGiveInvestmentOf(string investmentType, int money)
        {
            const string expectedInitial = "initial";
            const string expectedMonthly = "monthly";
            _ = ((investmentType.ToLower()) switch
            {
                expectedInitial => _initialInvestment = money,
                expectedMonthly => _monthlyInvestment = money,
                _ => throw new ArgumentOutOfRangeException(),
            });
        }

        [Given(@"my target is (.*)")]
        public void GivenMyTargetIs(int target)
        {
            _target = target;
        }

        [Given(@"I hope to invest for (.*)")]
        public void GivenIHopeToInvestFor(int years)
        {
            _years = years;
        }

        [When(@"I calculate the results")]
        public void WhenICalculateTheResults()
        {
            _projection = _growthRisk.CalculateGrowth(_initialInvestment, _monthlyInvestment, _target, _years);
        }

        [Then(@"I am told if my investment is (.*)")]
        public void ThenIAmToldIfMyInvestmentIs(bool doable)
        {
            //technically this is crappy, but it is an assertion that is needed. Didn't want empty THEN method.
            //Eventually move to adding to target state model then compare post test with Assert.Multiple
            Assert.AreEqual(doable, _projection.HasMetTarget);
        }

        [Then(@"provided with a final yearly total of (.*)")]
        public void ThenProvidedWithAFinalYearlyTotalOf(int finalTotal)
        {
            Assert.AreEqual(finalTotal, _projection.Growth[_projection.Growth.Count - 1].YearlyTotal);
        }



    }
}
