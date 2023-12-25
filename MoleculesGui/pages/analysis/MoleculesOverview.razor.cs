using Microsoft.AspNetCore.Components;
using MoleculesGui.data.viewmodel;
using MoleculesGui.services.molecules;

namespace MoleculesGui.pages.analysis
{
    public partial class MoleculesOverview : ComponentBase
    {
        [Inject] IMoleculesOverViewService? overViewService { get; set; }

        public List<MoleculesOverviewItemVM> Molecules => overViewService?.MoleculesOverviewVMs??new List<MoleculesOverviewItemVM>();

        protected override void OnInitialized()
        {
            //overViewService?.RetrieveMolecules("%");
        }
    }
}
