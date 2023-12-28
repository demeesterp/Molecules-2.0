using Microsoft.AspNetCore.Components;
using MoleculesGui.data.viewmodel;
using MoleculesGui.services.molecules;

namespace MoleculesGui.pages.analysis
{
    public partial class MoleculesDetail:ComponentBase
    {
        [Inject] private IMoleculesOverViewService? overViewService { get; set; }

        [Parameter]
        public int MoleculeId { get; set; }


        public MoleculesOverviewItemVM CurrentMolecule { get; set; }


        protected override void OnInitialized()
        {
        }

    }
}
