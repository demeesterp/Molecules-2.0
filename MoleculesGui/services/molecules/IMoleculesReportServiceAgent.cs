using MoleculesGui.data.serviceagents.molecules.report;

namespace MoleculesGui.services.molecules
{
    public interface IMoleculesReportServiceAgent
    {
        IObservable<List<MoleculeAtomPositionReport>> GetAtomPositionReport(int moleculeid);

        IObservable<List<GeneralMoleculeReport>> GetGeneralReport(int moleculeid);

        IObservable<List<MoleculeAtomOrbitalReport>> GetMoleculeAtomOrbitalReport(int moleculeid);

        IObservable<List<MoleculeAtomsChargeReport>> GetMoleculeAtomsChargeReport(int moleculeid);

        IObservable<List<MoleculeAtomsPopulationReport>> GetMoleculeAtomsPopulationReport(int moleculeid);

        IObservable<List<MoleculeBondsReport>> GetMoleculeBondsReport(int moleculeid);

    }
}
