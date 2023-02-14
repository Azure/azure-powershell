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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    /// <summary>
    /// ARM tracked resource
    /// </summary>
    public class PSNetAppFilesMonthlySchedule
    {
        /// <summary>
        /// Gets or sets Monthly snapshot count to keep
        /// </summary>
        public int? SnapshotsToKeep { get; set; }
        
        ///
        /// Summary:
        ///     Gets or sets indicates which days of the month snapshot should be taken. A comma
        ///     delimited string.        
        public string DaysOfMonth { get; set; }

        ///
        /// Summary:
        ///     Gets or sets indicates which hour in UTC timezone a snapshot should be taken
        public int? Hour { get; set; }
        
        /// <summary>
        /// 
        /// </summary>        
        ///     Gets or sets indicates which minute snapshot should be taken        
        public int? Minute { get; set; }
        
        /// <summary>
        /// Gets resource size in bytes, current storage usage for the volume in bytes
        /// </summary>
        public long? UsedBytes { get; set; }
    }
}