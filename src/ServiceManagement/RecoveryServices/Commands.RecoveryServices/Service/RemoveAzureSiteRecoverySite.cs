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
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Creates Azure Site Recovery Site.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureSiteRecoverySite")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureSiteRecoverySite : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the name of the site to be deleted
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true, HelpMessage = "Name of the site to be deleted")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false, HelpMessage = "Vault Object for which the site has to be deleted")]
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
                //// Check if site has registered things in it

                this.ConfirmAction(
                this.Force.IsPresent,
                string.Format(Properties.Resources.RemoveSiteWarning, this.Name),
                string.Format(Properties.Resources.RemoveSiteWhatIfMessage),
                this.Name,
                () =>
                    {
                        JobResponse response =
                            RecoveryServicesClient.DeleteAzureSiteRecoverySite(
                            this.Name);

                        this.WriteObject(response.Job, true);
                    });
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
