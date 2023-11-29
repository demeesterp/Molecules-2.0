using FluentValidation;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.services.validators.validation.service
{
    /// <summary>
    /// Helper service to group all validations for the CalcOrderItemService
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="createValidator">Injected validator from fluent validations</param>
    /// <param name="updateValidator">Injected validator from fluent validations</param>
    /// <exception cref="ArgumentNullException">validator should not be null</exception>
    public class CalcOrderItemServiceValidations(IValidator<CreateCalcOrderItem> createValidator,
                                                IValidator<UpdateCalcOrderItem> updateValidator) : ICalcOrderItemServiceValidations
    {
        #region dependencies

        private readonly IValidator<CreateCalcOrderItem> _createCalcOrderItemValidator = createValidator ;

        private readonly IValidator<UpdateCalcOrderItem> _updateCalcOrderItemValidator = updateValidator ;

        #endregion


        /// <inheritdoc/>
        public void Validate(CreateCalcOrderItem createCalcOrderItem)
        {
            _createCalcOrderItemValidator.ValidateAndThrow(createCalcOrderItem);
        }

        /// <inheritdoc/>
        public void Validate(UpdateCalcOrderItem updateCalcOrderItem)
        {
            _updateCalcOrderItemValidator.ValidateAndThrow(updateCalcOrderItem);
        }
    }
}
