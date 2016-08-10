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

using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Updates the integration account certificate.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmIntegrationAccountCertificate", SupportsShouldProcess = true),
     OutputType(typeof (object))]
    public class UpdateAzureIntegrationAccountCertificateCommand : LogicAppBaseCmdlet
    {

        #region Input Paramters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account certificate name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key version.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key vault ID.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The integration account certificate file path.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PublicCertificateFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate metadata.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account certificate update command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            var integrationAccountCertificate =
                IntegrationAccountClient.GetIntegrationAccountCertifcate(this.ResourceGroupName,
                    this.Name, this.CertificateName);

            if (!string.IsNullOrEmpty(this.KeyName))
            {
                integrationAccountCertificate.Key.KeyName = this.KeyName;
            }

            if (!string.IsNullOrEmpty(this.KeyVersion))
            {
                integrationAccountCertificate.Key.KeyVersion = this.KeyVersion;
            }

            if (!string.IsNullOrEmpty(this.KeyVaultId))
            {
                integrationAccountCertificate.Key.KeyVault.Id = this.KeyVaultId;
            }

            string certificate = null;

            if (!string.IsNullOrEmpty(this.PublicCertificateFilePath))
            {
                var certificateFilePath = this.TryResolvePath(this.PublicCertificateFilePath);

                if (!string.IsNullOrEmpty(certificateFilePath) && CmdletHelper.FileExists(certificateFilePath))
                {
                    var cert = new X509Certificate2(certificateFilePath);
                    certificate = Convert.ToBase64String(cert.RawData);
                }
            }

            if (!string.IsNullOrEmpty(certificate))
            {
                integrationAccountCertificate.PublicCertificate = certificate;
            }

            if (this.Metadata != null)
            {
                integrationAccountCertificate.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            ConfirmAction(Force.IsPresent,
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceWarning,
                    "Microsoft.Logic/integrationAccounts/certificates", this.Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resource.UpdateResourceMessage,
                    "Microsoft.Logic/integrationAccounts/certificates", this.Name),
                Name,
                () =>
                {
                    this.WriteObject(
                        IntegrationAccountClient.UpdateIntegrationAccountCertificate(this.ResourceGroupName,
                            integrationAccount.Name,
                            this.CertificateName, integrationAccountCertificate), true);
                },
                null);
        }
    }
}