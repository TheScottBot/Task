namespace GrowthCalculator
{
    using DataValidation;
    public class HighRisk : RiskRangeCalculator, IGrowthRisk
    {
        const double _lowerWideBound = -1;
        const double _upperWideBound = 7;
        const double _lowerNarrowBound = 2;
        const double _upperNarrowBound = 4;
        public HighRisk(IInputValitador inputValidator) : base(_lowerWideBound,_upperWideBound,_lowerNarrowBound,_upperNarrowBound, inputValidator)
        {

        }
        public double LowerWideBound { get => _lowerWideBound; }
        public double UpperWideBound { get => _upperWideBound; }
        public double LowerNarrowBound { get => _lowerNarrowBound; }
        public double UpperNarrowBound { get => _upperNarrowBound; }
    }
}
