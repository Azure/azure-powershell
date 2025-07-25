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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Details about the pod identity assigned to the Managed Cluster.
    /// </summary>
    public partial class PSManagedClusterPodIdentity
    {
        /// <summary>
        /// Gets or sets the name of the pod identity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the namespace of the pod identity.
        /// </summary>
        public string NamespaceProperty { get; set; }

        /// <summary>
        /// Gets or sets the binding selector to use for the AzureIdentityBinding resource.
        /// </summary>
        public string BindingSelector { get; set; }

        /// <summary>
        /// Gets or sets the user assigned identity details.
        /// </summary>
        public PSManagedClusterPodIdentityProfileUserAssignedIdentity Identity { get; set; }

        /// <summary>
        /// Gets the current provisioning state of the pod identity. Possible values include:
        /// 'Assigned', 'Updating', 'Deleting', 'Failed'
        /// </summary>
        public string ProvisioningState { get; private set; }

        public PSManagedClusterPodIdentityProvisioningInfo ProvisioningInfo { get; private set; }
    }
}
