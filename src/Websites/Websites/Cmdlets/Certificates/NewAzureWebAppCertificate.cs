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


using Azure;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Commands.WebApps.Utilities;
using System;
using System.Linq;
using System.Management.Automation;
using System.Net;
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

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 3, Mandatory = true, HelpMessage = "Custom hostname associated with web app/slot.")]
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
                var webApp = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, WebAppName, Slot));
                var location = webApp.Location;             

                var certificate = new Certificate(
                    webApp.Location,
                    type: "Microsoft.Web/certificates",
                    canonicalName: HostName,
                    password: "",
                    serverFarmId: webApp.ServerFarmId);

                PSCertificate createdCertdetails = new PSCertificate(certificate);

                if (this.ShouldProcess(this.WebAppName, string.Format($"Creating an App service managed certificate for Web App '{WebAppName}'")))
                {
                    Certificate createdCertificate = null;
                    try
                    {
                        //Default certName is HostName
                        certName = Name != null ? Name : HostName;
                        createdCertificate = WebsitesClient.CreateCertificate(
                            ResourceGroupName,
                            certName,
                            certificate);
                        createdCertdetails = new PSCertificate(createdCertificate);
                    }
                    catch (RequestFailedException e)
                    {
                        // 'Conflict' exception is thrown when certificate already exists. Let's swallow it and continue.
                        if (e.Status != (int)HttpStatusCode.Conflict)
                        {
                            throw;
                        }
                    }
                    Certificate fetchedCertificate = null;
                    for (int numChecks = 0;
                         numChecks < NumStatusChecks;
                         numChecks++)
                    {
                        try
                        {
                            fetchedCertificate =
                                WebsitesClient.GetCertificate(
                                    ResourceGroupName,
                                    certName);
                        }
                        catch (RequestFailedException e)
                            when (e.Status == (int)HttpStatusCode.NotFound)
                        {
                            fetchedCertificate = null;
                        }

                        if (fetchedCertificate != null &&
                            string.IsNullOrEmpty(fetchedCertificate.Thumbprint))
                        {
                            fetchedCertificate.Thumbprint =
                                createdCertificate?.Thumbprint;
                        }
                        else if (fetchedCertificate == null &&
                                 !string.IsNullOrEmpty(
                                     createdCertificate?.Thumbprint))
                        {
                            fetchedCertificate = createdCertificate;
                        }

                        if (!string.IsNullOrEmpty(
                                fetchedCertificate?.Thumbprint))
                        {
                            break;
                        }

                        if (numChecks + 1 < NumStatusChecks)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(5));
                        }
                    }

                    if (string.IsNullOrEmpty(fetchedCertificate?.Thumbprint))
                    {
                        WriteError(
                            new ErrorRecord(
                                new Exception(
                                    $"The creation of the managed certificate '{HostName}' is taking longer than expected. " +
                                    $"Please re-try the operation '{CreateInputCommand()}'"),
                                string.Empty,
                                ErrorCategory.OperationTimeout,
                                null));
                        return;
                    }

                    createdCertdetails = new PSCertificate(fetchedCertificate);

                    //Add only when user is opted for Binding
                    if (AddBinding)
                    {

                        WebsitesClient.UpdateHostNameSslState(ResourceGroupName,
                                                              WebAppName,
                                                              Slot,
                                                              webApp.Location,
                                                              HostName, SslState.HasValue ? SslState.Value : Microsoft.Azure.Management.WebSites.Models.SslState.SniEnabled,
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
