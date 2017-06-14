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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureRmBackupContainer", SupportsShouldProcess = true)]
    public class UnregisterAzureRMBackupContainer : AzureBackupContainerCmdletBase
    {
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Confirm unregistration and deletion of server")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                AzureBackupContainerType containerType = (AzureBackupContainerType)Enum.Parse(typeof(AzureBackupContainerType), Container.ContainerType, true);
                switch (containerType)
                {
                    case AzureBackupContainerType.Windows:
                    case AzureBackupContainerType.SCDPM:
                    case AzureBackupContainerType.AzureBackupServer:
                    case AzureBackupContainerType.Other:
                        DeleteServer();
                        break;
                    case AzureBackupContainerType.AzureVM:
                        UnregisterContainer();
                        break;
                    default:
                        break;
                }
            });
        }

        private void DeleteServer()
        {
            ConfirmAction(Force, Resources.UnregisterServerCaption, Resources.UnregisterServerMessage, "", () =>
                AzureBackupClient.UnregisterMachineContainer(Container.ResourceGroupName, Container.ResourceName, Container.Id));
        }

        private void UnregisterContainer()
        {
            ConfirmAction(Resources.UnregisterContainerAction,
                string.Format(Resources.UnregisterContainerTarget, Container.ResourceName, Container.ResourceGroupName),
                () =>
            {
                string containerUniqueName = Container.ContainerUniqueName;
                var operationId = AzureBackupClient.UnRegisterContainer(Container.ResourceGroupName,
                    Container.ResourceName, containerUniqueName);

                WriteObject(GetCreatedJobs(Container.ResourceGroupName,
                    Container.ResourceName,
                    new Models.AzureRMBackupVault(Container.ResourceGroupName, Container.ResourceName,
                        Container.Location),
                    GetOperationStatus(Container.ResourceGroupName, Container.ResourceName, operationId).JobList)
                    .FirstOrDefault());
            });
        }
    }
}
