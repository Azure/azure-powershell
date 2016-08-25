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
using System.IO;
using NodeFile = Microsoft.Azure.Batch.NodeFile;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the node files matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for node files.</param>
        /// <returns>The node files matching the specified filter options.</returns>
        public IEnumerable<PSNodeFile> ListNodeFiles(ListNodeFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            switch (options.NodeFileType)
            {
                case PSNodeFileType.Task:
                    {
                        return ListNodeFilesByTask(options);
                    }
                case PSNodeFileType.ComputeNode:
                    {
                        return ListNodeFilesByComputeNode(options);
                    }
                default:
                    {
                        throw new ArgumentException(Resources.NoNodeFileParent);
                    }
            }
        }

        // Lists the node files under a task.
        private IEnumerable<PSNodeFile> ListNodeFilesByTask(ListNodeFileOptions options)
        {
            // Get the single node file matching the specified name
            if (!string.IsNullOrEmpty(options.NodeFileName))
            {
                WriteVerbose(string.Format(Resources.GetNodeFileByTaskByName, options.NodeFileName, options.TaskId));
                JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                NodeFile nodeFile = jobOperations.GetNodeFile(options.JobId, options.TaskId, options.NodeFileName, options.AdditionalBehaviors);
                PSNodeFile psNodeFile = new PSNodeFile(nodeFile);
                return new PSNodeFile[] { psNodeFile };
            }
            // List node files using the specified filter
            else
            {
                string taskId = options.Task == null ? options.TaskId : options.Task.Id;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GetNodeFileByTaskByOData, taskId);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GetNodeFileByTaskNoFilter, taskId);
                }
                WriteVerbose(verboseLogString);

                IPagedEnumerable<NodeFile> nodeFiles = null;
                if (options.Task != null)
                {
                    nodeFiles = options.Task.omObject.ListNodeFiles(options.Recursive, odata, options.AdditionalBehaviors);
                }
                else
                {
                    JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                    nodeFiles = jobOperations.ListNodeFiles(options.JobId, options.TaskId, options.Recursive, odata, options.AdditionalBehaviors);
                }
                Func<NodeFile, PSNodeFile> mappingFunction = f => { return new PSNodeFile(f); };
                return PSPagedEnumerable<PSNodeFile, NodeFile>.CreateWithMaxCount(
                    nodeFiles, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        // Lists the node files under a compute node.
        private IEnumerable<PSNodeFile> ListNodeFilesByComputeNode(ListNodeFileOptions options)
        {
            // Get the single node file matching the specified name
            if (!string.IsNullOrEmpty(options.NodeFileName))
            {
                WriteVerbose(string.Format(Resources.GetNodeFileByComputeNodeByName, options.NodeFileName, options.ComputeNodeId));
                PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                NodeFile nodeFile = poolOperations.GetNodeFile(options.PoolId, options.ComputeNodeId, options.NodeFileName, options.AdditionalBehaviors);
                PSNodeFile psNodeFile = new PSNodeFile(nodeFile);
                return new PSNodeFile[] { psNodeFile };
            }
            // List node files using the specified filter
            else
            {
                string computeNodeId = options.ComputeNode == null ? options.ComputeNodeId : options.ComputeNode.Id;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GetNodeFileByComputeNodeByOData, computeNodeId);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GetNodeFileByComputeNodeNoFilter, computeNodeId);
                }
                WriteVerbose(verboseLogString);

                IPagedEnumerable<NodeFile> nodeFiles = null;
                if (options.ComputeNode != null)
                {
                    nodeFiles = options.ComputeNode.omObject.ListNodeFiles(options.Recursive, odata, options.AdditionalBehaviors);
                }
                else
                {
                    PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                    nodeFiles = poolOperations.ListNodeFiles(options.PoolId, options.ComputeNodeId, options.Recursive, odata, options.AdditionalBehaviors);
                }
                Func<NodeFile, PSNodeFile> mappingFunction = f => { return new PSNodeFile(f); };
                return PSPagedEnumerable<PSNodeFile, NodeFile>.CreateWithMaxCount(
                    nodeFiles, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Deletes the specified file from its compute node.
        /// </summary>
        /// <param name="recursive">If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail..</param>
        /// <param name="parameters">Specifies which node file to delete.</param>
        public void DeleteNodeFile(bool? recursive, NodeFileOperationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            switch (parameters.NodeFileType)
            {
                case PSNodeFileType.Task:
                    {
                        JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
                        jobOperations.DeleteNodeFile(parameters.JobId, parameters.TaskId, parameters.NodeFileName, recursive: recursive, additionalBehaviors: parameters.AdditionalBehaviors);
                        break;
                    }
                case PSNodeFileType.ComputeNode:
                    {
                        PoolOperations poolOperations = parameters.Context.BatchOMClient.PoolOperations;
                        poolOperations.DeleteNodeFile(parameters.PoolId, parameters.ComputeNodeId, parameters.NodeFileName, recursive: recursive, additionalBehaviors: parameters.AdditionalBehaviors);
                        break;
                    }
                case PSNodeFileType.PSNodeFileInstance:
                    {
                        parameters.NodeFile.omObject.Delete(recursive: recursive, additionalBehaviors: parameters.AdditionalBehaviors);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(Resources.NoNodeFile);
                    }
            }
        }

        /// <summary>
        /// Downloads a node file using the specified options.
        /// </summary>
        /// <param name="options">The download options.</param>
        public void DownloadNodeFile(DownloadNodeFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            NodeFile nodeFile = null;
            switch (options.NodeFileType)
            {
                case PSNodeFileType.Task:
                    {
                        JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                        nodeFile = jobOperations.GetNodeFile(options.JobId, options.TaskId, options.NodeFileName, options.AdditionalBehaviors);
                        break;
                    }
                case PSNodeFileType.ComputeNode:
                    {
                        PoolOperations poolOperations = options.Context.BatchOMClient.PoolOperations;
                        nodeFile = poolOperations.GetNodeFile(options.PoolId, options.ComputeNodeId, options.NodeFileName, options.AdditionalBehaviors);
                        break;
                    }
                case PSNodeFileType.PSNodeFileInstance:
                    {
                        nodeFile = options.NodeFile.omObject;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(Resources.NoNodeFile);
                    }
            }

            DownloadNodeFileByInstance(nodeFile, options.DestinationPath, options.Stream, options.AdditionalBehaviors);
        }

        // Downloads the file represented by an NodeFile instance to the specified path.
        private void DownloadNodeFileByInstance(NodeFile file, string destinationPath, Stream stream, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (stream != null)
            {
                // Don't dispose supplied Stream
                file.CopyToStream(stream, additionalBehaviors);
            }
            else
            {
                WriteVerbose(string.Format(Resources.DownloadingNodeFile, file.Name, destinationPath));
                using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
                {
                    file.CopyToStream(fs, additionalBehaviors);
                }
            }
        }

        /// <summary>
        /// Downloads a Remote Desktop Protocol file using the specified options.
        /// </summary>
        /// <param name="options">The download options.</param>
        public void DownloadRemoteDesktopProtocolFile(DownloadRemoteDesktopProtocolFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (options.Stream != null)
            {
                // Don't dispose supplied Stream
                CopyRDPStream(options.Stream, options.Context.BatchOMClient, options.PoolId, options.ComputeNodeId, options.ComputeNode, options.AdditionalBehaviors);
            }
            else
            {
                string computeNodeId = options.ComputeNode == null ? options.ComputeNodeId : options.ComputeNode.Id;
                WriteVerbose(string.Format(Resources.DownloadingRDPFile, computeNodeId, options.DestinationPath));

                using (FileStream fs = new FileStream(options.DestinationPath, FileMode.Create))
                {
                    CopyRDPStream(fs, options.Context.BatchOMClient, options.PoolId, options.ComputeNodeId, options.ComputeNode, options.AdditionalBehaviors);
                }
            }
        }

        private void CopyRDPStream(Stream destinationStream, Microsoft.Azure.Batch.BatchClient client, string poolId, string computeNodeId,
            PSComputeNode computeNode, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (computeNode == null)
            {
                PoolOperations poolOperations = client.PoolOperations;
                poolOperations.GetRDPFile(poolId, computeNodeId, destinationStream, additionalBehaviors);
            }
            else
            {
                computeNode.omObject.GetRDPFile(destinationStream, additionalBehaviors);
            }
        }
    }
}
