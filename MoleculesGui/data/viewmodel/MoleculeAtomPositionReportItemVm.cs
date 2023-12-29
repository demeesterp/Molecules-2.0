using MoleculesGui.data.serviceagents.molecules.report;

namespace MoleculesGui.data.viewmodel
{
    public class MoleculeAtomPositionReportItemVm
    {

        public MoleculeAtomPositionReportItemVm(MoleculeAtomPositionReport report)
        {
            MoleculeName = report.MoleculeName;
            AtomPosition = report.AtomPosition;
            AtomSymbol = report.AtomSymbol;
            PosX = report.PosX;
            PosY = report.PosY;
            PosZ = report.PosZ;
        }

        public string MoleculeName { get; set; }

        public int AtomPosition { get; set; }

        public string AtomSymbol { get; set; }

        public decimal? PosX { get; set; }

        public decimal? PosY { get; set; }

        public decimal? PosZ { get; set; }

    }
}
