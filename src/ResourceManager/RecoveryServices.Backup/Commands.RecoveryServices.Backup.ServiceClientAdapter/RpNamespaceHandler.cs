// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Modifies the resource provider namespace in the URLs to be sent, based on
    /// the value specified in service client adapter dll config.
    /// </summary>
    public class RpNamespaceHandler : DelegatingHandler, ICloneable
    {
        string rpNamespace;

        public RpNamespaceHandler(string rpNamespace)
        {
            this.rpNamespace = rpNamespace;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace(
                ServiceClientAdapter.ResourceProviderProductionNamespace, rpNamespace));

            return base.SendAsync(request, cancellationToken);
        }

        public object Clone()
        {
            return new RpNamespaceHandler(rpNamespace);
        }
    }
}
