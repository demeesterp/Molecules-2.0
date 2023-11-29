using molecules.core.common.dbentity.calcorder;
using molecules.core.domain.aggregates;

namespace molecules.core.factories.calcorder
{
    /// <summary>
    /// Interface for the factory service to create CalcOrder entity
    /// </summary>
    public interface ICalcOrderFactory
    {
        /// <summary>
        /// Create a new CalcOrder entity from a CalcOrderDbEntity
        /// </summary>
        /// <param name="dbEntity">Data comming from DB</param>
        /// <returns>Completd calcorder</returns>
        CalcOrder CreateCalcOrder(CalcOrderDbEntity dbEntity);
    }
}
