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
using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Enables migration for an ASR item by creating a replication migration item.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationMigrationItem", SupportsShouldProcess = true)]
    [Alias("New-ASRReplicationMigrationItem")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrReplicationMigrationItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets a name for the ASR replication migration item. The name must be unique within the vault.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the ASR protection container mapping object corresponding to
        ///     the replication policy to be used for replication.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets the ARM Id of the VM discovered in VMware.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string VMwareMachineId { get; set; }

        /// <summary>
        ///     Gets or sets the disks to include list.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRVMwareCbtDiskInput[] DisksToInclude { get; set; }

        /// <summary>
        ///     Gets or sets the name of the operating system disk.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NoLicenseType,
            Constants.LicenseTypeWindowsServer)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the data mover runas account Id.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DataMoverRunAsAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the snapshot runas account Id.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SnapshotRunAsAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the target VM name.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetVmName { get; set; }

        /// <summary>
        ///     Gets or sets the target VM size.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetVmSize { get; set; }

        /// <summary>
        ///     Gets or sets the target resource group ARM Id.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target resource group ARM Id.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TargetNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the target subnet name.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string TargetSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the target availability set ARM Id.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string TargetAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets the target boot diagnostics storage account ARM Id.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string TargetBootDiagnosticsStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether auto resync is to be done.
        /// </summary>
        [Parameter]
        public SwitchParameter PerformAutoResync { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(this.Name, VerbsCommon.New))
            {
                var policy = this.RecoveryServicesClient.GetAzureSiteRecoveryPolicy(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.PolicyId,
                        ARMResourceTypeConstants.ReplicationPolicies));
                var policyInstanceType = policy.Properties.ProviderSpecificDetails;

                var enableMigrationProviderSpecificInput =
                    new EnableMigrationProviderSpecificInput();
                    
                var inputProperties = new EnableMigrationInputProperties
                {
                    PolicyId = this.ProtectionContainerMapping.PolicyId,
                    ProviderSpecificDetails = enableMigrationProviderSpecificInput
                };

                var input = new EnableMigrationInput { Properties = inputProperties };

                if (!(policyInstanceType is VmwareCbtPolicyDetails))
                {
                    throw new PSArgumentException(
                        string.Format(
                            Resources.ContainerMappingParameterSetMismatch,
                            this.ProtectionContainerMapping.Name,
                            policyInstanceType));
                }

                VMwareCbtMigration(input);

                this.response = this.RecoveryServicesClient.EnableMigration(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.Name,
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

        private void VMwareCbtMigration(EnableMigrationInput input)
        {
            var providerSettings = new VMwareCbtEnableMigrationInput
            {
                VmwareMachineId = this.VMwareMachineId,
                LicenseType = this.LicenseType,
                DataMoverRunAsAccountId = this.DataMoverRunAsAccountId,
                SnapshotRunAsAccountId = this.SnapshotRunAsAccountId,
                TargetVmName = this.TargetVmName,
                TargetVmSize = this.TargetVmSize,
                TargetResourceGroupId = this.TargetResourceGroupId,
                TargetNetworkId = this.TargetNetworkId,
                TargetSubnetName = this.TargetSubnetName,
                TargetAvailabilitySetId = this.TargetAvailabilitySetId,
                TargetBootDiagnosticsStorageAccountId = this.TargetBootDiagnosticsStorageAccountId,
                PerformAutoResync = this.PerformAutoResync ? "true" : "false"
            };

            if (this.IsParameterBound(c => c.DisksToInclude))
            {
                List<VMwareCbtDiskInput> vmwareCbtDiskInput = DisksToInclude.Select(
                    p => new VMwareCbtDiskInput()
                    {
                        DiskId = p.DiskId,
                        IsOSDisk = p.IsOSDisk,
                        LogStorageAccountId = p.LogStorageAccountId,
                        LogStorageAccountSasSecretName = p.LogStorageAccountSasSecretName,
                        DiskType = p.DiskType,
                        DiskEncryptionSetId = p.DiskEncryptionSetId
                    }).ToList();
                providerSettings.DisksToInclude = vmwareCbtDiskInput;
            }

            // Set the VmwareCbt Provider specific input in the Enable Migration Input.
            input.Properties.ProviderSpecificDetails = providerSettings;
        }

        private Job jobResponse;

        /// <summary>
        ///     Job response.
        /// </summary>
        private PSSiteRecoveryLongRunningOperation response;
    }
}
