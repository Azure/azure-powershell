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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

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
            HelpMessage = ParamHelpMsgs.Container.RegisteredContainer)]
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
                       Container.BackupManagementType == BackupManagementType.AzureStorage)))
                {
                    throw new ArgumentException(string.Format(Resources.UnsupportedContainerException,
                        Container.ContainerType, Container.BackupManagementType));
                }
                string containerName = Container.Name;

                if (Container.ContainerType == ContainerType.AzureSQL)
                {
                    containerName = ContainerConstansts.SqlContainerNamePrefix + containerName;
                }

                ServiceClientAdapter.UnregisterContainers(
                    containerName,
                    vaultName: vaultName,
                    resourceGroupName: resourceGroupName);

                if (PassThru.IsPresent)
                {
                    WriteObject(Container);
                }
            }, ShouldProcess(Container.Name, VerbsLifecycle.Unregister));
        }
    }
}
