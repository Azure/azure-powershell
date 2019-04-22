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
using System.Security;

namespace Microsoft.Azure.Commands.Sql.VirtualCluster.Model
{
    /// <summary>
    /// Represents the core properties of a Virtual Cluster
    /// </summary>
    public class AzureSqlVirtualClusterModel
    {
        /// <summary>
        /// Gets or sets the location the virtual cluster is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Virtual Cluster
        /// </summary>
        public string VirtualClusterName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the managed instance.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets subnet resource ID for the Virtual Cluster.
        /// </summary>
        public string SubnetId { get; set; }
    }
}
