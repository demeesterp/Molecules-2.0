using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.services.validators;

namespace molecules.core.test.services.validators
{
    public class CreateCalcOrderItemValidatorTests
    {

        [Fact]
        public void CreateCalcOrderItemValidator_WhenMoleculeNameIsEmpty_ReturnsError()
        {
            // Arrange
            var createCalcOrderItem = new CreateCalcOrderItem("",null);
            var validator = new CreateCalcOrderItemValidator();

            // Act
            var result = validator.Validate(createCalcOrderItem);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("MoleculeName is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void CreateCalcOrderItemValidator_WhenMoleculeNameIsWhitespace_ReturnsError()
        {
            // Arrange
            var createCalcOrderItem = new CreateCalcOrderItem(" ", null);
            var validator = new CreateCalcOrderItemValidator();

            // Act
            var result = validator.Validate(createCalcOrderItem);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("MoleculeName is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void CreateCalcOrderItemValidator_WhenMoleculeNameIsTooLong_ReturnsError()
        {
            // Arrange
            var createCalcOrderItem = new CreateCalcOrderItem(new string('t', 251),null);
            var validator = new CreateCalcOrderItemValidator();

            // Act
            var result = validator.Validate(createCalcOrderItem);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("MoleculeName cannot be longer than 250 characters", result.Errors[0].ErrorMessage);
        }

    }
}
