using FluentValidation;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.services.validators
{
    public class CreateCalcOrderItemValidator : AbstractValidator<CreateCalcOrderItem>
    {

        public CreateCalcOrderItemValidator()
        {
            RuleFor(x => x.MoleculeName).NotEmpty().WithMessage("MoleculeName is required");
            RuleFor(x => x.MoleculeName).MaximumLength(250).WithMessage("MoleculeName cannot be longer than 250 characters");      
        }

    }
}
