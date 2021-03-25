namespace Models
{
    using System.Collections.Generic;
    public class Projection
    { 
        public List<GrowthTracking> Growth { get; set; }

        public int TargetYears { get; set; }
        public int ActualYears { get; set; }

        public bool HasMetTarget { get; set; }
    }
}
