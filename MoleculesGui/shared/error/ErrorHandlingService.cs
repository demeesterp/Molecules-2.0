using MoleculesGui.data.serviceagents.errorcontract;
using MoleculesGui.data.viewmodel;
using MoleculesGui.shared.httpclient_helper;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MoleculesGui.shared.error
{
    public class ErrorHandlingService
    {
        private Subject<HttpErrorVm> HttpErrors = new Subject<HttpErrorVm>();

        public void NotifyHttpError(Exception exception)
        {
            if (exception is ServerErrorException)
            {
                ServerErrorException dummy = (ServerErrorException)exception;
                NotifyHttpError(dummy.ErrorContract, dummy.ErrorDetails);
            }

            if (exception is ServerValidationException)
            {
                ServerValidationException dummy = (ServerValidationException)exception;
                NotifyHttpError(dummy.ErrorContract, dummy.ErrorDetails);
            }

            if (exception is UnKnownHttpException)
            {
                UnKnownHttpException dummy = (UnKnownHttpException)exception;
                NotifyHttpError(dummy.Message, dummy.ErrorDetails);
            }
        }


        public void NotifyHttpError(ServiceError serviceError, HttpErrorDetails error)
        {
            HttpErrorVm httpError = new HttpErrorVm(serviceError, error);
            Console.WriteLine(httpError.GetFullErrorLog());
            HttpErrors.OnNext(httpError);
        }

        public void NotifyHttpError(string serviceError, HttpErrorDetails error)
        {
            HttpErrorVm httpError = new HttpErrorVm(serviceError, error);
            Console.WriteLine(httpError.GetFullErrorLog());
            HttpErrors.OnNext(httpError);
        }

        public void NotifyHttpError(ServiceValidationError serviceError, HttpErrorDetails error)
        {
            HttpErrorVm httpError = new HttpErrorVm(serviceError, error);
            Console.WriteLine(httpError.GetFullErrorLog());
            HttpErrors.OnNext(httpError);
        }

        public IObservable<HttpErrorVm> RegisterHttpErrorHandler(Action<HttpErrorVm> actions)
        {
            return HttpErrors.Do( item =>  actions(item));
        }

        public IObservable<HttpErrorVm> Errors => HttpErrors;

    }
}
