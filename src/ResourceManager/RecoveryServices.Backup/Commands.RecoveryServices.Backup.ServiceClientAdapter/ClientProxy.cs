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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using AutoRestNS = Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
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
                    client = AzureSession.ClientFactory.CreateArmClient<TClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
                }

                return client;
            }
        }

        public ClientProxy(AzureContext context)
            : base(context)
        {
        }

        //internal Dictionary<string, List<string>> GetCustomRequestHeaders()
        //{
        //    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>()
        //    {
        //        "x-ms-client-request-id"
        //    };
        //}
    }
}
