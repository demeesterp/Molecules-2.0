using molecule.core.common.calcorder;
using molecules.core.domain.aggregates;

namespace molecules.core.factories.calcorder
{
    public interface ICalcMoleculeFactory
    {
        CalcMolecule BuildMolecule(MoleculeDbEntity moleculeDbEntity);

        CalcMolecule BuildMolecule(MoleculeNameInfoDbEntity moleculeNameInfoDb);
    }
}
