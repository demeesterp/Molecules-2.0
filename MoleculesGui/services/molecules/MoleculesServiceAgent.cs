﻿using MoleculesGui.data.serviceagents.molecules;
using MoleculesGui.shared.httpclient_helper;

namespace MoleculesGui.services.molecules
{
    public class MoleculesServiceAgent : IMoleculesServiceAgent
    {
        #region dependencies

        private readonly HttpClient _httpClient;

        private readonly MoleculesHttpClient _moleculesHttpClient;

        #endregion

        public MoleculesServiceAgent(HttpClient httpClient, MoleculesHttpClient moleculesHttpClient)
        {
            _httpClient = httpClient;
            _moleculesHttpClient = moleculesHttpClient;
        }

        public IObservable<CalcMolecule> Get(int id)
        {
            return _moleculesHttpClient.Get<CalcMolecule>(_httpClient, $"molecule/{id}");
        }

        public IObservable<IList<CalcMolecule>> GetByName(string name)
        {
            return _moleculesHttpClient.Get<List<CalcMolecule>>(_httpClient, $"molecule/name/{name}");
        }
    }
}
