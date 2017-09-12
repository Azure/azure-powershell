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
using System.Collections.ObjectModel;
using Microsoft.Azure.Management.RecoveryServices.Models;
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
        [Parameter(
            ParameterSetName = ASRParameterSets.ARSVaultACS,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ARSVault Vault { get; set; }

        /// <summary>
        /// Gets or sets Authentication type.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ARSVaultACS, Mandatory = true)]
        [Obsolete("This parameter is obsolete.  Will be removed in future release.", false)]
        public SwitchParameter UseACSAuthentication
        {
            get { return useACSAuthentication; }
            set { useACSAuthentication = value; }
        }

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
                        this.SetARSVaultContext(this.Vault, AuthType.AAD);
                        break;
                    case ASRParameterSets.ARSVaultACS:
                        this.SetARSVaultContext(this.Vault, AuthType.ACS);
                        break;
                    default:
                        throw new PSInvalidOperationException(Resources.InvalidParameterSet);
                }
            }
        }

        /// <summary>
        ///     Set Azure Recovery Services Vault context.
        /// </summary>
        /// <param name="arsVault">Azure recovery services vault.</param>
        /// <param name="authType">Authentication type used to set vault context.</param>
        private void SetARSVaultContext(ARSVault arsVault, string authType)
        {
            try
            {
                using (var powerShell = System.Management.Automation.PowerShell.Create())
                {
                    Collection<PSObject> result;
                    if (string.IsNullOrEmpty(authType) || authType == AuthType.AAD)
                    {
                        result = powerShell
                         .AddCommand("Get-AzureRmRecoveryServicesVaultSettingsFile")
                         .AddParameter("Vault", arsVault)
                         .Invoke();
                    }
                    else
                    {
                        result = powerShell
                         .AddCommand("Get-AzureRmRecoveryServicesVaultSettingsFile")
                         .AddParameter("Vault", arsVault)
                         .AddParameter("useACSAuthentication", null)
                         .Invoke();
                    }
                    var vaultSettingspath = (string)result[0]
                        .Members["FilePath"]
                        .Value;
                    powerShell.Commands.Clear();

                    result = powerShell
                        .AddCommand("Import-AzureRmRecoveryServicesAsrVaultSettingsFile")
                        .AddParameter(
                            "Path",
                            vaultSettingspath)
                        .Invoke();
                    this.WriteObject(result);
                    powerShell.Commands.Clear();
                }
            }
            catch (InvalidOperationException e)
            {
                this.WriteDebug(e.Message);
            }
        }
        /// <summary>
        ///     Gets or sets flag to use ACS authentication.
        /// </summary>
        private bool useACSAuthentication;
    }
}
