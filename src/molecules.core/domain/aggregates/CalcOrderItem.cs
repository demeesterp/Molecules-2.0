using molecules.core.domain.valueobjects.calcorderitem;

namespace molecules.core.domain.aggregates
{
    public class CalcOrderItem(int id, string moleculeName, CalcOrderItemDetails details)
    {
        public int Id { get; } = id;

        public string MoleculeName { get; } = moleculeName;

        public CalcOrderItemDetails Details { get; set; } = details;

        public void UpdateDetails(CalcOrderItemDetails details)
        {
            ArgumentNullException.ThrowIfNull(details, nameof(details));
            Details = details;
        }

    }
}
