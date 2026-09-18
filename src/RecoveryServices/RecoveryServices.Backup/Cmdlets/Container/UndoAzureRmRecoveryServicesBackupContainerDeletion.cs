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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Undeletes a softdeleted backup container in a recovery services vault.
    /// </summary>
    [Cmdlet("Undo", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupContainerDeletion", DefaultParameterSetName = UndeleteParamSet, SupportsShouldProcess = true), OutputType(typeof(ContainerBase))]
    public class UndoAzureRmRecoveryServicesBackupContainerDeletion
        : RSBackupVaultCmdletBase
    {
        internal const string UndeleteParamSet = "undelete";

        /// <summary>
        /// Specifies the backup container to be rehydrated
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = ParamHelpMsgs.Item.Container,
            ParameterSetName = UndeleteParamSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }

        /// <summary>
        /// The backup management type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.Common.BackupManagementType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureVM", "AzureWorkload", "AzureStorage")]
        public Models.BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// Workload type of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureVM", "AzureFiles", "MSSQL", "SAPHanaDatabase")]
        public Models.WorkloadType WorkloadType { get; set; }

        /// <summary>
        /// Prevents the confirmation dialog when specified.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = ParamHelpMsgs.Container.ForceOption)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                string containerName = Container?.Name ?? throw new ArgumentNullException(nameof(Container), "Container name cannot be null.");

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.UndeleteContainerWarning, containerName),
                    Resources.UndeleteContainerMessage,
                    containerName, () =>
                    {
                        base.ExecuteCmdlet();

                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                        string vaultName = resourceIdentifier.ResourceName;
                        string vaultResourceGroupName = resourceIdentifier.ResourceGroupName;

                        PsBackupProviderManager providerManager =
                            new PsBackupProviderManager(new Dictionary<Enum, object>()
                            {
                                { VaultParams.VaultName, vaultName },
                                { VaultParams.ResourceGroupName, vaultResourceGroupName },
                                { ContainerParams.Name, containerName },
                                { ContainerParams.ContainerType, ServiceClientHelpers.GetServiceClientWorkloadType(WorkloadType).ToString() },
                                { ContainerParams.BackupManagementType, BackupManagementType.ToString() },
                                { ContainerParams.Container, Container}
                            }, ServiceClientAdapter);

                        IPsBackupProvider psBackupProvider =
                        providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                        psBackupProvider.UndeleteContainer();

                        string[] parseContainer = containerName.Split(';');
                        string friendlyName = parseContainer[parseContainer.Length - 1];

                        // List containers
                        string backupManagementType = BackupManagementType.ToString();
                        ODataQuery<BMSContainerQueryObject> queryParams = new ODataQuery<BMSContainerQueryObject>(
                        q => q.FriendlyName == friendlyName &&
                        q.BackupManagementType == backupManagementType);

                        var listResponse = ServiceClientAdapter.ListContainers(queryParams,
                            vaultName: vaultName, resourceGroupName: vaultResourceGroupName);
                        var containerModels = ConversionHelpers.GetContainerModelList(listResponse);
                        WriteObject(containerModels, enumerateCollection: true);
                    });
            }, ShouldProcess(Container.Name, VerbsLifecycle.Register));
        }
    }
}
