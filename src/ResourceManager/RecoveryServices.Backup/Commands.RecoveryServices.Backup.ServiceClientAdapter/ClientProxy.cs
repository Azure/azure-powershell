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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using AutoRestNS = Microsoft.Rest;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    /// <summary>
    /// Client proxy to talk to the backend service
    /// </summary>
    /// <typeparam name="TClient">Type of the client - should be a Swagger based client</typeparam>
    public partial class ClientProxy<TClient> : ClientProxyBase
        where TClient : AutoRestNS.ServiceClient<TClient>
    {
        /// <summary>
        /// Client to talk to backend service
        /// </summary>
        private TClient client;

        /// <summary>
        /// Get Recovery Services Backup service client.
        /// </summary>
        public TClient Client
        {
            get
            {
                if (client == null)
                {
                    client = AzureSession.ClientFactory.CreateArmClient<TClient>(
                        Context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return client;
            }
        }

        /// <summary>
        /// AzureContext based ctor
        /// </summary>
        /// <param name="context"></param>
        public ClientProxy(AzureContext context)
            : base(context)
        {
        }
    }
}
