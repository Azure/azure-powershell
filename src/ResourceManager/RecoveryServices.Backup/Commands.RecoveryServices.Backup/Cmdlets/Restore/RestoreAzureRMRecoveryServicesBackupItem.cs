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
using System.Threading;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Restores an item using the recovery point provided within the recovery services vault
    /// </summary>
    [Cmdlet(VerbsData.Restore, "AzureRmRecoveryServicesBackupItem", SupportsShouldProcess = true),
        OutputType(typeof(JobBase))]
    public class RestoreAzureRmRecoveryServicesBackupItem : RecoveryServicesBackupCmdletBase
    {
        /// <summary>
        /// Recovery point of the item to be restored
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, Position = 0,
            HelpMessage = ParamHelpMsgs.RestoreDisk.RecoveryPoint)]
        [ValidateNotNullOrEmpty]
        public RecoveryPointBase RecoveryPoint { get; set; }

        /// <summary>
        /// Storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Resource group name of Storage account name where the disks need to be recovered
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = ParamHelpMsgs.RestoreDisk.StorageAccountResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceGroupName { get; set; }

        /// <summary>
        /// Use this switch if the disks from the recovery point are to be restored to their original storage accounts
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.RestoreDisk.OsaOption)]
        public SwitchParameter UseOriginalStorageAccount { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                GenericResource storageAccountResource = GetStorageAccountResource();
                WriteDebug(string.Format("StorageId = {0}", storageAccountResource.Id));

                PsBackupProviderManager providerManager = new PsBackupProviderManager(
                    new Dictionary<Enum, object>()
                {
                    {RestoreBackupItemParams.RecoveryPoint, RecoveryPoint},
                    {RestoreBackupItemParams.StorageAccountId, storageAccountResource.Id},
                    {RestoreBackupItemParams.StorageAccountLocation, storageAccountResource.Location},
                    {RestoreBackupItemParams.StorageAccountType, storageAccountResource.Type},
                    {RestoreBackupItemParams.OsaOption, UseOriginalStorageAccount.IsPresent}
                }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider = providerManager.GetProviderInstance(
                    RecoveryPoint.WorkloadType, RecoveryPoint.BackupManagementType);
                var jobResponse = psBackupProvider.TriggerRestore();

                WriteDebug(string.Format("Restore submitted"));
                HandleCreatedJob(jobResponse, Resources.RestoreOperation);
            }, ShouldProcess(RecoveryPoint.ItemName, VerbsData.Restore));
        }

        private GenericResource GetStorageAccountResource()
        {
            StorageAccountName = StorageAccountName.ToLower();
            ResourceIdentity identity = new ResourceIdentity();
            identity.ResourceName = StorageAccountName;
            identity.ResourceProviderNamespace = "Microsoft.ClassicStorage/storageAccounts";
            identity.ResourceProviderApiVersion = "2015-12-01";
            identity.ResourceType = string.Empty;
            identity.ParentResourcePath = string.Empty;

            GenericResource resource = null;
            try
            {
                WriteDebug(string.Format("Query Microsoft.ClassicStorage with name = {0}",
                    StorageAccountName));
                resource = RmClient.Resources.GetAsync(
                    StorageAccountResourceGroupName,
                    identity.ResourceProviderNamespace,
                    identity.ParentResourcePath,
                    identity.ResourceType,
                    identity.ResourceName,
                    identity.ResourceProviderApiVersion,
                    CancellationToken.None).Result;
            }
            catch (Exception)
            {
                identity.ResourceProviderNamespace = "Microsoft.Storage/storageAccounts";
                identity.ResourceProviderApiVersion = "2016-01-01";
                resource = RmClient.Resources.GetAsync(
                    StorageAccountResourceGroupName,
                    identity.ResourceProviderNamespace,
                    identity.ParentResourcePath,
                    identity.ResourceType,
                    identity.ResourceName,
                    identity.ResourceProviderApiVersion,
                    CancellationToken.None).Result;
            }

            return resource;
        }
    }
}
