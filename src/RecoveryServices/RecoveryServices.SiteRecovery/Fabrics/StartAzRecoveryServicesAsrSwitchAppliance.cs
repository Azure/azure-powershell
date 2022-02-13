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
    ///     Switch replication from one Process server to another for load balancing.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrSwitchAppliance", DefaultParameterSetName = ASRParameterSets.Default, SupportsShouldProcess = true)]
    [Alias("Start-ASRSwitchAppliance")]
    [OutputType(typeof(ASRJob))]
    public class StartAzRecoveryServicesAsrSwitchAppliance : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the fabric corresponding to the Configuration Server.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets the replication protected item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicatedItem")]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets the name of appliance to switch replication to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TargetApplianceName { get; set; }

        /// <summary>
        ///     Gets or sets the name of credentials to be used to push install the mobility service
        ///     on source machine if needed.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string CredentialsToAccessVm { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.ReplicationProtectedItem.FriendlyName,
                "Switch the appliance"))
            {
                // Set the Fabric Name and Protection Container Name.
                string fabricName = this.Fabric.Name;
                string protectionContainerName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);

                var updateApplianceInput = new UpdateApplianceForReplicationProtectedItemInputProperties();
                if (this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.InMageRcm))
                {
                    this.InMageRcmValidateSwitchApplianceInput();
                    this.InMageRcmSwitchAppliance(updateApplianceInput);
                }
                else
                {
                    throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderOperation,
                        this.ReplicationProtectedItem.ReplicationProvider,
                        "SwitchAppliance"));
                }

                var input = new UpdateApplianceForReplicationProtectedItemInput
                {
                    Properties = updateApplianceInput
                };

                // Switch the appliance for protected item.
                var response = this.RecoveryServicesClient.SwitchAppliance(
                    fabricName,
                    protectionContainerName,
                    this.ReplicationProtectedItem.Name,
                    input);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        /// <summary>
        ///     Validates the InMageRcm provider switch appliance input.
        /// </summary>
        private void InMageRcmValidateSwitchApplianceInput()
        {
            ASRInMageRcmSpecificRPIDetails specificRPIDetails =
                this.ReplicationProtectedItem.ProviderSpecificDetails as ASRInMageRcmSpecificRPIDetails;
            if (specificRPIDetails.ProcessServerName.Equals(
                this.TargetApplianceName,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.TargetApplianceAlreadyMapped,
                        this.TargetApplianceName,
                        this.ReplicationProtectedItem.FriendlyName));
            }

            ASRInMageRcmFabricSpecificDetails fabricSpecificDetails =
                this.Fabric.FabricSpecificDetails as ASRInMageRcmFabricSpecificDetails;

            var processServer = fabricSpecificDetails
                .ProcessServers
                .Where(x => x.Name == this.TargetApplianceName)
                .FirstOrDefault();
            if (processServer == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ApplianceNotFound,
                        this.TargetApplianceName));
            }

            this.targetApplianceId = processServer.Id;

            // Todo(Prmyaka): Handle accountIds with same name.
            // Todo(Prmyaka): Handle accountIds where physical server protected.
            if (this.CredentialsToAccessVm != null)
            {
                VMwareRunAsAccount runAsAccount =
                    this.FabricDiscoveryClient.GetAzureSiteRecoveryRunAsAccounts(
                        fabricSpecificDetails.VmwareSiteId)
                    .Where(x => x.Properties.DisplayName.Equals(
                            this.CredentialsToAccessVm, StringComparison.OrdinalIgnoreCase) &&
                        x.Properties.ApplianceName.Equals(
                            this.TargetApplianceName, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                if (runAsAccount == null)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.RunAsAccountNotFound,
                            this.CredentialsToAccessVm,
                            this.TargetApplianceName,
                            fabricSpecificDetails.VmwareSiteId));
                }

                this.runAsAccountId = runAsAccount.Id;
            }
        }

        /// <summary>
        ///     InMageRcm provider switch appliance input.
        /// </summary>
        private void InMageRcmSwitchAppliance(UpdateApplianceForReplicationProtectedItemInputProperties input)
        {
            var inMageRcmSwitchApplianceInput =
                new InMageRcmUpdateApplianceForReplicationProtectedItemInput();

            if (this.runAsAccountId != null)
            {
                inMageRcmSwitchApplianceInput.RunAsAccountId =
                    this.runAsAccountId;
            }

            input.TargetApplianceId = this.targetApplianceId;
            input.ProviderSpecificDetails = inMageRcmSwitchApplianceInput;
        }

        #region Private parameters

        /// <summary>
        ///     Gets or sets the target appliance Id.
        /// </summary>
        private string targetApplianceId;

        /// <summary>
        ///     Gets or sets run as account Id.
        /// </summary>
        private string runAsAccountId;

        #endregion
    }
}
