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
    /// The list of available upgrades for compute pools.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PSManagedClusterUpgradeProfile
    {
        /// <summary>
        /// Gets id of upgrade profile.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets name of upgrade profile.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets type of upgrade profile.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets or sets the list of available upgrade versions for the control
        /// plane.
        /// </summary>
        public PSManagedClusterPoolUpgradeProfile ControlPlaneProfile { get; set; }

        /// <summary>
        /// Gets or sets the list of available upgrade versions for agent
        /// pools.
        /// </summary>
        public IList<PSManagedClusterPoolUpgradeProfile> AgentPoolProfiles { get; set; }
    }
}
