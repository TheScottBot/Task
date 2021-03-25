namespace GrowthCalculator
{
    using Models;
    public interface IGrowthRisk
    {
        double LowerWideBound { get; }
        double UpperWideBound { get; }
        double LowerNarrowBound { get; }
        double UpperNarrowBound { get; }
        Projection CalculateGrowth(decimal initialInvestment, decimal monthlyInvestment, decimal targetValue, int years);
    }
}
