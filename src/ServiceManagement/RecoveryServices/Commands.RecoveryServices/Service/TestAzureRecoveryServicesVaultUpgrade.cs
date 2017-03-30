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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to validate vault upgrade prerequisites.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "AzureRecoveryServicesVaultUpgrade")]
    [OutputType(typeof(List<string>))]
    public class TestAzureRecoveryServicesVaultUpgrade : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets vault type.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.ASRVaultType,
            Constants.BackupVault,
            IgnoreCase = true)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets vault name.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Gets or sets location of the vault.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets target resource group.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("TargetRG", "TargetRGName", "RG")]
        public string TargetResourceGroupName { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteResponse(Properties.Resources.StartingPrerequisitesCheck);
                this.RecoveryServicesClient.TestVaultUpgradePrerequistes(
                    this.VaultName,
                    this.Location,
                    this.ResourceType,
                    this.TargetResourceGroupName,
                    this.Profile.Context.Subscription.Id.ToString());

                this.WriteObject(Properties.Resources.CheckPrereqSucceeded);
                this.WriteObject(Environment.NewLine);
            }
            catch (Exception exception)
            {
                ExceptionDetails details =
                    this.HandleVaultUpgradeException(exception);
                if (!string.IsNullOrEmpty(details.WarningDetails))
                {
                    this.WriteWarning(details.WarningDetails);
                }

                if (!string.IsNullOrEmpty(details.ErrorDetails))
                {
                    Exception ex = new InvalidOperationException(
                        string.Format(
                            Properties.Resources.ConfirmVaultUpgradePrereqFailed,
                            Properties.Resources.VaultUpgradeExceptionDetails,
                            details.ErrorDetails));
                    this.ThrowTerminatingError(
                        new ErrorRecord(
                            ex,
                            string.Empty,
                            ErrorCategory.InvalidOperation,
                            null));
                }
            }
        }
    }
}