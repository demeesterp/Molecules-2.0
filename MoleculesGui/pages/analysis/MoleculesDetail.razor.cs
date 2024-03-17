using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MoleculesGui.data.viewmodel;
using MoleculesGui.services.molecules;
using MoleculesGui.services.molecules_display;

namespace MoleculesGui.pages.analysis
{
    public partial class MoleculesDetail:ComponentBase
    {
        [Inject]
        private IMoleculesAnalysisService? analysisService { get; set; }

        [Inject]
        private IJSRuntime jsRuntime { get; set; }

        [Parameter]
        public int MoleculeId { get; set; }

        public MoleculeReportVM CurrentMoleculeReport { get; set; } = new MoleculeReportVM(0);


        protected override void OnInitialized()
        {
            analysisService?.GetReport(MoleculeId).Subscribe(async report =>
                {
                    CurrentMoleculeReport = report;
                    var molecule = GetMolfile();

                    // Call the JavaScript function
                    await jsRuntime.InvokeVoidAsync("drawMolecule2D", "moleculedisplay", molecule);
                    this.StateHasChanged();
                }
            );
        }


        private string GetMolfile()
        {
            return MoleculesDisplayService.GetMolFile(CurrentMoleculeReport);
        }

    }
}
