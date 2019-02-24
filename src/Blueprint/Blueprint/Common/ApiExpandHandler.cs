using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Specialized;
using System.Web;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    /// <summary>
    /// Delegating handler class to append $expand=versions to the URL. Needed to get blueprint versions.
    /// </summary>
    public class ApiExpandHandler : DelegatingHandler, ICloneable
    {
        private const string ExpandString = "versions";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriString = request.RequestUri.ToString();
            UriBuilder uri = new UriBuilder(uriString);
            var expandQueryString = "&$expand=" + ExpandString;
            var apiString =  uri.ToString() + expandQueryString;
            request.RequestUri = new Uri(apiString);

            return base.SendAsync(request, cancellationToken);
        }
        public object Clone()
        {
            return new ApiExpandHandler();
        }
    }
}
