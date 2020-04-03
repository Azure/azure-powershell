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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Sets recovery properties for the specified replication migration item.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationMigrationItem", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Update-ASRReplicationMigrationItem")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrReplicationMigrationItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the input object to the cmdlet: The ASR replication migration item object corresponding to the replication migration item to update.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationMigrationItem")]
        public ASRReplicationMigrationItem InputObject { get; set; }

        /// <summary>
        ///     Gets or sets the target VM name.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TargetVmName { get; set; }

        /// <summary>
        ///     Gets or sets the target VM size.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TargetVmSize { get; set; }

        /// <summary>
        ///     Gets or sets the target resource group ARM Id.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string TargetResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target availability set ARM Id.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string TargetAvailabilitySetId { get; set; }

        /// <summary>
        ///      Gets or sets the target boot diagnostics storage account ARM Id.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string TargetBootDiagnosticsStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the target network ARM Id.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string TargetNetworkId { get; set; }

        /// <summary>
        ///      Gets or sets the list of NIC details.
        /// </summary>
        [Parameter]
        public List<ASRVMwareCbtNicInput> VmNics { get; set; }

        /// <summary>
        ///     Gets or sets LicenseType for
        ///     HUB https://azure.microsoft.com/en-in/pricing/hybrid-use-benefit/
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NoLicenseType,
            Constants.LicenseTypeWindowsServer)]
        public string LicenseType { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether auto resync is to be done.
        /// </summary>
        [Parameter]
        public SwitchParameter PerformAutoResync { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.Name,
                VerbsCommon.Set))
            {
                var replicationMigrationItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationMigrationItem(
                        Utilities.GetValueFromArmId(
                            this.InputObject.Id,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.Id,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name);

                var provider = replicationMigrationItemResponse.Properties.ProviderSpecificDetails;

                // Check for Replication Provider type VMwareCbt
                if (!(provider is VMwareCbtMigrationDetails))
                {
                    this.WriteWarning(
                        Resources.UnsupportedReplicationProvidedForUpdateVmProperties);
                    return;
                }

                // Check for at least one option
                if (string.IsNullOrEmpty(this.TargetVmName) &&
                    string.IsNullOrEmpty(this.TargetVmSize) &&
                    string.IsNullOrEmpty(this.TargetResourceGroupId) &&
                    string.IsNullOrEmpty(this.TargetAvailabilitySetId) &&
                    string.IsNullOrEmpty(this.TargetBootDiagnosticsStorageAccountId) &&
                    string.IsNullOrEmpty(this.TargetNetworkId) &&
                    string.IsNullOrEmpty(this.LicenseType) &&
                    this.VmNics == null)
                {
                    this.WriteWarning(Resources.ArgumentsMissingForUpdateVmProperties);
                    return;
                }

                var targetVmName = this.TargetVmName;
                var targetVmSize = this.TargetVmSize;
                var targetResourceGroupId = this.TargetResourceGroupId;
                var licenseType = this.LicenseType;
                var targetAvailabilitySetId = this.TargetAvailabilitySetId;
                var targetBootDiagnosticsStorageAccountId = this.TargetBootDiagnosticsStorageAccountId;
                var targetNetworkId = this.TargetNetworkId;
                var performAutoResync = this.PerformAutoResync ? "true" : "false";
                var vmNics = this.VmNics;
                var vmNicInputDetailsList = new List<VMwareCbtNicInput>();

                if (provider is VMwareCbtMigrationDetails)
                {
                    var providerSpecificDetails =
                        (VMwareCbtMigrationDetails)replicationMigrationItemResponse
                            .Properties.ProviderSpecificDetails;

                    if (string.IsNullOrEmpty(this.TargetVmName))
                    {
                        targetVmName = providerSpecificDetails.TargetVmName;
                    }

                    if (string.IsNullOrEmpty(this.TargetVmSize))
                    {
                        targetVmSize = providerSpecificDetails.TargetVmSize;
                    }

                    if (string.IsNullOrEmpty(this.TargetResourceGroupId))
                    {
                        targetResourceGroupId = providerSpecificDetails
                            .TargetResourceGroupId;
                    }

                    if (string.IsNullOrEmpty(this.LicenseType))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    if (string.IsNullOrEmpty(this.TargetAvailabilitySetId))
                    {
                        targetAvailabilitySetId = providerSpecificDetails.TargetAvailabilitySetId;
                    }

                    if (string.IsNullOrEmpty(this.TargetBootDiagnosticsStorageAccountId))
                    {
                        targetBootDiagnosticsStorageAccountId =
                            providerSpecificDetails.TargetBootDiagnosticsStorageAccountId;
                    }

                    if (string.IsNullOrEmpty(this.TargetNetworkId))
                    {
                        targetNetworkId =
                            providerSpecificDetails.TargetNetworkId;
                    }

                    if (this.VmNics == null ||
                       this.VmNics.Count == 0)
                    {
                        foreach (var vmNic in providerSpecificDetails.VmNics)
                        {
                            var nic = new VMwareCbtNicInput
                            {
                                NicId = vmNic.NicId,
                                IsPrimaryNic = vmNic.IsPrimaryNic,
                                TargetSubnetName = vmNic.TargetSubnetName,
                                TargetStaticIPAddress = vmNic.TargetIPAddress,
                                IsSelectedForMigration = vmNic.IsSelectedForMigration
                            };
                            vmNicInputDetailsList.Add(nic);
                        }
                    } else
                    {
                        foreach (var vmNic in this.VmNics)
                        {
                            var nic = new VMwareCbtNicInput
                            {
                                NicId = vmNic.NicId,
                                IsPrimaryNic = vmNic.IsPrimaryNic,
                                TargetSubnetName = vmNic.TargetSubnetName,
                                TargetStaticIPAddress = vmNic.TargetStaticIPAddress,
                                IsSelectedForMigration = vmNic.IsSelectedForMigration
                            };
                            vmNicInputDetailsList.Add(nic);
                        }
                    }

                    var providerSpecificInput =
                        new VMwareCbtUpdateMigrationItemInput
                        {
                            TargetVmName = targetVmName,
                            TargetVmSize = targetVmSize,
                            TargetAvailabilitySetId = targetAvailabilitySetId,
                            TargetBootDiagnosticsStorageAccountId = targetBootDiagnosticsStorageAccountId,
                            TargetNetworkId = targetNetworkId,
                            TargetResourceGroupId = targetResourceGroupId,
                            LicenseType = licenseType == Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                         .NoLicenseType.ToString()
                                         ? Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                         .NoLicenseType
                                         : Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                         .WindowsServer,
                            PerformAutoResync = performAutoResync
                        };
                    providerSpecificInput.VmNics = vmNicInputDetailsList;

                    var updateMigrationItemInputProperties = new UpdateMigrationItemInputProperties
                    {
                        ProviderSpecificDetails = providerSpecificInput
                    };

                    var input = new UpdateMigrationItemInput
                    {
                        Properties = updateMigrationItemInputProperties
                    };

                    var response = this.RecoveryServicesClient.UpdateMigrationItem(
                    Utilities.GetValueFromArmId(
                        this.InputObject.Id,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.InputObject.Id,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.InputObject.Name,
                    input);

                    var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                        PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                    this.WriteObject(new ASRJob(jobResponse));
                }
            }
        }
    }
}
