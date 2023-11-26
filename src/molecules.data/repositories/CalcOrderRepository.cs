using Microsoft.EntityFrameworkCore;
using molecule.core.common.dbentity.calcorder;
using molecule.core.common.errorhandling;
using molecule.core.common.interfaces.repositories;
using molecules.infrastructure.data;

namespace molecules.data.repositories
{
    public class CalcOrderRepository(MoleculesDbContext context) : ICalcOrderRepository
    {

        private readonly MoleculesDbContext _context = context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CalcOrderDbEntity> CreateAsync(CalcOrderDbEntity entity)
        {
            await _context.CalcOrders.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
           var result = await _context.CalcOrders.Include(o => o.CalcOrderItems).FirstOrDefaultAsync(o => o.Id == id);
           if ( result != null)
           {
                _context.CalcOrders.Remove(result);
           }
            else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderDbEntity)} with Id {id} was not found");
            }
        }

        public async Task<CalcOrderDbEntity> UpdateAsync(int id, string name, string description)
        {
            var result = await _context.CalcOrders.Include(o => o.CalcOrderItems).FirstOrDefaultAsync(o => o.Id == id);
            if (result != null)
            {
                result.Name =name;
                result.Description = description;
                return result;
            } else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderDbEntity)} with Id {id} was not found");
            }
        }

        public async Task<List<CalcOrderDbEntity>> GetAllAsync()
        {
            return await (from i in _context.CalcOrders.Include(o => o.CalcOrderItems) select i).ToListAsync();
        }

        public async Task<CalcOrderDbEntity> GetByIdAsync(int id)
        {
            var result = await _context.CalcOrders.Include(o => o.CalcOrderItems).FirstOrDefaultAsync(i => i.Id == id);
            if ( result != null)
            {
                return result;
            }
            else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderDbEntity)} with Id {id} was not found");
            }
        }

        public async Task<List<CalcOrderDbEntity>> GetByNameAsync(string name)
        {
           return await _context.CalcOrders.Include(o => o.CalcOrderItems).Where(i => i.Name == name).ToListAsync();
        }


    }
}
