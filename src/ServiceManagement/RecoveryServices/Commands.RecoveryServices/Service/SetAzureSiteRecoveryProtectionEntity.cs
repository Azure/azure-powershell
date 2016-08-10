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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Set Protection Entity protection state.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.ByPEObject, SupportsShouldProcess = true)]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryProtectionEntity : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Job response.
        /// </summary>
        private JobResponse jobResponse = null;

        /// <summary>
        /// Protection Status of the entity.
        /// </summary>
        private bool alreadyEnabled = false;

        /// <summary>
        /// Holds either Name (if object is passed) or ID (if IDs are passed) of the PE.
        /// </summary>
        private string targetNameOrId = string.Empty;

        /// <summary>
        /// Gets or sets ID of the Virtual Machine.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByIDs, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets ID of the ProtectionContainer containing the Virtual Machine.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByIDs, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ProtectionContainerId { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Protection profile.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public ASRProtectionProfile ProtectionProfile { get; set; }

        /// <summary>
        /// Gets or sets Protection to set, either enable or disable.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.EnableProtection,
            Constants.DisableProtection)]
        public string Protection { get; set; }

        /// <summary>
        /// Gets or sets OS disk name.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        /// <summary>
        /// Gets or sets OS.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.OSWindows,
            Constants.OSLinux)]
        public string OS { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command waits till completion.
        /// </summary>
        [Parameter]
        public SwitchParameter WaitForCompletion { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.WriteWarningWithTimestamp(
                string.Format(
                    Properties.Resources.CmdletWillBeDeprecatedSoon,
                    this.MyInvocation.MyCommand.Name));

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByPEObject:
                    this.Id = this.ProtectionEntity.ID;
                    this.ProtectionContainerId = this.ProtectionEntity.ProtectionContainerId;
                    this.targetNameOrId = this.ProtectionEntity.Name;
                    this.alreadyEnabled = this.ProtectionEntity.Protected;

                    break;
                case ASRParameterSets.ByIDs:
                    this.targetNameOrId = this.Id;
                    ProtectionEntityResponse protectionEntityResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                        this.ProtectionContainerId,
                        this.Id);
                    this.alreadyEnabled = protectionEntityResponse.ProtectionEntity.Protected;
                    this.targetNameOrId = protectionEntityResponse.ProtectionEntity.Name;

                    break;
            }

            if (this.alreadyEnabled &&
                this.Protection.Equals(Constants.EnableProtection, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    string.Format(                   
                        Properties.Resources.ProtectionEntityAlreadyEnabled,
                        this.targetNameOrId));
            }
            else if (!this.alreadyEnabled &&
                this.Protection.Equals(Constants.DisableProtection, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    Properties.Resources.ProtectionEntityAlreadyDisabled,
                    this.targetNameOrId);
            }

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
                                string profileId = string.Empty;
                                var input = new EnableProtectionInput();

                                if (this.ProtectionEntity == null)
                                {
                                    var pe = RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                                        this.ProtectionContainerId,
                                        this.Id);
                                    this.ProtectionEntity = new ASRProtectionEntity(pe.ProtectionEntity);
                                }

                                // Get the replciation provider from profile object otherwise assume its E2E.
                                // Let the call go without profileId set.
                                string replicationProvider = null;

                                if (this.ProtectionProfile != null)
                                {
                                    profileId = this.ProtectionProfile.ID;
                                    replicationProvider = this.ProtectionProfile.ReplicationProvider;
                                }
                                else
                                {
                                    string pcId = this.ProtectionContainerId ?? this.ProtectionEntity.ProtectionContainerId;
                                    var pc = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(
                                        pcId);

                                    // PC will have all profiles associated with same replciation providers only.
                                    replicationProvider =
                                        pc.ProtectionContainer.AvailableProtectionProfiles.Count < 1 ?
                                        null :
                                        pc.ProtectionContainer.AvailableProtectionProfiles[0].ReplicationProvider;

                                    if (replicationProvider != Constants.HyperVReplica)
                                    {
                                        throw new Exception("Please provide the protection profile object. It can be chosen from available protection profiles of the protection container.");
                                    }
                                }

                                if (this.ParameterSetName == ASRParameterSets.ByIDs)
                                {
                                    this.ValidateUsageById(replicationProvider, "Id");
                                }

                                if (replicationProvider == Constants.HyperVReplicaAzure)
                                {
                                    input.ProtectionProfileId = this.ProtectionProfile.ID;
                                    AzureEnableProtectionInput azureInput = new AzureEnableProtectionInput();
                                    azureInput.HvHostVmId = this.ProtectionEntity.FabricObjectId;
                                    azureInput.VmName = this.ProtectionEntity.Name;

                                    azureInput.OSType = this.OS;
                                    if (string.IsNullOrWhiteSpace(this.OS))
                                    {
                                        azureInput.OSType = this.ProtectionEntity.OS;
                                    }

                                    if (string.IsNullOrWhiteSpace(this.OSDiskName))
                                    {
                                        azureInput.VHDId = this.ProtectionEntity.OSDiskId;
                                    }
                                    else
                                    {
                                        foreach (var disk in this.ProtectionEntity.Disks)
                                        {
                                            if (disk.Name == this.OSDiskName)
                                            {
                                                azureInput.VHDId = disk.Id;
                                                break;
                                            }
                                        }
                                    }

                                    input.ReplicationProviderInput = DataContractUtils.Serialize<AzureEnableProtectionInput>(azureInput);
                                }
                                else if (string.IsNullOrWhiteSpace(profileId))
                                {
                                    input = null;
                                }
                                else
                                {
                                    input.ReplicationProviderInput = string.Empty;
                                    input.ProtectionProfileId = profileId;
                                }

                                this.jobResponse =
                                    RecoveryServicesClient.EnableProtection(
                                    this.ProtectionContainerId,
                                    this.Id,
                                    input);
                            }
                            else
                            {
                                this.jobResponse =
                                    RecoveryServicesClient.DisbleProtection(
                                    this.ProtectionContainerId,
                                    this.Id);
                            }

                            this.WriteJob(this.jobResponse.Job);

                            if (this.WaitForCompletion.IsPresent)
                            {
                                this.WaitForJobCompletion(this.jobResponse.Job.ID);
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
        private void WriteJob(Microsoft.WindowsAzure.Management.SiteRecovery.Models.Job job)
        {
            this.WriteObject(new ASRJob(job));
        }
    }
}