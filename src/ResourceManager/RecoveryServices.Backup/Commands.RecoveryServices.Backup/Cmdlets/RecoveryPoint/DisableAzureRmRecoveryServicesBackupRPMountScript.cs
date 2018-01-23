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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Disable the mount script of recovery point of an item.
    /// Files won't be mounted after running this cmdlet.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Disable, "AzureRmRecoveryServicesBackupRPMountScript",
        SupportsShouldProcess = true), OutputType(typeof(RecoveryPointBase))]
    public class DisableAzureRmRecoveryServicesBackupRPMountScript : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Recovery point of the item. Access to the mounted files of this recovery point
        /// will be disabled upon running this cmdlet.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// Return the recovery point.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the recovery point.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    new Dictionary<Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint}
                }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                string content = string.Empty;
                psBackupProvider.RevokeItemLevelRecoveryAccess();

                if (PassThru.IsPresent)
                {
                    WriteObject(RecoveryPoint);
                }

                WriteDebug(string.Format("Disabled the mount script of recovery point"));
            }, ShouldProcess(RecoveryPoint.ItemName, VerbsLifecycle.Disable));
        }
    }
}
