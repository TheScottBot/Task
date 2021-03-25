namespace GrowthCalculatorTests
{
    using DataValidation;
    using GrowthCalculator;
    using NUnit.Framework;

    public class RiskRangeCalculatorTests
    {

        [Test]
        public void GetNarrowBoundRangeReturnsExpectedListOfThreeItems()
        {
            var testCalculator = new FakeRiskRangeCalculator();
            const int expectedCount = 3;
            const int expectedZeroIndex = 3;
            const int expectedOneIndex = 4;
            const int expectedTwoIndex = 5;

            var result = testCalculator.GetNarrowBoundRange();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, result.Count);
                Assert.AreEqual(expectedZeroIndex, result[0]);
                Assert.AreEqual(expectedOneIndex, result[1]);
                Assert.AreEqual(expectedTwoIndex, result[2]);
            });
        }

        [Test]
        public void GetWideBoundRangeReturnsExpectedListOfFiveItems()
        {
            var testCalculator = new FakeRiskRangeCalculator();
            const int expectedCount = 5;
            const int expectedZeroIndex = 2;
            const int expectedOneIndex = 3;
            const int expectedTwoIndex = 4;
            const int expectedThreeIndex = 5;
            const int expectedFourIndex = 6;

            var result = testCalculator.GetWideBoundRange();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedCount, result.Count);
                Assert.AreEqual(expectedZeroIndex, result[0]);
                Assert.AreEqual(expectedOneIndex, result[1]);
                Assert.AreEqual(expectedTwoIndex, result[2]);
                Assert.AreEqual(expectedThreeIndex, result[3]);
                Assert.AreEqual(expectedFourIndex, result[4]);
            });
        }

        [Test]
        public void CalculateGrowthReturnsResultHasMetTargetTrueWhenGrowthExceedsOrMeetsTargetedValue()
        {
            var testCalculator = new FakeRiskRangeCalculator();
            
            var result = testCalculator.CalculateGrowth(100, 2, 105, 2);

            Assert.IsTrue(result.HasMetTarget);
        }

        [Test]
        public void CalculateGrowthReturnsResultHasMetTargetFalseWhenGrowthDoesNotExceedOrMeetTargetedValue()
        {
            var testCalculator = new FakeRiskRangeCalculator();

            var result = testCalculator.CalculateGrowth(100, 2, 150, 2);

            Assert.IsFalse(result.HasMetTarget);
        }
    }


    //Lightweight fakes (doubles) to avoid using moq at this stage
    //Resorted to using moq in the end for ease of throwing exceptions
    public class FakeRiskRangeCalculator : RiskRangeCalculator, IGrowthRisk
    {
        const double _lowerWideBound = 2;
        const double _upperWideBound = 6;
        const double _lowerNarrowBound = 3;
        const double _upperNarrowBound = 5;
        public FakeRiskRangeCalculator() : base(_lowerWideBound, _upperWideBound, _lowerNarrowBound, _upperNarrowBound, new FakeInputValidator())
        {

        }
        public double LowerWideBound { get => _lowerWideBound; }
        public double UpperWideBound { get => _upperWideBound; }
        public double LowerNarrowBound { get => _lowerNarrowBound; }
        public double UpperNarrowBound { get => _upperNarrowBound; }
    }

    public class FakeInputValidator : IInputValitador
    {
        public void CheckForNulls(object verify, string nameOfVerifyingValue)
        {
            //intentionally blank
        }

        public void EnsureNonNegative(decimal negativeInput, string nameOfVerifyingValue)
        {
            //intentionally blank
        }
    }
}