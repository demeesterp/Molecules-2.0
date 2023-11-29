using molecules.core.common.dbentity.calcorder;

namespace molecules.core.common.interfaces.repositories
{
    public interface IMoleculeRepository
    {
        Task SaveChangesAsync();

        Task<MoleculeDbEntity> CreateAsync(MoleculeDbEntity entity);

        Task<MoleculeDbEntity> UpdateAsync(int id, string moleculeName, string molecule);

        Task DeleteAsync(int id);

        Task<MoleculeDbEntity> GetByIdAsync(int id);

        Task<MoleculeDbEntity?> FindAsync(string orderName, string basisSet, string moleculeName);

        Task<List<MoleculeNameInfoDbEntity>> FindAllByNameAsync(string moleculeName);
    }
}
