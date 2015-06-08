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
using  Microsoft.Azure.Commands.Compute.Models;


namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "AzureBackupContainer"), OutputType(typeof(Guid))]
    public class UnregisterAzureBackupContainer : AzureBackupVaultCmdletBase
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

                ListContainerQueryParameter queryParams = new ListContainerQueryParameter();
                queryParams.ContainerStatusField = "Registered"; //TODO: Use enum
                queryParams.ContainerFriendlyNameField = vmName;

                ListContainerResponse containers = 
                AzureBackupClient.Container.ListAsync(queryParams, 
                                GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                if(containers.Objects.Count() == 0)
                {
                    WriteVerbose("Container is not in the registered list");
                    jobId = Guid.Empty;
                }
                
                else
                {
                    //We can havemultiple container with same friendly name.
                    //Look for resourceGroup name in the ParentFriendlyName
                    ContainerInfo containerToUnreg = containers.Objects.Where(c => c.ParentContainerFriendlyName.ToLower().Equals(rgName.ToLower())).FirstOrDefault();
                    if (containerToUnreg == null)
                    {
                        //Container is not in list of registered container
                        jobId = Guid.Empty;
                    }
                    else
                    {
                        UnregisterContainerRequest unregRequest = new UnregisterContainerRequest(containerToUnreg.Name, "IaasVMContainer"); //TODO: Use enum
                        MBS.OperationResponse operationResponse = AzureBackupClient.Container.UnregisterAsync(unregRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                        jobId = operationResponse.OperationId; //TODO: Fix it once PiyushKa publish the rest APi to get jobId based on operationId                        
                    }
                }

                WriteObject(jobId);
            });
        }
    }
}
