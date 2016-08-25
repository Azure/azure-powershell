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

using System.CodeDom;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary>
    /// Creates a new integration account map.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntegrationAccountCertificate", SupportsShouldProcess = true), OutputType(typeof(object))]
    public class NewAzureIntegrationAccountCertificateCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

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

        [Parameter(Mandatory = true, HelpMessage = "The integration account certificate key name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account certificate key version.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account certificate key vault ID.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate file path",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PublicCertificateFilePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate metadata.",
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public object Metadata { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the integration account certificate create command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.Metadata != null)
            {
                this.Metadata = CmdletHelper.ConvertToMetadataJObject(this.Metadata);
            }

            string certificate = null;

            var integrationAccount = IntegrationAccountClient.GetIntegrationAccount(this.ResourceGroupName, this.Name);

            if (!string.IsNullOrEmpty(this.PublicCertificateFilePath))
            {
                var certificateFilePath = this.TryResolvePath(this.PublicCertificateFilePath);

                if (!string.IsNullOrEmpty(certificateFilePath) && CmdletHelper.FileExists(certificateFilePath))
                {
                    var cert = new X509Certificate2(certificateFilePath);
                    certificate = Convert.ToBase64String(cert.RawData);
                }
            }

            this.WriteObject(
                IntegrationAccountClient.CreateIntegrationAccountCertificate(this.ResourceGroupName,
                    integrationAccount.Name,
                    this.CertificateName, new IntegrationAccountCertificate
                    {
                        Name = this.CertificateName,
                        Key = new KeyVaultKeyReference
                        {
                            KeyName = this.KeyName,
                            KeyVersion = this.KeyVersion,
                            KeyVault = new KeyVaultKeyReferenceKeyVault()
                            {
                                Id = this.KeyVaultId
                            }
                        },
                        Metadata = this.Metadata,
                        PublicCertificate = certificate
                    }
                    ), true);
        }
    }
}