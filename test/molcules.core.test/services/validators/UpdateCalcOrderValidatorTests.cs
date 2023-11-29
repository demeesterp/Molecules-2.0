using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.services.validators;

namespace molecules.core.test.services.validators
{
    public class UpdateCalcOrderValidatorTests
    {
        [Fact]
        public void CalcOrderDetailsValidator_WhenNameIsEmpty_ReturnsError()
        {
            // Arrange
            var calcOrderDetails = new UpdateCalcOrder(string.Empty,string.Empty);
            var validator = new UpdateCalcOrderValidator();

            // Act
            var result = validator.Validate(calcOrderDetails);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Name is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void CalcOrderDetailsValidator_WhenNameIsWhitespace_ReturnsError()
        {
            // Arrange
            var calcOrderDetails = new UpdateCalcOrder(" ",string.Empty);
            var validator = new UpdateCalcOrderValidator();

            // Act
            var result = validator.Validate(calcOrderDetails);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Name is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void CalcOrderDetailsValidator_WhenNameIsTooLong_ReturnsError()
        {
            // Arrange
            var calcOrderDetails = new UpdateCalcOrder(new string('t', 251),String.Empty);
            var validator = new UpdateCalcOrderValidator();

            // Act
            var result = validator.Validate(calcOrderDetails);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Name cannot be longer than 250 characters", result.Errors[0].ErrorMessage);
        }
    }
}
