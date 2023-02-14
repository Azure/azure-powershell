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

using Microsoft.Azure.Commands.PowerBI.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Commands.PowerBI.Models
{
    /// <summary>
    /// The base class for all Microsoft Azure PowerBI Embedded Capacities Management cmdlets
    /// </summary>
    public abstract class PowerBICmdletBase : AzureRMCmdlet
    {
        private PowerBIClient powerBIClient;

        /// <summary>
        /// The filesystem request timeout in minutes, which is used for long running upload/download operations
        /// </summary>
        private const int filesystemRequestTimeoutInMinutes = 5;
        public PowerBIClient PowerBIClient
        {
            get
            {
                if (powerBIClient == null)
                {
                    powerBIClient = new PowerBIClient(DefaultProfile.DefaultContext);
                }
                return powerBIClient;
            }

            set { powerBIClient = value; }
        }

        internal static TClient CreateAsClient<TClient>(IAzureContext context, string endpoint, bool parameterizedBaseUri = false) where TClient : ServiceClient<TClient>
        {
            if (context == null)
            {
                throw new ApplicationException(Resources.NoSubscriptionInContext);
            }

            TClient client = AzureSession.Instance.ClientFactory.CreateArmClient<TClient>(context, endpoint);
            return client;
        }
    }
}