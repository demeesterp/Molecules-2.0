namespace molecules.core.services.calcdelivery
{
    public interface ICalcDeliveryService
    {
        Task ExportCalcDeliveryInputAsync(string basePath);

        Task ImportCalcDeliveryOutputAsync(string basePath);
    }
}
