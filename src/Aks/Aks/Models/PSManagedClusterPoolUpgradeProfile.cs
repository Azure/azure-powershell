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
    /// The list of available upgrade versions.
    /// </summary>
    public partial class PSManagedClusterPoolUpgradeProfile
    {
        /// <summary>
        /// Gets or sets kubernetes version (major, minor, patch).
        /// </summary>
        public string KubernetesVersion { get; set; }

        /// <summary>
        /// Gets or sets pool name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets osType to be used to specify os type. Choose from
        /// Linux and Windows. Default to Linux. Possible values include:
        /// 'Linux', 'Windows'
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets list of orchestrator types and versions available for
        /// upgrade.
        /// </summary>
        public IList<PSManagedClusterPoolUpgradeProfileUpgradesItem> Upgrades { get; set; }

    }
}
