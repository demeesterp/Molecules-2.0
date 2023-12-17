using MoleculesGui.data.serviceagents.errorcontract;

namespace MoleculesGui.shared.httpclient_helper
{
    public class ServerErrorException : MoleculesHttpClientException<ServiceError>
    {
        public ServerErrorException(ServiceError errorContract, HttpErrorDetails errorDetails) 
                : base(errorContract, errorDetails)
        {
        }
    }
}
