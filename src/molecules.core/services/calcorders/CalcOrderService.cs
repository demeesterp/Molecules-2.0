using molecule.core.common.dbentity.calcorder;
using molecule.core.common.interfaces.logging;
using molecule.core.common.interfaces.repositories;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.factories.calcorder;
using molecules.core.services.validators.validation.service;

namespace molecules.core.services.calcorders
{
    /// <inheritdoc/>
    /// <summary>
    /// Construct the CalcOrderService
    /// </summary>
    /// <param name="validations">The validation service helper</param>
    /// <param name="logger">The logger</param>
    public class CalcOrderService(ICalcOrderServiceValidations validations,
                                ICalcOrderRepository calcOrderRepository,
                                ICalcOrderFactory calcOrderFactory,
                                IMoleculesLogger logger) : ICalcOrderService
    {
        #region dependencies

        private readonly IMoleculesLogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        private readonly ICalcOrderServiceValidations _validations = validations ?? throw new ArgumentNullException(nameof(validations));

        private readonly ICalcOrderRepository _calcOrderRepository = calcOrderRepository ?? throw new ArgumentNullException(nameof(calcOrderRepository));

        private readonly ICalcOrderFactory _calcOrderFactory = calcOrderFactory ?? throw new ArgumentNullException(nameof(calcOrderFactory));

        #endregion

        /// <inheritdoc/>
        public async Task<CalcOrder> CreateAsync(CreateCalcOrder createCalcOrder)
        {
            ArgumentNullException.ThrowIfNull(createCalcOrder);

            _logger.LogInformation($"Create a new CalcOrder called with name " +
                                    $"{createCalcOrder.Name} and description {createCalcOrder.Description}" );
            _validations.Validate(createCalcOrder);
            var dbresult = await _calcOrderRepository.CreateAsync(new CalcOrderDbEntity()
            {
                Name = createCalcOrder.Name,
                Description = createCalcOrder.Description,
                CustomerName = "Default",

            });
            await _calcOrderRepository.SaveChangesAsync();
            return _calcOrderFactory.CreateCalcOrder(dbresult);
        }

        /// <inheritdoc/>
        public async Task<CalcOrder?> UpdateAsync(int id, UpdateCalcOrder updateCalcOrder)
        {
            ArgumentNullException.ThrowIfNull(updateCalcOrder);

            _logger.LogInformation($"Update CalcOrder with id: {id} set Name: {updateCalcOrder.Name} and set Description: {updateCalcOrder.Description}");
            _validations.Validate(updateCalcOrder);
            var dbresult = await _calcOrderRepository.UpdateAsync(id, updateCalcOrder.Name, updateCalcOrder.Description);
            await _calcOrderRepository.SaveChangesAsync();
            return _calcOrderFactory.CreateCalcOrder(dbresult);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation($"DeleteAsync with id {id}");

            await _calcOrderRepository.DeleteAsync(id);

            await _calcOrderRepository.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<CalcOrder> GetAsync(int id)
        {
            _logger.LogInformation($"GetAsync with id {id}");

            var dbresult = await _calcOrderRepository.GetByIdAsync(id);

            return _calcOrderFactory.CreateCalcOrder(dbresult);
        }

        /// <inheritdoc/>
        public async Task<List<CalcOrder>> GetByNameAsync(string name)
        {
            _logger.LogInformation($"GetByNameAsync with name {name}");

            var dbresult = await _calcOrderRepository.GetByNameAsync(name);

            return dbresult.ConvertAll(_calcOrderFactory.CreateCalcOrder);
        }

        /// <inheritdoc/>
        public async Task<List<CalcOrder>> ListAsync()
        {
            _logger.LogInformation("ListAsync");

            var dbresult = await _calcOrderRepository.GetAllAsync();

            return dbresult.ConvertAll(_calcOrderFactory.CreateCalcOrder);
        }


    }
}
