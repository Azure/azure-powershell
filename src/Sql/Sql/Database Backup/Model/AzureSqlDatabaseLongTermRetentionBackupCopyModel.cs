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
    public class AzureSqlDatabaseLongTermRetentionBackupCopyModel
    {
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string SourceResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the location name.
        /// </summary>
        public string SourceLocation { get; set; }

        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        public string SourceServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string SourceDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        public string SourceBackupName { get; set; }

        /// <summary>
        /// Gets or sets the source backup resource ID.
        /// </summary>
        public string SourceBackupResourceId { get; set; }

        /// <summary>
        /// Gets or sets the source backup's backup storage redundancy.
        /// </summary>
        public string SourceBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the target subscription ID.
        /// </summary>
        public string TargetSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the target resource group name.
        /// </summary>
        public string TargetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the target location name.
        /// </summary>
        public string TargetLocation { get; set; }

        /// <summary>
        /// Gets or sets the target server name.
        /// </summary>
        public string TargetServerName { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified domain name of the target server.
        /// </summary>
        public string TargetServerFullyQualifiedDomainName { get; set; }

        /// <summary>
        /// Gets or sets the target server resource id.
        /// </summary>
        public string TargetServerResourceId { get; set; }

        /// <summary>
        /// Gets or sets the target database name.
        /// </summary>
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the backup name.
        /// </summary>
        public string TargetBackupName { get; set; }

        /// <summary>
        /// Gets or sets the target backup resource ID.
        /// </summary>
        public string TargetBackupResourceId { get; set; }
    }
}
