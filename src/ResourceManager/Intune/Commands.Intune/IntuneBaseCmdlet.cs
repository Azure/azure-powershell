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
namespace Microsoft.Azure.Commands.Intune
{
    using System;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Common.Authentication;
    using System.Collections.Concurrent;
    using System.Management.Automation;
    using Management.Intune;

    /// <summary>
    /// Base class for all commandlets. Helps create an instance of the client that commandlets can leverage. 
    /// </summary>
    public abstract class IntuneBaseCmdlet: AzureRMCmdlet
    {
        /// <summary>
        /// Contains the errors that encountered while satisfying the request.
        /// </summary>
        internal static readonly ConcurrentBag<ErrorRecord> errors = new ConcurrentBag<ErrorRecord>();

        private static IntuneResourceManagementClient intuneClient;

        /// <summary>
        /// The default parameter set.
        /// </summary>
        internal const string DefaultParameterSet = "Default Parameter Set for Intune MAM Policy cmdlets.";

        internal IntuneResourceManagementClient IntuneClient
        {
            get
            {
                if(intuneClient == null)
                {
                    intuneClient = GetIntuneManagementClient(this.DefaultContext);
                }
                return intuneClient;
            }
        }

        /// <summary>
        /// ASU host name for the tenant
        /// </summary>
        private static string asuHostName;
        internal string AsuHostName
        {
            get
            {
                if (asuHostName == null)
                {
                    var location = IntuneClient.GetLocationByHostName();
                    asuHostName = location.HostName;                    
                }

                return asuHostName;
            }
        }
        /// <summary>
        /// Gets a new instance of the <see cref="IntuneResourceManagementClient"/>.
        /// </summary>
        /// <param name="context">The azure profile.</param>
        internal static IntuneResourceManagementClient GetIntuneManagementClient(AzureContext context)
        {
            var endpoint = context.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ApplicationException(
                    "The endpoint for the Azure Resource Manager service is not set. Please report this issue via GitHub or contact Microsoft customer support.");
            }

            var endpointUri = new Uri(endpoint, UriKind.Absolute);
            var intuneClient  = AzureSession.ClientFactory.CreateArmClient<IntuneResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            intuneClient.BaseUri = endpointUri;
            return intuneClient;
        }
    }
}
