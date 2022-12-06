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
    /// Access profile for managed cluster API server.
    /// </summary>
    public partial class PSManagedClusterAPIServerAccessProfile
    {
        /// <summary>
        /// Gets or sets authorized IP Ranges to kubernetes API server.
        /// </summary>
        public IList<string> AuthorizedIPRanges { get; set; }

        /// <summary>
        /// Gets or sets whether to create the cluster as a private cluster or
        /// not.
        /// </summary>
        public bool? EnablePrivateCluster { get; set; }

        /// <summary>
        /// Gets or sets the private DNS zone mode for the cluster.
        /// </summary>
        /// <remarks>
        /// The default is System. For more details see [configure private DNS
        /// zone](https://docs.microsoft.com/azure/aks/private-clusters#configure-private-dns-zone).
        /// Allowed values are 'system' and 'none'.
        /// </remarks>
        public string PrivateDNSZone { get; set; }

        /// <summary>
        /// Gets or sets whether to create additional public FQDN for private
        /// cluster or not.
        /// </summary>
        public bool? EnablePrivateClusterPublicFQDN { get; set; }

        /// <summary>
        /// Gets or sets whether to disable run command for the cluster or not.
        /// </summary>
        public bool? DisableRunCommand { get; set; }

    }
}
