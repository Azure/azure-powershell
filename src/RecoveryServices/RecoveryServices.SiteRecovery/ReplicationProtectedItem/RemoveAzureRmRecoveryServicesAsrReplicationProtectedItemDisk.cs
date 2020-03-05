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

using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    /// Removes disks to replication protected item.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItemDisk", DefaultParameterSetName = ASRParameterSets.AzureToAzure, SupportsShouldProcess = true)]
    [Alias("Remove-ASRReplicationProtectedItemDisk")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrReplicationProtectedItemDisk : SiteRecoveryCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationProtectedItem")]
        public ASRReplicationProtectedItem InputObject { get; set; }

        /// <summary>
        /// Gets or sets the disk uri.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] VhdUri { get; set; }

        /// <summary>
        /// Gets or sets the disk Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] DiskId { get; set; }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            // check for A2A protected item - if providerSpecificDetails is A2AReplicationDetails.

            var removeDisksProviderSpecificInput = new RemoveDisksProviderSpecificInput();
            var inputProperties = new RemoveDisksInputProperties
            {
                ProviderSpecificDetails = removeDisksProviderSpecificInput
            };
            var input = new RemoveDisksInput { Properties = inputProperties };
            FillRemoveDiskInputForAzureToAzureReplication(input);

            if (this.ShouldProcess(
                this.InputObject.FriendlyName,
                "Removes the protected disk"))
            {
                PSSiteRecoveryLongRunningOperation response =
                    this.RecoveryServicesClient.RemoveDisks(
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name,
                        input);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));
            }
        }

        /// <summary>
        /// Helper method to fill in input details.
        /// </summary>
        private void FillRemoveDiskInputForAzureToAzureReplication(RemoveDisksInput input)
        {
            var providerSettings = new A2ARemoveDisksInput()
            {
                VmDisksUris = new List<string>(),
                VmManagedDisksIds = new List<string>()
            };

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.AzureToAzure:
                    providerSettings.VmDisksUris = this.VhdUri;
                    break;
                case ASRParameterSets.AzureToAzureManagedDisk:
                    providerSettings.VmManagedDisksIds = this.DiskId;
                    break;
            }

            input.Properties.ProviderSpecificDetails = providerSettings;
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">Job object.</param>
        private void WriteJob(
            Job job)
        {
            this.WriteObject(new ASRJob(job));
        }

        private Job jobResponse;
    }
}
