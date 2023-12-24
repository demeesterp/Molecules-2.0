using MoleculesGui.data.serviceagents.molecules;

namespace MoleculesGui.services.molecules
{
    public interface IMoleculesServiceAgent
    {
        IObservable<CalcMolecule> Get(int id);

        IObservable<IList<CalcMolecule>> GetByName(string name);
    }
}
