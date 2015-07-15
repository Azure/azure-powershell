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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Commands.AzureBackup.Library;
using Microsoft.Azure.Commands.AzureBackup.Models;
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
        //[Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ManagedResourceGroupName)]
        //[ValidateNotNullOrEmpty]
        //public string ManagedResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ManagedResourceName)]
        [ValidateNotNullOrEmpty]
        public string ManagedResourceName { get; set; }

        //[Parameter(Mandatory = false, HelpMessage = AzureBackupCmdletHelpMessage.ContainerRegistrationStatus)]
        //[ValidateNotNullOrEmpty]
        //public AzureBackupContainerStatusInput Status { get; set; }

        [Parameter(Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.ContainerType)]
        [ValidateNotNullOrEmpty]
        public AzureBackupContainerTypeInput Type { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                List<AzureBackupContainer> containers = new List<AzureBackupContainer>();

                switch (Type)
                {
                    case AzureBackupContainerTypeInput.Windows:
                    case AzureBackupContainerTypeInput.SCDPM:
                        containers.AddRange(GetMachineContainers());
                        break;
                    default:
                        break;
                }

                WriteObject(containers);
            });
        }

        private List<AzureBackupContainer> GetMachineContainers()
        {
            List<MarsContainerResponse> marsContainerResponses = new List<MarsContainerResponse>();
            if (!string.IsNullOrEmpty(ManagedResourceName))
            {
                marsContainerResponses.AddRange(AzureBackupClient.ListMachineContainers());
            }
            else
            {
                marsContainerResponses.AddRange(AzureBackupClient.ListMachineContainers(ManagedResourceName));
            }

            return marsContainerResponses.ConvertAll<AzureBackupContainer>(marsContainerResponse =>
            {
                return new AzureBackupContainer(Vault, marsContainerResponse);
            }).Where(container => container.ContainerType == GetCustomerType().ToString()).ToList();
        }

        private CustomerType GetCustomerType()
        {
            CustomerType customerType = CustomerType.Invalid;

            switch (Type)
            {
                case AzureBackupContainerTypeInput.Windows:
                    customerType = CustomerType.OBS;
                    break;
                case AzureBackupContainerTypeInput.SCDPM:
                    customerType = CustomerType.DPM;
                    break;
                default:
                    break;
            }

            return customerType;
        }
    }
}
