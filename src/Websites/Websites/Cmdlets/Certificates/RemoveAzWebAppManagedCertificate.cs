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
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppManagedCertificate"), OutputType(typeof(void))]
    public class RemoveAzWebAppManagedCertificate : WebAppBaseClientCmdLet
    {
        const string ParameterSet1Name = "S1";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ResourceNameCompleter("Microsoft.Web/sites/slots", "ResourceGroupName", "WebAppName")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Custom hostnames associated with web app/slot.")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space.")]
        [ValidateNotNullOrEmpty]
        public string ThumbPrint { get; set; }
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                if (this.ShouldProcess(this.HostName, string.Format("Deleting certificate - '{0}' from Web Application - {1}", this.HostName, this.WebAppName)))
                {
                    var webapp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                    var hostNameSslStates = CmdletHelpers.GetHostNameSslStatesFromSiteResponse(webapp, HostName).ToList();
                    if (hostNameSslStates.Count > 0)
                    {
                        WebsitesClient.UpdateHostNameSslState(ResourceGroupName, WebAppName, Slot, webapp.Location, HostName, SslState.Disabled, null);
                    }
                    var certificateResourceGroup = CmdletHelpers.GetResourceGroupFromResourceId(webapp.ServerFarmId);
                    var certificates = CmdletHelpers.GetCertificates(this.ResourcesClient, this.WebsitesClient, certificateResourceGroup, ThumbPrint);
                    if (certificates.Length > 0)
                    {
                        try
                        {
                            WebsitesClient.RemoveCertificate(certificateResourceGroup, certificates[0].Name);
                        }
                        catch (DefaultErrorResponseException e)
                        {
                            // This exception is thrown when certificate already exists. Let's swallow it and continue.
                            if (e.Response.StatusCode != HttpStatusCode.Conflict)
                            {
                                throw;
                            }
                        }
                    }

                }
            }
        }
    }
}
