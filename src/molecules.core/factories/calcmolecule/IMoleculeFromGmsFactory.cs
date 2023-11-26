using molecules.core.domain.valueobjects.molecules;

namespace molecules.core.factories.calcmolecule
{
    public interface IMoleculeFromGmsFactory
    {

        bool TryCompleteMolecule(string fileName, List<string> fileLines, Molecule? molecule);

    }
}
