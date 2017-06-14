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
using Microsoft.Azure.Commands.AzureBackup.Models;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Get list of containers
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "AzureRmBackupContainer"), OutputType(typeof(AzureRMBackupJob))]
    public class RegisterAzureRMBackupContainer : AzureBackupVaultCmdletBase
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

                if (this.ParameterSetName == V1VMParameterSet)
                {
                    vmName = Name;
                    rgName = ServiceName;
                    WriteDebug(String.Format(Resources.RegisteringARMVM1, vmName, rgName));
                    ServiceOrRG = "CloudServiceName";
                }
                else if (this.ParameterSetName == V2VMParameterSet)
                {
                    vmName = Name;
                    rgName = ResourceGroupName;
                    WriteDebug(String.Format(Resources.RegisteringARMVM2, vmName, rgName));
                    ServiceOrRG = "ResourceGroupName";
                }

                else
                {
                    throw new PSArgumentException(Resources.PSArgumentException); //TODO: PM scrub needed
                }

                Guid jobId = Guid.Empty;
                bool isDiscoveryNeed = false;

                CSMContainerResponse container = null;
                isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                if (isDiscoveryNeed)
                {
                    WriteDebug(String.Format(Resources.VMNotDiscovered, vmName));
                    RefreshContainer(Vault.ResourceGroupName, Vault.Name);
                    isDiscoveryNeed = IsDiscoveryNeeded(vmName, rgName, out container);
                    if ((isDiscoveryNeed == true) || (container == null))
                    {
                        //Container is not discovered. Throw exception
                        string errMsg = String.Format(Resources.DiscoveryFailure, vmName, ServiceOrRG, rgName);
                        WriteDebug(errMsg);
                        ThrowTerminatingError(new ErrorRecord(new Exception(Resources.AzureVMNotFound), string.Empty, ErrorCategory.InvalidArgument, null));
                    }
                }

                //Container is discovered. Register the container
                WriteDebug(String.Format(Resources.RegisteringVM, vmName));
                var operationId = AzureBackupClient.RegisterContainer(Vault.ResourceGroupName, Vault.Name, container.Name);

                var operationStatus = GetOperationStatus(Vault.ResourceGroupName, Vault.Name, operationId);
                WriteObject(GetCreatedJobs(Vault.ResourceGroupName, Vault.Name, Vault, operationStatus.JobList).FirstOrDefault());
            });
        }

        private void RefreshContainer(string resourceGroupName, string resourceName)
        {
            bool isRetryNeeded = true;
            int retryCount = 1;
            bool isDiscoverySuccessful = false;
            string errorMessage = string.Empty;
            while (isRetryNeeded && retryCount <= 3)
            {
                var operationId = AzureBackupClient.RefreshContainers(resourceGroupName, resourceName);

                //Now wait for the operation to Complete               
                isRetryNeeded = WaitForDiscoveryToComplete(resourceGroupName, resourceName, operationId, out isDiscoverySuccessful, out errorMessage);
                retryCount++;
            }

            if (!isDiscoverySuccessful)
            {
                ThrowTerminatingError(new ErrorRecord(new Exception(errorMessage), string.Empty, ErrorCategory.InvalidArgument, null));
            }
        }

        private bool WaitForDiscoveryToComplete(string resourceGroupName, string resourceName, Guid operationId, out bool isDiscoverySuccessful, out string errorMessage)
        {
            bool isRetryNeeded = false;
            var status = TrackOperation(resourceGroupName, resourceName, operationId);
            errorMessage = String.Empty;

            isDiscoverySuccessful = true;
            //If operation fails check if retry is needed or not
            if (status.Status != CSMAzureBackupOperationStatus.Succeeded.ToString())
            {
                isDiscoverySuccessful = false;
                errorMessage = status.Error.Message;
                WriteDebug(String.Format(Resources.DiscoveryFailureErrorCode, status.Error.Code));
                if ((status.Error.Code == AzureBackupOperationErrorCode.DiscoveryInProgress.ToString() ||
                    (status.Error.Code == AzureBackupOperationErrorCode.BMSUserErrorObjectLocked.ToString())))
                {
                    //Need to retry for this errors
                    isRetryNeeded = true;
                    WriteDebug(String.Format(Resources.RertyDiscovery));
                }
            }
            return isRetryNeeded;
        }

        private bool IsDiscoveryNeeded(string vmName, string rgName, out CSMContainerResponse container)
        {
            bool isDiscoveryNeed = false;
            ContainerQueryParameters parameters = new ContainerQueryParameters()
            {
                ContainerType = ManagedContainerType.IaasVM.ToString(),
                FriendlyName = vmName,
                Status = AzureBackupContainerRegistrationStatus.NotRegistered.ToString(),
            };

            //First check if container is discovered or not            
            var containers = AzureBackupClient.ListContainers(Vault.ResourceGroupName, Vault.Name, parameters);
            WriteDebug(String.Format(Resources.ContainerCountFromService, containers.Count()));
            if (containers.Count() == 0)
            {
                //Container is not discover
                WriteDebug(Resources.ContainerNotDiscovered);
                container = null;
                isDiscoveryNeed = true;
            }

            else
            {
                //We can have multiple container with same friendly name. 
                container = containers.Where(c => ContainerHelpers.GetRGNameFromId(c.Properties.ParentContainerId).Equals(rgName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (container == null)
                {
                    //Container is not in list of registered container
                    WriteDebug(String.Format(Resources.DesiredContainerNotFound));
                    isDiscoveryNeed = true;
                }
            }
            return isDiscoveryNeed;
        }
    }
}
