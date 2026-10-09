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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    public abstract class AzureSqlManagedDatabaseLongTermRetentionBackupActionCmdletBase :
        AzureSqlManagedDatabaseLongTermRetentionBackupCmdletBase
    {
        protected const string DefaultParameterSet = "Default";
        protected const string InputObjectParameterSet = "InputObject";
        protected const string ResourceIdParameterSet = "ResourceId";

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 0,
            HelpMessage = "The location of the backup's source Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Sql/locations/longTermRetentionManagedInstances")]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 1,
            HelpMessage = "The name of the Managed Instance the backup is under.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 2,
            HelpMessage = "The name of the Managed Database the backup is from.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances/databases", "ResourceGroupName", "InstanceName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, Position = 3,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the backup.")]
        [ValidateNotNullOrEmpty]
        public string BackupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, Position = 0,
            ValueFromPipeline = true, HelpMessage = "The Managed Instance Long Term Retention Backup to update.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedDatabaseLongTermRetentionBackupModel InputObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, Position = 0,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The resource ID of the Managed Instance Long Term Retention Backup to update.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(HelpMessage = "Skip confirmation message for performing the action.")]
        public SwitchParameter Force { get; set; }

        [Parameter(HelpMessage = "Whether to output the updated backup at the end of execution.")]
        public SwitchParameter PassThru { get; set; }

        protected override bool WriteResult()
        {
            return PassThru;
        }

        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> GetEntity()
        {
            return ModelAdapter.GetManagedDatabaseLongTermRetentionBackups(
                Location, InstanceName, DatabaseName, BackupName, ResourceGroupName, null, null);
        }

        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> model)
        {
            return model;
        }

        protected void ResolveBackupIdentity()
        {
            if (InputObject != null)
            {
                Location = InputObject.Location;
                InstanceName = InputObject.ManagedInstanceName;
                DatabaseName = InputObject.DatabaseName;
                BackupName = InputObject.BackupName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ParseResourceId(ResourceId);
            }

            if (string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new ArgumentException("The backup resource ID must include a resource group.", nameof(ResourceGroupName));
            }
        }

        private void ParseResourceId(string resourceId)
        {
            string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 14 ||
                !tokens[2].Equals("resourceGroups", StringComparison.OrdinalIgnoreCase) ||
                !tokens[8].Equals("longTermRetentionManagedInstances", StringComparison.OrdinalIgnoreCase) ||
                !tokens[10].Equals("longTermRetentionDatabases", StringComparison.OrdinalIgnoreCase) ||
                !tokens[12].Equals("longTermRetentionManagedInstanceBackups", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Invalid parameter", nameof(ResourceId));
            }

            ResourceGroupName = tokens[3];
            Location = tokens[7];
            InstanceName = tokens[9];
            DatabaseName = tokens[11];
            BackupName = tokens[13];
        }
    }
}