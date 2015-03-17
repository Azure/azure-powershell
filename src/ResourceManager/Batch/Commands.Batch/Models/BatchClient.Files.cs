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
        /// Lists the Task files matching the specified filter options
        /// </summary>
        /// <param name="options">The options to use when querying for Task files</param>
        /// <returns>The Task files matching the specified filter options</returns>
        public IEnumerable<PSTaskFile> ListTaskFiles(ListTaskFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if ((string.IsNullOrWhiteSpace(options.WorkItemName) || string.IsNullOrWhiteSpace(options.JobName) || string.IsNullOrWhiteSpace(options.TaskName)) 
                && options.Task == null)
            {
                throw new ArgumentNullException(Resources.GBTF_NoTaskSpecified);
            }

            // Get the single Task file matching the specified name
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
            // List Task files using the specified filter
            else
            {
                string tName = options.Task == null ? options.TaskName : options.Task.Name;
                ODATADetailLevel odata = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    WriteVerbose(string.Format(Resources.GBTF_GetByOData, tName));
                    odata = new ODATADetailLevel(filterClause: options.Filter);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.GBTF_NoFilter, tName));
                }

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
                if (options.MaxCount <= 0)
                {
                    return new PSAsyncEnumerable<PSTaskFile, ITaskFile>(taskFiles, mappingFunction);
                }
                else
                {
                    WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount));
                    return new PSAsyncEnumerable<PSTaskFile, ITaskFile>(taskFiles, mappingFunction).Take(options.MaxCount);   
                }
            }
        }

        /// <summary>
        /// Downloads a Task file to the local machine
        /// </summary>
        /// <param name="options">The download options</param>
        public void DownloadTaskFile(DownloadTaskFileOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if ((string.IsNullOrWhiteSpace(options.WorkItemName) || string.IsNullOrWhiteSpace(options.JobName) || string.IsNullOrWhiteSpace(options.TaskName) 
                || string.IsNullOrWhiteSpace(options.TaskFileName)) && options.TaskFile == null)
            {
                throw new ArgumentNullException(Resources.GBTFC_NoTaskFileSpecified);
            }

            if (string.IsNullOrWhiteSpace(options.DestinationPath))
            {
                throw new ArgumentNullException(Resources.GBTFC_NoDestinationPath);
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

            WriteVerbose(string.Format(Resources.GBTFC_Downloading, taskFile.Name, options.DestinationPath));
            if (options.Stream != null)
            {
                // Used for testing.
                // Don't dispose supplied Stream
                taskFile.CopyToStream(options.Stream, options.AdditionalBehaviors);
            }
            else
            {
                using (FileStream fs = new FileStream(options.DestinationPath, FileMode.Create))
                {
                    taskFile.CopyToStream(fs, options.AdditionalBehaviors);
                }   
            }
        }
    }
}
