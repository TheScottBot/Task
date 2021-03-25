namespace GrowthCalculator
{
    using DataValidation;
    public class MediumRisk : RiskRangeCalculator, IGrowthRisk
    {
        const double _lowerWideBound = 0;
        const double _upperWideBound = 5;
        const double _lowerNarrowBound = 1.5;
        const double _upperNarrowBound = 3.5;
        public MediumRisk(IInputValitador inputValidator) : base(_lowerWideBound, _upperWideBound, _lowerNarrowBound, _upperNarrowBound, inputValidator)
        {

        }
        public double LowerWideBound { get => _lowerWideBound; }
        public double UpperWideBound { get => _upperWideBound; }
        public double LowerNarrowBound { get => _lowerNarrowBound; }
        public double UpperNarrowBound { get => _upperNarrowBound; }
    }
}
