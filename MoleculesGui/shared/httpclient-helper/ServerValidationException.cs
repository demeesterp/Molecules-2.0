using MoleculesGui.data.serviceagents.errorcontract;

namespace MoleculesGui.shared.httpclient_helper
{
    public class ServerValidationException : MoleculesHttpClientException<ServiceValidationError>
    {
        public ServerValidationException(ServiceValidationError errorContract, HttpErrorDetails errorDetails) :
            base(errorContract, errorDetails) { }
    }
}
