using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Specialized;
using System.Web;

namespace Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Common
{
    /// <summary>
    /// Delegating handler class to append $expand=versions to the URL. Needed to get blueprint versions.
    /// </summary>
    class ApiExpandHandler : DelegatingHandler
    {
        public ApiExpandHandler()
        {

        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var uriString = request.RequestUri.ToString();
            UriBuilder uri = new UriBuilder(uriString);
            var apiString =  uri.ToString() + "&$expand=versions";
            request.RequestUri = new Uri(apiString);

            return base.SendAsync(request, cancellationToken);
        }

    }
}
