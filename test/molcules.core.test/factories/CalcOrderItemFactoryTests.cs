using FluentAssertions;
using molecules.core.common.dbentity.calcorder;
using molecules.core.domain.valueobjects.basisset;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.factories.calcorder;

namespace molecules.core.tests.factories
{
    public class CalcOrderItemFactoryTests
    {

        public CalcOrderItemFactory CalcOrderItemFactory { get; set; }

        public CalcOrderItemFactoryTests()
        {
            CalcOrderItemFactory = new CalcOrderItemFactory();
        }

        public static CalcOrderItemDbEntity CreateDummyCalcOrderItem(string calcType)
        {
            CalcOrderItemDbEntity dbEntity = new()
            {
                XYZ = "Test",
                Charge = -1,
                CalcType = calcType,
                Id = 1,
                MoleculeName = "TestMolecule",
                CalcOrderId = 2,
                BasissetCode = CalcBasisSetCode.B3_21G.ToString()
            };
            return dbEntity;
        }

        [Fact]
        public void CreateCalcOrderItem_Should_Return_Valid_CalcOrderItem_When_Valid_CalcType_Input()
        {
            // Arrange
            var dbEntity = CreateDummyCalcOrderItem(CalcOrderItemType.MolecularProperties.ToString());

            // Act
            var result = CalcOrderItemFactory.CreateCalcOrderItem(dbEntity);

            // Assert
            result.Should().NotBeNull();

            result.MoleculeName.Should().Be(dbEntity.MoleculeName);
            result.Id.Should().Be(dbEntity.Id);
            result.Details.Charge.Should().Be(dbEntity.Charge);
            result.Details.XYZ.Should().Be(dbEntity.XYZ);
            result.Details.Type.ToString().Should().Be(dbEntity.CalcType);
            result.Details.BasisSetCode.ToString().Should().Be(dbEntity.BasissetCode);
        }

        [Fact]
        public void CreateCalcOrderItem_Should_Return_Valid_CalcOrderItem_With_GeoOpt_When_InValid_CalcType_Input()
        {

            // Arrange
            var dbEntity = CreateDummyCalcOrderItem("Test");

            // Act
            var result = CalcOrderItemFactory.CreateCalcOrderItem(dbEntity);

            // Assert
            result.Should().NotBeNull();
            result.MoleculeName.Should().Be(dbEntity.MoleculeName);
            result.Id.Should().Be(dbEntity.Id);
            result.Details.Charge.Should().Be(dbEntity.Charge);
            result.Details.XYZ.Should().Be(dbEntity.XYZ);
            result.Details.Type.Should().Be(CalcOrderItemType.GeoOpt);
            result.Details.BasisSetCode.ToString().Should().Be(dbEntity.BasissetCode);
        }

    }
}
