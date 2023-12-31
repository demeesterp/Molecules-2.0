﻿using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.basisset;
using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.tests.aggregates
{
    public class CalcOrderTests
    {
        public class ConstructorTests : CalcOrderTests
        {
            [Fact]
            public void Should_Initialise_Name_When_Constructor_With_Name_Parameter_Is_Called()
            {
                // Arrange
                string name = "Test Name";
                int id = 0;

                // Act
                CalcOrder calcOrder = new(id, name);

                // Assert
                Assert.Equal(0, calcOrder.Id);
                Assert.Equal("Default", calcOrder.CustomerName);
                Assert.Equal(name, calcOrder.Details.Name);
                Assert.Equal(string.Empty, calcOrder.Details.Description);
            }

            [Fact]
            public void Should_Initialise_Id_When_Constructor_With_Id_Parameter_Is_Called()
            {
                // Arrange
                string name = "Test Name";
                int id = 1;

                // Act
                CalcOrder calcOrder = new(id, name);

                // Assert
                Assert.Equal(id, calcOrder.Id);
                Assert.Equal("Default", calcOrder.CustomerName);
                Assert.Equal(name, calcOrder.Details.Name);
                Assert.Equal(string.Empty, calcOrder.Details.Description);

            }

            [Fact]
            public void Should_Initialise_Name_And_Description_When_Constructor_With_Name_And_DescriptionParameter_Is_Called()
            {
                // Arrange
                string name = "Test Name";
                string description = "Test Description";
                int id = 0;

                // Act
                CalcOrder calcOrder = new(id, name, description);

                // Assert
                Assert.Equal(0, calcOrder.Id);
                Assert.Equal(name, calcOrder.Details.Name);
                Assert.Equal("Default", calcOrder.CustomerName);
                Assert.Equal(description, calcOrder.Details.Description);
            }

            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("\r")]
            [InlineData("\r\n")]
            [InlineData("\t")]
            public void Should_Throw_When_Contractor_With_Invalid_Name_Is_Called(string name)
            {
                // Arrange
                Assert.Throws<ArgumentException>(() => new CalcOrder(0,name));
            }
        }



        public class AddItemTests : CalcOrderTests
        {
            [Fact]
            public void Should_Add_Item_ToList_WhenItem_Is_Valid()
            {
                // Arrange
                CalcOrder calcOrder = new(0, "test");

                CalcOrderItem toAdd = new(12, "Test Molecule",
                                                new CalcOrderItemDetails(0, "xyz file",
                                                           CalcBasisSetCode.BSTO3G,
                                                             CalcOrderItemType.MolecularProperties));

                // Act
                calcOrder.AddItem(toAdd);

                // Assert
                Assert.Single(calcOrder.Items);
                Assert.Equal(toAdd, calcOrder.Items[0]);
            }
        }


        public class RemoveItemTests : CalcOrderTests
        {
            [Fact]
            public void Should_Remove_Item_FromList_WhenItem_Is_Valid()
            {
                // Arrange
                CalcOrder calcOrder = new(0, "test");

                CalcOrderItem toAdd = new(100, "Test Molecule",
                                          new CalcOrderItemDetails(0, "xyz file",
                                               CalcBasisSetCode.BSTO3G,
                                               CalcOrderItemType.MolecularProperties));
                calcOrder.AddItem(toAdd);

                // Act
                calcOrder.RemoveItem(100);

                // Assert
                Assert.Empty(calcOrder.Items);
            }

            [Fact]
            public void Should_Not_Remove_Item_FromList_WhenItem_Is_Not_Found()
            {
                // Arrange
                CalcOrder calcOrder = new(0, "test");

                CalcOrderItem toAdd = new(12, "Test Molecule", 
                                            new CalcOrderItemDetails(0, "xyz file",
                                                    CalcBasisSetCode.BSTO3G,
                                                    CalcOrderItemType.MolecularProperties));
                calcOrder.AddItem(toAdd);

                // Act
                calcOrder.RemoveItem(999);

                // Assert
                Assert.Single(calcOrder.Items);
            }   
        }

    }
}
