using System.Net;

namespace MoleculesGui.shared.httpclient_helper
{
    public record HttpErrorDetails(HttpMethod method, HttpStatusCode status, string? requestUri) { }
}
