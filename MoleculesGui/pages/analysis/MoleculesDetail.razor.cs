using Microsoft.AspNetCore.Components;
using MoleculesGui.data.viewmodel;
using MoleculesGui.services.molecules;

namespace MoleculesGui.pages.analysis
{
    public partial class MoleculesDetail:ComponentBase
    {
        [Inject]
        private IMoleculesAnalysisService? analysisService { get; set; }

        [Parameter]
        public int MoleculeId { get; set; }

        public MoleculeReportVM CurrentMoleculeReport { get; set; } = new MoleculeReportVM(0);


        protected override void OnInitialized()
        {
            analysisService?
                .GetReport(MoleculeId)
                .Subscribe(report =>
                {
                    CurrentMoleculeReport = report;
                    this.StateHasChanged();
                }
            );
        }

    }
}
