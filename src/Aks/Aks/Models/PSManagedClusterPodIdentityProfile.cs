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
    /// The pod identity profile of the Managed Cluster.
    /// </summary>
    public partial class PSManagedClusterPodIdentityProfile
    {
        /// <summary>
        /// Gets or sets whether the pod identity addon is enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets or sets whether pod identity is allowed to run on clusters with Kubenet
        /// networking.
        /// </summary>
        public bool? AllowNetworkPluginKubenet { get; set; }

        /// <summary>
        /// Gets or sets the pod identities to use in the cluster.
        /// </summary>
        public IList<PSManagedClusterPodIdentity> UserAssignedIdentities { get; set; }

        /// <summary>
        /// Gets or sets the pod identity exceptions to allow.
        /// </summary>
        public IList<PSManagedClusterPodIdentityException> UserAssignedIdentityExceptions { get; set; }

    }
}
