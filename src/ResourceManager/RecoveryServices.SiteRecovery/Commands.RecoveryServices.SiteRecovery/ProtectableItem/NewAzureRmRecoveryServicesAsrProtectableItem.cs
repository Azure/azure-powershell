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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Add(Discover) a physical server to the list of protectable items.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrProtectableItem",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("New-ASRProtectableItem")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrProtectableItem : SiteRecoveryCmdletBase
    {
        #region Public Parameters

        /// <summary>
        ///     Gets or sets the protection container object to which the protectable item should be added.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }

        /// <summary>
        ///     Gets or sets the friendly name for the protectable item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets IPAddress of the Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string IPAddress { get; set; }

        /// <summary>
        ///     Gets or sets OS Type of the Protectable Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OSWindows,
            Constants.OSLinux)]
        public string OSType { get; set; }

        #endregion Public Parameters
        
        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.FriendlyName,
                VerbsCommon.New))
            {
                // Validate the Fabric Type for VMWare.
                if (this.ProtectionContainer.FabricType != Constants.VMware)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.UnsupportedFabricTypeForDiscoverVirtualMachines,
                            this.ProtectionContainer.FabricType));
                }

                // Set the Fabric Name.
                this.fabricName = Utilities.GetValueFromArmId(
                    this.ProtectionContainer.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                // Create the Discover Protectable Item input request.
                var input = new DiscoverProtectableItemRequest
                {
                    Properties = new DiscoverProtectableItemRequestProperties
                    {
                        FriendlyName = this.FriendlyName,
                        IpAddress = this.IPAddress,
                        OsType = this.OSType
                    }
                };

                // Discover the Protectable Item.
                var response = this.RecoveryServicesClient.NewAzureSiteRecoveryProtectableItem(
                    this.fabricName,
                    this.ProtectionContainer.Name,
                    input);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(
                        response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
        #region Local Parameters

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        #endregion Local Parameters
    }
}