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

using BCI = Microsoft.BackupManagementService.CommonInterface;
using BMI = Microsoft.BackupManagementService.ManagementInterface;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureBackupContainer"), OutputType(typeof(AzureBackupContainer), typeof(List<AzureBackupContainer>))]
    public class GetAzureBackupContainer : AzureBackupVaultCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ContainerResourceGroupName)]
        [ValidateNotNullOrEmpty]
        public string ContainerResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ContainerResourceName)]
        [ValidateNotNullOrEmpty]
        public string ContainerResourceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ContainerRegistrationStatus)]
        [ValidateNotNullOrEmpty]
        public AzureBackupContainerStatus Status { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ContainerType)]
        [ValidateNotNullOrEmpty]
        public AzureBackupContainerType Type { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                string queryFilterString = string.Empty;
                queryFilterString = ConstructQueryFilterString();
                ListContainerResponse listContainerResponse = AzureBackupClient.Container.ListAsync(queryFilterString,
                    GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                List<ContainerInfo> containerInfos = listContainerResponse.Objects.ToList();

                // When resource group name is specified, remove all containers whose resource group name
                // doesn't match the given resource group name
                if (!string.IsNullOrEmpty(ContainerResourceGroupName))
                {
                    containerInfos.RemoveAll(containerInfo =>
                    {
                        return containerInfo.ParentContainerName != ContainerResourceGroupName;
                    });
                }

                WriteObject(containerInfos.ConvertAll(containerInfo =>
                {
                    return new AzureBackupContainer(containerInfo, ResourceGroupName, ResourceName,  Location);
                }));
            });
        }

        private string ConstructQueryFilterString()
        {
            BMI.ContainerQueryObject containerQueryObject = new BMI.ContainerQueryObject();

            switch (Type)
            {
                case AzureBackupContainerType.AzureVirtualMachine:
                    containerQueryObject.Type = BCI.ContainerType.IaasVMContainer.ToString();
                    break;
                default:
                    break;
            }

            switch (Status)
            {
                case AzureBackupContainerStatus.Registered:
                    containerQueryObject.Status = BCI.RegistrationStatus.Registered.ToString();
                    break;
                case AzureBackupContainerStatus.Registering:
                    containerQueryObject.Status = BCI.RegistrationStatus.Registering.ToString();
                    break;
                case AzureBackupContainerStatus.NotRegistered:
                    containerQueryObject.Status = BCI.RegistrationStatus.NotRegistered.ToString();
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(ContainerResourceName))
            {
                containerQueryObject.FriendlyName = ContainerResourceName;
            }

            return BMI.BackupManagementAPIHelper.GetQueryString(containerQueryObject.GetNameValueCollection());
        }
    }
}
