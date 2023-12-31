using molecules.shared;

namespace molecules.core.domain.valueobjects.moleculereport
{
    public  record ConfigurationReportItem(string Symbol, decimal? Population, decimal? PopulationFraction)
    {
        public override string ToString()
        {
           return Symbol + "(" + StringConversion.ToString(PopulationFraction, "0.00") + ")";
        }
    }
}
