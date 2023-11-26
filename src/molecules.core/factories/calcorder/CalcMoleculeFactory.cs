using molecule.core.common.dbentity.calcorder;
using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.molecules;
using molecules.shared;

namespace molecules.core.factories.calcorder
{
    public class CalcMoleculeFactory : ICalcMoleculeFactory
    {
        public CalcMolecule BuildMolecule(MoleculeDbEntity moleculeDbEntity)
        {
            CalcMolecule retval = new CalcMolecule(moleculeDbEntity.Id,
                                    moleculeDbEntity.OrderName,
                                        moleculeDbEntity.BasisSet, 
                                            moleculeDbEntity.MoleculeName);


            retval.Molecule = StringConversion.FromJsonString<Molecule>(moleculeDbEntity.Molecule);
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
