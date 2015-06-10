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
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        //[Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine)]
        //[ValidateNotNullOrEmpty]
        //public PSVirtualMachineInstanceView VirtualMachine { get; set; }
        [Parameter(Position = 2, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine)]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineName { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = AzureBackupCmdletHelpMessage.VirtualMachine)]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineRGName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecutionBlock(() =>
            {
                //string vmName = VirtualMachine.Name;
                //string rgName = VirtualMachine.ResourceGroupName;
                string vmName = VirtualMachineName;
                string rgName = VirtualMachineRGName;
                Guid jobId = Guid.Empty;
                bool isDiscoveryNeed = false;
                MBS.OperationResponse operationResponse;

                ContainerInfo container = null;
                isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                if(isDiscoveryNeed)
                {
                    RefreshContainer();
                    isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                    if ((isDiscoveryNeed == true) || (container == null))
                    {
                        //Container is not discovered. Throw exception
                        throw new NotImplementedException();
                    }
                }                

                //Container is discovered. Register the container
                List<string> containerNameList = new List<string>();
                containerNameList.Add(container.Name);
                RegisterContainerRequestInput registrationRequest = new RegisterContainerRequestInput(containerNameList, AzureBackupContainerType.IaasVMContainer.ToString());
                operationResponse = AzureBackupClient.Container.RegisterAsync(registrationRequest, GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                //TODO fix the OperationResponse to JobID conversion
                jobId = operationResponse.OperationId;
                WriteObject(jobId);
            });
        }

        private void RefreshContainer()
        {
            bool isRetyNeeded = true;
            int retryCount = 1;
            bool isDiscoverySuccessful = false;
            while (isRetyNeeded && retryCount <= 3)
            {
                MBS.OperationResponse opResponse =
                    AzureBackupClient.Container.RefreshAsync(GetCustomRequestHeaders(), CmdletCancellationToken).Result;

                //Now wait for the operation to Complete               
                isRetyNeeded = WaitForDiscoveryToCOmplete(opResponse.OperationId.ToString(), out isDiscoverySuccessful);
                retryCount++;
            }

            if (!isDiscoverySuccessful)
            {
                //Discovery failed
                throw new Exception(); //TODO:
            }
        }

        private bool WaitForDiscoveryToCOmplete(string operationId, out bool isDiscoverySuccessful)
        {
            bool isRetryNeeded = false;
            
            
            BMSOperationStatusResponse status = new BMSOperationStatusResponse() 
                        {
                            OperationStatus = AzureBackupOperationStatus.InProgress.ToString() 
                        };

            while (status.OperationStatus != AzureBackupOperationStatus.Completed.ToString())
            {
                status = AzureBackupClient.OperationStatus.GetAsync(operationId, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(15));
            }

            isDiscoverySuccessful = true;
            //If operation fails check if retry is needed or not
            if (status.OperationResult != AzureBackupOperationResult.Succeeded.ToString())
            {
                isDiscoverySuccessful = false;
                if ((status.ErrorCode == AzureBackupOperationErrorCode.DiscoveryInProgress.ToString() ||
                    (status.ErrorCode == AzureBackupOperationErrorCode.BMSUserErrorObjectLocked.ToString())))
                {
                    //Need to retry for this errors
                    isRetryNeeded = true;
                }
            }
            return isRetryNeeded;         
        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, out ContainerInfo container)
        {
            bool isDiscoveryNeed = false;
            //First check if container is discoverd or not
            ListContainerQueryParameter queryParams = new ListContainerQueryParameter();
            queryParams.ContainerTypeField = AzureBackupContainerType.IaasVMContainer.ToString();
            queryParams.ContainerStatusField = String.Empty;
            queryParams.ContainerFriendlyNameField = vmName;
            string queryString = GetQueryFileter(queryParams);

            ListContainerResponse containers = AzureBackupClient.Container.ListAsync(queryString,
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

        private string GetQueryFileter(ListContainerQueryParameter queryParams)
        {
            NameValueCollection collection = new NameValueCollection();
            if (!String.IsNullOrEmpty(queryParams.ContainerTypeField))
            {
                collection.Add("ContainerType", queryParams.ContainerTypeField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerStatusField))
            {
                collection.Add("ContainerStatus", queryParams.ContainerStatusField);
            }

            if (!String.IsNullOrEmpty(queryParams.ContainerFriendlyNameField))
            {
                collection.Add("FriendlyName", queryParams.ContainerFriendlyNameField);
            }

            if (collection == null || collection.Count == 0)
            {
                return String.Empty;
            }

            var httpValueCollection = HttpUtility.ParseQueryString(String.Empty);
            httpValueCollection.Add(collection);

            return "&" + httpValueCollection.ToString();
        }
    }
}
