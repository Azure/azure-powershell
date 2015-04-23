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

using System.Linq;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the task files matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for task files</param>
        /// <returns>The task files matching the specified filter options</returns>
        public IEnumerable<PSTaskFile> ListTaskFiles(ListTaskFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single task file matching the specified name
            if (!string.IsNullOrEmpty(options.TaskFileName))
            {
                WriteVerbose(string.Format(Resources.GBTF_GetByName, options.TaskFileName, options.TaskName));
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    ITaskFile taskFile = wiManager.GetTaskFile(options.WorkItemName, options.JobName, options.TaskName, options.TaskFileName, options.AdditionalBehaviors);
                    PSTaskFile psTaskFile = new PSTaskFile(taskFile);
                    return new PSTaskFile[] { psTaskFile };
                }
            }
            // List task files using the specified filter
            else
            {
                string tName = options.Task == null ? options.TaskName : options.Task.Name;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBTF_GetByOData, tName);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBTF_NoFilter, tName);
                }
                WriteVerbose(verboseLogString);

                IEnumerableAsyncExtended<ITaskFile> taskFiles = null;
                if (options.Task != null)
                {
                    taskFiles = options.Task.omObject.ListTaskFiles(options.Recursive, odata, options.AdditionalBehaviors);
                }
                else
                {
                    using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                    {
                        taskFiles = wiManager.ListTaskFiles(options.WorkItemName, options.JobName, options.TaskName, options.Recursive, odata, options.AdditionalBehaviors);
                    }
                }
                Func<ITaskFile, PSTaskFile> mappingFunction = f => { return new PSTaskFile(f); };
                return PSAsyncEnumerable<PSTaskFile, ITaskFile>.CreateWithMaxCount(
                    taskFiles, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Downloads a task file using the specified options.
        /// </summary>
        /// <param name="options">The download options</param>
        public void DownloadTaskFile(DownloadTaskFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            ITaskFile taskFile = null;
            if (options.TaskFile == null)
            {
                using (IWorkItemManager wiManager = options.Context.BatchOMClient.OpenWorkItemManager())
                {
                    taskFile = wiManager.GetTaskFile(options.WorkItemName, options.JobName, options.TaskName, options.TaskFileName, options.AdditionalBehaviors);
                }
            }
            else
            {
                taskFile = options.TaskFile.omObject;
            }

            DownloadITaskFile(taskFile, options.DestinationPath, "task", options.Stream, options.AdditionalBehaviors);
        }

        /// <summary>
        /// Lists the vm files matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for vm files</param>
        /// <returns>The vm files matching the specified filter options</returns>
        public IEnumerable<PSVMFile> ListVMFiles(ListVMFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single vm file matching the specified name
            if (!string.IsNullOrEmpty(options.VMFileName))
            {
                WriteVerbose(string.Format(Resources.GBVMF_GetByName, options.VMFileName, options.VMName));
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    ITaskFile vmFile = poolManager.GetVMFile(options.PoolName, options.VMName, options.VMFileName, options.AdditionalBehaviors);
                    PSVMFile psVMFile = new PSVMFile(vmFile);
                    return new PSVMFile[] { psVMFile };
                }
            }
            // List vm files using the specified filter
            else
            {
                string vmName = options.VM == null ? options.VMName : options.VM.Name;
                ODATADetailLevel odata = null;
                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = string.Format(Resources.GBVMF_GetByOData, vmName);
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    verboseLogString = string.Format(Resources.GBVMF_NoFilter, vmName);
                }
                WriteVerbose(verboseLogString);

                IEnumerableAsyncExtended<ITaskFile> vmFiles = null;
                if (options.VM != null)
                {
                    vmFiles = options.VM.omObject.ListVMFiles(options.Recursive, odata, options.AdditionalBehaviors);
                }
                else
                {
                    using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                    {
                        vmFiles = poolManager.ListVMFiles(options.PoolName, options.VMName, options.Recursive, odata, options.AdditionalBehaviors);
                    }
                }
                Func<ITaskFile, PSVMFile> mappingFunction = f => { return new PSVMFile(f); };
                return PSAsyncEnumerable<PSVMFile, ITaskFile>.CreateWithMaxCount(
                    vmFiles, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Downloads a vm file using the specified options.
        /// </summary>
        /// <param name="options">The download options</param>
        public void DownloadVMFile(DownloadVMFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            ITaskFile vmFile = null;
            if (options.VMFile == null)
            {
                using (IPoolManager poolManager = options.Context.BatchOMClient.OpenPoolManager())
                {
                    vmFile = poolManager.GetVMFile(options.PoolName, options.VMName, options.VMFileName, options.AdditionalBehaviors);
                }
            }
            else
            {
                vmFile = options.VMFile.omObject;
            }

            DownloadITaskFile(vmFile, options.DestinationPath, "vm", options.Stream, options.AdditionalBehaviors);
        }

        /// <summary>
        /// Downloads an RDP file using the specified options.
        /// </summary>
        /// <param name="options">The download options</param>
        public void DownloadRDPFile(DownloadRDPFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (options.Stream != null)
            {
                // Don't dispose supplied Stream
                CopyRDPStream(options.Stream, options.Context.BatchOMClient, options.PoolName, options.VMName, options.VM, options.AdditionalBehaviors);
            }
            else
            {
                string vmName = options.VM == null ? options.VMName : options.VM.Name;
                string verboseLogFileName = string.Format("for vm {0}", vmName);
                WriteVerbose(string.Format(Resources.Downloading, "RDP", verboseLogFileName, options.DestinationPath));

                using (FileStream fs = new FileStream(options.DestinationPath, FileMode.Create))
                {
                    CopyRDPStream(fs, options.Context.BatchOMClient, options.PoolName, options.VMName, options.VM, options.AdditionalBehaviors);
                }
            }
        }

        private void CopyRDPStream(Stream destinationStream, IBatchClient client, string poolName, string vmName,
            PSVM vm, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (vm == null)
            {
                using (IPoolManager poolManager = client.OpenPoolManager())
                {
                    poolManager.GetRDPFile(poolName, vmName, destinationStream, additionalBehaviors);
                }
            }
            else
            {
                vm.omObject.GetRDPFile(destinationStream, additionalBehaviors);
            }
        }

        // Downloads the file represented by an ITaskFile instance to the specified path
        private void DownloadITaskFile(ITaskFile file, string destinationPath, string loggingFileType, Stream stream = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            if (stream != null)
            {
                // Don't dispose supplied Stream
                file.CopyToStream(stream, additionalBehaviors);
            }
            else
            {
                WriteVerbose(string.Format(Resources.Downloading, loggingFileType, file.Name, destinationPath));
                using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
                {
                    file.CopyToStream(fs, additionalBehaviors);
                }
            }
        }
    }
}
