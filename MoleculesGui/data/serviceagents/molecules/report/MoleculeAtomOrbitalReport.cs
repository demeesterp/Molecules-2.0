using System.Text.Json.Serialization;
using System.Text;

namespace MoleculesGui.data.serviceagents.molecules.report
{
    public class MoleculeAtomOrbitalReport
    {
        public string MoleculeName { get; set; } = "";

        public string AtomID { get; set; } = "";

        public decimal? MullikenPopulation { get; set; }

        public string ElectronConfiguration { get; set; } = "";

        public string ElectronConfigurationHOMO { get; set; } = "";

        public string ElectronConfigurationLUMO { get; set; } = "";

    }
}
