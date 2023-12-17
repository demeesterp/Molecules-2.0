using MoleculesGui.data.serviceagents.orderbook;

namespace MoleculesGui.Services.OrderBook
{
    public interface ICalcOrderServiceAgent
    {
        Task<IList<CalcOrder>> ListAsync();

        Task<CalcOrder> GetAsync(int id);

        Task<IList<CalcOrder>> GetByNameAsync(string name);

        Task<CalcOrder> CreateAsync(CreateCalcOrder createCalcOrder);


        Task<CalcOrder> UpdateAsync(int id, UpdateCalcOrder updateCalcOrder);

        Task DeleteAsync(int id);


        Task<CalcOrderItem> CreateCalcOrderItemAsync(int calcOrderId, CreateCalcOrderItem createCalcOrderItem);


        Task<CalcOrderItem> UpdateCalcOrderItemAsync(int calcOrderId, CreateCalcOrderItem createCalcOrderItem);


        Task DeleteCalcOrderItemAsync(int calcOrderItemId);
    }
}
