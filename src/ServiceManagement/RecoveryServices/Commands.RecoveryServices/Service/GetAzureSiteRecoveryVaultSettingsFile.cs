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
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Retrieves Azure Site Recovery Vault Settings File.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryVaultSettingsFile", DefaultParameterSetName = ASRParameterSets.ByParam)]
    [OutputType(typeof(VaultSettingsFilePath))]
    public class GetAzureSiteRecoveryVaultSettingsFile : RecoveryServicesCmdletBase
    {
        /// <summary>
        /// Expiry in hours for generated certificate.
        /// </summary>
        private const int VaultCertificateExpiryInHoursForHRM = 120;

        #region Parameters

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = true, HelpMessage = "Vault Name for which the cred file to be generated")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the vault
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = true, HelpMessage = "Geo Location Name to which the vault belongs")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets vault Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRVault Vault { get; set; }

        /// <summary>
        /// Gets or sets the site name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = false, HelpMessage = "The site name if the vault credentials to be downloaded for a Hyper-V sites.")]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets the site id
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = false, HelpMessage = "The site Id if the vault credentials to be downloaded for a Hyper-V sites.")]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets site object
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ASRSite Site { get; set; }

        /// <summary>
        /// Gets or sets the path where the credential file is to be generated
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = false, HelpMessage = "The path where the vault credential file is to be created.")]
        public string Path { get; set; }

        #endregion Parameters

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

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByObject:
                        this.GetByObject();
                        break;
                    case ASRParameterSets.ByParam:
                        this.Vault = new ASRVault()
                        {
                            Name = this.Name,
                            Location = this.Location
                        };
                        if (!string.IsNullOrEmpty(this.SiteId) && !string.IsNullOrEmpty(this.SiteName))
                        {
                            this.Site = new ASRSite()
                            {
                                ID = this.SiteId,
                                Name = this.SiteName
                            };
                        }

                        this.GetByObject();
                        break;
                    default:
                        this.GetByObject();
                        break;
                }
            }
            catch (AggregateException aggregateEx)
            {
                // if an exception is thrown from a task, it will be wrapped in AggregateException 
                // and propagated to the main thread. Just throwing the first exception in the list.
                Exception exception = aggregateEx.InnerExceptions.First<Exception>();
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Method to execute the command
        /// </summary>
        private void GetByObject()
        {
            AzureSubscription subscription = this.Profile.Context.Subscription;
            this.Vault.SubscriptionId = subscription.Id.ToString();

            CloudService cloudService = RecoveryServicesClient.GetCloudServiceForVault(this.Vault);
            this.Vault.CloudServiceName = cloudService.Name;

            // Generate certificate
            X509Certificate2 cert = CertUtils.CreateSelfSignedCertificate(VaultCertificateExpiryInHoursForHRM, subscription.Id.ToString(), this.Vault.Name);

            var site = new Site();

            if (this.Site != null)
            {
                site.ID = this.Site.ID;
                site.Name = this.Site.Name;
                site.Type = this.Site.Type;
            }

            // Generate file.
            ASRVaultCreds vaultCreds = RecoveryServicesClient.GenerateVaultCredential(
                                            cert,
                                            this.Vault,
                                            site);

            string filePath = string.IsNullOrEmpty(this.Path) ? Utilities.GetDefaultPath() : this.Path;
            string fileName = this.GenerateFileName();

            // write the content to a file.
            VaultSettingsFilePath output = new VaultSettingsFilePath()
            {
                FilePath = Utilities.WriteToFile<ASRVaultCreds>(vaultCreds, filePath, fileName)
            };

            // print the path to the user.
            this.WriteObject(output, true);
        }

        /// <summary>
        /// Method to generate the file name
        /// </summary>
        /// <returns>file name as string.</returns>
        private string GenerateFileName()
        {
            string fileName;
            string format = "yyyy-MM-ddTHH-mm-ss";
            if (null == this.Site || string.IsNullOrEmpty(this.Site.Name))
            {
                fileName = string.Format("{0}_{1}.VaultCredentials", this.Vault.Name, DateTime.UtcNow.ToString(format));
            }
            else
            {
                fileName = string.Format("{0}_{1}_{2}.VaultCredentials", this.Site.Name, this.Vault.Name, DateTime.UtcNow.ToString(format));
            }

            return fileName;
        }
    }
}
