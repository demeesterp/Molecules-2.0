using molecules.core.common.dbentity.calcorder;
using molecules.core.common.interfaces.repositories;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.factories.calcorder;
using molecules.core.services.validators.validation.service;
using molecules.shared;

namespace molecules.core.services.calcorders
{
    public class CalcOrderItemService(ICalcOrderItemRepository calcOrderItemRepository,
                                            ICalcOrderItemFactory calcOrderItemFactory,
                                            ICalcOrderItemServiceValidations calcOrderItemServiceValidations,
                                                IMoleculesLogger logger) : ICalcOrderItemService
    {
        #region dependencies

        private readonly ICalcOrderItemFactory _calcOrderItemFactory = calcOrderItemFactory ?? throw new ArgumentNullException(nameof(calcOrderItemFactory));

        private readonly ICalcOrderItemRepository _calcOrderItemRepository = calcOrderItemRepository ?? throw new ArgumentNullException(nameof(calcOrderItemRepository));

        private readonly ICalcOrderItemServiceValidations _calcOrderItemServiceValidations = calcOrderItemServiceValidations ?? throw new ArgumentNullException(nameof(calcOrderItemServiceValidations));

        private readonly IMoleculesLogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        #endregion

        // <inheritdoc />
        public async Task<CalcOrderItem> CreateAsync(int calcOrderId, CreateCalcOrderItem createCalcOrderItem)
        {
            _logger.LogInformation($"CreateAsync for calcOrderId {calcOrderId} and molecule {createCalcOrderItem.MoleculeName} with details {createCalcOrderItem.Details} was called ");

            _calcOrderItemServiceValidations.Validate(createCalcOrderItem);

            var result = await _calcOrderItemRepository.CreateAsync(new CalcOrderItemDbEntity()
            {
                CalcOrderId = calcOrderId,
                MoleculeName = createCalcOrderItem.MoleculeName,
                XYZ = createCalcOrderItem.Details.XYZ,
                Charge = createCalcOrderItem.Details.Charge,
                CalcType = createCalcOrderItem.Details.Type.ToString(),
                BasissetCode = createCalcOrderItem.Details.BasisSetCode.ToString()
            });

            await _calcOrderItemRepository.SaveChangesAsync();

            return _calcOrderItemFactory.CreateCalcOrderItem(result);
        }

        // <inheritdoc />
        public async Task<CalcOrderItem> UpdateAsync(int id, UpdateCalcOrderItem updateCalcOrderItem)
        {
            _logger.LogInformation($"UpdateAsync with id {id}");

            _calcOrderItemServiceValidations.Validate(updateCalcOrderItem);

            var result = await _calcOrderItemRepository.UpdateAsync(id, updateCalcOrderItem.Details.Charge,
                                                updateCalcOrderItem.MoleculeName, updateCalcOrderItem.Details.Type.ToString(),
                                                updateCalcOrderItem.Details.BasisSetCode.ToString(), updateCalcOrderItem.Details.XYZ);

            await _calcOrderItemRepository.SaveChangesAsync();

            return _calcOrderItemFactory.CreateCalcOrderItem(result);
        }

        // <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation($"DeleteAsync with id {id}");

            await _calcOrderItemRepository.DeleteAsync(id);

            await _calcOrderItemRepository.SaveChangesAsync();
        }


    }
}
