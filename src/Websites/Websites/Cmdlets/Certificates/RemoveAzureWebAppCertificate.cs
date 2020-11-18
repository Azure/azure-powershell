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
        const string ParameterSet2Name = "S2";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 3, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space.")]
        [ValidateNotNullOrEmpty]
        public string ThumbPrint { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ResourceNameCompleter("Microsoft.Web/sites/slots", "ResourceGroupName", "WebAppName")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 3, Mandatory = true, HelpMessage = "Custom hostnames associated with web app/slot.")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        public override void ExecuteCmdlet()
        {
            PSSite webapp = null;
            string certificateResourceGroup = null;
            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                    certificateResourceGroup = ResourceGroupName;
                    break;
                case ParameterSet2Name:
                    webapp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                    var hostNameSslStates = CmdletHelpers.GetHostNameSslStatesFromSiteResponse(webapp, HostName).ToList();
                    if (hostNameSslStates.Count > 0)
                    {
                        WebsitesClient.UpdateHostNameSslState(ResourceGroupName, WebAppName, Slot, webapp.Location, HostName, SslState.Disabled, null);
                    }
                    certificateResourceGroup = CmdletHelpers.GetResourceGroupFromResourceId(webapp.ServerFarmId);
                    break;
            }

            var certificates = CmdletHelpers.GetCertificates(this.ResourcesClient, this.WebsitesClient, certificateResourceGroup, ThumbPrint);
            if (certificates.Length > 0)
            {
                if (this.ShouldProcess(this.WebAppName, string.Format($"Removing an App service managed certificate for Web App '{WebAppName}'")))
                {
                    var certName = !string.IsNullOrEmpty(HostName) ? HostName : certificates[0].Name;
                    try
                    {
                        WebsitesClient.RemoveCertificate(certificateResourceGroup, certName);
                    }
                    catch (DefaultErrorResponseException)
                    {
                        throw;
                    }
                }
            }

        }
    }
}
