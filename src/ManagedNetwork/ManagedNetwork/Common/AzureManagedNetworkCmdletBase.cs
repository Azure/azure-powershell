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
using System.Collections.Generic;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.ManagedNetwork;

namespace Microsoft.Azure.Commands.ManagedNetwork.Common
{
    /// <summary>
    /// Base class of Azure ManagedNetwork Cmdlet.
    /// </summary>
    public class AzureManagedNetworkCmdletBase : AzureRMCmdlet
    {
        private IManagedNetworkManagementClient _managedNetworkManagementClient;

        private Dictionary<string, List<string>> _defaultRequestHeaders;

        /// <summary>
        /// Gets or sets the ManagedNetwork management client.
        /// </summary>
        public IManagedNetworkManagementClient ManagedNetworkManagementClient
        {
            get
            {
                return _managedNetworkManagementClient ??
                       (_managedNetworkManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<ManagedNetworkManagementClient>(DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _managedNetworkManagementClient = value; }
        }

        /// <summary>
        /// Gets or sets the default headers send with rest requests.
        /// </summary>
        public Dictionary<string, List<string>> DefaultRequestHeaders
        {
            get
            {
                return _defaultRequestHeaders ??
                       (_defaultRequestHeaders =
                           new Dictionary<string, List<string>> { { "UserAgent", new List<string> { "PowerShell" } } });
            }
            set { _defaultRequestHeaders = value; }
        }

        public bool IsManagedNetworkPresent(string resourceGroupName, string managedNetworkName)
        {
            try
            {
                ManagedNetworkManagementClient.ManagedNetworks.Get(resourceGroupName, managedNetworkName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsManagedNetworkGroupPresent(string resourceGroupName, string managedNetworkName, string managedNetworkGroupName)
        {
            try
            {
                ManagedNetworkManagementClient.ManagedNetworkGroups.Get(resourceGroupName, managedNetworkName, managedNetworkGroupName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsManagedNetworkPeeringPolicyPresent(string resourceGroupName, string managedNetworkName, string managedNetworkPeeringPolicyName)
        {
            try
            {
                ManagedNetworkManagementClient.ManagedNetworkPeeringPolicies.Get(resourceGroupName, managedNetworkName, managedNetworkPeeringPolicyName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            Execute();
        }
        public virtual void Execute()
        {
        }
    }
}