using MoleculesGui.data.viewmodel;

namespace MoleculesGui.services.molecules
{
    public interface IMoleculesAnalysisService
    {
        IObservable<List<MoleculesOverviewItemVM>> SearchCalculatedMolecules(string findquery);

        IObservable<MoleculeReportVM> GetReport(int moleculeId);

    }
}
