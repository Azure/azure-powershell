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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    [CmdletPreview("Legal Hold feature for SQL Long Term Retention backups is currently in Public Preview")]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLongTermRetentionBackupLegalHold", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlManagedDatabaseLongTermRetentionBackupModel))]
    public class RemoveAzureSqlManagedDatabaseLongTermRetentionBackupLegalHold : AzureSqlManagedDatabaseLongTermRetentionBackupActionCmdletBase
    {
        [Parameter(HelpMessage = "Skip confirmation when removing legal hold from an expired backup.")]
        public SwitchParameter ForceDropExpired { get; set; }

        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> entity)
        {
            return new[]
            {
                ModelAdapter.RemoveManagedDatabaseLongTermRetentionBackupLegalHold(
                    ResourceGroupName, Location, InstanceName, DatabaseName, BackupName)
            };
        }

        public override void ExecuteCmdlet()
        {
            ResolveBackupIdentity();
            ModelAdapter = InitModelAdapter();
            AzureSqlManagedDatabaseLongTermRetentionBackupModel entity = GetEntity().Single();

            if (!ShouldProcess(BackupName))
            {
                return;
            }

            if (entity.BackupExpirationTime <= DateTime.UtcNow)
            {
                if (ForceDropExpired.IsPresent || ShouldContinue(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupExpiredWarning, BackupName, DatabaseName, InstanceName, Location),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupDescription, BackupName, DatabaseName, InstanceName, Location)))
                {
                    base.ExecuteCmdlet();
                }
            }
            else if (Force.IsPresent || ShouldContinue(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupWarning, BackupName, DatabaseName, InstanceName, Location),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupDescription, BackupName, DatabaseName, InstanceName, Location)))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}