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

using Microsoft.Azure.Commands.RecoveryServices;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Vault Settings.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSiteRecoveryVaultSettings")]
    [OutputType(typeof(ASRVaultSettings))]
    public class SetAzureSiteRecoveryVaultSettings : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets ASR vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ASRVault, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRVault ASRVault { get; set; }

        /// <summary>
        /// Gets or sets ARS vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ARSVault, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault ARSVault { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ASRVault:
                    this.SetASRVaultContext(this.ASRVault);
                    break;
                case ASRParameterSets.ARSVault:
                    this.SetARSVaultContext(this.ARSVault);
                    break;
                default:
                    throw new PSInvalidOperationException(Properties.Resources.InvalidParameterSet);
            }
        }

        /// <summary>
        /// Set Azure Site Recovery Vault context.
        /// </summary>
        private void SetASRVaultContext(ASRVault asrVault)
        {
            // Change the vault context
            RecoveryServicesClient.ChangeVaultContext(asrVault);

            // Validate the Vault
            RecoveryServicesClient.ValidateVaultSettings(
                asrVault.Name,
                asrVault.ResourceGroupName);

            this.WriteObject(new ASRVaultSettings(PSRecoveryServicesClient.asrVaultCreds));
        }

        /// <summary>
        /// Set Azure Recovery Services Vault context.
        /// </summary>
        private void SetARSVaultContext(ARSVault arsVault)
        {
            try
            {
                using (System.Management.Automation.PowerShell powerShell = System.Management.Automation.PowerShell.Create())
                {
                    Collection<PSObject> result =
                        powerShell
                        .AddCommand("Get-AzureRmRecoveryServicesVaultSettingsFile")
                        .AddParameter("Vault", arsVault)
                        .Invoke();

                    string vaultSettingspath = (string)result[0].Members["FilePath"].Value;
                    powerShell.Commands.Clear();

                    result =
                        powerShell
                        .AddCommand("Import-AzureRmSiteRecoveryVaultSettingsFile")
                        .AddParameter("Path", vaultSettingspath)
                        .Invoke();
                    WriteObject(result);
                    powerShell.Commands.Clear();
                }
            }
            catch (InvalidOperationException e)
            {
                WriteDebug(e.Message);
            }
        }
    }
}