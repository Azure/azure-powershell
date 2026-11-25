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

using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    [CmdletPreview("Legal Hold feature for SQL Long Term Retention backups is currently in Public Preview")]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseLongTermRetentionBackupLegalHold", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlManagedDatabaseLongTermRetentionBackupModel))]
    public class SetAzureSqlManagedDatabaseLongTermRetentionBackupLegalHold : AzureSqlManagedDatabaseLongTermRetentionBackupActionCmdletBase
    {
        protected override IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> PersistChanges(
            IEnumerable<AzureSqlManagedDatabaseLongTermRetentionBackupModel> entity)
        {
            return new[]
            {
                ModelAdapter.SetManagedDatabaseLongTermRetentionBackupLegalHold(
                    ResourceGroupName, Location, InstanceName, DatabaseName, BackupName)
            };
        }

        public override void ExecuteCmdlet()
        {
            ResolveBackupIdentity();
            if (ShouldProcess(BackupName) &&
                (Force.IsPresent || ShouldContinue(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupWarning, BackupName, DatabaseName, InstanceName, Location),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetLegalHoldAzureSqlInstanceDatabaseLongTermRetentionBackupDescription, BackupName, DatabaseName, InstanceName, Location))))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}