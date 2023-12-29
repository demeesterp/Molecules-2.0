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
        }


        public string MoleculeName { get; set; }

        public string AtomID { get; set; }

        public decimal? CHelpGCharge { get; set; }

        public decimal? MullNeutral { get; set; }

        public string Configuration { get; set; }

        public decimal? MullLewisAcid { get; set; }

        public string ConfigurationLewisAcid { get; set; }

        public decimal? MullLewisBase { get; set; }

        public string ConfigurationLewisBase { get; set; }

    }
}
