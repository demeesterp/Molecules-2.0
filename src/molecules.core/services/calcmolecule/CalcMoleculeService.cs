using molecules.core.common.dbentity.calcorder;
using molecules.core.common.interfaces.logging;
using molecules.core.common.interfaces.repositories;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.molecules;
using molecules.core.factories.calcmolecule;
using molecules.shared;

namespace molecules.core.services.calcmolecule
{
    public class CalcMoleculeService(ICalcMoleculeFactory factory,
                                    IMoleculeRepository repository,
                                        IMoleculesLogger logger) : ICalcMoleculeService
    {

        private readonly ICalcMoleculeFactory _factory = factory;

        private readonly IMoleculeRepository _repository = repository;

        private readonly IMoleculesLogger _logger = logger;

        public async Task<CalcMolecule> GetAsync(int id)
        {
            _logger.LogInformation($"GetAsync {id}");

            var moleculeDbEntity = await _repository.GetByIdAsync(id);

            return _factory.BuildMolecule(moleculeDbEntity);
        }

        public async Task<CalcMolecule?> FindAsync(string orderName, string basisSet, string moleculeName)
        {
            _logger.LogInformation($"FindAsync for OrderName {orderName}, basisSet {basisSet} moleculeName {moleculeName} ");

            var moleculeDbEntity = await _repository.FindAsync(orderName, basisSet, moleculeName);

            return moleculeDbEntity == null ? null : _factory.BuildMolecule(moleculeDbEntity);
        }

        public async Task<List<CalcMolecule>> FindAllByNameAsync(string moleculeName)
        {
            _logger.LogInformation($"DeleteAsync with id {moleculeName}");

            var moleculeDbEntities = await _repository.FindAllByNameAsync(moleculeName);

            return moleculeDbEntities.OrderByDescending(i => i.OrderName)
                                    .ThenByDescending(i => i.MoleculeName)
                                    .ThenByDescending(i => i.Id)
                                    .Select(_factory.BuildMolecule).ToList();
        }

        public async Task<CalcMolecule> CreateAsync(CalcMolecule molecule)
        {
            _logger.LogInformation("CreateAsync");

            string moleculeStringData = "";

            if (molecule.Molecule != null)
            {
                moleculeStringData = StringConversion.ToJsonString(molecule.Molecule);
            }

            var moleculeDbEntity =
                await _repository.CreateAsync(new MoleculeDbEntity()
                {
                    Id = molecule.Id,
                    OrderName = molecule.OrderName,
                    BasisSet = molecule.BasisSet,
                    MoleculeName = molecule.MoleculeName,
                    Molecule = moleculeStringData
                });

            await _repository.SaveChangesAsync();


            return _factory.BuildMolecule(moleculeDbEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("DeleteAsync");

            await _repository.DeleteAsync(id);

            await _repository.SaveChangesAsync();
        }

        public async Task<CalcMolecule> UpdateAsync(int id, Molecule? molecule)
        {
            _logger.LogInformation("UpdateAsync");
            ArgumentNullException.ThrowIfNull(molecule);

            var result = await _repository.UpdateAsync(id, molecule.Name, StringConversion.ToJsonString(molecule));

            await _repository.SaveChangesAsync();

            return _factory.BuildMolecule(result);
        }


    }
}
