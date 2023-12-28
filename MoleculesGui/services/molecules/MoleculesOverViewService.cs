﻿using MoleculesGui.data.serviceagents.molecules;
using MoleculesGui.data.viewmodel;
using MoleculesGui.shared.error;
using System.Reactive.Linq;

namespace MoleculesGui.services.molecules
{
    public class MoleculesOverViewService: IMoleculesOverViewService
    {
        #region dependencies

        private readonly IMoleculesServiceAgent _moleculesServiceAgent;

        private readonly ErrorHandlingService _errorHandlingService;

        #endregion


        public MoleculesOverViewService(IMoleculesServiceAgent moleculesServiceAgent, ErrorHandlingService errorHandlingService)
        {
            _moleculesServiceAgent = moleculesServiceAgent;
            _errorHandlingService = errorHandlingService;
        }


        public IObservable<List<MoleculesOverviewItemVM>> RetrieveMolecules(string findquery)
        {
            return _moleculesServiceAgent.
                    GetByName(findquery)
                    .Catch<IList<CalcMolecule>, Exception>(HandleError)
                    .Select(result => result.Select(resultItem => new MoleculesOverviewItemVM(resultItem)).ToList());
        }

        private IObservable<List<CalcMolecule>> HandleError(Exception ex)
        {
            _errorHandlingService.NotifyHttpError(ex);
            return Observable.Return(new List<CalcMolecule>());
        }


    }
}
