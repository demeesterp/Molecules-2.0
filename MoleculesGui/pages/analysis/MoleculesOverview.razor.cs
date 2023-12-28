﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MoleculesGui.data.viewmodel;
using MoleculesGui.services.molecules;

namespace MoleculesGui.pages.analysis
{
    public partial class MoleculesOverview : ComponentBase
    {
        #region datamembers
        [Inject] private IMoleculesOverViewService? overViewService { get; set; }

        private List<MoleculesOverviewItemVM> Molecules { get; set; } = new List<MoleculesOverviewItemVM>();

        private string searchTerm = "";

        #endregion

        protected override void OnInitialized()
        {
            overViewService?.RetrieveMolecules("%")
                            .Subscribe(molecules =>
                            {
                                Molecules = molecules;
                                StateHasChanged();
                            });
        }

        private void OnSearchMoleculeClick(MouseEventArgs args)
        {
            overViewService?.RetrieveMolecules(searchTerm)
                            .Subscribe(molecules =>
                            {
                                Molecules = molecules;
                                StateHasChanged();
                            });
        }

    }
}
