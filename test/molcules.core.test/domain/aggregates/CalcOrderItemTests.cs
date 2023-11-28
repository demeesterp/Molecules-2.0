﻿using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.basisset;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.tests.domain.aggregates
{

    public class CalcOrderItemTests
    {
        public class CalcOrderItemConstructorTests : CalcOrderItemTests
        {

            [Fact]
            public void Should_Initialise_Members_When_Default_Constructor_Called()
            {
                // Act
                CalcOrderItem item = new(0, "moleculename",
                                    new CalcOrderItemDetails(0, "xyzfile", 
                                                            CalcBasisSetCode.BSTO3G,
                                                                CalcOrderItemType.MolecularProperties));

                // Assert
                Assert.Equal(0, item.Id);
                Assert.Equal("moleculename", item.MoleculeName);
                Assert.NotNull(item.Details);

            }

            [Fact]
            public void Should_Throw_ArgumentException_When_MoleculeName_Is_Null()
            {
                // Arrange
                string moleculeName = null;

                // Act
                void action() =>
                         new CalcOrderItem(0, moleculeName,
                                        new CalcOrderItemDetails(0, "xyz file", CalcBasisSetCode.BSTO3G, CalcOrderItemType.MolecularProperties));

                // Assert
                Assert.Throws<ArgumentNullException>(action);
            }

            [Fact]
            public void Should_Throw_ArgumentException_When_MoleculeName_Is_Empty()
            {
                // Arrange
                string moleculeName = string.Empty;

                // Act
                void action() =>
                         new CalcOrderItem(0, moleculeName,
                                        new CalcOrderItemDetails(0,
                                                                 "xyz file",
                                                                 CalcBasisSetCode.BSTO3G,
                                                                  CalcOrderItemType.MolecularProperties));

                // Assert
                Assert.Throws<ArgumentNullException>(action);
            }

            [Fact]
            public void Should_Initialise_Members_When_MoleculeName_Is_Valid()
            {
                // Arrange
                string moleculeName = "MoleculeName";

                // Act
                CalcOrderItem item = new(0, moleculeName,
                                        new CalcOrderItemDetails(0, "xyz file", CalcBasisSetCode.BSTO3G, CalcOrderItemType.MolecularProperties));

                // Assert
                Assert.Equal(0, item.Id);
                Assert.Equal(moleculeName, item.MoleculeName);
                Assert.NotNull(item.Details);
            }
        }

        public class UpdateDetailsTests : CalcOrderItemTests
        {
            [Fact]
            public void Should_Throw_ArgumentNullException_When_Details_Is_Null()
            {
                // Arrange
                CalcOrderItem item = new(0, "moleculeName",
                                        new CalcOrderItemDetails(0, "xyz fle", CalcBasisSetCode.BSTO3G, CalcOrderItemType.MolecularProperties));
                CalcOrderItemDetails details = null;

                // Act
                void action() => item.UpdateDetails(details);

                // Assert
                Assert.Throws<ArgumentNullException>(action);
            }

            [Fact]
            public void Should_Update_Details_When_Details_Is_Valid()
            {
                // Arrange
                CalcOrderItem item = new(0, "moleculeName",
                     new CalcOrderItemDetails(0, "xyz file", CalcBasisSetCode.BSTO3G, CalcOrderItemType.MolecularProperties));
                
                CalcOrderItemDetails details = new(0, "moleculeName", CalcBasisSetCode.BSTO3G, CalcOrderItemType.MolecularProperties);

                // Act
                item.UpdateDetails(details);

                // Assert
                Assert.Equal(details, item.Details);
            }
        }

    }
}
