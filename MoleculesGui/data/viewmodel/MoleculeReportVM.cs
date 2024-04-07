using System.Text;

namespace MoleculesGui.data.viewmodel
{
    public class MoleculeReportVM
    {

        public MoleculeReportVM(int moleculeId)
        {
            MoleculeId = moleculeId;
            AtomPositions = new List<MoleculeAtomPositionReportItemVm>();
            ReportItems = new List<GeneralMoleculeReportItemVm>();
            MoleculeBonds = new List<MoleculeBondsReportItemVm>();
        }

        public string MoleculeName => ReportItems.Select(item => item.MoleculeName).FirstOrDefault("");

        public int MoleculeId { get; set; }


        public List<MoleculeAtomPositionReportItemVm> AtomPositions { get; set; }


        public List<GeneralMoleculeReportItemVm> ReportItems { get; set; }


        public List<MoleculeBondsReportItemVm> MoleculeBonds { get; set; }


        public string GetXyz()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{AtomPositions.Count}");
            builder.AppendLine(MoleculeName);

            foreach(var atom in AtomPositions)
            {
                builder.AppendLine($"{atom.AtomSymbol} {atom.PosX:0.0000} {atom.PosY:0.0000} {atom.PosZ:0.0000}");
            }

            return builder.ToString();
        }

    }
}
