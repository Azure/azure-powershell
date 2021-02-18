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

namespace Microsoft.Azure.Commands.Aks.Models
{
    /// <summary>
    /// Profile for Windows VMs in the container service cluster.
    /// </summary>
    public partial class PSManagedClusterWindowsProfile
    {
        /// <summary>
        /// Gets or sets the administrator username to use for Windows VMs.
        /// </summary>
        public string AdminUsername { get; set; }

        /// <summary>
        /// Gets or sets the administrator password to use for Windows VMs.
        /// </summary>
        public string AdminPassword { get; set; }
    }
}
