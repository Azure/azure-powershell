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
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Restart", "AzureAnalysisServicesInstance", SupportsShouldProcess=true)]
    [Alias("Restart-AzureAsInstance")]
    [OutputType(typeof(bool))]
    public class RestartAzureAnalysisServer: AzurePSCmdlet
    {
        private string serverName;

        [Parameter(Mandatory = true, HelpMessage = "Name of the Azure Analysis Services server to restart")]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public IAsAzureHttpClient AsAzureHttpClient { get; private set; }

        public ITokenCacheItemProvider TokenCacheItemProvider { get; private set; }

        public RestartAzureAnalysisServer()
        {
            this.AsAzureHttpClient = new AsAzureHttpClient(() => new HttpClient());
            this.TokenCacheItemProvider = new TokenCacheItemProvider();

        }

        public RestartAzureAnalysisServer(IAsAzureHttpClient AsAzureHttpClient, ITokenCacheItemProvider TokenCacheItemProvider)
        {
            this.AsAzureHttpClient = AsAzureHttpClient;
            this.TokenCacheItemProvider = TokenCacheItemProvider;
        }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Managment context
                return null;
            }
        }

        protected override string DataCollectionWarning
        {
            get
            {
                return Resources.ARMDataCollectionMessage;
            }
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

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
            else
            {
                var currentContext = AsAzureClientSession.Instance.Profile.Context;
                if (currentContext != null 
                    && AsAzureClientSession.AsAzureRolloutEnvironmentMapping.ContainsKey(currentContext.Environment.Name))
                {
                    throw new PSInvalidOperationException(string.Format(Resources.InvalidServerName, serverName));
                }
            }

            if (this.AsAzureHttpClient == null)
            {
                this.AsAzureHttpClient = new AsAzureHttpClient(() =>
                {
                    return new HttpClient();
                });
            }

            if (this.TokenCacheItemProvider == null)
            {
                this.TokenCacheItemProvider = new TokenCacheItemProvider();
            }
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
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(AsAzureClientSession.TokenCache, context.Account.UniqueId);

                Uri restartBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var restartEndpoint = string.Format((string)context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat], serverName);

                using (HttpResponseMessage message = AsAzureHttpClient.CallPostAsync(
                    restartBaseUri,
                    restartEndpoint,
                    accessToken).Result)
                {
                    message.EnsureSuccessStatusCode();
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                }
            }
        }
    }
}
