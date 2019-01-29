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
using Microsoft.Azure.Commands.Sql.Backup.Services;
using Microsoft.Azure.Commands.Sql.Common;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    public abstract class AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>, AzureSqlDatabaseBackupAdapter>
    {
        /// <summary>
        /// The expected number of segments in a short term retention policy resource id.
        /// </summary>
        private const int BackupShortTermRetentionPolicyResourceIdSegmentsLength = 12;

        /// <summary>
        /// Parameter set with ResourceGroup name, Server name and Database name.
        /// </summary>
        protected const string PolicyByResourceServerDatabaseSet = "PolicyByResourceServerDatabaseSet";

        /// <summary>
        /// Parameter set for using a Database Input Object.
        /// </summary>
        private const string PolicyByInputObjectSet = "PolicyByInputObjectSet";

        /// <summary>
        /// Parameter set for using a resource Id.
        /// </summary>
        private const string PolicyByResourceIdSet = "PolicyByResourceIdSet";

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByInputObjectSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The database object to get the policy for.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureSqlDatabase")]
        public AzureSqlDatabaseModel AzureSqlDatabaseObject { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceIdSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The short term retention policy resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server the database is in.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to use.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlDatabaseBackupAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseBackupAdapter(DefaultProfile.DefaultContext);
        }

        public override void ExecuteCmdlet()
        {
            if (AzureSqlDatabaseObject != null)
            {
                this.ResourceGroupName = AzureSqlDatabaseObject.ResourceGroupName;
                this.ServerName = AzureSqlDatabaseObject.ServerName;
                this.DatabaseName = AzureSqlDatabaseObject.DatabaseName;
            }
            else if (!string.IsNullOrEmpty(ResourceId))
            {
                ParseResourceId();
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Helper method to parse resourceGroupName, serverName, databaseName from resourceId
        /// Ideally this would utilize Microsoft.Azure.Management.Internal.Resources.Utilities.Models.ResourceIdentifier
        /// However, that class is not setup to handle resources that have an ancestry higher than just parent level.
        /// That class could recursively create a parent ResourceIdentifier on a __get__ ParentResource,
        /// rather than just a string, so a consumer could work all the way to the root resource easily.
        /// Leave as a TODO for now, as many other cmdlets consume that class, and I will work on it in separate change.
        /// </summary>
        private void ParseResourceId()
        {
            string[] tokens = ResourceId.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            // "/subscriptions/<subId>/resourceGroups/<resourceGroup>/providers/Microsoft.Sql/servers/<server>/databases/<database>/backupShortTermRetentionPolicies/default"
            if (tokens.Length != BackupShortTermRetentionPolicyResourceIdSegmentsLength)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "ResourceId");
            }

            // Convert tokens into TYPE:NAME key value pairs, ignoring case
            Dictionary<string, string> segments = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            int i = 0;
            while (i < tokens.Length)
            {
                string type = tokens[i++];
                string name = tokens[i++];
                segments[type] = name;
            }

            try
            {
                this.ResourceGroupName = segments["resourceGroups"];
                this.ServerName = segments["servers"];
                this.DatabaseName = segments["databases"];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException(
                    "Invalid format of the resource identifier. ResourceID should follow format /subscriptions/<subscriptionId>/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/servers/<serverName>/databases/<databaseName>/backupShortTermRetentionPolicies/default");
            }
        }
    }
}
