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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Unregisters container from the recovery services vault.
    /// </summary>
    [Cmdlet("Register", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupContainer", SupportsShouldProcess = true), OutputType(typeof(ContainerBase))]
    public class RegisterAzureRmRecoveryServicesBackupContainer
        : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Azure Vm Id.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0,
            HelpMessage = ParamHelpMsgs.Container.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// The backup management type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.Container.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureWorkload")]
        public Models.BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// Workload type of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        public Models.WorkloadType WorkloadType { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string vaultResourceGroupName = resourceIdentifier.ResourceGroupName;

                string containerName = ResourceId.Split('/')[8];

                PsBackupProviderManager providerManager =
                    new PsBackupProviderManager(new Dictionary<Enum, object>()
                    {
                        { VaultParams.VaultName, vaultName },
                        { VaultParams.ResourceGroupName, vaultResourceGroupName },
                        { ContainerParams.Name, containerName },
                        { ContainerParams.ContainerType, ServiceClientHelpers.GetServiceClientWorkloadType(WorkloadType).ToString() },
                        { ContainerParams.BackupManagementType, BackupManagementType.ToString() },
                    }, ServiceClientAdapter);

                IPsBackupProvider psBackupProvider =
                providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                psBackupProvider.RegisterContainer();

                // List containers
                string backupManagementType = BackupManagementType.ToString();
                ODataQuery<BMSContainerQueryObject> queryParams = new ODataQuery<BMSContainerQueryObject>(
                q => q.FriendlyName == containerName &&
                q.BackupManagementType == backupManagementType);

                var listResponse = ServiceClientAdapter.ListContainers(queryParams,
                    vaultName: vaultName, resourceGroupName: vaultResourceGroupName);
                var containerModels = ConversionHelpers.GetContainerModelList(listResponse);
                WriteObject(containerModels, enumerateCollection: true);
            }, ShouldProcess(ResourceId, VerbsLifecycle.Register));
        }
    }
}
