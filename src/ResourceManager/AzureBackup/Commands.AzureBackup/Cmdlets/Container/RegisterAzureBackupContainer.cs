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
using Microsoft.Azure.Management.BackupServices.Models;
using MBS = Microsoft.Azure.Management.BackupServices;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Management.BackupServices;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureBackupContainer", DefaultParameterSetName = V1VMParameterSet), OutputType(typeof(AzureBackupJob))]
    public class RegisterAzureBackupContainer : AzureBackupVaultCmdletBase
    {
        internal const string V1VMParameterSet = "V1VM";
        internal const string V2VMParameterSet = "V2VM";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = V1VMParameterSet, HelpMessage = AzureBackupCmdletHelpMessage.VMName)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = V2VMParameterSet, HelpMessage = AzureBackupCmdletHelpMessage.VMName)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = V1VMParameterSet, HelpMessage = AzureBackupCmdletHelpMessage.ServiceName)]
        public string ServiceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = V2VMParameterSet, HelpMessage = AzureBackupCmdletHelpMessage.RGName)]
        public string ResourceGroupName { get; set; }

        
        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                base.ExecuteCmdlet();

                string vmName = String.Empty;
                string rgName = String.Empty;
                string ServiceOrRG = String.Empty;

                if(this.ParameterSetName == V1VMParameterSet)
                {
                    vmName = Name;
                    rgName = ServiceName;
                    WriteDebug(String.Format("Registering ARM-V1 VM, VMName: {0}, CloudServiceName: {1}", vmName, rgName));
                    ServiceOrRG = "CloudServiceName";
                }
                else if(this.ParameterSetName == V2VMParameterSet)
                {
                    vmName = Name;
                    rgName = ResourceGroupName;
                    WriteDebug(String.Format("Registering ARM-V2 VM, VMName: {0}, ResourceGroupName: {1}", vmName, rgName));
                    ServiceOrRG = "ResourceGroupName";
                }

                else
                {
                    throw new PSArgumentException("Please make sure you have pass right set of parameters"); //TODO: PM scrub needed
                }

                Guid jobId = Guid.Empty;
                bool isDiscoveryNeed = false;

                CSMContainerResponse container = null;
                isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                if(isDiscoveryNeed)
                {
                    WriteDebug(String.Format("VM {0} is not yet discovered. Triggering Discovery", vmName));
                    RefreshContainer();
                    isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                    if ((isDiscoveryNeed == true) || (container == null))
                    {
                        //Container is not discovered. Throw exception
                        string errMsg = String.Format("Failed to discover VM {0} under {1} {2}. Please make sure names are correct and VM is not deleted", vmName, ServiceOrRG, rgName);
                        WriteDebug(errMsg);
                        ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
                    }
                }                

                //Container is discovered. Register the container
                WriteDebug(String.Format("Going to register VM {0}", vmName));
                var operationId = AzureBackupClient.RegisterContainer(container.Name);

                var operationStatus = GetOperationStatus(operationId);
                WriteObject(GetCreatedJobs(Vault, operationStatus.JobList).FirstOrDefault());
            });
        }

        private void RefreshContainer()
        {
            bool isRetryNeeded = true;
            int retryCount = 1;
            bool isDiscoverySuccessful = false;
            string errorMessage = string.Empty;
            while (isRetryNeeded && retryCount <= 3)
            {
                var operationId = AzureBackupClient.RefreshContainers();

                //Now wait for the operation to Complete               
                isRetryNeeded = WaitForDiscoveryToComplete(operationId, out isDiscoverySuccessful, out errorMessage);
                retryCount++;
            }

            if (!isDiscoverySuccessful)
            {
                ThrowTerminatingError(new ErrorRecord(new Exception(errorMessage), string.Empty, ErrorCategory.InvalidArgument, null));
            }
        }

        private bool WaitForDiscoveryToComplete(Guid operationId, out bool isDiscoverySuccessful, out string errorMessage)
        {
            bool isRetryNeeded = false;
            var status = TrackOperation(operationId);
            errorMessage = String.Empty;

            isDiscoverySuccessful = true;
            //If operation fails check if retry is needed or not
            if (status.Status != CSMAzureBackupOperationStatus.Succeeded.ToString())
            {
                isDiscoverySuccessful = false;
                errorMessage = status.Error.Message;
                WriteDebug(String.Format("Discovery operation failed with ErrorCode: {0}", status.Error.Code));
                if ((status.Error.Code == AzureBackupOperationErrorCode.DiscoveryInProgress.ToString() ||
                    (status.Error.Code == AzureBackupOperationErrorCode.BMSUserErrorObjectLocked.ToString())))
                {
                    //Need to retry for this errors
                    isRetryNeeded = true;
                    WriteDebug(String.Format("Going to retry Discovery if retry count is not exceeded"));
                }
            }
            return isRetryNeeded;         
        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, out CSMContainerResponse container)
        {
            bool isDiscoveryNeed = false;
            //First check if container is discoverd or not
            ListContainerQueryParameter queryParams = new ListContainerQueryParameter();
            queryParams.ContainerTypeField = ManagedContainerType.IaasVMContainer.ToString();
            queryParams.ContainerStatusField = String.Empty;
            queryParams.ContainerFriendlyNameField = vmName;
            string queryString = ContainerHelpers.GetQueryFilter(queryParams);

            var containers = AzureBackupClient.ListContainers(queryString);
            WriteDebug(String.Format("Container count returned from service: {0}.", containers.Count()));
            if (containers.Count() == 0)
            {
                //Container is not discover
                WriteDebug("Container is not discovered");
                container = null;
                isDiscoveryNeed = true;
            }

            else
            {
                //We can have multiple container with same friendly name. 
                container = containers.Where(c => ContainerHelpers.GetRGNameFromId(c.Properties.ParentContainerId).Equals(rgName.ToLower())).FirstOrDefault(); //TODO need to change.
                if (container == null)
                {
                    //Container is not in list of registered container
                    WriteDebug(String.Format("Desired Container is not found. Returning with isDiscoveryNeed = true"));
                    isDiscoveryNeed = true;
                }
            }
            return isDiscoveryNeed;
        }
    }
}
