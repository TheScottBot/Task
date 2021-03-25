namespace GrowthCalculator
{
    using DataValidation;
    using Models;
    using System.Collections.Generic;
    public abstract class RiskRangeCalculator
    {
        private readonly double _lowerWideBound;
        private readonly double _upperWideBound;
        private readonly double _lowerNarrowBound;
        private readonly double _upperNarrowBound;
        private readonly IInputValitador _inputValidator;
        /*
         * Lump sum investment
         * monthly investment
         * target value
         * timescale in years
         */

        public RiskRangeCalculator(double lowerWideBound, double upperWideBound, double lowerNarrowBound, double upperNarrowBound, IInputValitador inputValidator)
        {
            _lowerWideBound = lowerWideBound;
            _upperWideBound = upperWideBound;
            _lowerNarrowBound = lowerNarrowBound;
            _upperNarrowBound = upperNarrowBound;
            _inputValidator = inputValidator;
        }

        public List<double> GetWideBoundRange()
        {
            return GetBoundRange(_lowerWideBound, _upperWideBound);
        }

        public List<double> GetNarrowBoundRange()
        {
            return GetBoundRange(_lowerNarrowBound, _upperNarrowBound);
        }

        public Projection CalculateGrowth(decimal initialInvestment, decimal monthlyInvestment, decimal targetValue, int years)
        {
            Validation(initialInvestment, monthlyInvestment);

            var tracking = new List<GrowthTracking>();
            var projection = new Projection
            {
                HasMetTarget = PopulateGrowthTracking(initialInvestment, monthlyInvestment, years, targetValue, ref tracking),
                TargetYears = years
            };

            while (!PopulateGrowthTracking(tracking[tracking.Count - 1].YearlyTotal, monthlyInvestment, years + 1, targetValue, ref tracking, years))
            {
                years++;
            }

            projection.ActualYears = years++;
            projection.Growth = tracking;

            return projection;
        }

        private void Validation(decimal initialInvestment, decimal monthlyInvestment)
        {
            _inputValidator.EnsureNonNegative(initialInvestment, nameof(initialInvestment));
            _inputValidator.EnsureNonNegative(monthlyInvestment, nameof(monthlyInvestment));
        }

        private bool PopulateGrowthTracking(decimal initialInvestment, decimal monthlyInvestment, int years, decimal targetValue, ref List<GrowthTracking> tracking, int startAtIndex = 0)
        {
            const int monthsInYear = 12;
            for (int i = startAtIndex; i < years; i++)
            {
                var total = initialInvestment + (monthlyInvestment * monthsInYear);

                tracking.Add(new GrowthTracking
                {
                    YearlyTotal = total,
                    LowerNarrow = total + total * AsPercent(_lowerNarrowBound),
                    UpperNarrow = total + total * AsPercent(_upperNarrowBound),
                    LowerWide = total + total * AsPercent(_lowerWideBound),
                    UpperWide = total + total * AsPercent(_upperWideBound)
                });

                initialInvestment = total;
            }

            return tracking[tracking.Count - 1].YearlyTotal >= targetValue;
        }

        private decimal AsPercent(double input)
        {
            return (decimal)((decimal)input / (decimal)100);
        }

        private List<double> GetBoundRange(double lower, double upper)
        {
            var range = new List<double>();
            for (double i = lower; i <= upper; i++)
            {
                range.Add(i);
            }
            return range;
        }
    }
}
