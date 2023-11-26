using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.molecules;

namespace molecules.core.services.calcmolecule
{
    public interface ICalcMoleculeService
    {
        Task<CalcMolecule> GetAsync(int id);

        Task<CalcMolecule?> FindAsync(string orderName, string basisSet, string moleculeName);

        Task<List<CalcMolecule>> FindAllByNameAsync(string moleculeName);

        Task<CalcMolecule> CreateAsync(CalcMolecule molecule);

        Task<CalcMolecule> UpdateAsync(int id, Molecule? molecule);

        Task DeleteAsync(int id);


    }
}
