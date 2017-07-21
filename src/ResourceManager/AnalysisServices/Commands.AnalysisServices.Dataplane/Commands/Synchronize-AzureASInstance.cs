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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Synchronize", "AzureAnalysisServicesInstance", SupportsShouldProcess = true)]
    [Alias("Synchronize-AzureAsInstance")]
    [OutputType(typeof(bool))]
    public class SynchronizeAzureAzureAnalysisServer: AzurePSCmdlet
    {
        private string serverName;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Azure Analysis Services server to synchronize",
            Position = 0,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of databases that need to be replicated. Omitting this parameter will replicate all databases.",
            Position = 1,
            ValueFromPipeline = true)]
        public string[] Databases { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
                return null;
            }
        }

        public IAsAzureHttpClient AsAzureHttpClient { get; private set; }

        public ITokenCacheItemProvider TokenCacheItemProvider { get; private set; }

        public SynchronizeAzureAzureAnalysisServer(): this(new AsAzureHttpClient(() => new HttpClient()), new TokenCacheItemProvider())
        {
        }

        public SynchronizeAzureAzureAnalysisServer(IAsAzureHttpClient AsAzureHttpClient, ITokenCacheItemProvider TokenCacheItemProvider)
        {
            this.AsAzureHttpClient = AsAzureHttpClient;
            this.TokenCacheItemProvider = TokenCacheItemProvider;
        }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.RestartingAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(AsAzureClientSession.TokenCache, context.Account.UniqueId);

                Uri syncBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var synchronize = string.Format((string)context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.SynchronizeEndpointFormat], serverName);

                HttpContent requestBody = CreateRequestBodyFromDatabases(Databases);

                // POST synchronize request
                Uri pollingUrl;
                using (HttpResponseMessage message = AsAzureHttpClient.CallPostAsync(
                    syncBaseUri,
                    synchronize,
                    accessToken,
                    content: requestBody).Result)
                {
                    message.EnsureSuccessStatusCode();
                    pollingUrl = message.Headers.Location;
                }

                // GET operation status until terminated (succeed / fail)
                if (pollingUrl != null)
                {
                    bool done = false;
                    do
                    {
                        using (HttpResponseMessage message = AsAzureHttpClient.CallGetAsync(
                            pollingUrl,
                            string.Empty,
                            accessToken).Result)
                        {
                            done = !message.StatusCode.Equals(System.Net.HttpStatusCode.SeeOther);
                            if (done)
                            {
                                message.EnsureSuccessStatusCode();
                                if (PassThru.IsPresent)
                                {
                                    WriteObject(true);
                                }
                            }
                            else
                            {
                                pollingUrl = message.Headers.Location;
                            }
                        }
                    } while (!done);
                }
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
            // No data collection for this commandlet
        }

        protected override void PromptForDataCollectionProfileIfNotExists()
        {
            // No data collection for this commandlet
        }

        protected override void SaveDataCollectionProfile()
        {
            // No data collection for this commandlet
        }

        private static StringContent CreateRequestBodyFromDatabases(IEnumerable<string> databaseNames)
        {
            var requestPayloadModel = new SynchronizeModel
            {
                Databases = databaseNames
            };

            var content = JsonConvert.SerializeObject(requestPayloadModel);
            return new StringContent(content);
        }
    }
}
