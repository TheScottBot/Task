namespace GrowthCalculator
{
    using DataValidation;
    using System;
    public class LowRisk : RiskRangeCalculator, IGrowthRisk
    {
        const double _lowerWideBound = 1;
        const double _upperWideBound = 3;
        const double _lowerNarrowBound = 1.5;
        const double _upperNarrowBound = 2.5;
        public LowRisk(IInputValitador inputValidator) : base(_lowerWideBound, _upperWideBound, _lowerNarrowBound, _upperNarrowBound, inputValidator)
        {

        }
        public double LowerWideBound { get => _lowerWideBound; }
        public double UpperWideBound { get => _upperWideBound; }
        public double LowerNarrowBound { get => _lowerNarrowBound; }
        public double UpperNarrowBound { get => _upperNarrowBound; }
    }
}
