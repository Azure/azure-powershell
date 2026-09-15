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
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Registers container from the recovery services vault.
    /// </summary>
    [Cmdlet("Register", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupContainer", DefaultParameterSetName = RegisterParamSet, SupportsShouldProcess = true), OutputType(typeof(ContainerBase))]
    public class RegisterAzureRmRecoveryServicesBackupContainer
        : RSBackupVaultCmdletBase
    {
        internal const string RegisterParamSet = "Register";
        internal const string ReRegisterParamSet = "ReRegister";
        internal const string AzureFileRegisterParamSet = "AzureFileRegister";

        /// <summary>
        /// List of supported BackupManagementTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validBackupManagementTypes = "AzureWorkload, AzureStorage";

        /// <summary>
        /// List of supported WorkloadTypes for this cmdlet. Used in help text creation.
        /// </summary>
        private const string validWorkloadTypes = "MSSQL, AzureFiles";

        /// <summary>
        /// Azure Vm Id.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = RegisterParamSet,
            HelpMessage = ParamHelpMsgs.Container.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// When this option is specified, The container will be registered
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = ParamHelpMsgs.Item.Container,
            ParameterSetName = ReRegisterParamSet, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }

        /// <summary>
        /// Storage account name to register for Azure Files (AFS) backup.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = AzureFileRegisterParamSet,
            HelpMessage = ParamHelpMsgs.Item.AzureFileStorageAccountName)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Access type used by backup to reach the storage account for Azure Files (KeyBased / IdentityBased).
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileRegisterParamSet,
            HelpMessage = ParamHelpMsgs.Item.AccessType)]
        [ValidateSet("KeyBased", "IdentityBased")]
        public string AccessType { get; set; }

        /// <summary>
        /// Use the vault's system-assigned managed identity for identity-based Azure Files access.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileRegisterParamSet,
            HelpMessage = ParamHelpMsgs.Item.IsSystemAssignedIdentity)]
        public SwitchParameter IsSystemAssignedIdentity { get; set; }

        /// <summary>
        /// ARM url of the user-assigned managed identity for identity-based Azure Files access.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = AzureFileRegisterParamSet,
            HelpMessage = ParamHelpMsgs.Item.UserAssignedIdentityArmUrl)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentityArmUrl { get; set; }

        /// <summary>
        /// The backup management type of the container(s) to be fetched.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.Common.BackupManagementType + validBackupManagementTypes)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureWorkload", "AzureStorage")]
        public Models.BackupManagementType BackupManagementType { get; set; }

        /// <summary>
        /// Workload type of the item to be returned.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2,
            HelpMessage = ParamHelpMsgs.Common.WorkloadType + validWorkloadTypes)]
        [ValidateNotNullOrEmpty]
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
                // Azure Files (AFS) storage-account registration path.
                if (ParameterSetName == AzureFileRegisterParamSet ||
                    BackupManagementType == Models.BackupManagementType.AzureStorage)
                {
                    RegisterAzureFileStorageAccount();
                    return;
                }

                string containerName = Container != null ? Container.Name : ResourceId.Split('/')[8];

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RegisterContainerWarning, containerName),
                    Resources.RegisterContainerMessage,
                    containerName, () =>
                    {
                        base.ExecuteCmdlet();

                        string vmResourceGroupParsed = null;
                        ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                        string vaultName = resourceIdentifier.ResourceName;
                        string vaultResourceGroupName = resourceIdentifier.ResourceGroupName;

                        if (Container != null)
                        {
                            if (Container is AzureVmWorkloadContainer)
                            {
                                AzureVmWorkloadContainer azureVmWorkloadContainer = (AzureVmWorkloadContainer)Container;
                                Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(azureVmWorkloadContainer.SourceResourceId);
                                vmResourceGroupParsed = HelperUtils.GetResourceGroupNameFromId(keyValueDict, azureVmWorkloadContainer.SourceResourceId);
                            }
                            else
                            {
                                vmResourceGroupParsed = vaultResourceGroupName;
                            }
                        }
                        else
                        {
                            Dictionary<UriEnums, string> keyValueDict = HelperUtils.ParseUri(ResourceId);
                            vmResourceGroupParsed = HelperUtils.GetResourceGroupNameFromId(keyValueDict, ResourceId);
                        }

                        PsBackupProviderManager providerManager =
                            new PsBackupProviderManager(new Dictionary<Enum, object>()
                            {
                                { VaultParams.VaultName, vaultName },
                                { VaultParams.ResourceGroupName, vaultResourceGroupName },
                                { ContainerParams.Name, containerName },
                                { ContainerParams.ContainerType, ServiceClientHelpers.GetServiceClientWorkloadType(WorkloadType).ToString() },
                                { ContainerParams.BackupManagementType, BackupManagementType.ToString() },
                                { ContainerParams.Container, Container},
                                { ContainerParams.ResourceGroupName, vmResourceGroupParsed },
                            }, ServiceClientAdapter);

                        IPsBackupProvider psBackupProvider =
                        providerManager.GetProviderInstance(WorkloadType, BackupManagementType);
                        psBackupProvider.RegisterContainer();

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
            }, ShouldProcess(StorageAccountName ?? ResourceId, VerbsLifecycle.Register));
        }

        /// <summary>
        /// Registers (or re-registers) an Azure Files storage-account container, optionally binding a managed
        /// identity for identity-based access. Mirrors the register / re-register behavior of
        /// Enable-AzRecoveryServicesBackupProtection for AFS.
        /// </summary>
        private void RegisterAzureFileStorageAccount()
        {
            ValidateAfsIdentityParameters();

            base.ExecuteCmdlet();

            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
            string vaultName = resourceIdentifier.ResourceName;
            string vaultResourceGroupName = resourceIdentifier.ResourceGroupName;

            PsBackupProviderManager providerManager =
                new PsBackupProviderManager(new Dictionary<Enum, object>()
                {
                    { VaultParams.VaultName, vaultName },
                    { VaultParams.ResourceGroupName, vaultResourceGroupName },
                    { ContainerParams.Name, StorageAccountName },
                    { ItemParams.AccessType, AccessType },
                    { ItemParams.IsSystemAssignedIdentity, IsSystemAssignedIdentity.IsPresent },
                    { ItemParams.UserAssignedIdentityArmUrl, UserAssignedIdentityArmUrl },
                    { ItemParams.ForceReregister, Force.IsPresent },
                    { ItemParams.ConfirmReregister, new Func<bool>(() =>
                        ShouldContinue(
                            string.Format(Resources.AFSReregisterIdentityChangeWarning, StorageAccountName),
                            Resources.AFSReregisterIdentityChangeCaption)) },
                }, ServiceClientAdapter);

            IPsBackupProvider psBackupProvider =
                providerManager.GetProviderInstance(
                    Models.WorkloadType.AzureFiles,
                    Models.BackupManagementType.AzureStorage);
            psBackupProvider.RegisterContainer();

            // List the registered container and return it.
            string backupManagementType = Models.BackupManagementType.AzureStorage.ToString();
            ODataQuery<BMSContainerQueryObject> queryParams = new ODataQuery<BMSContainerQueryObject>(
                q => q.FriendlyName == StorageAccountName &&
                     q.BackupManagementType == backupManagementType);

            var listResponse = ServiceClientAdapter.ListContainers(
                queryParams,
                vaultName: vaultName,
                resourceGroupName: vaultResourceGroupName);
            var containerModels = ConversionHelpers.GetContainerModelList(listResponse);
            WriteObject(containerModels, enumerateCollection: true);
        }

        /// <summary>
        /// Validates the Azure Files identity-based access (MSI) parameters. Role-assignment existence and
        /// vault-MI checks are validated by the backend service when the (re)registration request is sent.
        /// </summary>
        private void ValidateAfsIdentityParameters()
        {
            bool hasUami = !string.IsNullOrEmpty(UserAssignedIdentityArmUrl);
            bool hasSami = IsSystemAssignedIdentity.IsPresent;

            if (hasSami && hasUami)
            {
                throw new ArgumentException(Resources.AFSIdentityBothSpecified);
            }

            if (string.IsNullOrEmpty(AccessType) && (hasSami || hasUami))
            {
                throw new ArgumentException(Resources.AFSIdentityRequiresAccessType);
            }

            if (string.Equals(AccessType, ServiceClientModel.AccessType.IdentityBased, StringComparison.OrdinalIgnoreCase))
            {
                if (!hasSami && !hasUami)
                {
                    throw new ArgumentException(Resources.AFSIdentityBasedRequiresIdentity);
                }
            }
            else if (string.Equals(AccessType, ServiceClientModel.AccessType.KeyBased, StringComparison.OrdinalIgnoreCase))
            {
                if (hasSami || hasUami)
                {
                    throw new ArgumentException(Resources.AFSKeyBasedWithIdentity);
                }
            }
        }
    }
}
