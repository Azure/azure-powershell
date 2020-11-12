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
    public class PSNetAppFilesWeeklySchedule
    {
        /// <summary>
        /// Gets or sets Weekly snapshot count to keep
        /// </summary>
        public int? SnapshotsToKeep { get; set; }

        /// <summary>
        /// Gets or sets which weekdays snapshot should be taken, accepts a comma separated list of week day names in english
        /// </summary>
        public string Day { get; set; }


        /// <summary>
        /// Gets or sets which hour in UTC timezone a snapshot should be taken
        /// </summary>
        public int? Hour { get; set; }

        /// <summary>
        /// Gets or sets which minute snapshot should be taken
        /// </summary>
        public int? Minute { get; set; }

        /// <summary>
        /// Gets resource size in bytes, current storage usage for the volume in bytes
        /// </summary>
        public long? UsedBytes { get; set; }
    }
}