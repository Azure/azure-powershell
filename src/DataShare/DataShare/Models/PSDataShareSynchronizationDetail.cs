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

namespace Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models
{
    using System;
    using System.Collections;

    public class PSDataShareSynchronizationDetail
    {
        public string DataSetId { get; set; }
        public string DataSetType { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string Status { get; set; }
        public int? DurationMs { get; set; }
        public long? FilesRead { get; set; }
        public long? FilesWritten { get; set; }
        public long? SizeRead { get; set; }
        public long? SizeWritten { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
