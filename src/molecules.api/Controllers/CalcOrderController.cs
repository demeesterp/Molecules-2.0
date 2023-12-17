using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using molecules.api.filter;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.services.calcorders;
using molecules.shared;

namespace molecules.api.Controllers
{
    /// <summary>
    /// Endpoint to handle all the CRUD operations for the Calculation Order
    /// </summary>
    /// <remarks>
    /// constructor
    /// </remarks>
    /// <param name="calcOrderService">The service that handles operations on calcorders</param>
    /// <param name="calcOrderItemService">The service that handles operations on calcorderitems</param>
    /// <param name="logger">The logger</param>
    /// <exception cref="ArgumentNullException"></exception>
    [ApiController]
    [Produces("application/json")]
    [Route("calcorders")]
    [AllowAnonymous]
    public class CalcOrderControllerS(ICalcOrderService calcOrderService,
                                    ICalcOrderItemService calcOrderItemService,
                                            IMoleculesLogger logger) : ControllerBase
    {
        private readonly IMoleculesLogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        private readonly ICalcOrderService _calcOrderService = calcOrderService ?? throw new ArgumentNullException(nameof(calcOrderService));

        private readonly ICalcOrderItemService _calcOrderItemService = calcOrderItemService ?? throw new ArgumentNullException(nameof(calcOrderItemService));

        /// <summary>
        /// Get the list of all CalcOrders
        /// </summary>
        /// <returns>All CalcOrders</returns>
        /// <response code="200">A list of all CalcOrders</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<CalcOrder>>> ListAsync()
        {
            _logger.LogInformation("Get the list of all Calculation Orders called");
           return Ok(await _calcOrderService.ListAsync());
        }

        /// <summary>
        /// Get a CalcOrder for the specified id
        /// </summary>
        /// <param name="id">The id of the CalcOrder</param>
        /// <returns>The CalcOrder corresponding to the id</returns>
        /// <response code="200">A list of all CalcOrders</response>
        /// <response code="404">There was no calcorder with the specified name</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CalcOrder>> GetAsync([FromRoute]int id)
        {
            _logger.LogInformation($"Get a calculation order by id:{id}");
            var result = await _calcOrderService.GetAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get the list of all CalcOrders the matches the specified name
        /// </summary>
        /// <param name="name">The name to lookup</param>
        /// <returns>The list of CalcOrders that corresponds</returns>
        /// <response code="200">A list of all CalcOrders</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpGet]
        [Route("Name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<CalcOrder>>> GetByNameAsync([FromRoute] string name)
        {
            _logger.LogInformation($"Get a calculation order by name:{name}");
            return Ok(await _calcOrderService.GetByNameAsync(name));
        }
        /// <summary>
        /// Create a new CalcOrders
        /// </summary>
        /// <param name="createCalcOrder">The name and the description of the new CalcOrder</param>
        /// <returns>The newly created CalcOrder</returns>
        /// <response code="201">The CalcOrders was created</response>
        /// <response code="422">Failed to create the calcorder because the input was invalid</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpPost()]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceValidationError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CalcOrder>> CreateAsync([FromBody]CreateCalcOrder createCalcOrder)
        {
            _logger.LogInformation($"Create a calculation order with name:{createCalcOrder.Name} " +
                                        $"and description:{createCalcOrder.Description}");
            return StatusCode(StatusCodes.Status201Created, await _calcOrderService.CreateAsync(createCalcOrder));

        }

        /// <summary>
        /// Update the CalcOrder
        /// </summary>
        /// <param name="id">The id of the CalcOrder to update</param>
        /// <param name="updateCalcOrder">The new name and the new description</param>
        /// <returns>The updated CalcOrder</returns>
        /// <response code="200">The CalcOrders was updated</response>
        /// <response code="404">No CalcOrder found for the specified id</response>
        /// <response code="422">Failed to update calcorder because the input was invalid</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpPatch]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ServiceValidationError), StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<CalcOrder>> UpdateAsync([FromRoute] int id, [FromBody] UpdateCalcOrder updateCalcOrder)
        {
            _logger.LogInformation($"Update a calculation order with name:{updateCalcOrder.Name} and description:{updateCalcOrder.Description}");  
            return Ok(await _calcOrderService.UpdateAsync(id, updateCalcOrder));
        }

        /// <summary>
        /// Delete a calcorder
        /// </summary>
        /// <param name="id">The id of the calcorder to be deleted</param>
        /// <returns></returns>
        /// <response code="204">The CalcOrders was deleted</response>
        /// <response code="404">No CalcOrder found for the specified id</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            _logger.LogInformation($"Delete a calculation order with id:{id}");
            await _calcOrderService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }


        /// <summary>
        /// Create a new CalcOrderItem
        /// </summary>
        /// <param name="createCalcOrderItem">The name and the description of the new CalcOrder</param>
        /// <param name="calcOrderId">The calcorder to who the tiem belongs</param>
        /// <returns>The newly created CalcOrderItem</returns>
        /// <response code="201">The CalcOrderItem was created</response>
        /// <response code="422">Failed to create the calcorderitem because the input was invalid</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpPost()]
        [Route("{calcOrderId}/calcorderitem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceValidationError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CalcOrderItem>> CreateCalcOrderItemAsync([FromRoute] int calcOrderId, [FromBody] CreateCalcOrderItem createCalcOrderItem)
        {
            _logger.LogInformation($"Create calcorder item for calcOrder {calcOrderId} and molecule {createCalcOrderItem.MoleculeName} with details {createCalcOrderItem.Details}");
            return StatusCode(StatusCodes.Status201Created, await _calcOrderItemService.CreateAsync(calcOrderId, createCalcOrderItem));

        }

        /// <summary>
        /// Update a calcorder item
        /// </summary>
        /// <param name="calcOrderItemId">The id of the item to be updated</param>
        /// <param name="updateCalcOrderItem">The data that must be updated</param>
        /// <returns>The updated item</returns>
        /// <response code="200">The CalcOrderItem was updated</response>
        /// <response code="422">Failed to update the calcorderitem because the input was invalid</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpPatch()]
        [Route("calcorderitem/{calcOrderItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceValidationError), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CalcOrderItem>> UpdateCalcOrderItemAsync([FromRoute] int calcOrderItemId, [FromBody] UpdateCalcOrderItem updateCalcOrderItem)
        {
            _logger.LogInformation($"Update calcorder item with id {calcOrderItemId}");
            return Ok(await _calcOrderItemService.UpdateAsync(calcOrderItemId, updateCalcOrderItem));
        }

        /// <summary>
        /// Delete a calcorder item
        /// </summary>
        /// <param name="id">The id of the calcorderitem to be deleted</param>
        /// <returns></returns>
        /// <response code="200">The calc orer item was deleted</response>
        /// <response code="404">No calcorder items was found for the specified id</response>
        /// <response code="500">An unexpected error happend</response>
        [HttpDelete()]
        [Route("calcorderitem/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ServiceError), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCalcOrderItemAsync([FromRoute] int id)
        {
            _logger.LogInformation($"Delete calcorder item with id {id}");
            await _calcOrderItemService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}