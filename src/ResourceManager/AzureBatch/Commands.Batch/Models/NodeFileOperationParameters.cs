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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    internal enum PSNodeFileType
    {
        PSNodeFileInstance,
        Task,
        ComputeNode
    }

    public class NodeFileOperationParameters : BatchClientParametersBase
    {
        public NodeFileOperationParameters(BatchAccountContext context, string jobId, string taskId, string poolId, string computeNodeId, string nodeFileName,
            PSNodeFile nodeFile, IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            PSNodeFileType? nodeFileType = null;

            if (nodeFile != null)
            {
                nodeFileType = PSNodeFileType.PSNodeFileInstance;
            }
            else if (!string.IsNullOrWhiteSpace(nodeFileName))
            {
                if (!string.IsNullOrWhiteSpace(jobId) && !string.IsNullOrWhiteSpace(taskId))
                {
                    nodeFileType = PSNodeFileType.Task;
                }
                else if (!string.IsNullOrWhiteSpace(poolId) && !string.IsNullOrWhiteSpace(computeNodeId))
                {
                    nodeFileType = PSNodeFileType.ComputeNode;
                }
            }

            if (nodeFileType == null)
            {
                throw new ArgumentException(Resources.NoNodeFile);
            }
            this.NodeFileType = nodeFileType.Value;

            this.JobId = jobId;
            this.TaskId = taskId;
            this.PoolId = poolId;
            this.ComputeNodeId = computeNodeId;
            this.NodeFileName = nodeFileName;
            this.NodeFile = nodeFile;
        }

        /// <summary>
        /// The id of the job containing the task.
        /// </summary>
        public string JobId { get; private set; }

        /// <summary>
        /// The id of the task.
        /// </summary>
        public string TaskId { get; private set; }

        /// <summary>
        /// The id of the pool containing the compute node.
        /// </summary>
        public string PoolId { get; private set; }

        /// <summary>
        /// The id of the compute node.
        /// </summary>
        public string ComputeNodeId { get; private set; }

        /// <summary>
        /// The name of the node file
        /// </summary>
        public string NodeFileName { get; private set; }

        /// <summary>
        /// The PSNodeFile object representing the target node file.
        /// </summary>
        public PSNodeFile NodeFile { get; private set; }

        /// <summary>
        /// Whether the node file is associated with a task, a compute node, or a PSNodeFile instance.
        /// </summary>
        internal PSNodeFileType NodeFileType { get; private set; }
    }
}
