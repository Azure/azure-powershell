// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdSecret
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecret", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdSecret))]
    public class NewAzFrontDoorCdnSecret : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecretCertificateAuthority, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string CertificateAuthority { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecretName, ParameterSetName = FieldsParameterSet)]
        public string SecretName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecretSource, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SecretSource { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecretVersion, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SecretVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecretSubjectAlternativeNames, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public List<string> SubjectAlternativeName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdSecretUseLatestVersion, ParameterSetName = FieldsParameterSet)]
        public SwitchParameter UseLatestVersion { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdSecretCreateMessage, this.SecretName, this.CreateAfdSecret);
        }

        private void CreateAfdSecret()
        {
            try
            {
                CustomerCertificateParameters afdCustomerCertificate = new CustomerCertificateParameters
                {
                    SecretSource = new ResourceReference(this.SecretSource),
                    SecretVersion = this.SecretVersion,
                    CertificateAuthority = this.CertificateAuthority,
                    UseLatestVersion = this.UseLatestVersion.IsPresent? true : false,
                    SubjectAlternativeNames = this.SubjectAlternativeName
                };

                PSAfdSecret psAfdSecret = this.CdnManagementClient.Secrets.Create(this.ResourceGroupName, this.ProfileName, this.SecretName, afdCustomerCertificate).ToPSAfdSecret();

                WriteObject(psAfdSecret);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
