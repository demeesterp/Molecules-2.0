using MoleculesGui.data.viewmodel;

namespace MoleculesGui.services.molecules
{
    public interface IMoleculesOverViewService
    {
        IObservable<List<MoleculesOverviewItemVM>> RetrieveMolecules(string findquery);

    }
}
