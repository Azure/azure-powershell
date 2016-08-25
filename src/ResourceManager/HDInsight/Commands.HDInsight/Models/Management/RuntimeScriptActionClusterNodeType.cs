using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    /// <summary>
    /// Enum specifically used for Runtime Script Actions
    /// Crud time script actions use ClusterNodeType
    /// </summary>
    public enum RuntimeScriptActionClusterNodeType
    {
        /// <summary>
        /// The head nodes of the cluster.
        /// </summary>
        HeadNode,

        /// <summary>
        /// The worker nodes of the cluster.
        /// </summary>
        WorkerNode,

        /// <summary>
        /// The zookeper nodes of the cluster.
        /// </summary>
        ZookeeperNode,

        /// <summary>
        /// The edge nodes of the cluster.
        /// </summary>
        EdgeNode
    }
}
