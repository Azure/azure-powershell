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


using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.Certificates
{
    /// <summary>
    /// This commandlet will let you delete a managed certificate
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppCertificate", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzureWebAppCertificate : WebAppBaseClientCmdLet
    {
        const string ParameterSet1Name = "S1";        

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        //[Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space.")]
        //[Parameter(ParameterSetName = ParameterSet2Name, Position = 3, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space.")]
        [ValidateNotNullOrEmpty]
        public string ThumbPrint { get; set; }
        

        public override void ExecuteCmdlet()
        {
            
            var certificates = CmdletHelpers.GetCertificates(this.ResourcesClient, this.WebsitesClient, ResourceGroupName, ThumbPrint);
            if (certificates.Length > 0)
            {
                if (this.ShouldProcess(this.ThumbPrint, string.Format($"Removing an App service certificate with thumbprint '{ThumbPrint}'")))
                {
                    //var certName = !string.IsNullOrEmpty(HostName) ? HostName : certificates[0].Name;
                    try
                    {
                        WebsitesClient.RemoveCertificate(ResourceGroupName, certificates[0].Name);
                    }
                    catch (DefaultErrorResponseException e)
                    {
                        throw e;
                    }
                }
            }

        }
    }
}
