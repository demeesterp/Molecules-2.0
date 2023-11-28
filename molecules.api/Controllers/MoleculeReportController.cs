﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using molecule.core.common.interfaces.logging;
using molecules.api.filter;
using molecules.core.domain.valueobjects.moleculereport;
using molecules.core.services.reports;

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomsChargeReport>> GetMoleculeAtomsChargeReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            var result = await _moleculeReportService.GetMoleculeAtomsChargeReportAsync(moleculeid);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Get the atomorbital report for the molecule
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/atomorbitalreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomOrbitalReport>> GetMoleculeAtomOrbitalReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            var result = await _moleculeReportService.GetMoleculeAtomOrbitalReportAsync(moleculeid);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Get the atom bond report for the miolecule
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/bondsreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeBondsReport>> GetMoleculeBondsReportsAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            var result = await _moleculeReportService.GetMoleculeBondsReportsAsync(moleculeid);
            if ( result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
           
        }

        /// <summary>
        /// Get the molecule Population report
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/moleculepopulationreport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MoleculeAtomsPopulationReport>> GetMoleculePopulationReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            var result = await _moleculeReportService.GetMoleculePopulationReportAsync(moleculeid);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Get the molecule summary report
        /// </summary>
        /// <param name="moleculeid">id of the molecule</param>
        /// <returns>The report</returns>
        [HttpGet]
        [Route("molecule/{moleculeid}/generalmoleculereport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GeneralMoleculeReport>>> GetGeneralMoleculeReportAsync([FromRoute] int moleculeid)
        {
            _logger.LogInformation($"GetMoleculeAtomsChargeReport by moleculeid:{moleculeid}");
            var result = await _moleculeReportService.GetGeneralMoleculeReportsAsync(moleculeid);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }   

    }
}
