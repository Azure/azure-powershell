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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesRansomwareReport
    {
        /// <summary>
        /// Gets the resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the resource name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the creation date and time of the report
        /// </summary>
        public DateTime? EventTime { get; set; }

        /// <summary>
        /// Gets state of the ARP report. Possible values include: 'Active', 'Resolved'
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets severity of the ARP report. Possible values include: 'None', 'Low', 'Moderate', 'High'
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Gets the number of cleared suspects identified by the ARP report
        /// </summary>
        public int? ClearedCount { get; set; }

        /// <summary>
        /// Gets the number of suspects identified by the ARP report
        /// </summary>
        public int? ReportedCount { get; set; }

        /// <summary>
        /// Gets suspects identified in the ARP report
        /// </summary>
        public IList<PSNetAppFilesRansomwareSuspect> Suspects { get; set; }

        /// <summary>
        /// Gets Azure lifecycle management
        /// </summary>
        public string ProvisioningState { get; set; }
    }

    public class PSNetAppFilesRansomwareSuspect
    {
        /// <summary>
        /// Gets suspect file extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets ARP report suspect resolution. Possible values include: 'PotentialThreat', 'FalsePositive'
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// Gets the number of suspect files
        /// </summary>
        public int? FileCount { get; set; }

        /// <summary>
        /// Gets suspect files
        /// </summary>
        public IList<PSNetAppFilesRansomwareSuspectFile> SuspectFiles { get; set; }
    }

    public class PSNetAppFilesRansomwareSuspectFile
    {
        /// <summary>
        /// Gets suspect filename
        /// </summary>
        public string SuspectFileName { get; set; }

        /// <summary>
        /// Gets the creation date and time of the file
        /// </summary>
        public DateTime? FileTimestamp { get; set; }
    }
}
