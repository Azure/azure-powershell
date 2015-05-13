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

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Describes a role on the cluster.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// The hardware profile.
        /// </summary>
        public HardwareProfile HardwareProfile { get; set; }

        /// <summary>
        /// The minimum instance count required to mark the cluster operational.
        /// </summary>
        public int? MinInstanceCount { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The operating system profile.
        /// </summary>
        public OsProfile OsProfile { get; set; }

        /// <summary>
        /// The instance count of the cluster.
        /// </summary>
        public int TargetInstanceCount { get; set; }

        /// <summary>
        /// The virtual network profile.
        /// </summary>
        public VirtualNetworkProfile VirtualNetworkProfile { get; set; }

        /// <summary>
        /// Initializes a new instance of the Role class.
        /// </summary>
        public Role()
        {
        }
    }
}
