namespace GrowthCalculator
{
    using DataValidation;
    using Models;
    using System;

    public static class RiskFactory
    {
        public static IGrowthRisk CreateInstance(RiskLevels riskLevels, IInputValitador inputValitador)
        {
            switch (riskLevels)
            {
                case RiskLevels.Low:
                    return new LowRisk(inputValitador);
                case RiskLevels.Medium:
                    return new MediumRisk(inputValitador);
                case RiskLevels.High:
                    return new HighRisk(inputValitador);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
