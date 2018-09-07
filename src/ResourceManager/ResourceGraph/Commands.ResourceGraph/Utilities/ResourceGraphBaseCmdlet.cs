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

namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.ResourceGraph;

    /// <summary>
    /// ResourceGraphBaseCmdlet
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet" />
    public abstract class ResourceGraphBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The resource graph client
        /// </summary>
        private IResourceGraphClient _resourceGraphClient;

        /// <summary>
        /// Gets the resource graph client.
        /// </summary>
        public IResourceGraphClient ResourceGraphClient
        {
            get
            {
                if (this._resourceGraphClient == null)
                {
                    AzureSession.Instance.ClientFactory.AddHandler(new IntHandler());

                    this._resourceGraphClient =
                        AzureSession.Instance.ClientFactory.CreateArmClient<ResourceGraphClient>(
                            this.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return this._resourceGraphClient;
            }
        }
    }

    public class IntHandler : DelegatingHandler, ICloneable
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestString = request.RequestUri.ToString();
            var intRequestString = requestString.Replace(
                "Microsoft.ResourceGraph", "Microsoft.ResourceGraph.PPE");
            request.RequestUri = new Uri(intRequestString, UriKind.Absolute);
            return base.SendAsync(request, cancellationToken);
        }

        public object Clone()
        {
            return new IntHandler();
        }
    }
}
