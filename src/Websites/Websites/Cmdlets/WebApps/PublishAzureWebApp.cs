
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
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Deploy a web app from a ZIP, WAR, or JAR archive.
    /// </summary>
    [Cmdlet("Publish", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebApp", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet2Name), OutputType(typeof(PSSite))]
    public class PublishAzureWebAppCmdlet : WebAppOptionalSlotBaseCmdlet
    {
        // Poll status for a maximum of 20 minutes (1200 seconds / 2 seconds per status check)
        private const int NumStatusChecks = 600;

        [Parameter(Mandatory = true, HelpMessage = "The path of the archive file. ZIP, WAR, and JAR are supported.")]
        [ValidateNotNullOrEmpty]
        public string ArchivePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Deploy the web app without prompting for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Configurable timeout in millseconds to wait for deployment operation to complete. The default timeout is 100000 milliseconds")]
        [ValidateRange(100000, 3600000)]
        public double Timeout { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            User user = WebsitesClient.GetPublishingCredentials(ResourceGroupName, Name, Slot);

            HttpResponseMessage r;
            string deployUrl;
            string deploymentStatusUrl = user.ScmUri + "/api/deployments/latest";

            if (ArchivePath.ToLower().EndsWith("war"))
            {
                deployUrl = user.ScmUri + "/api/wardeploy?isAsync=true";
            }
            else if (ArchivePath.ToLower().EndsWith("zip") || ArchivePath.ToLower().EndsWith("jar"))
            {
                deployUrl = user.ScmUri + "/api/zipdeploy?isAsync=true";
            }
            else
            {
                throw new Exception("Unknown archive type.");
            }

            Action zipDeployAction = () =>
            {
                using (var s = File.OpenRead(ArchivePath))
                {
                    HttpClient client = new HttpClient();
                    if (this.IsParameterBound(cmdlet => cmdlet.Timeout))
                    {
                        // Considering the deployment of large packages the default time(150 seconds) is not sufficient. So increased the timeout based on user choice.
                        client.Timeout = TimeSpan.FromMilliseconds(Timeout);
                    }

                    var byteArray = Encoding.ASCII.GetBytes(user.PublishingUserName + ":" + user.PublishingPassword);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    HttpContent fileContent = new StreamContent(s);
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
                    r = client.PostAsync(deployUrl, fileContent).Result;

                    // Checking the response of the post request. If the post request fails with 502 or 503 HTTP status 
                    // then deployments/latest endpoint may give false postive result.  
                    if (r.StatusCode != HttpStatusCode.OK && r.StatusCode != HttpStatusCode.Accepted)
                    {
                        var rec = new ErrorRecord(new Exception("Deployment failed with status code " + r.StatusCode), string.Empty, ErrorCategory.InvalidResult, null);
                        WriteError(rec);
                        return;
                    }

                    int numChecks = 0;
                    do
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        r = client.GetAsync(deploymentStatusUrl).Result;
                        numChecks++;
                    } while (r.StatusCode == HttpStatusCode.Accepted && numChecks < NumStatusChecks);

                    if (r.StatusCode == HttpStatusCode.Accepted && numChecks >= NumStatusChecks)
                    {
                        var rec = new ErrorRecord(new Exception("Maximum status polling time exceeded. Deployment is still in progress."), string.Empty, ErrorCategory.OperationTimeout, null);
                        WriteError(rec);
                    }
                    else if (r.StatusCode != HttpStatusCode.OK)
                    {
                        var rec = new ErrorRecord(new Exception("Deployment failed with status code " + r.StatusCode), string.Empty, ErrorCategory.InvalidResult, null);
                        WriteError(rec);
                    }
                }
            };

            ConfirmAction(this.Force.IsPresent, $"Contents of {ArchivePath} will be deployed to the web app {Name}.", "The web app has been deployed.", Name, zipDeployAction);

            PSSite app = new PSSite(WebsitesClient.GetWebApp(ResourceGroupName, Name, Slot));
            WriteObject(app);
        }

    }
}
