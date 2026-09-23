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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Backup.Model
{
    public class AzureSqlDatabaseLongTermRetentionBackupModel
    {
        /// <summary>
        /// Gets or sets the backup expiration time.
        /// </summary>
        public DateTime? BackupExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        public string BackupName { get; set; }

        /// <summary>
        /// Gets or sets the backup time.
        /// </summary>
        public DateTime? BackupTime { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the database deletion time.
        /// </summary>
        public DateTime? DatabaseDeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the server create time.
        /// </summary>
        public DateTime? ServerCreateTime { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the current backup storage redundancy for the database
        /// </summary>
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the setting for whether or not time-based immutability is
        /// enabled for the LTR backup. When time-based immutability is enabled and
        /// locked, the backup cannot be deleted until BackupExpirationTime. Possible values include: &#39;Enabled&#39;, &#39;Disabled&#39;
        /// </summary>
        public string TimeBasedImmutability { get; set; }

        /// <summary>
        /// Gets or sets the time-based immutability mode. Only applicable if
        /// time-based immutability is enabled. Possible values include: &#39;Locked&#39;, &#39;Unlocked&#39;
        /// </summary>
        public string TimeBasedImmutabilityMode { get; set; }

        /// <summary>
        /// Gets or sets the setting for whether LegalHold is enabled or disabled on
        /// the LTR backup. When LegalHold is enabled, the backup cannot be deleted
        /// until the LegalHold is removed. Possible values include: &#39;Enabled&#39;, &#39;Disabled&#39;
        /// </summary>
        public string LegalHoldImmutability { get; set; }
    }
}
