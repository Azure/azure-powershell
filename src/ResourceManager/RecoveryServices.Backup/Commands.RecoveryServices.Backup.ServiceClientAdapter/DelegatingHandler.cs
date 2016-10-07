using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public class RpNamespaceHandler : DelegatingHandler, ICloneable
    {
        string rpNamespace;

        public RpNamespaceHandler(string rpNamespace)
        {
            this.rpNamespace = rpNamespace;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {            
            request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace(ServiceClientAdapter.ResourceProviderProductionNamespace, rpNamespace));
            
            return base.SendAsync(request, cancellationToken);
        }

        public object Clone()
        {
            return new RpNamespaceHandler(rpNamespace);
        }
    }
}
