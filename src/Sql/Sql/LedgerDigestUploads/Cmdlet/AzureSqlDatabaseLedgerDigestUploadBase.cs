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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Services;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Cmdlet
{
    public class AzureSqlDatabaseLedgerDigestUploadBase : AzureSqlDatabaseCmdletBase<AzureSqlDatabaseLedgerDigestUploadModel, AzureSqlDatabaseLedgerDigestUploadAdapter>
    {
        /// <summary>
        /// Parameter set name for named resources
        /// </summary>
        protected const string DatabaseSet = "DatabaseParameterSet";

        /// <summary>
        /// Parameter set name for database object
        /// </summary>
        private const string InputObjectSet = "InputObjectParameterSet";

        /// <summary>
        /// Parameter set name for resource ID
        /// </summary>
        private const string ResourceIdSet = "ResourceIdParameterSet";

        [Parameter(
            ParameterSetName = DatabaseSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql server to use
        /// </summary>
        [Parameter(
            ParameterSetName = DatabaseSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "SQL server name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(
            ParameterSetName = DatabaseSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "SQL Database name.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public override string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get the ledger digest upload configuration for
        /// </summary>
        [Parameter(
            ParameterSetName = InputObjectSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The database object to disable digest uploads for.")]
        [ValidateNotNull]
        public AzureSqlDatabaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database Resource ID to get the ledger digest upload configuration for
        /// </summary>
        [Parameter(
            ParameterSetName = ResourceIdSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the database to disable digest uploads for.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        protected override AzureSqlDatabaseLedgerDigestUploadModel GetEntity()
        {
            if (ParameterSetName == ResourceIdSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                DatabaseName = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
                ServerName = identifier.ParentResource.Split('/')[1];
            }
            else if (ParameterSetName == InputObjectSet)
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
            }

            AzureSqlDatabaseLedgerDigestUploadModel model = ModelAdapter.GetLedgerDigestUpload(ResourceGroupName, ServerName, DatabaseName);

            return model;
        }

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
