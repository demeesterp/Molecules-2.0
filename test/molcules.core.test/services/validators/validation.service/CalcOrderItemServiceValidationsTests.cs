using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.services.validators.validation.service;

namespace molecules.core.test.services.validators.validation.service
{
    public class CalcOrderItemServiceValidationsTests
    {
        public class CalcOrderItemServiceValidationsConstructorTests : CalcOrderItemServiceValidationsTests
        {
            [Fact]
            public void CalcOrderItemServiceValidationsConstructorTests_WhenCreateValidatorIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IValidator<CreateCalcOrderItem> createvalidator = null;
                IValidator<UpdateCalcOrderItem> updateValidator = A.Fake<IValidator<UpdateCalcOrderItem>>();

                // Act
                Action act = () => new CalcOrderItemServiceValidations(createvalidator, updateValidator);

                // Assert
                act.Should().Throw<ArgumentNullException>();
            }

            [Fact]
            public void CalcOrderItemServiceValidationsConstructorTests_WhenUpdateValidatorIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IValidator<CreateCalcOrderItem> createvalidator = A.Fake<IValidator<CreateCalcOrderItem>>();
                IValidator<UpdateCalcOrderItem> updateValidator = null;

                // Act
                Action act = () => new CalcOrderItemServiceValidations(createvalidator, updateValidator);

                // Assert
                act.Should().Throw<ArgumentNullException>();
            }
        }
    }
}
