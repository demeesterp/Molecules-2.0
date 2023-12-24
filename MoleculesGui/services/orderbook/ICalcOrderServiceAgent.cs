using MoleculesGui.data.serviceagents.orderbook;
using System.Reactive;

namespace MoleculesGui.Services.OrderBook
{
    public interface ICalcOrderServiceAgent
    {
        IObservable<IList<CalcOrder>> List();

        IObservable<CalcOrder> Get(int id);

        IObservable<IList<CalcOrder>> GetByName(string name);

        IObservable<CalcOrder> Create(CreateCalcOrder createCalcOrder);


        IObservable<CalcOrder> Update(int id, UpdateCalcOrder updateCalcOrder);

        IObservable<Unit> Delete(int id);


        IObservable<CalcOrderItem> CreateCalcOrderItem(int calcOrderId, CreateCalcOrderItem createCalcOrderItem);


        IObservable<CalcOrderItem> UpdateCalcOrderItem(int calcOrderId, CreateCalcOrderItem createCalcOrderItem);


        IObservable<Unit> DeleteCalcOrderItem(int calcOrderItemId);
    }
}
