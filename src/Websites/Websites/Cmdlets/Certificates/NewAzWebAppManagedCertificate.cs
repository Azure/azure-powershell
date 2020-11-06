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
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.Certificates
{

    /// <summary>
    /// This commandlet will let you create a new managed certificate
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppManagedCertificate"), OutputType(typeof(PSCertificate))]
    public class NewAzWebAppManagedCertificate : WebAppBaseClientCmdLet
    {
        const string CertNamePostFixSeparator = "_";
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

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 4, Mandatory = false, HelpMessage = "To add the created certificate to WebApp/slot.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AddCertBinding { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 5, Mandatory = false, HelpMessage = "Ssl state option. Use either 'SniEnabled' or 'IpBasedEnabled'. Default option is 'SniEnabled'.")]
        [ValidateNotNullOrEmpty]
        public SslState? SslState { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                //PSSite webApp = null;
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;

                Certificate createdCertdetails = null;
                
                var certificate = new Certificate(
                    webApp.Location,
                    canonicalName: HostName,
                    password: "",                    
                    serverFarmId: webApp.ServerFarmId);

                try
                {
                    createdCertdetails = WebsitesClient.CreateCertificate(ResourceGroupName, HostName, certificate);
                }
                catch (DefaultErrorResponseException e)
                {
                    // This exception is thrown when certificate already exists. Let's swallow it and continue.
                    if (e.Response.StatusCode != HttpStatusCode.Conflict)
                    {
                        throw;
                    }
                }
                //Add only when user is opted for Binding
                if (AddCertBinding)
                {
                    WebsitesClient.UpdateHostNameSslState(ResourceGroupName,
                                                          WebAppName,
                                                          Slot,
                                                          webApp.Location,
                                                          HostName, SslState.HasValue ? SslState.Value : Management.WebSites.Models.SslState.SniEnabled,
                                                          createdCertdetails.Thumbprint);
                }
                WriteObject(createdCertdetails);

            }

        }
    }
}
