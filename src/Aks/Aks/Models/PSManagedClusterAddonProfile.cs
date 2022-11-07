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

using Microsoft.Azure.Management.ContainerService.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// A Kubernetes add-on profile for a managed cluster.
    /// </summary>
    public partial class PSManagedClusterAddonProfile
    {
        /// <summary>
        /// Gets or sets whether the add-on is enabled or not.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets key-value pairs for configuring an add-on.
        /// </summary>
        public IDictionary<string, string> Config { get; set; }

        /// <summary>
        /// Gets information of user assigned identity used by this add-on.
        /// </summary>
        public ManagedClusterAddonProfileIdentity Identity { get; private set; }
    }
}
