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
using System.Net;
using System.Management.Automation;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Sets the Recovery Services vault context to be used for subsequent Azure Site Recovery operations in the current PowerShell session.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrVaultContext", DefaultParameterSetName = ASRParameterSets.ARSVault, SupportsShouldProcess = true)]
    [Alias(
        "Set-ASRVaultContext",
        "Set-ASRVaultSettings",
        "Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrVaultSettings")]
    [OutputType(typeof(ASRVaultSettings))]
    public class SetAzureRmRecoveryServicesAsrVaultSettings : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the Recovery Services vault object corresponding to the Recovery Services vault.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ARSVault,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.Vault.Name,
                VerbsCommon.Set))
            {
                this.SetARSVaultContext(this.Vault);
            }
        }

        /// <summary>
        ///     Set Azure Recovery Services Vault context.
        /// </summary>
        private void SetARSVaultContext(
            ARSVault arsVault)
        {
            try
            {
                VaultExtendedInfoResource vaultExtendedInfo = null;

                try
                {
                    vaultExtendedInfo = this.RecoveryServicesClient
                    .GetVaultExtendedInfo(this.Vault.ResourceGroupName, this.Vault.Name);
                }
                catch (Exception ex)
                {
                    // code interanally handled the cloud exception thrown earlier.But still there are changes of other exception.
                    // suggesting alternate way to user to unblock if this command is failing.
                    Logger.Instance.WriteWarning(ex.Message);
                    throw new Exception(Resources.TryDownloadingVaultFile);
                }

                ASRVaultCreds asrVaultCreds = new ASRVaultCreds();

                asrVaultCreds.ResourceName = this.Vault.Name;
                asrVaultCreds.ResourceGroupName = this.Vault.ResourceGroupName;
                asrVaultCreds.ChannelIntegrityKey = vaultExtendedInfo.IntegrityKey;

                asrVaultCreds.ResourceNamespace = ARMResourceTypeConstants
                    .RecoveryServicesResourceProviderNameSpace;

                asrVaultCreds.ARMResourceType = ARMResourceTypeConstants.RecoveryServicesVault;
                asrVaultCreds.PrivateEndpointStateForSiteRecovery = this.Vault.Properties.PrivateEndpointStateForSiteRecovery;

                Utilities.UpdateCurrentVaultContext(asrVaultCreds);

                this.RecoveryServicesClient.ValidateVaultSettings(
                asrVaultCreds.ResourceName,
                asrVaultCreds.ResourceGroupName);

                this.WriteObject(new ASRVaultSettings(asrVaultCreds));
            }
            catch (InvalidOperationException e)
            {
                this.WriteDebug(e.Message);
            }
        }
    }
}
