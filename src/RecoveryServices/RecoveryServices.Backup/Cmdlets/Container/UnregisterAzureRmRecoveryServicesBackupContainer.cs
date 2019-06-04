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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Management.Automation;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets
{
    /// <summary>
    /// Unregisters container from the recovery services vault.
    /// </summary>
    [Cmdlet("Unregister", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesBackupContainer", SupportsShouldProcess = true), OutputType(typeof(ContainerBase))]
    public class UnregisterAzureRmRecoveryServicesBackupContainer
        : RSBackupVaultCmdletBase
    {
        /// <summary>
        /// Container model object to be unregistered from the vault.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1,
            HelpMessage = ParamHelpMsgs.Container.RegisteredContainer, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ContainerBase Container { get; set; }

        /// <summary>
        /// Return the container to be deleted
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the container to be deleted.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(VaultId);
                string vaultName = resourceIdentifier.ResourceName;
                string resourceGroupName = resourceIdentifier.ResourceGroupName;

                if (!((Container.ContainerType == ContainerType.Windows &&
                       Container.BackupManagementType == BackupManagementType.MARS) ||
                    (Container.ContainerType == ContainerType.AzureSQL &&
                     Container.BackupManagementType == BackupManagementType.AzureSQL) ||
                     (Container.ContainerType == ContainerType.AzureStorage &&
                       Container.BackupManagementType == BackupManagementType.AzureStorage) ||
                       (Container.ContainerType == ContainerType.AzureVMAppContainer &&
                       Container.BackupManagementType == BackupManagementType.AzureWorkload)))
                {
                    throw new ArgumentException(string.Format(Resources.UnsupportedContainerException,
                        Container.ContainerType, Container.BackupManagementType));
                }
                string containerName = Container.Name;

                if (Container.ContainerType == ContainerType.AzureSQL)
                {
                    containerName = ContainerConstansts.SqlContainerNamePrefix + containerName;
                }

                if (Container.ContainerType == ContainerType.AzureVMAppContainer)
                {
                    var unRegisterResponse = ServiceClientAdapter.UnregisterWorkloadContainers(
                    containerName,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                    var operationStatus = TrackingHelpers.GetOperationResult(
                        unRegisterResponse,
                        operationId =>
                            ServiceClientAdapter.GetContainerRefreshOrInquiryOperationResult(
                                operationId,
                                vaultName: vaultName,
                                resourceGroupName: resourceGroupName));

                    //Now wait for the operation to Complete
                    if (unRegisterResponse.Response.StatusCode
                            != SystemNet.HttpStatusCode.NoContent)
                    {
                        string errorMessage = string.Format(Resources.UnRegisterFailureErrorCode,
                            unRegisterResponse.Response.StatusCode);
                        Logger.Instance.WriteDebug(errorMessage);
                    }
                }
                else
                {
                    ServiceClientAdapter.UnregisterContainers(
                    containerName,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(Container);
                }
            }, ShouldProcess(Container.Name, VerbsLifecycle.Unregister));
        }
    }
}
