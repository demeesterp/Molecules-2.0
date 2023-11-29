using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using molecules.api.filter;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.molecules;
using molecules.core.services.calcmolecule;
using System.Net.Mime;
using System.Text;

namespace molecules.api.Controllers
{
    /// <summary>
    /// Endpoint to get various files related to molecules
    /// </summary>
    /// <remarks>
    /// Controller constructor
    /// </remarks>
    /// <param name="logger">logger</param>
    /// <param name="calcMoleculeService">moleculeFileService</param>
    [ApiController]
    [Route("moleculefiles")]
    [AllowAnonymous]
    public class MoleculeFileController(ICalcMoleculeService calcMoleculeService) : ControllerBase
    {

        private readonly ICalcMoleculeService _calcMoleculeService = calcMoleculeService;

        /// <summary>
        /// Get a Molecule for the specified id
        /// </summary>
        /// <param name="moleculeid">The id of the molecule</param>
        /// <returns>The xyz file corresponding to the moleculeid</returns>
        /// <response code="200">The requested molecule</response>
        /// <response code="404">There was no molecule</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpGet]
        [Route("xyzfile/{moleculeid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetXyzFileAsync([FromRoute]int moleculeid)
        {
            string fileName = $"{moleculeid}.xyz";

            CalcMolecule molecule = await _calcMoleculeService.GetAsync(moleculeid);
            string fileContent = Molecule.GetXyzFileData(molecule.Molecule);
            
            byte[] fileBytes = new byte[fileContent.Length];
            Encoding.UTF8.GetBytes(fileContent, 0, fileContent.Length, fileBytes, 0);
            return File(fileBytes, MediaTypeNames.Application.Octet, fileName);
        }
    }
}
