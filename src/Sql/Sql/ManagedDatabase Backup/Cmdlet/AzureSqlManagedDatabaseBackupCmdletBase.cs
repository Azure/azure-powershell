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


using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services;
using Microsoft.Azure.Commands.Sql.Properties;
using System;
using System.Collections.Generic;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    public abstract class AzureSqlManagedDatabaseBackupCmdletBase<TModel> : AzureSqlCmdletBase<TModel, AzureSqlManagedDatabaseBackupAdapter>
    {
        /// <summary>
        /// The expected number of segments in a short term retention policy resource id.
        /// </summary>
        private const int BackupShortTermRetentionPolicyResourceIdSegmentsLength = 12;

        /// <summary>
        /// Parameter set with ResourceGroup name, Server name and Database name.
        /// </summary>
        protected const string PolicyByResourceServerDatabaseSet = "PolicyByResourceInstanceDatabaseSet";

        /// <summary>
        /// Parameter set for using a Database Input Object.
        /// </summary>
        protected const string PolicyByInputObjectSet = "PolicyByInputObjectSet";

        /// <summary>
        /// Parameter set for using a resource Id.
        /// </summary>
        protected const string PolicyByResourceIdSet = "PolicyByResourceIdSet";

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByInputObjectSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The live or deleted database object to get/set the policy for.")]
        [ValidateNotNullOrEmpty]
        [Alias("AzureSqlInstanceDatabase", "AzureInstanceDatabaseObject")]
        public virtual AzureSqlManagedDatabaseBaseModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Database object to get the policy for.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceIdSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The short term retention policy resource Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(
            ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
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
            Position = 1,
            HelpMessage = "The name of the Azure SQL Managed Instance the database is in.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Instance Database to retrieve backups for.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public virtual string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the deletion date of the database to use.
        /// </summary>
        [Parameter(ParameterSetName = PolicyByResourceServerDatabaseSet,
            Mandatory = false,
            HelpMessage = "The deletion date of the Azure SQL Instance Database to retrieve backups for, with millisecond precision (e.g. 2016-02-23T00:21:22.847Z)")]
        [ValidateNotNullOrEmpty]
        public virtual DateTime? DeletionDate { get; set; }
        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlManagedDatabaseBackupAdapter InitModelAdapter()
        {
            return new AzureSqlManagedDatabaseBackupAdapter(DefaultProfile.DefaultContext);
        }

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                this.ResourceGroupName = InputObject.ResourceGroupName;
                this.InstanceName = InputObject.ManagedInstanceName;
                this.DatabaseName = InputObject.Name;
                if (InputObject is AzureSqlDeletedManagedDatabaseBackupModel)
                {
                    this.DeletionDate = ((AzureSqlDeletedManagedDatabaseBackupModel)InputObject).DeletionDate;
                }
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
        internal void ParseResourceId()
        {
            string[] tokens = ResourceId.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            // "/subscriptions/<subId>/resourceGroups/<resourceGroup>/providers/Microsoft.Sql/managedInstances/<managedInstance>/databases/<database>/backupShortTermRetentionPolicies/default"
            if (tokens.Length != BackupShortTermRetentionPolicyResourceIdSegmentsLength)
            {
                throw new ArgumentException(Resources.InvalidFormatResourceId, "ResourceId");
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
                this.InstanceName = segments["managedInstances"];
                if (segments.ContainsKey("databases"))
                {
                    this.DatabaseName = segments["databases"];
                }
                else
                {
                    int idx = segments["restorableDroppedDatabases"].LastIndexOf(',');

                    if (idx != -1)
                    {
                        this.DatabaseName = segments["restorableDroppedDatabases"].Substring(0, idx);
                        this.DeletionDate = DateTime.FromFileTimeUtc(Convert.ToInt64(segments["restorableDroppedDatabases"].Substring(idx + 1)));
                    }
                    else
                    {
                        throw new ArgumentException(Resources.InvalidFormatResourceId, "ResourceId");
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException(Resources.InvalidFormatResourceId, "ResourceId");
            }
        }
    }
}
