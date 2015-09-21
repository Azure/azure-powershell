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
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Set Protection Entity protection state.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.EnterpriseToEnterprise, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryProtectionEntity : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private LongRunningOperationResponse response = null;

        /// <summary>
        /// Holds either Name (if object is passed) or ID (if IDs are passed) of the PE.
        /// </summary>
        private string targetNameOrId = string.Empty;

        /// <summary>
        /// Gets or sets Protection Entity Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Protection profile.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets Protection to set, either enable or disable.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToEnterprise, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.EnableProtection,
            Constants.DisableProtection)]
        public string Protection { get; set; }

        /// <summary>
        /// Gets or sets OS disk name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.EnterpriseToAzure)]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        JobResponse jobResponse = null;

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.targetNameOrId = this.ProtectionEntity.FriendlyName;
            this.ConfirmAction(
                this.Force.IsPresent || 0 != string.CompareOrdinal(this.Protection, Constants.DisableProtection),
                string.Format(Properties.Resources.DisableProtectionWarning, this.targetNameOrId),
                string.Format(Properties.Resources.DisableProtectionWhatIfMessage, this.Protection),
                this.targetNameOrId,
                () =>
                    {
                        try
                        {
                            if (this.Protection == Constants.EnableProtection)
                            {
                                EnableProtectionInput input = new EnableProtectionInput();
                                
                                // Considering no PP input for E2E, if needed, change below logic
                                // for E2E, consider the profile created PS & a profile created in service
                                if (this.ProtectionProfile != null &&
                                    0 == string.Compare(
                                    this.ProtectionProfile.ReplicationProvider,
                                    Constants.HyperVReplicaAzure,
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    input.ProtectionProfileId = this.ProtectionProfile.Name;
                                    AzureEnableProtectionInput providerSettings = new AzureEnableProtectionInput();
                                    providerSettings.HvHostVmId = this.ProtectionEntity.FabricObjectId;
                                    providerSettings.VmName = this.ProtectionEntity.FriendlyName;

                                    // Id disk details are missing in input PE object, get the latest PE.
                                    // As get PE by name is failing before protection, get all & filter.
                                    // Once after we fix get pe by name, change the logic to use the same.
                                    if (string.IsNullOrEmpty(this.ProtectionEntity.OS))
                                    {
                                        // Just checked for OS to see whether the disk details got filled up or not
                                        ProtectionEntityListResponse protectionEntityListResponse =
                                            RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                                            this.ProtectionEntity.ProtectionContainerId);

                                        foreach (ProtectionEntity pe in protectionEntityListResponse.ProtectionEntities)
                                        {
                                            if (0 == string.Compare(this.ProtectionEntity.FriendlyName, pe.Properties.FriendlyName, true))
                                            {
                                                this.ProtectionEntity = new ASRProtectionEntity(pe);
                                                break;
                                            }
                                        }
                                    }
                                    providerSettings.OSType = this.ProtectionEntity.OS;

                                    if (string.IsNullOrWhiteSpace(this.OSDiskName))
                                    {
                                        providerSettings.VHDId = this.ProtectionEntity.OSDiskId;
                                    }
                                    else
                                    {
                                        foreach (var disk in this.ProtectionEntity.Disks)
                                        {
                                            if (0 == string.Compare(disk.Name, this.OSDiskName, true))
                                            {
                                                providerSettings.VHDId = disk.Id;
                                                break;
                                            }
                                        }
                                    }

                                    input.ProviderSettings = providerSettings;
                                }

                                this.response =
                                    RecoveryServicesClient.EnableProtection(
                                    this.ProtectionEntity.ProtectionContainerId,
                                    this.ProtectionEntity.Name,
                                    input);
                            }
                            else
                            {
                                DisableProtectionInput input = new DisableProtectionInput();

                                this.response =
                                    RecoveryServicesClient.DisableProtection(
                                    this.ProtectionEntity.ProtectionContainerId,
                                    this.ProtectionEntity.Name,
                                    input);
                            }

                            jobResponse =
                                RecoveryServicesClient
                                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                            WriteObject(new ASRJob(jobResponse.Job));

                            if (this.WaitForCompletion.IsPresent)
                            {
                                this.WaitForJobCompletion(this.jobResponse.Job.Name);
                            }
                        }
                        catch (Exception exception)
                        {
                            this.HandleException(exception);
                        }
                    });
        }

        /// <summary>
        /// Writes Job.
        /// </summary>
        /// <param name="job">JOB object</param>
        private void WriteJob(Microsoft.Azure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}