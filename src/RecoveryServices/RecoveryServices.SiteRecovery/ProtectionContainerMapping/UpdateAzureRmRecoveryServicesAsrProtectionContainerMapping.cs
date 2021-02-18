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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using System;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Deletes the specified Azure Site Recovery protection container mapping.
    /// </summary>
    [Cmdlet("Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrProtectionContainerMapping",
        DefaultParameterSetName = AzureToAzureEnableAutoUpdate,
        SupportsShouldProcess = true)]
    [Alias("Update-ASRProtectionContainerMapping")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrProtectionContainerMapping : SiteRecoveryCmdletBase
    {
        #region Parameter Set
        protected const string AzureToAzureEnableAutoUpdate = "AzureToAzureEnableAutoUpdate";
        protected const string AzureToAzureDisableAutoUpdate = "AzureToAzureDisableAutoUpdate";
        #endregion

        #region Parameters
        /// <summary>
        ///     Gets or sets protection container mapping object corresponding to the protection container to be updatd.
        /// </summary>
        [Parameter(ParameterSetName = AzureToAzureEnableAutoUpdate, Mandatory = true, ValueFromPipeline = true,HelpMessage = "Object for protection container mapping.")]
        [Parameter(ParameterSetName = AzureToAzureDisableAutoUpdate, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Object for protection container mapping.")]
        [ValidateNotNullOrEmpty]
        [Alias("ProtectionContainerMapping")]
        public ASRProtectionContainerMapping InputObject { get; set; }

        /// <summary>
        ///    Switch parameter specifying that the replication container used to replicate Azure virtual machines between 
        ///    two Azure regions will be updated.
        /// </summary>
        [Parameter(ParameterSetName = AzureToAzureEnableAutoUpdate, Mandatory = true, HelpMessage = "Specifies Azure to Azure protection container.")]
        [Parameter(ParameterSetName = AzureToAzureDisableAutoUpdate, Mandatory = true, HelpMessage = "Specifies Azure to Azure protection container.")]
        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///    Switch parameter specifying that the replication container used to replicate Azure virtual machines between 
        ///    two Azure regions will be updated.
        /// </summary>
        [Parameter(ParameterSetName = AzureToAzureEnableAutoUpdate, Mandatory = true, HelpMessage = "Switch parameter to enable auto update.")]
        public SwitchParameter EnableAutoUpdate { get; set; }

        /// <summary>
        ///    Switch parameter specifying that the replication container used to replicate Azure virtual machines between 
        ///    two Azure regions will be updated.
        /// </summary>
        [Parameter(ParameterSetName = AzureToAzureDisableAutoUpdate, Mandatory = true ,HelpMessage = "Switch parameter to disable auto update.")]
        public SwitchParameter DisableAutoUpdate { get; set; }

        /// <summary>
        ///    Switch parameter specifying that the replication container used to replicate Azure virtual machines between 
        ///    two Azure regions will be updated.
        /// </summary>
        [Parameter(
            ParameterSetName = AzureToAzureEnableAutoUpdate,
            Mandatory = true,
            HelpMessage = "Specifies the automation accountId used for auto udpate.")]
        public string AutomationAccountId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(this.InputObject.Name, VerbsData.Update))
            {
                if (this.ShouldProcess(this.InputObject.Name, VerbsData.Update))
                {
                    var protectionContainerMapping =
                        this.RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ReplicationFabrics),
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ProtectionContainerMappings));
                    if (protectionContainerMapping == null)
                    {
                        throw new Exception(
                            string.Format(
                                Resources.ProtectionContainerNotFound,
                                this.InputObject.Name,
                                PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                    }

                    var updateInput = new UpdateProtectionContainerMappingInput();
                    updateInput.Properties = new UpdateProtectionContainerMappingInputProperties();
                    updateInput.Properties.ProviderSpecificInput = new A2AUpdateContainerMappingInput();

                    switch (this.ParameterSetName)
                    {
                        case AzureToAzureEnableAutoUpdate:
                            updateInput.Properties.ProviderSpecificInput = new A2AUpdateContainerMappingInput
                            {
                                AgentAutoUpdateStatus = AgentAutoUpdateStatus.Enabled,
                                AutomationAccountArmId = this.AutomationAccountId
                            };
                            break;
                        case AzureToAzureDisableAutoUpdate:
                            updateInput.Properties.ProviderSpecificInput = new A2AUpdateContainerMappingInput
                            {
                                AgentAutoUpdateStatus = AgentAutoUpdateStatus.Disabled
                            };
                            break;
                    }

                    var response = this.RecoveryServicesClient.UpdateAzureSiteRecoveryProtectionContainerMapping(
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ReplicationFabrics),
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                            Utilities.GetValueFromArmId(this.InputObject.ID, ARMResourceTypeConstants.ProtectionContainerMappings),
                            updateInput);
                    var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                                         PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                    this.WriteObject(new ASRJob(jobResponse));
                }
            }
        }
    }
}