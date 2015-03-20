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
using System.Net;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault create operation.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSiteRecoveryVault")]
    [OutputType(typeof(VaultOperationOutput))]
    public class RemoveAzureSiteRecoveryVault : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// Holds the Name of the vault.
        /// </summary>
        private string targetName = string.Empty;

        #region Parameters

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = true, HelpMessage = "Vault to be deleted")]
        [ValidateNotNullOrEmpty]
        public ASRVault Vault { get; set; }

        /// <summary>
        /// Gets or sets switch parameter. On passing, command does not ask for confirmation.
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Properties.Resources.RemoveVaultWarning, this.Vault.Name),
                string.Format(Properties.Resources.RemoveVaultWhatIfMessage),
                this.Vault.Name,
                () =>
                {
                    AzureOperationResponse response = RecoveryServicesClient.DeleteVault(this.Vault.CloudServiceName, this.Vault.Name);

                    VaultOperationOutput output = new VaultOperationOutput()
                    {
                        Response = response.StatusCode == HttpStatusCode.OK ? Resources.VaultDeletionSuccessMessage : response.StatusCode.ToString()
                    };

                    this.WriteObject(output, true);
                });
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
