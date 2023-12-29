using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using molecules.api.filter;
using molecules.core.domain.valueobjects.moleculereport;
using molecules.core.services.reports;
using molecules.shared;

namespace molecules.api.Controllers
{
    /// <summary>
    /// Endpoint to handle all the CRUD operations for the Calculation Order
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("moleculereports")]
    [AllowAnonymous]
    public class MoleculeReportController : ControllerBase
    {
        private readonly IMoleculesLogger _logger;

        private readonly IMoleculeReportService _moleculeReportService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="moleculeReportService">The service that generates reports</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MoleculeReportController(IMoleculesLogger logger, IMoleculeReportService moleculeReportService)
        {
            _logger = logger?? throw new ArgumentNullException(nameof(logger));
            _moleculeReportService = moleculeReportService?? throw new ArgumentNullException(nameof(moleculeReportService)); ;
        }

        /// <summary>
        /// Get the atoms charges report for the molecule
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/atomchargereport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomsChargeReport>> GetMoleculeAtomsChargeReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetMoleculeAtomsChargeReportAsync(moleculeid));
        }

        /// <summary>
        /// Get the atomorbital report for the molecule
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/atomorbitalreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomOrbitalReport>> GetMoleculeAtomOrbitalReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetMoleculeAtomOrbitalReportAsync(moleculeid));
        }

        /// <summary>
        /// Get the atom bond report for the miolecule
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/bondsreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeBondsReport>> GetMoleculeBondsReportsAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetMoleculeBondsReportsAsync(moleculeid));
           
        }

        /// <summary>
        /// Get the molecule Population report
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/moleculepopulationreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomsPopulationReport>> GetMoleculePopulationReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetMoleculePopulationReportAsync(moleculeid));
        }

        /// <summary>
        /// Get the molecule summary report
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/generalmoleculereport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GeneralMoleculeReport>>> GetGeneralMoleculeReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetGeneralMoleculeReportsAsync(moleculeid));
        }



        /// <summary>
        /// Get the molecule atomposition report
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/moleculeatompositionreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<MoleculeAtomPositionReport>>> GetAtomPositionReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetAtomPositionReportAsync by moleculeid:{moleculeid}");
            return Ok(await _moleculeReportService.GetAtomPositionReportAsync(moleculeid));
        }

    }
}
