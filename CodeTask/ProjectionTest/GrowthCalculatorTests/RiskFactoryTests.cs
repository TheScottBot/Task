namespace GrowthCalculatorTests
{
    using DataValidation;
    using GrowthCalculator;
    using NUnit.Framework;
    [TestFixture]
    public class RiskFactoryTests
    {
        [Test]
        public void CreateInstanceCreatesInstanceOfLowRiskWhenLowIsProvided()
        {
            var lowRisk = RiskFactory.CreateInstance(Models.RiskLevels.Low, new FakeValidator());

            Assert.IsInstanceOf<LowRisk>(lowRisk);
        }

        [Test]
        public void CreateInstanceCreatesInstanceOfMediumRiskWhenMediumIsProvided()
        {
            var mediumRisk = RiskFactory.CreateInstance(Models.RiskLevels.Medium, new FakeValidator());

            Assert.IsInstanceOf<MediumRisk>(mediumRisk);
        }

        [Test]
        public void CreateInstanceCreatesInstanceOfHighRiskWhenHighIsProvided()
        {
            var highRisk = RiskFactory.CreateInstance(Models.RiskLevels.High, new FakeValidator());

            Assert.IsInstanceOf<HighRisk>(highRisk);
        }
    }

    public class FakeValidator : IInputValitador
    {
        public void CheckForNulls(object verify, string nameOfVerifyingValue)
        {
            //intentially blank
        }

        public void EnsureNonNegative(decimal negativeInput, string nameOfVerifyingValue)
        {
            //intentially blank
        }
    }
}
