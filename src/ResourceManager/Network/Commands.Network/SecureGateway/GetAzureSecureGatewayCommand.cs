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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSecureGateway"), OutputType(typeof(PSSecureGateway), typeof(IEnumerable<PSSecureGateway>))]
    public class GetAzureSecureGatewayCommand : SecureGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var secureGateway = this.GetSecureGateway(this.ResourceGroupName, this.Name);

                WriteObject(secureGateway);
            }
            else
            {
                IPage<SecureGateway> secureGatewayPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    secureGatewayPage = this.SecureGatewayClient.List(this.ResourceGroupName);
                }
                else
                {
                    secureGatewayPage = this.SecureGatewayClient.ListAll();
                }

                // Get all resources by polling on next page link
                var secureGwResponseLIst = ListNextLink<SecureGateway>.GetAllResourcesByPollingNextLink(secureGatewayPage, this.SecureGatewayClient.ListNext);

                var psSecureGateways = new List<PSSecureGateway>();

                foreach (var secureGw in secureGwResponseLIst)
                {
                    var psSecureGw = this.ToPsSecureGateway(secureGw);
                    psSecureGw.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(secureGw.Id);
                    psSecureGateways.Add(psSecureGw);
                }

                WriteObject(psSecureGateways, true);
            }
        }
    }
}
