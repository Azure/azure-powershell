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
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.Management.BackupServices.Models;
using MBS = Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Commands.Compute.Models;


namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureBackupContainer"), OutputType(typeof(Guid))]
    public class RegisterAzureBackupContainer : AzureBackupVaultCmdletBase
    {
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineInstanceView VirtualMachine { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                string vmName = VirtualMachine.Name;
                string rgName = VirtualMachine.ResourceGroupName;
                Guid jobId = Guid.Empty;
                bool isDiscoveryNeed = false;
                MBS.OperationResponse operationResponse;

                ContainerInfo container = null;
                isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                if(isDiscoveryNeed)
                {
                    RefreshContainer();
                }

                isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                if((isDiscoveryNeed == false) && (container == null))
                {
                    //Container is not discovered. Throw exception
                    throw new NotImplementedException();
                }
                else
                {
                    //Container is discovered. Register the container
                    List<string> containerNameList = new List<string>();
                    containerNameList.Add(container.Name);
                    RegisterContainerRequest registrationRequest = new RegisterContainerRequest(containerNameList, "IaasVMContainer"); //TODO: Container type from enum
                    operationResponse = AzureBackupClient.Container.RegisterAsync(registrationRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                    //TODO fix the OperationResponse to JobID conversion
                    jobId = operationResponse.OperationId;
                    WriteObject(jobId);
                }
            });
        }

        private void RefreshContainer()
        {
            MBS.OperationResponse opResponse = 
                AzureBackupClient.Container.RefreshAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

            //Now wait for the operation to Complete

            //If operat
            throw new NotImplementedException();
        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, out ContainerInfo container)
        {
            bool isDiscoveryNeed = false;
            //First check if container is discoverd or not
            ListContainerQueryParameter queryParams = new ListContainerQueryParameter();
            queryParams.ContainerFriendlyNameField = vmName;
            ListContainerResponse containers = AzureBackupClient.Container.ListAsync(queryParams,
                            GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            if (containers.Objects.Count() == 0)
            {
                //Container is not discover
                WriteVerbose("Container is not discovered");
                container = null;
                isDiscoveryNeed = true;
            }

            else
            {
                //We can have multiple container with same friendly name.
                //Look for resourceGroup name in the container unoque name
                container = containers.Objects.Where(c => c.ParentContainerFriendlyName.ToLower().Equals(rgName.ToLower())).FirstOrDefault();
                if (container == null)
                {
                    //Container is not in list of registered container
                    isDiscoveryNeed = true;
                }
            }
            return isDiscoveryNeed;
        }
    }
}
