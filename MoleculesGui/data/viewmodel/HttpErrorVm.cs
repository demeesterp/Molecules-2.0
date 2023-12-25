using MoleculesGui.data.serviceagents.errorcontract;
using MoleculesGui.shared.httpclient_helper;
using System.Net;

namespace MoleculesGui.data.viewmodel
{
    public class HttpErrorVm
    {

        public HttpErrorVm(ServiceError serviceError, HttpErrorDetails httpErrorDetails) 
        {
            StatusCode = httpErrorDetails.status;
            HttpMethod = httpErrorDetails.method;
            Uri = httpErrorDetails.requestUri;
            ServerErrorMessage = serviceError.GetErrorMsg(); 
        }

        public HttpErrorVm(string serviceError, HttpErrorDetails httpErrorDetails)
        {
            StatusCode = httpErrorDetails.status;
            HttpMethod = httpErrorDetails.method;
            Uri = httpErrorDetails.requestUri;
            ServerErrorMessage = serviceError;
        }

        public HttpErrorVm(ServiceValidationError serviceValidationError, HttpErrorDetails httpErrorDetails)
        {
            StatusCode = httpErrorDetails.status;
            HttpMethod = httpErrorDetails.method;
            Uri = httpErrorDetails.requestUri;
            ServerErrorMessage = $"{serviceValidationError.GetErrorMsg()} : " +
                                    $"{string.Join(",", serviceValidationError.ValidationErrors
                                                            .Select(vError => $"{vError.PropertyName} : {vError.Message}")
                                                            .ToList())}";
        }

        public HttpMethod HttpMethod { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string? Uri { get; set; }

        public string ServerErrorMessage { get; set; }


        public string GetFullErrorLog()
        {
            return $"An error occured while calling {HttpMethod} on {Uri} with Http statuscode {StatusCode} and error message {ServerErrorMessage}.";
        }


    }
}
