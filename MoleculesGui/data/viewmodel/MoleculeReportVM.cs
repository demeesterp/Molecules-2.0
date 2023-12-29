namespace MoleculesGui.data.viewmodel
{
    public class MoleculeReportVM
    {

        public MoleculeReportVM(int moleculeId)
        {
            MoleculeId = moleculeId;
            AtomPositions = new List<MoleculeAtomPositionReportItemVm>();
            ReportItems = new List<GeneralMoleculeReportItemVm>();
        }

        public string MoleculeName => ReportItems.Select(item => item.MoleculeName).FirstOrDefault("");

        public int MoleculeId { get; set; }


        public List<MoleculeAtomPositionReportItemVm> AtomPositions { get; set; }


        public List<GeneralMoleculeReportItemVm> ReportItems { get; set; }

    }
}
