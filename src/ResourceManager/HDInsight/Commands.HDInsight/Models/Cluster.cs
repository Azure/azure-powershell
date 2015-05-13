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

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Describes the cluster.
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// Optional. The ETag for the resource
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Optional. The ID of the resource.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Optional. The location of the resource.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Optional. The name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Optional. The properties of the cluster.
        /// </summary>
        public ClusterGetProperties Properties { get; set; }

        /// <summary>
        /// Optional. The resource tags.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Optional. The type of resource.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the Cluster class.
        /// </summary>
        public Cluster()
        {
            this.Tags = new Dictionary<string, string>();
        }
    }
}
