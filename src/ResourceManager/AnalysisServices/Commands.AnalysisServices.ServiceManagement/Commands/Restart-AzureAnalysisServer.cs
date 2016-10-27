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

using System;
using System.Management.Automation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.ServiceManagement.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.AnalysisServices.ServiceManagement
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Restart", "AzureAnalysisServer", SupportsShouldProcess=true)]
    [Alias("Restart-AzureAs")]
    [OutputType(typeof(AsAzureProfile))]
    public class RestartAzureAnalysisServer: AzurePSCmdlet, IModuleAssemblyInitializer
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of the Azure Analysis Services server to restart")]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override AzureContext DefaultContext { get; }

        protected override void SaveDataCollectionProfile()
        {
            // No data collection for this commandlet 
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
            // No data collection for this commandlet 
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

#pragma warning disable 0618
            if (Instance == null)
            {
                throw new PSArgumentNullException(nameof(Instance));
            }

            if (AsAzureClientSession.Instance.Profile.Environments.Count == 0)
            {
                throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
            }
#pragma warning restore 0618
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Instance))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                var restartEndpoint = string.Format(context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat], Instance);
                string restartBaseUri = string.Format("https://{0}", context.Environment.Name);
                var accessToken = AsAzureClientSession.GetAadAuthenticatedToken(
                    context, 
                    null, 
                    PromptBehavior.Auto, 
                    AsAzureClientSession.AsAzureClientId, 
                    restartBaseUri, 
                    AsAzureClientSession.RedirectUri);

                using (HttpResponseMessage message = CallPostAsync(
                    new Uri(restartBaseUri),
                    restartEndpoint,
                    accessToken).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
            else
            {
                WriteExceptionError(new PSArgumentNullException(nameof(Instance), "Name of Azure Analysis Services server not specified"));
            }
        }

        public static async Task<HttpResponseMessage> CallPostAsync(Uri baseURI, string requestURL, string accessToken)
        {
            using (HttpClient client = new HttpClient())
            {
                if (accessToken == null)
                {
                    throw new PSArgumentNullException(nameof(accessToken), string.Format(Resources.NotLoggedInMessage, ""));
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = baseURI;
                HttpResponseMessage response = await client.PostAsync(requestURL, new StringContent(""));
                return response;
            }
        }

        public void OnImport()
        {
            // Nothing to do on assembly initialize
        }
    }
}
