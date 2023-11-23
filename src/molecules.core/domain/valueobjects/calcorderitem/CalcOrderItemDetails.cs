using molecules.core.domain.valueobjects.basisset;

namespace molecules.core.domain.valueobjects.calcorderitem
{
    public class CalcOrderItemDetails(int charge, string xyz, CalcBasisSetCode calcBasisSetCode, CalcOrderItemType type): CalcDetails(charge, xyz, calcBasisSetCode)
    {
        public CalcOrderItemType Type { get; init; } = type;
    };
}
