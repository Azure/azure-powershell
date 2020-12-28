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
using System;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.Certificates
{

    /// <summary>
    /// This commandlet will let you create a new managed certificate
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebAppCertificate", SupportsShouldProcess = true), OutputType(typeof(PSCertificate))]
    public class NewAzureWebAppCertificate : WebAppBaseClientCmdLet
    {
        // Poll status for a maximum of 6 minutes (360 seconds / 2 seconds per status check)
        private const int NumStatusChecks = 72;
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

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "The name of the certificate")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ResourceNameCompleter("Microsoft.Web/sites/slots", "ResourceGroupName", "WebAppName")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Custom hostnames associated with web app/slot.")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "To add the created certificate to WebApp/slot.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AddBinding { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Mandatory = false, HelpMessage = "Ssl state option. Use either 'SniEnabled' or 'IpBasedEnabled'. Default option is 'SniEnabled'.")]
        [ValidateNotNullOrEmpty]
        public SslState? SslState { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrWhiteSpace(ResourceGroupName) && !string.IsNullOrWhiteSpace(WebAppName))
            {
                string certName = null;
                HttpStatusCode statusCode = HttpStatusCode.OK;
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;

                Certificate createdCertdetails = new Certificate();

                var certificate = new Certificate(
                    webApp.Location,
                    type: "Microsoft.Web/certificates",
                    canonicalName: HostName,
                    password: "",
                    serverFarmId: webApp.ServerFarmId);
                if (this.ShouldProcess(this.WebAppName, string.Format($"Creating an App service managed certificate for Web App '{WebAppName}'")))
                {
                    try
                    {
                        //Default certName is HostName
                        certName = Name != null ? Name : HostName;
                        createdCertdetails = (PSCertificate)WebsitesClient.CreateCertificate(ResourceGroupName, certName, certificate);
                    }
                    catch (DefaultErrorResponseException e)
                    {
                        statusCode = e.Response.StatusCode;
                        // 'Conflict' exception is thrown when certificate already exists. Let's swallow it and continue.
                        //'Accepted' exception is thrown by default for create cert method. 
                        if (e.Response.StatusCode != HttpStatusCode.Conflict &&
                            e.Response.StatusCode != HttpStatusCode.Accepted)
                        {
                            throw;
                        }
                        if (e.Response.StatusCode == HttpStatusCode.Accepted)
                        {
                            var poll_url = e.Response.Headers["Location"].FirstOrDefault();
                            var token=WebsitesClient.GetAccessToken(DefaultContext);
                            HttpClient client = new HttpClient();
                            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
                            
                            HttpResponseMessage r;
                            int numChecks = 0;
                            do
                            {
                                Thread.Sleep(TimeSpan.FromSeconds(5));
                                r = client.GetAsync(poll_url).Result;
                                numChecks++;
                            } while (r.StatusCode == HttpStatusCode.Accepted && numChecks < NumStatusChecks);

                            if (r.StatusCode == HttpStatusCode.Accepted && numChecks >= NumStatusChecks)
                            {
                                var rec = new ErrorRecord(new Exception(string.Format($"The creation of the managed certificate '{this.HostName}' is taking longer than expected." +
                                                                                    $" Please re-try the operation '{CreateInputCommand()}'")),
                                                                                    string.Empty, ErrorCategory.OperationTimeout, null);
                                WriteError(rec);
                            }


                        }
                    }
                    createdCertdetails = WebsitesClient.GetCertificate(ResourceGroupName, certName);

                    //Add only when user is opted for Binding
                    if (AddBinding)
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
        private string CreateInputCommand()
        {
            StringBuilder command = new StringBuilder("New-AzWebAppCertificate ");
            command.Append($"-ResourceGroupName {this.ResourceGroupName} -WebAppName {this.WebAppName} -HostName {this.HostName} ");
            if (Slot != null)
                command.Append($"-Slot {this.Slot} ");
            if (AddBinding)
                command.Append($"-AddBinding ");
            if (SslState != null)
                command.Append($"-SslState {this.SslState} ");
            return command.ToString(); ;
        }
    }
}
