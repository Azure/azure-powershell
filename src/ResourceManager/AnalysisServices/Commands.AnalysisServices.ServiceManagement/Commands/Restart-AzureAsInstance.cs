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
using System.Linq;
using System.Management.Automation;
using System.Management.Instrumentation;
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
    [Cmdlet("Restart", "AzureAsInstance", SupportsShouldProcess=true)]
    [Alias("Restart-AzureAs")]
    [OutputType(typeof(AsAzureProfile))]
    public class RestartAzureAnalysisServer: AzurePSCmdlet, IModuleAssemblyInitializer
    {
        private string serverName;

        [Parameter(Mandatory = true, HelpMessage = "Name of the Azure Analysis Services server to restart")]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        protected override AzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Managment context
                return null;
            }
        }

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
                throw new PSArgumentNullException(nameof(Instance), "Name of Azure Analysis Services server not specified");
            }

            if (AsAzureClientSession.Instance.Profile.Environments.Count == 0)
            {
                throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
            }

            serverName = Instance;
            Uri uriResult;

            // if the user specifies the FQN of the server, then extract the servername out of that.
            // and set the current context
            if (Uri.TryCreate(Instance, UriKind.Absolute, out uriResult) && uriResult.Scheme == "asazure")
            {
                serverName = uriResult.PathAndQuery.Trim('/');
                if (string.Compare(AsAzureClientSession.Instance.Profile.Context.Environment.Name, uriResult.DnsSafeHost, StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    AsAzureClientSession.Instance.SetCurrentContext(
                        new AsAzureAccount(),
                        AsAzureClientSession.Instance.Profile.CreateEnvironment(uriResult.DnsSafeHost));
                }
            }

#pragma warning restore 0618
        }

        protected override void InitializeQosEvent()
        {
            // nothing to do here.
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.RestartingAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);
                TokenCacheItem tokenCacheItem = AsAzureClientSession.TokenCache.ReadItems()
                    .FirstOrDefault(tokenItem => tokenItem.TenantId.Equals(context.Account.Tenant));

                if (tokenCacheItem == null || string.IsNullOrEmpty(tokenCacheItem.AccessToken))
                {
                    throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
                }

                Uri restartBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var restartEndpoint = string.Format(context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat], serverName);
                using (HttpResponseMessage message = CallPostAsync(
                    restartBaseUri,
                    restartEndpoint,
                    tokenCacheItem.AccessToken).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
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
