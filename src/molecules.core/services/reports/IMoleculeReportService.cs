using molecules.core.domain.valueobjects.moleculereport;

namespace molecules.core.services.reports
{
    public interface IMoleculeReportService
    {
        Task<List<MoleculeAtomsChargeReport>> GetMoleculeAtomsChargeReportAsync(int moleculeId);

        Task<List<MoleculeAtomOrbitalReport>> GetMoleculeAtomOrbitalReportAsync(int moleculeId);

        Task<List<MoleculeBondsReport>> GetMoleculeBondsReportsAsync(int moleculeId);

        Task<List<MoleculeAtomsPopulationReport>> GetMoleculePopulationReportAsync(int moleculeId);

        Task<List<GeneralMoleculeReport>> GetGeneralMoleculeReportsAsync(int moleculeId);
    }
}
