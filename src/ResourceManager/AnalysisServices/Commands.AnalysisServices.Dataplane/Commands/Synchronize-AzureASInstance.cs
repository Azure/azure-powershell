using System;
using System.Linq;
using System.Management.Automation;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

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
        private static TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(1);

        private string serverName;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Azure Analysis Services server to synchronize",
            Position = 0,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of databases that need to be replicated",
            Position = 1,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
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
            if (ShouldProcess(Instance, Resources.SynchronizingAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(AsAzureClientSession.TokenCache, context.Account.UniqueId);

                Uri syncBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var syncResults = Task.WhenAll(Databases.Select(databaseName => SynchronizeDatabaseAsync(context, syncBaseUri, databaseName, accessToken))).Result;

                if (syncResults.Any(syncResult => !syncResult.SyncState.Equals(DatabaseSyncStateDetail.Succeeded)))
                {
                    var e = new ApplicationFailedException(Resources.SynchronizationFailedException);
                    WriteError(GenerateErrorRecordFromSyncDetails(syncResults));
                    throw e;
                }
                else if (PassThru.IsPresent)
                {
                    WriteObject(syncResults, true);
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

        private static ErrorRecord GenerateErrorRecordFromSyncDetails(IEnumerable<ScaleOutServerDatabaseSyncDetails> syncResults)
        {
            var errorRecord = new ErrorRecord(new ApplicationException(Resources.SynchronizationFailedException), "SynchronizeDatabasesUnsuccessful", ErrorCategory.OperationTimeout, syncResults);

            return errorRecord;
        }

        private async Task<ScaleOutServerDatabaseSyncDetails> SynchronizeDatabaseAsync(AsAzureContext context, Uri syncBaseUri, string databaseName, string accessToken, int maxNumberOfAttempts = 3)
        {
            var synchronize = string.Format((string)context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.SynchronizeEndpointFormat], serverName, databaseName);

            return await Task.Run(async () =>
            {
                var pollingUrlAndRetryAfter = await PostSyncRequestAsync(syncBaseUri, synchronize, accessToken);

                Uri pollingUrl = pollingUrlAndRetryAfter.Item1;
                var retryAfter = pollingUrlAndRetryAfter.Item2;

                if (pollingUrl != null)
                {
                    var defaultSyncDetails = new ScaleOutServerDatabaseSyncDetails
                    {
                        Database = databaseName,
                        SyncState = DatabaseSyncStateDetail.Unknown
                    };

                    ScaleOutServerDatabaseSyncResult result = await PollSyncStatusWithRetryAsync(accessToken, pollingUrl, retryAfter.Delta ?? DefaultPollingInterval,  maxNumberOfAttempts: maxNumberOfAttempts);

                    return result != null ? ScaleOutServerDatabaseSyncDetails.FromResult(result) : defaultSyncDetails;
                }
                else
                {
                    throw new HttpRequestException();
                }
            });
        }

        private async Task<Tuple<Uri, RetryConditionHeaderValue>> PostSyncRequestAsync(
            Uri syncBaseUri, 
            string synchronize,
            string accessToken)
        {
            return await Task.Run(async () =>
            {
                Uri pollingUrl = null;
                RetryConditionHeaderValue retryAfter = null;
                using (HttpResponseMessage message = await AsAzureHttpClient.CallPostAsync(
                    syncBaseUri,
                    synchronize,
                    accessToken))
                {
                    if (message.IsSuccessStatusCode)
                    {
                        pollingUrl = message.Headers.Location;
                        retryAfter = message.Headers.RetryAfter;
                    }
                }

                return new Tuple<Uri, RetryConditionHeaderValue>(pollingUrl, retryAfter);
            });
        }

        private async Task<ScaleOutServerDatabaseSyncResult> PollSyncStatusWithRetryAsync(string accessToken, Uri pollingUrl, TimeSpan pollingInterval, int maxNumberOfAttempts = 3)
        {
            return await Task.Run(async () =>
            {
                ScaleOutServerDatabaseSyncResult response = null;
                bool done = false;
                do
                {
                    IList<Exception> exceptions = new List<Exception>();

                    int numberOfAttempts = 0;
                    while (numberOfAttempts < maxNumberOfAttempts)
                    {
                        using (HttpResponseMessage message = await AsAzureHttpClient.CallGetAsync(
                            pollingUrl,
                            string.Empty,
                            accessToken))
                        {
                            done = !message.StatusCode.Equals(HttpStatusCode.SeeOther);
                            if (done)
                            {
                                if (message.IsSuccessStatusCode)
                                {
                                    response = JsonConvert.DeserializeObject<ScaleOutServerDatabaseSyncResult>(await message.Content.ReadAsStringAsync());
                                    break;
                                }
                                else
                                {
                                    numberOfAttempts++;
                                }
                            }
                            else
                            {
                                pollingUrl = message.Headers.Location;
                                pollingInterval = message.Headers.RetryAfter.Delta ?? pollingInterval;
                            }
                        }
                    }
                } while (!done);

                return response;
            });
        }
    }
}
