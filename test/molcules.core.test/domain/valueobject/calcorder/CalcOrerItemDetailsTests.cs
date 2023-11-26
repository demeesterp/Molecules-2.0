using molecules.core.domain.valueobjects.basisset;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.test.domain.valueobjects.calcorder
{
    public class CalcOrderItemDetailsTests
    {
        public class CalcOrderItemDetailsConstructorTests : CalcOrderItemDetailsTests
        {
            [Fact]
            public void Should_Initialise_Members_When_Default_Constructor_Called()
            {
                // Act
                CalcOrderItemDetails details = new CalcOrderItemDetails(0,"xyz file", 
                                                            CalcBasisSetCode.B3_21G,
                                                                    CalcOrderItemType.GeoOpt);

                // Assert
                Assert.Equal(0, details.Charge);

                Assert.Equal(CalcOrderItemType.GeoOpt, details.Type);

                Assert.Equal(CalcBasisSetCode.B3_21G, details.BasisSetCode);
            }
        }

    }
}
