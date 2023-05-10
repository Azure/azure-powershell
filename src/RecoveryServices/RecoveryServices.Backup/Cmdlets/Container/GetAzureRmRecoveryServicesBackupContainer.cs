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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Fetches containers registered to the vault according to the filters passed via the cmdlet parameters.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupContainer"), OutputType(typeof(ContainerBase))]
    public class GetAzureRmRecoveryServicesBackupContainer : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// The type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, HelpMessage = ParamHelpMsgs.Container.ContainerType)]
        [ValidateNotNullOrEmpty]
        public ContainerType ContainerType { get; set; }

        /// <summary>
        /// The backup management type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2,
            HelpMessage = ParamHelpMsgs.Container.BackupManagementType)]
        [ValidateSet("AzureVM", "AzureStorage", "AzureWorkload", "MAB")]
        public string BackupManagementType { get; set; }

        /// <summary>
        /// Friendly name of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3,
            HelpMessage = ParamHelpMsgs.Container.FriendlyName)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Resource group name of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4,
            HelpMessage = ParamHelpMsgs.Container.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }        

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                BackupManagementType? backupManagementTypeNullable = null;
                BackupManagementType backupManagementType;
                if (BackupManagementType != null)
                {
                    Enum.TryParse(BackupManagementType, out backupManagementType);
                    backupManagementTypeNullable = backupManagementType;
                }

                // Currently the containers API doesn't support any status level filtering 
                // Also the NotRegitered container isn't a valid scenario, so we're not allowing client filtering too
                // If the filtering is required in future we can add client side filtering                 
                // Status = ContainerRegistrationStatus.Registered;

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, resourceGroupName },
                        { ContainerParams.ContainerType, ContainerType },
                        { ContainerParams.BackupManagementType, backupManagementTypeNullable },
                        { ContainerParams.FriendlyName, FriendlyName },
                        { ContainerParams.ResourceGroupName, ResourceGroupName },                        
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                    providerManager.GetProviderInstance(ContainerType, backupManagementTypeNullable);
                var containerModels = psBackupProvider.ListProtectionContainers();
                WriteObject(containerModels, enumerateCollection: true);
            });
        }
    }
}
