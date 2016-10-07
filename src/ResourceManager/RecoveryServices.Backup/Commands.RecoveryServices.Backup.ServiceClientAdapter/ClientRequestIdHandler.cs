using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public class ClientRequestIdHandler : DelegatingHandler, ICloneable
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            
            return base.SendAsync(request, cancellationToken);
        }

        public object Clone()
        {
            return new ClientRequestIdHandler();
        }
    }
}
