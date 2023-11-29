using molecules.core.domain.valueobjects.moleculereport;
using molecules.core.factories.reports;
using molecules.core.services.calcmolecule;
using molecules.shared;

namespace molecules.core.services.reports
{
    public class MoleculeReportService(ICalcMoleculeService calcMoleculeService,
                                    IMoleculeReportFactory moleculeReportFactory,
                                        IMoleculesLogger logger) : IMoleculeReportService
    {
        private readonly IMoleculeReportFactory _moleculeReportFactory = moleculeReportFactory ?? throw new ArgumentNullException(nameof(moleculeReportFactory));

        private readonly ICalcMoleculeService _calcMoleculeService = calcMoleculeService ?? throw new ArgumentNullException(nameof(calcMoleculeService));

        private readonly IMoleculesLogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<List<GeneralMoleculeReport>> GetGeneralMoleculeReportsAsync(int moleculeId)
        {
            _logger.LogInformation($"GetGeneralMoleculeReportsAsync({moleculeId})");
            var molecule = await _calcMoleculeService.GetAsync(moleculeId);
            return _moleculeReportFactory.GetGeneralMoleculeReport(molecule?.Molecule);
        }

        public async Task<List<MoleculeAtomOrbitalReport>> GetMoleculeAtomOrbitalReportAsync(int moleculeId)
        {
            _logger.LogInformation($"GetMoleculeAtomOrbitalReportAsync({moleculeId})");
            var molecule = await _calcMoleculeService.GetAsync(moleculeId);
            return _moleculeReportFactory.GetMoleculeAtomOrbitalReport(molecule?.Molecule);
        }

        public async Task<List<MoleculeAtomsChargeReport>> GetMoleculeAtomsChargeReportAsync(int moleculeId)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReportAsync({moleculeId})");
            var molecule = await _calcMoleculeService.GetAsync(moleculeId);
            return _moleculeReportFactory.GetMoleculeAtomsChargeReport(molecule?.Molecule);
        }

        public async Task<List<MoleculeBondsReport>> GetMoleculeBondsReportsAsync(int moleculeId)
        {
            _logger.LogInformation($"GetMoleculeBondsReportsAsync({moleculeId})");
            var molecule = await _calcMoleculeService.GetAsync(moleculeId);
            return _moleculeReportFactory.GetMoleculeBondsReports(molecule?.Molecule);
        }

        public async Task<List<MoleculeAtomsPopulationReport>> GetMoleculePopulationReportAsync(int moleculeId)
        {
            _logger.LogInformation($"GetMoleculePopulationReportAsync({moleculeId})");
            var molecule = await _calcMoleculeService.GetAsync(moleculeId);
            return _moleculeReportFactory.GetMoleculePopulationReport(molecule?.Molecule);
        }
    }
}
