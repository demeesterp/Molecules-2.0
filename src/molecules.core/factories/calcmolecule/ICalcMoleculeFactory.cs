using molecule.core.common.dbentity.calcorder;
using molecules.core.domain.aggregates;

namespace molecules.core.factories.calcmolecule
{
    public interface ICalcMoleculeFactory
    {
        CalcMolecule BuildMolecule(MoleculeDbEntity moleculeDbEntity);

        CalcMolecule BuildMolecule(MoleculeNameInfoDbEntity moleculeNameInfoDb);
    }
}
