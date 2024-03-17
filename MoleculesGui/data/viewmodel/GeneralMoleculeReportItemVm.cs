using MoleculesGui.data.serviceagents.molecules.report;

namespace MoleculesGui.data.viewmodel
{
    public class GeneralMoleculeReportItemVm
    {
        public GeneralMoleculeReportItemVm(GeneralMoleculeReport report)
        {
            MoleculeName = report.MoleculeName;
            AtomID = report.AtomID;
            CHelpGCharge = report.CHelpGCharge;
            MullNeutral = report.MullNeutral;
            MullLewisAcid = report.MullLewisAcid;
            MullLewisBase = report.MullLewisBase;
            Configuration = report.Configuration;
            ConfigurationLewisAcid = report.ConfigurationLewisAcid;
            ConfigurationLewisBase = report.ConfigurationLewisBase;
            ConfigurationItems = report.ConfigurationItems.ConvertAll(i => new ConfigurationReportItemVm(i));
            ConfigurationItemsLewisBase = report.ConfigurationItemsLewisBase.ConvertAll(i => new ConfigurationReportItemVm(i));
            ConfigurationItemsLewisAcid = report.ConfigurationItemsLewisAcid.ConvertAll(i => new ConfigurationReportItemVm(i));
        }

        public string MoleculeName { get; set; }

        public string AtomID { get; set; }

        public decimal? CHelpGCharge { get; set; }

        public decimal ColorFractionCHelpGCharge => Math.Abs(CHelpGCharge ?? 0);

        public decimal? MullNeutral { get; set; }

        public string Configuration { get; set; }

        public decimal? MullLewisAcid { get; set; }

        public decimal ColorFractionMullLewisAcid => Math.Abs(MullLewisAcid ?? 0);

        public string ConfigurationLewisAcid { get; set; }

        public decimal? MullLewisBase { get; set; }

        public decimal? ColorFractionMullLewisBase => Math.Abs(MullLewisBase ?? 0);

        public string ConfigurationLewisBase { get; set; }

        public List<ConfigurationReportItemVm> ConfigurationItems { get; set; }

        public List<ConfigurationReportItemVm> ConfigurationItemsLewisBase { get; set; }

        public List<ConfigurationReportItemVm> ConfigurationItemsLewisAcid { get; set; }

    }
}
