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

using System.IO;
using Microsoft.Azure.Batch;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class DownloadTaskFileOptions : BatchClientParametersBase
    {
        /// <summary>
        /// The name of the WorkItem
        /// </summary>
        public string WorkItemName { get; set; }

        /// <summary>
        /// The name of the Job
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// The name of the Task
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// The name of the Task file to download
        /// </summary>
        public string TaskFileName { get; set; }

        /// <summary>
        /// The Task file to download
        /// </summary>
        public PSTaskFile TaskFile { get; set; }

        /// <summary>
        /// The path to the directory where the Task file will be downloaded
        /// </summary>
        public string DestinationPath { get; set; }

        /// <summary>
        /// The Stream into which the task file data will be written. This stream will not be closed or rewound by this call.
        /// </summary>
        internal Stream Stream { get; set; }
    }
}
