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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Container
{
    /// <summary>
    /// Unregisters the backup management server from the vault.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureRmRecoveryServicesBackupManagementServer",
        SupportsShouldProcess = true)]
    public class UnregisterAzureRmRecoveryServicesBackupManagementServer
        : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// The backup management server to be unregistered from the vault.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.Container.RegisteredContainer)]
        [ValidateNotNullOrEmpty]
        public BackupEngineBase AzureRmBackupManagementServer { get; set; }

        /// <summary>
        /// Return the Backup Management Server to be deleted
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Backup Management Server to be deleted.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                if ((AzureRmBackupManagementServer.BackupEngineType !=
                    BackupEngineType.DpmBackupEngine.ToString() &&
                    AzureRmBackupManagementServer.BackupEngineType !=
                    BackupEngineType.AzureBackupServerEngine.ToString()) ||
                    AzureRmBackupManagementServer.BackupManagementType.ToString() !=
                    BackupManagementType.SCDPM.ToString() &&
                    AzureRmBackupManagementServer.BackupManagementType.ToString() !=
                    BackupManagementType.AzureBackupServer.ToString())
                {
                    throw new ArgumentException(string.Format(
                        Resources.UnsupportedAzureRmBackupManagementServerException,
                        AzureRmBackupManagementServer.BackupEngineType,
                        AzureRmBackupManagementServer.BackupManagementType));
                }

                string azureRmBackupManagementServer = AzureRmBackupManagementServer.Name;
                ServiceClientAdapter.UnregisterContainers(azureRmBackupManagementServer);

                if (PassThru.IsPresent)
                {
                    WriteObject(AzureRmBackupManagementServer);
                }
            }, ShouldProcess(AzureRmBackupManagementServer.Name, VerbsLifecycle.Unregister));
        }
    }
}
