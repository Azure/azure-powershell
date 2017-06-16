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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Vault Settings.
    /// </summary>
    [Cmdlet(VerbsCommon.Set,
        "AzureRmRecoveryServicesAsrVaultSettings",
        DefaultParameterSetName = ASRParameterSets.ARSVault)]
    [Alias("Set-ASRVaultContext",
        "Set-ASRVaultSettings")]
    [OutputType(typeof(ASRVaultSettings))]
    public class SetAzureRmRecoveryServicesAsrVaultSettings : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets ARS vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ARSVault,
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

            switch (ParameterSetName)
            {
                case ASRParameterSets.ARSVault:
                    SetARSVaultContext(Vault);
                    break;
                default:
                    throw new PSInvalidOperationException(Resources.InvalidParameterSet);
            }
        }

        /// <summary>
        ///     Set Azure Recovery Services Vault context.
        /// </summary>
        private void SetARSVaultContext(ARSVault arsVault)
        {
            try
            {
                using (var powerShell = System.Management.Automation.PowerShell.Create())
                {
                    var result = powerShell
                        .AddCommand("Get-AzureRmRecoveryServicesVaultSettingsFile")
                        .AddParameter("Vault",
                            arsVault)
                        .Invoke();

                    var vaultSettingspath = (string) result[0]
                        .Members["FilePath"]
                        .Value;
                    powerShell.Commands.Clear();

                    result = powerShell
                        .AddCommand("Import-AzureRmRecoveryServicesAsrVaultSettingsFile")
                        .AddParameter("Path",
                            vaultSettingspath)
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