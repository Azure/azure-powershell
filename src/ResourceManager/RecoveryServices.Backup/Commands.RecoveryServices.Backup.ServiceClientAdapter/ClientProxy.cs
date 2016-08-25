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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ClientProxy<TClient, THeader> : ClientProxyBase
        where TClient : ServiceClient<TClient>
    {
        /// <summary>
        /// Client to talk to backend service
        /// </summary>
        private TClient client;

        /// <summary>
        /// Delegate action to generate custom request headers
        /// </summary>
        private Func<string, THeader> CustomRequestHeaderGenerator;

        /// <summary>
        /// Get Recovery Services Backup service client.
        /// </summary>
        public TClient Client
        {
            get
            {
                if (this.client == null)
                {
                    this.client = AzureSession.ClientFactory.CreateCustomClient<TClient>(Parameters);
                }

                return this.client;
            }
        }

        public ClientProxy(Func<string, THeader> headerGenerator, params object[] parameters)
            : base(parameters)
        {
            CustomRequestHeaderGenerator = headerGenerator;
        }

        /// <summary>
        /// Gets customer request headers
        /// </summary>
        public THeader GetCustomRequestHeaders()
        {
            return CustomRequestHeaderGenerator(this.ClientRequestId);
        }
    }
}
