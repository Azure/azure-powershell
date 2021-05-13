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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Services;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Cmdlet
{
    public abstract class AzureSqlDatabaseLedgerDigestUploadBase : AzureSqlCmdletBase<IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel>, AzureSqlDatabaseLedgerDigestUploadAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql server to use
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The Azure Sql Server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get the ledger digest upload configuration for
        /// </summary>
        [Parameter(
            ParameterSetName = "DatabaseObjectParameterSet",
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The database object to manage its ledger digest upload configuration.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureSqlDatabase")]
        public AzureSqlDatabaseModel AzureSqlDatabaseObject { get; set; }

        /// <summary>
        /// Gets or sets the Database Resource ID to get backups for
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The database Resource ID to get backups for.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected override AzureSqlDatabaseLedgerDigestUploadAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseLedgerDigestUploadAdapter(DefaultProfile.DefaultContext);
        }
    }
}
