﻿using FakeItEasy;
using FluentAssertions;
using molecule.core.common.dbentity.calcorder;
using molecules.core.domain.valueobjects.calcorderitem;
using molecules.core.factories.calcorder;

namespace molecules.core.tests.factories
{
    public class CalcOrderFactoryTests
    {
        #region dependencies

        private readonly ICalcOrderItemFactory _calcOrderItemFactory;

        private readonly CalcOrderFactory calcOrderFactory;

        #endregion

        public CalcOrderFactoryTests()
        {
            _calcOrderItemFactory = A.Fake<ICalcOrderItemFactory>();
            calcOrderFactory = new CalcOrderFactory(_calcOrderItemFactory);
        }

        public static CalcOrderDbEntity CreateDummyCalcOrderDbEntity(List<CalcOrderItemDbEntity> items)
        {
            CalcOrderDbEntity retval = new CalcOrderDbEntity();
            retval.Id = 1;
            retval.Name = "Test";
            retval.Description = "Test";
            retval.CalcOrderItems = items;
            return retval;
        }

        [Fact]
        public void Should_Create_Valid_CalcOrder_From_Valid_CalcOrderItemDbEntity()
        {
            // Arrange
            var dbEntity = CreateDummyCalcOrderDbEntity(new List<CalcOrderItemDbEntity>()
            {
                CalcOrderItemFactoryTests.CreateDummyCalcOrderItem(CalcOrderItemType.MolecularProperties.ToString())
            });

            // Act
            var result = calcOrderFactory.CreateCalcOrder(dbEntity);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(dbEntity.Id);
            result.Details.Name.Should().Be(dbEntity.Name);
            result.Details.Description.Should().Be(dbEntity.Description);

            A.CallTo(() => _calcOrderItemFactory.CreateCalcOrderItem(A<CalcOrderItemDbEntity>.Ignored)).MustHaveHappenedOnceExactly();
        }


    }
}
