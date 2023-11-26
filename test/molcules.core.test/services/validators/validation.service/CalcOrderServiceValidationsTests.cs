using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.services.validators.validation.service;

namespace molecules.core.test.services.validators.validation.service
{
    public class CalcOrderServiceValidationsTests
    {
        #region dependencies

        private readonly IValidator<CreateCalcOrder> _createCalcOrderValidator;
        private readonly IValidator<UpdateCalcOrder> _updateCalcOrderValidator;
        private CalcOrderServiceValidations Service { get; set; }

        #endregion

        public CalcOrderServiceValidationsTests() 
        { 

            this._updateCalcOrderValidator = A.Fake<IValidator<UpdateCalcOrder>>();
            this._createCalcOrderValidator = A.Fake<IValidator<CreateCalcOrder>>();
            this.Service = new CalcOrderServiceValidations(this._createCalcOrderValidator, this._updateCalcOrderValidator);   
        }

        public class CalcOrderServiceValidationsConstructorTests : CalcOrderServiceValidationsTests
        {

            [Fact]
            public void ShouldThrowArgumentNullExceptionWhenCreateCalcOrderValidatorIsNull()
            {
                // Arrange
                IValidator<CreateCalcOrder> createCalcOrderValidator = null;
                IValidator<UpdateCalcOrder> updateCalcOrderValidator = A.Fake<IValidator<UpdateCalcOrder>>();

                // Act
                Action act = () => new CalcOrderServiceValidations(createCalcOrderValidator, updateCalcOrderValidator);

                // Assert
                act.Should().Throw<ArgumentNullException>();
            }

            [Fact]
            public void ShouldThrowArgumentNullExceptionWhenUpdateCalcOrderValidatorIsNull()
            {
                // Arrange
                IValidator<CreateCalcOrder> createCalcOrderValidator = A.Fake<IValidator<CreateCalcOrder>>();
                IValidator<UpdateCalcOrder> updateCalcOrderValidator = null;

                // Act
                Action act = () => new CalcOrderServiceValidations(createCalcOrderValidator, updateCalcOrderValidator);

                // Assert
                act.Should().Throw<ArgumentNullException>();
            }
        
        }
    }
}
