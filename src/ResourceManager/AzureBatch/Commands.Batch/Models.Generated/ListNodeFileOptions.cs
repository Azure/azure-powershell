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
    public class ListNodeFileOptions : BatchClientParametersBase
    {
        public ListNodeFileOptions(BatchAccountContext context, string jobId, string taskId, PSCloudTask task, string poolId, string computeNodeId, PSComputeNode computeNode,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if ((!string.IsNullOrWhiteSpace(jobId) && !string.IsNullOrWhiteSpace(taskId)) || task != null)
            {
                this.NodeFileType = PSNodeFileType.Task;
            }
            else if ((!string.IsNullOrWhiteSpace(poolId) && !string.IsNullOrWhiteSpace(computeNodeId)) || computeNode != null)
            {
                this.NodeFileType = PSNodeFileType.ComputeNode;
            }
            else
            {
                throw new ArgumentException(Resources.NoNodeFileParent);
            }

            this.JobId = jobId;
            this.TaskId = taskId;
            this.Task = task;
            this.PoolId = poolId;
            this.ComputeNodeId = computeNodeId;
            this.ComputeNode = computeNode;
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
        /// The PSCloudTask object representing the target task.
        /// </summary>
        public PSCloudTask Task { get; private set; }

        /// <summary>
        /// The id of the pool containing the compute node.
        /// </summary>
        public string PoolId { get; private set; }

        /// <summary>
        /// The id of the compute node
        /// </summary>
        public string ComputeNodeId { get; private set; }

        /// <summary>
        /// The PSComputeNode object representing the target compute node.
        /// </summary>
        public PSComputeNode ComputeNode { get; private set; }

        /// <summary>
        /// If specified, the single node file with this name will be returned.
        /// </summary>
        public string NodeFileName { get; set; }

        /// <summary>
        /// The OData filter to use when querying for node files.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// The maximum number of node files to return.
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// If true, performs a recursive list of all files of the task. If false, returns only the files at the task directory root.
        /// </summary>
        public bool Recursive { get; set; }

        /// <summary>
        /// Whether the node file is associated with a task or a compute node
        /// </summary>
        internal PSNodeFileType NodeFileType { get; private set; }
    }
}
