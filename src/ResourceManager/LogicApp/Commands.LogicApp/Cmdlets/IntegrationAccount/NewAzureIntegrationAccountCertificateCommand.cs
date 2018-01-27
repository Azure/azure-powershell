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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System;
    using System.Management.Automation;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Creates a new integration account map.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntegrationAccountCertificate", SupportsShouldProcess = true)]
    [OutputType(typeof(IntegrationAccountCertificate))]
    public class NewAzureIntegrationAccountCertificateCommand : LogicAppBaseCmdlet
    {

        #region Input Parameters

        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey", Mandatory = true)]
        [Parameter(ParameterSetName = "PublicKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey", Mandatory = true)]
        [Parameter(ParameterSetName = "PublicKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account certificate name.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey", Mandatory = true)]
        [Parameter(ParameterSetName = "PublicKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CertificateName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key name.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey",Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key version.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate key vault ID.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PrivateKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string KeyVaultId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The integration account certificate file path",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = "PublicKey", Mandatory = true)]
        [Parameter(ParameterSetName = "Both", Mandatory = true)]
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

            KeyVaultKeyReference keyref = null;

            if (!string.IsNullOrEmpty(this.KeyName) && !string.IsNullOrEmpty(this.KeyVersion) && !string.IsNullOrEmpty(this.KeyVaultId))
            {
                keyref = new KeyVaultKeyReference
                {
                    KeyName = this.KeyName,
                    KeyVersion = this.KeyVersion,
                    KeyVault = new KeyVaultKeyReferenceKeyVault()
                    {
                        Id = this.KeyVaultId
                    }
                };
            }

            this.WriteObject(
                IntegrationAccountClient.CreateIntegrationAccountCertificate(this.ResourceGroupName,
                    integrationAccount.Name,
                    this.CertificateName, new IntegrationAccountCertificate
                    {
                        Key = keyref,
                        Metadata = this.Metadata,
                        PublicCertificate = certificate
                    }
                    ), true);
        }
    }
}