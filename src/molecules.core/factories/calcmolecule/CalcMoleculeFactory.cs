using molecule.core.common.dbentity.calcorder;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.molecules;
using molecules.shared;

namespace molecules.core.factories.calcmolecule
{
    public class CalcMoleculeFactory : ICalcMoleculeFactory
    {
        public CalcMolecule BuildMolecule(MoleculeDbEntity moleculeDbEntity)
        {
            CalcMolecule retval = new(moleculeDbEntity.Id,
                                    moleculeDbEntity.OrderName,
                                        moleculeDbEntity.BasisSet,
                                            moleculeDbEntity.MoleculeName)
            {
                Molecule = StringConversion.FromJsonString<Molecule>(moleculeDbEntity.Molecule)
            };
            return retval;
        }

        public CalcMolecule BuildMolecule(MoleculeNameInfoDbEntity moleculeNameInfoDb)
        {
            return new CalcMolecule(moleculeNameInfoDb.Id,
                                    moleculeNameInfoDb.OrderName,
                                        moleculeNameInfoDb.BasisSet,
                                            moleculeNameInfoDb.MoleculeName);
        }
    }
}
