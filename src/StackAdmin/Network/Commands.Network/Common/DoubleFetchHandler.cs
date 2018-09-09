using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Network
{
    public class DoubleFetchHandler : DelegatingHandler, ICloneable
    {
        public object Clone() {
            return new DoubleFetchHandler();
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(response =>
            {
                var result = response.Result;
                    if (result.Headers.Contains("Location") && result.Headers.Contains("Azure-AsyncOperation"))
                    {
                        result.Headers.Remove("Location");
                    }

                return result;
            });
        }

    }
}
