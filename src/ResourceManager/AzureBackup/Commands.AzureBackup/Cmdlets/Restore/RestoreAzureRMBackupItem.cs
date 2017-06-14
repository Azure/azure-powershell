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

using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Linq;
using System.Management.Automation;
using System.Web.Script.Serialization;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Restore Azure Backup Item
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureRmBackupItem"), OutputType(typeof(AzureRMBackupJob))]
    public class RestoreAzureRMBackupItem : AzureBackupRestoreBase
    {
        [Parameter(Position = 1, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                WriteDebug(Resources.MakingClientCall);
                AzureIaaSVMRecoveryInputsCSMObject azureIaaSVMRecoveryInputsCSMObject = new AzureIaaSVMRecoveryInputsCSMObject()
                {
                    CloudServiceName = string.Empty,
                    VmName = string.Empty,
                    CreateNewCloudService = false,
                    ContinueProtection = false,
                    InputStorageAccountName = StorageAccountName,
                    AffinityGroup = "",
                    Region = RecoveryPoint.Location,
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string azureIaaSVMRecoveryInputsCSMObjectString = serializer.Serialize(azureIaaSVMRecoveryInputsCSMObject);

                CSMRestoreRequest csmRestoreRequest = new CSMRestoreRequest()
                {
                    Properties = new CSMRestoreRequestProperties()
                    {
                        TypeOfRecovery = RecoveryType.RestoreDisks.ToString(),
                        RecoveryDSTypeSpecificInputs = azureIaaSVMRecoveryInputsCSMObjectString,
                    },
                };

                Guid operationId = AzureBackupClient.TriggerRestore(RecoveryPoint.ResourceGroupName, RecoveryPoint.ResourceName, RecoveryPoint.ContainerUniqueName, RecoveryPoint.ItemName, RecoveryPoint.RecoveryPointName, csmRestoreRequest);
                WriteDebug(string.Format(Resources.TriggeringRestore, operationId));

                var operationStatus = TrackOperation(RecoveryPoint.ResourceGroupName, RecoveryPoint.ResourceName, operationId);
                WriteObject(GetCreatedJobs(RecoveryPoint.ResourceGroupName,
                    RecoveryPoint.ResourceName,
                    new Models.AzureRMBackupVault(RecoveryPoint.ResourceGroupName, RecoveryPoint.ResourceName, RecoveryPoint.Location),
                    operationStatus.JobList).FirstOrDefault());

            });
        }
    }
}
