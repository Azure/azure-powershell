
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


using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.WebApps
{
    /// <summary>
    /// Deploy a web app from a ZIP, WAR, or JAR archive.
    /// </summary>
    [Cmdlet("Publish", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "WebApp", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet2Name), OutputType(typeof(PSSite))]
    public class PublishAzureWebAppCmdlet : WebAppOptionalSlotBaseCmdlet
    {
        // Poll status for a maximum of 35 minutes (2100 seconds / 2 seconds per status check)
        private const int NumStatusChecks = 1050;

        [Parameter(Mandatory = true, HelpMessage = "The path of the archive file. ZIP, WAR, and JAR are supported.")]
        [ValidateNotNullOrEmpty]
        public string ArchivePath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Used to override the type of artifact being deployed.")]
        [ValidateSet("war", "jar", "ear", "zip", "static")]
        public string Type { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Cleans the target directory prior to deploying the file(s).")]
        public SwitchParameter Clean { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The artifact is deployed asynchronously. (The command will exit once the artifact is pushed to the web app.)")]
        public SwitchParameter Async { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The web app will be restarted following the deployment. Set this to false if you are deploying multiple artifacts and do not want to restart the site on the earlier deployments.")]
        public SwitchParameter Restart { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Absolute path that the artifact should be deployed to.")]
        public string TargetPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disables any language-specific defaults")]
        public SwitchParameter IgnoreStack { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Reset Java web apps to default parking page")]
        public SwitchParameter Reset { get; set; }

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
            string deploymentStatusUrl = user.ScmUri + "/api/deployments/latest";

            string apiPath = "/api/publish";
            var scmUrl = new Uri(user.ScmUri);
            var deployUri = new Uri(scmUrl, apiPath);

            var uriBuilder = new UriBuilder(deployUri);
            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);

            string fileExtention = Path.GetExtension(ArchivePath);
            string[] validTypes = { "war", "jar", "ear", "zip", "static" };

            if (!string.IsNullOrEmpty(Type))
            {
                paramValues["type"] = Type;
            }

            else if (!string.IsNullOrEmpty(fileExtention))
            {
                if (validTypes.Contains(fileExtention.Substring(1)))
                {
                    paramValues["type"] = fileExtention.Substring(1);
                }

                else
                {
                    paramValues["type"] = "static";
                }
            }

            else
            {
                throw new Exception("Unknown artifact type.");
            }

            paramValues.Add("path", TargetPath);

            // Purposely using IsParameterBound to check if the parameter is passed or not. In this case we want to return true if $false is passed. 
            // We only want to set the parameter if a value is passed.
            // default async to true if not provided to match old behavior
            if (this.IsParameterBound(c => c.Async))
            {
                paramValues.Add("async", Async.ToString());
            }
            else
            {
                paramValues.Add("async", "true");
            }

            if (this.IsParameterBound(c => c.Restart))
            {
                paramValues.Add("restart", Restart.ToString());
            }

            if (this.IsParameterBound(c => c.Clean))
            {
                paramValues.Add("clean", Clean.ToString());
            }

            if (this.IsParameterBound(c => c.IgnoreStack))
            {
                paramValues.Add("ignorestack", IgnoreStack.ToString());
            }

            if (this.IsParameterBound(c => c.Reset))
            {
                paramValues.Add("reset", Reset.ToString());
            }

            uriBuilder.Query = paramValues.ToString();

            string deployUrl = uriBuilder.Uri.ToString();

            Action zipDeployAction = () =>
            {
                if (!Path.IsPathRooted(ArchivePath))
                    ArchivePath = Path.Combine(this.SessionState.Path.CurrentFileSystemLocation.Path, ArchivePath);
                using (var s = File.OpenRead(ArchivePath))
                {
                    HttpClient client = new HttpClient();
                    if (this.IsParameterBound(cmdlet => cmdlet.Timeout))
                    {
                        // Considering the deployment of large packages the default time(150 seconds) is not sufficient. So increased the timeout based on user choice.
                        client.Timeout = TimeSpan.FromMilliseconds(Timeout);
                    }

                    var token = WebsitesClient.GetAccessToken(DefaultContext);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

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
