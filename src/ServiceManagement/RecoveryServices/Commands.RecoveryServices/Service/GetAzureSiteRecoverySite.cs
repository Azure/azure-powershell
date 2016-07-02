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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Site.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoverySite")]
    [OutputType(typeof(List<ASRSite>))]
    public class GetAzureSiteRecoverySite : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = false, HelpMessage = "Vault Object for which the site list is to be fetched")]
        [ValidateNotNullOrEmpty]
        public ASRVault Vault { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                SiteListResponse response = RecoveryServicesClient.GetAzureSiteRecoverySites(this.Vault);

                this.WriteSites(response.Sites);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Writes ASRSites
        /// </summary>
        /// <param name="siteList">List of Hydra Sites</param>
        private void WriteSites(IList<Site> siteList)
        {
            this.WriteObject(siteList.Select(s => new ASRSite(s)), true);
        }
    }
}
