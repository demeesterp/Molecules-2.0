using FluentValidation;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.services.validators.validation.service
{
    /// <summary>
    /// Helpers service to group all validations for the CalcOrderService
    /// </summary>
    /// <remarks>
    /// Constructor for CalcOrderServiceValidations
    /// </remarks>
    /// <param name="createCalcOrderValidator">CreateCalcOrder validation logic</param>
    /// <param name="updateCalcOrderValidator">UpdateCalcOrder validation logic</param>
    public class CalcOrderServiceValidations(IValidator<CreateCalcOrder> createCalcOrderValidator,
                                            IValidator<UpdateCalcOrder> updateCalcOrderValidator) : ICalcOrderServiceValidations
    {
        #region dependencies

        private readonly IValidator<CreateCalcOrder> _createCalcOrderValidator = createCalcOrderValidator ?? throw new ArgumentNullException(nameof(createCalcOrderValidator));

        private readonly IValidator<UpdateCalcOrder> _updateCalcOrderValidator = updateCalcOrderValidator ?? throw new ArgumentNullException(nameof(updateCalcOrderValidator));

        #endregion

        /// <summary>
        /// Validate CreateCalcOrder
        /// </summary>
        /// <param name="createCalcOrder">Object to be validated</param>
        /// <exception cref="ValidationException">Throws when validation fails</exception>"
        public void Validate(CreateCalcOrder createCalcOrder)
        {
            _createCalcOrderValidator.ValidateAndThrow(createCalcOrder);
        }

        /// <summary>
        /// Validate UpdateCalcOrder
        /// </summary>
        /// <param name="updateCalcOrder">Object to be validated</param>
        /// <exception cref="ValidationException">Throws when validation fails</exception>"
        public void Validate(UpdateCalcOrder updateCalcOrder)
        {
            _updateCalcOrderValidator.ValidateAndThrow(updateCalcOrder);
        }


    }
}
