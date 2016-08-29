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


using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Azure;
using System;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// this commandlet will let you create a new Azure Web app using ARM APIs
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmWebAppSSLBinding")]
    public class NewAzureWebAppSSLBinding : WebAppBaseClientCmdLet
    {
        const string CertNamePostFixSeparator = "_";
        const string ParameterSet1Name = "S1";
        const string ParameterSet2Name = "S2";
        const string ParameterSet3Name = "S3";
        const string ParameterSet4Name = "S4";

        string resourceGroupName;
        string webAppName;
        string slot;

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.")]
        [ValidateNotNullOrEmpty]
        public string WebAppName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [Parameter(ParameterSetName = ParameterSet2Name, Position = 2, Mandatory = false, HelpMessage = "The name of the web app slot.")]
        [ValidateNotNullOrEmpty]
        public string Slot { get; set; }

        [Parameter(ParameterSetName = ParameterSet3Name, Position = 0, Mandatory = true, HelpMessage = "The web app object.", ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ParameterSet4Name, Position = 0, Mandatory = true, HelpMessage = "The web app object.", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public Site WebApp { get; set; }

        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The name of the host name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = false, HelpMessage = "Ssl state option. Use either 'SniEnabled' or 'IpBasedEnabled'. Default option is 'SniEnabled'.")]
        [ValidateNotNullOrEmpty]
        public SslState? SslState { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 4, Mandatory = true, HelpMessage = "Certificate file path")]
        [Parameter(ParameterSetName = ParameterSet3Name, Position = 4, Mandatory = true, HelpMessage = "Certificate file path")]
        [ValidateNotNullOrEmpty]
        public string CertificateFilePath { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 5, Mandatory = true, HelpMessage = "Certificate password")]
        [Parameter(ParameterSetName = ParameterSet3Name, Position = 5, Mandatory = true, HelpMessage = "Certificate password")]
        [ValidateNotNullOrEmpty]
        public string CertificatePassword { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 6, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space")]
        [Parameter(ParameterSetName = ParameterSet4Name, Position = 6, Mandatory = true, HelpMessage = "Thumbprint of the certificate that already exists in web space")]
        [ValidateNotNullOrEmpty]
        public string Thumbprint { get; set; }

        protected override void ProcessRecord()
        {
            if (ParameterSetName != ParameterSet1Name
                && ParameterSetName != ParameterSet2Name
                && ParameterSetName != ParameterSet3Name
                && ParameterSetName != ParameterSet4Name)
            {
                throw new ValidationMetadataException("Please input web app and certificate.");
            }

            if (ParameterSetName == ParameterSet3Name
                || ParameterSetName == ParameterSet4Name)
            {
                CmdletHelpers.ExtractWebAppPropertiesFromWebApp(WebApp, out resourceGroupName, out webAppName, out slot);
            }
            else
            {
                resourceGroupName = ResourceGroupName;
                webAppName = WebAppName;
                slot = Slot;
            }

            string thumbPrint = null;
            var webapp = WebsitesClient.GetWebApp(resourceGroupName, webAppName, slot);

            switch (ParameterSetName)
            {
                case ParameterSet1Name:
                case ParameterSet3Name:
                    var certificateBytes = File.ReadAllBytes(CertificateFilePath);
                    var certificateDetails = new X509Certificate2(certificateBytes, CertificatePassword);

                    var certificateName = GenerateCertName(certificateDetails.Thumbprint, webapp.HostingEnvironmentProfile != null ? webapp.HostingEnvironmentProfile.Name : null, webapp.Location, resourceGroupName);
                    var certificate = new Certificate
                    {
                        PfxBlob = Convert.ToBase64String(certificateBytes),
                        Password = CertificatePassword,
                        Location = webapp.Location
                    };

                    if (webapp.HostingEnvironmentProfile != null)
                    {
                        certificate.HostingEnvironmentProfile = webapp.HostingEnvironmentProfile;
                    }

                    var certificateResourceGroup = CmdletHelpers.GetResourceGroupFromResourceId(webapp.ServerFarmId);
                    try
                    {
                        WebsitesClient.CreateCertificate(certificateResourceGroup, certificateName, certificate);
                    }
                    catch (CloudException e)
                    {
                        // This exception is thrown when certificate already exists. Let's swallow it and continue.
                        if (e.Response.StatusCode != HttpStatusCode.Conflict)
                        {
                            throw;
                        }
                    }

                    thumbPrint = certificateDetails.Thumbprint;
                    break;

                case ParameterSet2Name:
                case ParameterSet4Name:
                    thumbPrint = Thumbprint;
                    break;
            }

            WriteObject(CmdletHelpers.GetHostNameSslStatesFromSiteResponse(
                WebsitesClient.UpdateHostNameSslState(
                    resourceGroupName,
                    webAppName,
                    slot,
                    webapp.Location,
                    Name,
                    SslState.HasValue ? SslState.Value : Management.WebSites.Models.SslState.SniEnabled,
                    thumbPrint),
                Name));
        }

        private string GenerateCertName(string thumbPrint, string hostingEnv, string location, string resourceGroupName)
        {
            return string.Format("{0}{1}{2}", thumbPrint, CertNamePostFixSeparator, GenerateCertNamePostFix(hostingEnv, location, resourceGroupName));
        }

        private string GenerateCertNamePostFix(string hostingEnv, string location, string resourceGroupName)
        {
            return string.Format("{0}{1}{2}{3}{4}", string.IsNullOrEmpty(hostingEnv) ? "" : hostingEnv, CertNamePostFixSeparator, location, CertNamePostFixSeparator, resourceGroupName);
        }
    }
}
