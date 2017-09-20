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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Autobackup settings to configure managed backup on SQL VM
    /// </summary>
    public class AutoBackupSettings
    {
        /// <summary>
        /// Defines if the Auto-backup feature is enabled or disabled
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// Defines if backups will be encrypted or not
        /// </summary>
        public bool EnableEncryption { get; set; }

        /// <summary>
        /// Defines the number of days to keep the backups
        /// </summary>
        public int RetentionPeriod { get; set; }

        /// <summary>
        /// storage url where databases will be backed up
        /// </summary>
        [JsonIgnoreAttribute()]
        public string StorageUrl { get; set; }

        /// <summary>
        /// Key of storage account used by managed backup
        /// </summary>
        [JsonIgnoreAttribute()]
        public string StorageAccessKey { get; set; }

        /// <summary>
        /// Password required for certification when encryption is enabled
        /// </summary>
        [JsonIgnoreAttribute()]
        public string Password { get; set; }
    }
}
