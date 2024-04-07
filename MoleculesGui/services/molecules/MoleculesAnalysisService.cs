using MoleculesGui.data.serviceagents.molecules;
using MoleculesGui.data.serviceagents.molecules.report;
using MoleculesGui.data.viewmodel;
using MoleculesGui.shared.error;
using System.Reactive.Linq;

namespace MoleculesGui.services.molecules
{
    public class MoleculesAnalysisService: IMoleculesAnalysisService
    {
        #region dependencies

        private readonly IMoleculesServiceAgent _moleculesServiceAgent;

        private readonly IMoleculesReportServiceAgent _moleculesReportServiceAgent;

        private readonly ErrorHandlingService _errorHandlingService;

        #endregion


        public MoleculesAnalysisService(IMoleculesServiceAgent moleculesServiceAgent,
                                            IMoleculesReportServiceAgent moleculesReportServiceAgent,
                                            ErrorHandlingService errorHandlingService)
        {
            _moleculesServiceAgent = moleculesServiceAgent;
            _errorHandlingService = errorHandlingService;
            _moleculesReportServiceAgent = moleculesReportServiceAgent;
        }


        public IObservable<List<MoleculesOverviewItemVM>> SearchCalculatedMolecules(string findquery)
        {
            return _moleculesServiceAgent.
                    GetByName(findquery)
                    .Catch<IList<CalcMolecule>, Exception>(HandleError<List<CalcMolecule>>)
                    .Select(result => result.Select(resultItem => new MoleculesOverviewItemVM(resultItem)).ToList());
        }


        public IObservable<MoleculeReportVM> GetReport(int moleculeId)
        {
            var generalReportObservable = _moleculesReportServiceAgent.GetGeneralReport(moleculeId)
                            .Catch<List<GeneralMoleculeReport>, Exception>(HandleError<List<GeneralMoleculeReport>>);


           var atomPositionObservable = _moleculesReportServiceAgent.GetAtomPositionReport(moleculeId)
                           .Catch<List<MoleculeAtomPositionReport>, Exception>(HandleError<List<MoleculeAtomPositionReport>>);


            var moleculeBondObservable = _moleculesReportServiceAgent.GetMoleculeBondsReport(moleculeId)
                            .Catch<List<MoleculeBondsReport>, Exception>(HandleError<List<MoleculeBondsReport>>);


            return generalReportObservable.CombineLatest(atomPositionObservable, moleculeBondObservable,
                    (generalReport, atomPosition, moleculeBond) => new MoleculeReportVM(moleculeId)
                    {
                        ReportItems = generalReport.ConvertAll(item => new GeneralMoleculeReportItemVm(item)),
                        AtomPositions = atomPosition.ConvertAll(item => new MoleculeAtomPositionReportItemVm(item)),
                        MoleculeBonds = moleculeBond.ConvertAll(item => new MoleculeBondsReportItemVm(item))
                    });
        }

        #region private helpers


        private IObservable<ReturnType> HandleError<ReturnType>(Exception ex) where ReturnType : new() 
        {
            _errorHandlingService.NotifyHttpError(ex);
            return Observable.Return(new ReturnType());
        }

        #endregion


    }
}
