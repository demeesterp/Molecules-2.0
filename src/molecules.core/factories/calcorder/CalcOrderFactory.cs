﻿using molecules.core.common.dbentity.calcorder;
using molecules.core.domain.aggregates;

namespace molecules.core.factories.calcorder
{
    /// <summary>
    /// Factory service to create CalcOrder entity
    /// </summary>
    /// <remarks>
    /// Constrcutor
    /// </remarks>
    /// <param name="calcOrderItemFactory">Factory for the items</param>
    public class CalcOrderFactory(ICalcOrderItemFactory calcOrderItemFactory) : ICalcOrderFactory
    {

        #region dependencies

        private readonly ICalcOrderItemFactory _calcOrderItemFactory = calcOrderItemFactory;

        #endregion

        /// <summary>
        /// Create a new CalcOrder entity from a CalcOrderDbEntity
        /// </summary>
        /// <param name="dbEntity">Data comming from DB</param>
        /// <returns>Completd calcorder</returns>
        public CalcOrder CreateCalcOrder(CalcOrderDbEntity dbEntity)
        {
            CalcOrder retval = new(dbEntity.Id, dbEntity.Name, dbEntity.Description);
            retval.Items.AddRange(dbEntity.CalcOrderItems.Select(_calcOrderItemFactory.CreateCalcOrderItem));
            return retval;
        }
    }
}
