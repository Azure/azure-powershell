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
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Net;
using System.Threading;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class ClientAdapter<TClient, THeader> : ClientAdapterBase
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
        /// Get Azure backup client.
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

        public ClientAdapter(Func<string, THeader> headerGenerator, params object[] parameters)
            : base(parameters)
        {
            CustomRequestHeaderGenerator = headerGenerator;
        }

        public THeader GetCustomRequestHeaders()
        {
            return CustomRequestHeaderGenerator(this.ClientRequestId);
        }
    }
}

