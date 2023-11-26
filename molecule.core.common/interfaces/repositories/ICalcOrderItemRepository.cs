using molecule.core.common.dbentity.calcorder;

namespace molecule.core.common.interfaces.repositories
{
    public interface ICalcOrderItemRepository
    {
        Task SaveChangesAsync();

        Task<CalcOrderItemDbEntity> CreateAsync(CalcOrderItemDbEntity entity);


        Task<CalcOrderItemDbEntity> UpdateAsync(int id, int charge, string moleculeName, string calcType, string basisSetCode, string xyz);

        Task DeleteAsync(int id);

    }
}
