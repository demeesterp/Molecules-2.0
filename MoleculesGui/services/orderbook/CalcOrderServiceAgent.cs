namespace MoleculesGui.Services.OrderBook
{
    public class CalcOrderServiceAgent : ICalcOrderServiceAgent
    {

        private readonly HttpClient _httpClient;


        public CalcOrderServiceAgent(HttpClient httpClient) 
        { 
            _httpClient = httpClient;   
        }



    }
}
