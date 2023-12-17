using MoleculesGui.data.serviceagents.orderbook;
using MoleculesGui.shared.httpclient_helper;
using System.Net.Http.Json;

namespace MoleculesGui.Services.OrderBook
{
    public class CalcOrderServiceAgent : ICalcOrderServiceAgent
    {

        private readonly HttpClient _httpClient;

        private readonly MoleculesHttpClient _moleculesHttpClient;


        public CalcOrderServiceAgent(HttpClient httpClient, MoleculesHttpClient moleculesHttpClient) 
        { 
            _httpClient = httpClient;
            _moleculesHttpClient = moleculesHttpClient;
        }

        public async Task<CalcOrder> CreateAsync(CreateCalcOrder createCalcOrder)
        {
            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("", createCalcOrder);

            


            throw new NotImplementedException();
        }

        public Task<CalcOrderItem> CreateCalcOrderItemAsync(int calcOrderId, CreateCalcOrderItem createCalcOrderItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCalcOrderItemAsync(int calcOrderItemId)
        {
            throw new NotImplementedException();
        }

        public Task<CalcOrder> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CalcOrder>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CalcOrder>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CalcOrder> UpdateAsync(int id, UpdateCalcOrder updateCalcOrder)
        {
            throw new NotImplementedException();
        }

        public Task<CalcOrderItem> UpdateCalcOrderItemAsync(int calcOrderId, CreateCalcOrderItem createCalcOrderItem)
        {
            throw new NotImplementedException();
        }
    }
}
