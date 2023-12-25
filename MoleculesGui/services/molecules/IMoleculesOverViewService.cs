using MoleculesGui.data.viewmodel;

namespace MoleculesGui.services.molecules
{
    public interface IMoleculesOverViewService
    {
        void RetrieveMolecules(string findquery);

        List<MoleculesOverviewItemVM> MoleculesOverviewVMs { get; set; }
    }
}
