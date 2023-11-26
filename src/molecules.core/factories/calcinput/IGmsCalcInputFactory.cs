using molecules.core.domain.aggregates;
using molecules.core.domain.valueobjects.gmscalc.Input;

namespace molecules.core.factories.calcinput
{
    public interface IGmsCalcInputFactory
    {
        List<GmsCalcInputItem> BuildCalcInput(IList<CalcOrder> orders);
    }
}
