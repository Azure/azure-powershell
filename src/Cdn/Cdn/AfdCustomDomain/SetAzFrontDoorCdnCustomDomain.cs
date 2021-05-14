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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdCustomDomain
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnCustomDomain", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAfdCustomDomain))]
    public class SetAzFrontDoorCdnCustomDomain : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.AfdCustomDomainAzureDnsZoneId)]
        [ValidateNotNullOrEmpty]
        public string AzureDnsZoneId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainName)]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainMinimumTlsVersion, ParameterSetName = AfdParameterSet.AfdCustomDomainCustomerCertificate)]
        [PSArgumentCompleter("TLS10", "TLS12")]
        [ValidateNotNullOrEmpty]
        public string MinimumTlsVersion { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdCustomDomainSecretId, ParameterSetName = AfdParameterSet.AfdCustomDomainCustomerCertificate)]
        [ValidateNotNullOrEmpty]
        public string SecretId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(AfdResourceProcessMessage.AfdCustomDomainUpdateMessage, this.CustomDomainName, this.UpdateAfdCustomDomain);
        }

        private void UpdateAfdCustomDomain()
        {
            try
            {
                AFDDomainHttpsParameters tlsSettings = null;
                ResourceReference azureDnsZoneId = null;

                if (MyInvocation.BoundParameters.ContainsKey("AzureDnsZoneId"))
                {
                    azureDnsZoneId = new ResourceReference(this.AzureDnsZoneId);
                }

                if (ParameterSetName == AfdParameterSet.AfdCustomDomainCustomerCertificate)
                {
                    tlsSettings = new AFDDomainHttpsParameters
                    {
                        CertificateType = "CustomerCertificate",
                        MinimumTlsVersion = AfdUtilities.CreateMinimumTlsVersion(this.MinimumTlsVersion),
                        Secret = new ResourceReference(this.SecretId)
                    };
                }
                
                PSAfdCustomDomain psAfdCustomDomain = this.CdnManagementClient.AFDCustomDomains.Update(this.ResourceGroupName, this.ProfileName, this.CustomDomainName, tlsSettings, azureDnsZoneId).ToPSAfdCustomDomain();

                WriteObject(psAfdCustomDomain);
            }
            catch (AfdErrorResponseException errorResponse)
            {
                throw new PSArgumentException(errorResponse.Response.Content);
            }
        }
    }
}
