using molecules.shared;
using MoleculesGui.data.serviceagents.molecules.report;

namespace MoleculesGui.data.viewmodel
{
    public class ConfigurationReportItemVm
    {
        public ConfigurationReportItemVm(ConfigurationReportItem configurationReportItem)
        {
            Symbol = configurationReportItem.Symbol;
            Population = configurationReportItem.Population;
            PopulationFraction = configurationReportItem.PopulationFraction;
        }

        public string Symbol { get; set; } = "";

        public decimal? Population { get; set; }

        public decimal? PopulationFraction { get; set; }


        public override string ToString()
        {
            return Symbol + "(" + StringConversion.ToString(PopulationFraction, "0.00") + ")";
        }
    }
}
