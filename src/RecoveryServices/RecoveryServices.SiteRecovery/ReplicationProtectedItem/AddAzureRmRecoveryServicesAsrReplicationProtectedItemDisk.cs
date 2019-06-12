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
    /// Adds disks to replication protected item.
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItemDisk",
        DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
        SupportsShouldProcess = true)]
    [Alias("Add-ASRReplicationProtectedItemDisk")]
    [OutputType(typeof(ASRJob))]
    public class AddAzureRmRecoveryServicesAsrReplicationProtectedItemDisk : SiteRecoveryCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationProtectedItem")]
        public ASRReplicationProtectedItem InputObject { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureDiskReplicationConfiguration { get; set; }

        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (ShouldProcess(this.InputObject.FriendlyName, VerbsCommon.Add))
            {
                // check for A2A protected item - if providerSpecificDetails is A2AReplicationDetails.

                var addDisksProviderSpecificInput = new AddDisksProviderSpecificInput();
                var inputProperties = new AddDisksInputProperties
                {
                    ProviderSpecificDetails = addDisksProviderSpecificInput
                };
                var input = new AddDisksInput { Properties = inputProperties };
                AzureToAzureReplication(input);

                this.response = this.RecoveryServicesClient.AddDisks(
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.InputObject.Name,
                    input);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(this.response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));

                if (this.WaitForCompletion.IsPresent)
                {
                    this.WaitForJobCompletion(this.jobResponse.Name);

                    this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                        PSRecoveryServicesClient
                            .GetJobIdFromReponseLocation(this.response.Location));

                    this.WriteObject(new ASRJob(this.jobResponse));
                }
            }
        }

        /// <summary>
        /// Helper method to fill in input details.
        /// </summary>
        private void AzureToAzureReplication(AddDisksInput input)
        {
            var providerSettings = new A2AAddDisksInput()
            {
                VmDisks = new List<A2AVmDiskInputDetails>(),
                VmManagedDisks = new List<A2AVmManagedDiskInputDetails>()
            };

            foreach (ASRAzuretoAzureDiskReplicationConfig disk in this.AzureToAzureDiskReplicationConfiguration)
            {
                if (disk.IsManagedDisk)
                {
                    providerSettings.VmManagedDisks.Add(new A2AVmManagedDiskInputDetails
                    {
                        DiskId = disk.DiskId,
                        RecoveryResourceGroupId = disk.RecoveryResourceGroupId,
                        PrimaryStagingAzureStorageAccountId = disk.LogStorageAccountId,
                        RecoveryReplicaDiskAccountType = disk.RecoveryReplicaDiskAccountType,
                        RecoveryTargetDiskAccountType = disk.RecoveryTargetDiskAccountType
                    });
                }
                else
                {
                    providerSettings.VmDisks.Add(new A2AVmDiskInputDetails
                    {
                        DiskUri = disk.VhdUri,
                        RecoveryAzureStorageAccountId = disk.RecoveryAzureStorageAccountId,
                        PrimaryStagingAzureStorageAccountId = disk.LogStorageAccountId
                    });
                }
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

        /// <summary>
        /// Job response.
        /// </summary>
        private PSSiteRecoveryLongRunningOperation response;
    }
}