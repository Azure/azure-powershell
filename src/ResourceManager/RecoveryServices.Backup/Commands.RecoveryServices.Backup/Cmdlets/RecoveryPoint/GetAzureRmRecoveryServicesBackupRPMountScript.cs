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
    /// Get script to mount recovery point of an item for item level recovery.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmRecoveryServicesBackupRPMountScript",
        SupportsShouldProcess = true), OutputType(typeof(RPMountScriptDetails))]
    public class GetAzureRmRecoveryServicesBackupRPMountScript : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Recovery point of the item to be explored
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// Location where the mount script to access the given recovery point is to be downloaded.
        /// </summary>
        [Parameter(
            Mandatory = false,
            Position = 1,
            HelpMessage = ParamHelpMsgs.RecoveryPoint.FileDownloadLocation)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    new Dictionary<Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint},
                        { RecoveryPointParams.FileDownloadLocation, Path }
                }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                var response = psBackupProvider.ProvisionItemLevelRecoveryAccess();

                WriteDebug(string.Format("Mount Script download completed"));

                WriteObject(response);
            }, ShouldProcess(RecoveryPoint.ItemName, "Downloading script"));
        }
    }
}
