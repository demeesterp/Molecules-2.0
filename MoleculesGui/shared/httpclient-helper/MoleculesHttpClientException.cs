using MoleculesGui.data.serviceagents.errorcontract;

namespace MoleculesGui.shared.httpclient_helper
{
    public class MoleculesHttpClientException<ErrorContractType> : Exception where ErrorContractType : IServiceError
    {
        public MoleculesHttpClientException(ErrorContractType errorContract, HttpErrorDetails errorDetails) :
                base(errorContract.GetErrorMsg())
        {
            ErrorDetails = errorDetails;
            ErrorContract = errorContract;
        }

        public ErrorContractType ErrorContract { get; set; }

        public HttpErrorDetails ErrorDetails { get; }

    }
}
