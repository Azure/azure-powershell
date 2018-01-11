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
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Vault Settings.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        "AzureRmRecoveryServicesAsrVaultContext",
        DefaultParameterSetName = ASRParameterSets.ARSVault,
        SupportsShouldProcess = true)]
    [Alias(
        "Set-ASRVaultContext",
        "Set-ASRVaultSettings",
        "Set-AzureRmRecoveryServicesAsrVaultSettings")]
    [OutputType(typeof(ASRVaultSettings))]
    public class SetAzureRmRecoveryServicesAsrVaultSettings : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets ARS vault Object.
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
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ARSVault:
                        this.SetARSVaultContext(this.Vault);
                        break;
                    default:
                        throw new PSInvalidOperationException(Resources.InvalidParameterSet);
                }
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
                using (var powerShell = System.Management.Automation.PowerShell.Create())
                {
                    var vaultExtendedInfo = this.RecoveryServicesClient
                        .GetVaultExtendedInfo(this.Vault.ResourceGroupName,this.Vault.Name);


                    ASRVaultCreds asrVaultCreds = new ASRVaultCreds();
                    
                    asrVaultCreds.ResourceName = this.Vault.Name;
                    asrVaultCreds.ResourceGroupName = this.Vault.ResourceGroupName;
                    asrVaultCreds.ChannelIntegrityKey = vaultExtendedInfo.IntegrityKey;
                    
                    asrVaultCreds.ResourceNamespace = ARMResourceTypeConstants
                        .RecoveryServicesResourceProviderNameSpace;

                    asrVaultCreds.ARMResourceType = ARMResourceTypeConstants.RecoveryServicesVault;

                    Utilities.UpdateCurrentVaultContext(asrVaultCreds);

                    this.RecoveryServicesClient.ValidateVaultSettings(
                    asrVaultCreds.ResourceName,
                    asrVaultCreds.ResourceGroupName);

                    this.WriteObject(new ASRVaultSettings(asrVaultCreds));
                    powerShell.Commands.Clear();
                }
            }
            catch (InvalidOperationException e)
            {
                this.WriteDebug(e.Message);
            }
        }
    }
}