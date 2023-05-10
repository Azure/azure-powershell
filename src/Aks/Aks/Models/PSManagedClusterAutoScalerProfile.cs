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
    /// Parameters to be applied to the cluster-autoscaler when enabled.
    /// </summary>
    public partial class PSManagedClusterAutoScalerProfile
    {
        /// <summary>
        /// Gets or sets detects similar node pools and balances the number of nodes between
        /// them.
        /// </summary>
        public string BalanceSimilarNodeGroups { get; set; }

        /// <summary>
        /// Gets or sets the expander to use when scaling up
        /// </summary>
        public string Expander { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of empty nodes that can be deleted at the same
        /// time. This must be a positive integer.
        /// </summary>
        public string MaxEmptyBulkDelete { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of seconds the cluster autoscaler waits for pod
        /// termination when trying to scale down a node.
        /// </summary>
        public string MaxGracefulTerminationSec { get; set; }

        /// <summary>
        /// Gets or sets the maximum time the autoscaler waits for a node to be provisioned.
        /// </summary>
        public string MaxNodeProvisionTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum percentage of unready nodes in the cluster. After this
        /// percentage is exceeded, cluster autoscaler halts operations.
        /// </summary>
        public string MaxTotalUnreadyPercentage { get; set; }

        /// <summary>
        /// Gets or sets ignore unscheduled pods before they're a certain age.
        /// </summary>
        public string NewPodScaleUpDelay { get; set; }

        /// <summary>
        /// Gets or sets the number of allowed unready nodes, irrespective of max-total-unready-percentage.
        /// </summary>
        public string OkTotalUnreadyCount { get; set; }

        /// <summary>
        /// Gets or sets how often cluster is reevaluated for scale up or down.
        /// </summary>
        public string ScanInterval { get; set; }

        /// <summary>
        /// Gets or sets how long after scale up that scale down evaluation resumes
        /// </summary>
        public string ScaleDownDelayAfterAdd { get; set; }

        /// <summary>
        /// Gets or sets how long after node deletion that scale down evaluation resumes.
        /// </summary>
        public string ScaleDownDelayAfterDelete { get; set; }

        /// <summary>
        /// Gets or sets how long after scale down failure that scale down evaluation resumes.
        /// </summary>
        public string ScaleDownDelayAfterFailure { get; set; }

        /// <summary>
        /// Gets or sets how long a node should be unneeded before it is eligible for scale
        /// </summary>
        /// down.
        public string ScaleDownUnneededTime { get; set; }

        /// <summary>
        /// Gets or sets how long an unready node should be unneeded before it is eligible
        /// for scale down
        /// </summary>
        public string ScaleDownUnreadyTime { get; set; }

        /// <summary>
        /// Gets or sets node utilization level, defined as sum of requested resources divided
        /// by capacity, below which a node can be considered for scale down.
        /// </summary>
        public string ScaleDownUtilizationThreshold { get; set; }

        /// <summary>
        /// Gets or sets if cluster autoscaler will skip deleting nodes with pods with local
        /// storage, for example, EmptyDir or HostPath.
        /// </summary>
        public string SkipNodesWithLocalStorage { get; set; }

        /// <summary>
        /// Gets or sets if cluster autoscaler will skip deleting nodes with pods from kube-system
        /// (except for DaemonSet or mirror pods)
        /// </summary>
        public string SkipNodesWithSystemPods { get; set; }

    }
}
