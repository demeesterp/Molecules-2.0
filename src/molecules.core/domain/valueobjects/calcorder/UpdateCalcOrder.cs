using molecules.core.domain.valueobjects.calcorder;

namespace molecules.core.domain.valueobjects.calcorderitem
{
    public record UpdateCalcOrder(string Name, string Description) : CalcOrderDetails(Name, Description);
}
