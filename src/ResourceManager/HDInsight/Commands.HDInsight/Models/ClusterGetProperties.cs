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

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    /// <summary>
    /// Describes the properties of a cluster.
    /// </summary>
    public class ClusterGetProperties
    {
        /// <summary>
        /// The cluster definition.
        /// </summary>
        public ClusterDefinition ClusterDefinition { get; set; }

        /// <summary>
        /// The state of the cluster.
        /// </summary>
        public string ClusterState { get; set; }

        /// <summary>
        /// The version of the cluster.
        /// </summary>
        public string ClusterVersion { get; set; }

        /// <summary>
        /// The compute profile.
        /// </summary>
        public ComputeProfile ComputeProfile { get; set; }

        /// <summary>
        /// The list of connectivity endpoints.
        /// </summary>
        public IList<ConnectivityEndpoint> ConnectivityEndpoints { get; set; }

        /// <summary>
        /// The date on which the cluster was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The list of errors.
        /// </summary>
        public IList<ErrorInfo> ErrorInfos { get; set; }

        /// <summary>
        /// The type of operating system.
        /// </summary>
        public string OperatingSystemType { get; set; }

        /// <summary>
        /// The provisioning state, which only appears in the response.
        /// </summary>
        public HDInsightClusterProvisioningState ProvisioningState { get; set; }

        /// <summary>
        /// The quota information.
        /// </summary>
        public QuotaInfo QuotaInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the ClusterGetProperties class.
        /// </summary>
        public ClusterGetProperties()
        {
            this.ConnectivityEndpoints = new List<ConnectivityEndpoint>();
            this.ErrorInfos = new List<ErrorInfo>();
        }

        /// <summary>
        /// Initializes a new instance of the ClusterGetProperties class with
        /// required arguments.
        /// </summary>
        public ClusterGetProperties(ClusterDefinition clusterDefinition)
            : this()
        {
            if (clusterDefinition == null)
            {
                throw new ArgumentNullException("clusterDefinition");
            }
            this.ClusterDefinition = clusterDefinition;
        }
    }
}
