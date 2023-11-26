using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.services.validators.validation.service
{
    public interface ICalcOrderServiceValidations
    {
        /// <summary>
        /// Validate CreateCalcOrder
        /// </summary>
        /// <param name="createCalcOrder">Object to be validated</param>
        /// <exception cref="ValidationException">Throws when validation fails</exception>"
        void Validate(CreateCalcOrder createCalcOrder);

        /// <summary>
        /// Validate UpdateCalcOrder
        /// </summary>
        /// <param name="updateCalcOrder">Object to be validated</param>
        /// <exception cref="ValidationException">Throws when validation fails</exception>"
        void Validate(UpdateCalcOrder updateCalcOrder);
    }
}
