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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    public abstract class AzureSqlDeletedDatabaseBackupCmdletBase
        : AzureSqlCmdletBase<IEnumerable<AzureSqlDeletedDatabaseBackupModel>, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the database is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to retrieve backups for.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the database to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The deletion date of the Azure SQL Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)")]
        [ValidateNotNullOrEmpty]
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">The subscription to operate on</param>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.Context);
        }
    }
}
