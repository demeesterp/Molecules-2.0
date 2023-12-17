namespace MoleculesGui.data.serviceagents.orderbook
{
    public class CalcOrderItem(int id, string moleculeName, CalcOrderItemDetails details)
    {
        public int Id { get; } = id;

        public string MoleculeName { get; } = string.IsNullOrWhiteSpace(moleculeName) ?
                                                throw new ArgumentException(nameof(details)) : moleculeName;

        public CalcOrderItemDetails Details { get; set; } = details;

    }
}
