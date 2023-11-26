using Microsoft.EntityFrameworkCore;
using molecule.core.common.dbentity.calcorder;
using molecule.core.common.errorhandling;
using molecule.core.common.interfaces.repositories;
using molecules.infrastructure.data;

namespace molecules.data.repositories
{
    public class CalcOrderItemRepository(MoleculesDbContext context) : ICalcOrderItemRepository
    {
        private readonly MoleculesDbContext _context = context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<CalcOrderItemDbEntity> CreateAsync(CalcOrderItemDbEntity entity)
        {
            var order = _context.CalcOrders.Find(entity.CalcOrderId);
            if( order != null )
            {
                entity.CalcOrder = order;
                await _context.CalcOrderItems.AddAsync(entity);
            }
            else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderDbEntity)} with Id {entity.CalcOrderId} was not found");
            }            
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.CalcOrderItems.FindAsync(id);
            if ( result != null)
            {
                _context.CalcOrderItems.Remove(result);
            }
            else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderItemDbEntity)} with Id {id} was not found");
            }
        }

        public async Task<CalcOrderItemDbEntity> UpdateAsync(int id, int charge, string moleculeName, string calcType, string basisSetCode, string xyz)
        {
            var result = await _context.CalcOrderItems.Include(oi => oi.CalcOrder).FirstOrDefaultAsync(oi => oi.Id == id);
            if (result != null)
            {
                result.MoleculeName = moleculeName;
                result.Charge = charge;
                result.CalcType = calcType;
                result.BasissetCode = basisSetCode;
                result.XYZ = xyz;
                return result;
            }
            else
            {
                throw new MoleculesResourceNotFoundException($"Resource {nameof(CalcOrderItemDbEntity)} with Id {id} was not found");
            }
        }
    }
}
