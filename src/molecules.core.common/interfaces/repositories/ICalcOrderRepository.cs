using molecules.core.common.dbentity.calcorder;

namespace molecules.core.common.interfaces.repositories
{
    public interface ICalcOrderRepository
    {
        Task SaveChangesAsync();

        Task<CalcOrderDbEntity> CreateAsync(CalcOrderDbEntity entity);

        Task<CalcOrderDbEntity> UpdateAsync(int id, string name, string description);

        Task DeleteAsync(int id);

        Task<CalcOrderDbEntity> GetByIdAsync(int id);

        Task<List<CalcOrderDbEntity>> GetAllAsync();

        Task<List<CalcOrderDbEntity>> GetByNameAsync(string name);

    }
}
