using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Sync", "AzureAnalysisServicesInstance", SupportsShouldProcess = true)]
    [Alias("Sync-AzureAsInstance")]
    [OutputType(typeof(ScaleOutServerDatabaseSyncDetails[]))]
    public class SynchronizeAzureAzureAnalysisServer: AzurePSCmdlet
    {
        private static TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        private static TimeSpan DefaultRetryIntervalForPolling = TimeSpan.FromSeconds(1); 

        private string serverName;

        private Guid correlationId;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Azure Analysis Services server to synchronize",
            Position = 0,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Instance { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "One or more databases that need to be replicated",
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

        protected override void SetupDebuggingTraces()
        {
            // nothing to do here.
        }

        protected override void TearDownDebuggingTraces()
        {
            // nothing to do here.
        }

        protected override void SetupHttpClientPipeline()
        {
            // nothing to do here.
        }

        protected override void TearDownHttpClientPipeline()
        {
            // nothing to do here.
        }


        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.SynchronizingAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(AsAzureClientSession.TokenCache, context.Account.UniqueId);
                Uri syncBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                WriteObject(string.Format("Successfully authenticated for '{0}' environment.", context.Environment.Name));

                correlationId = Guid.NewGuid();

                ScaleOutServerDatabaseSyncDetails[] syncResults = null;
                try
                {
                    syncResults = Task.WhenAll(Databases.Select(databaseName => SynchronizeDatabaseAsync(context, syncBaseUri, databaseName, accessToken))).GetAwaiter().GetResult();
                }
                catch (AggregateException aex)
                {
                    foreach (var innerException in aex.Flatten().InnerExceptions)
                    {
                        WriteExceptionError(innerException);
                    }
                }
                catch(Exception ex)
                {
                    WriteExceptionError(ex);
                }

                WriteObject(syncResults, true);
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

        protected override void SetDataCollectionProfileIfNotExists()
        {
            // No data collection for this commandlet 
        }

        protected override void SaveDataCollectionProfile()
        {
            // No data collection for this commandlet
        }

        private static ErrorRecord GenerateErrorRecordFromSyncDetails(Exception e, IEnumerable<ScaleOutServerDatabaseSyncDetails> syncResults)
        {
            var errorRecord = new ErrorRecord(e, "SynchronizeDatabasesUnsuccessful", ErrorCategory.OperationTimeout, syncResults);

            return errorRecord;
        }

        private async Task<ScaleOutServerDatabaseSyncDetails> SynchronizeDatabaseAsync(
            AsAzureContext context, 
            Uri syncBaseUri, 
            string databaseName, 
            string accessToken, 
            int maxNumberOfAttempts = 3)
        {
            return await Task.Run(async () =>
                {
                    Tuple<Uri, RetryConditionHeaderValue> pollingUrlAndRetryAfter = new Tuple<Uri, RetryConditionHeaderValue>(null, null);
                    try
                    {
                        pollingUrlAndRetryAfter = await PostSyncRequestAsync(context, syncBaseUri, databaseName, accessToken);
                    }
                    catch (Exception e)
                    {
                        var timestampNow = DateTime.Now;

                        // Return sync details with exception message as details
                        return new ScaleOutServerDatabaseSyncDetails
                                   {
                                        CorrelationId = correlationId.ToString(),
                                        Database = databaseName,
                                        SyncState = DatabaseSyncState.Invalid,
                                        Details = Resources.PostSyncRequestFailureMessage.FormatInvariant(
                                                                    this.serverName,
                                                                    string.Empty,
                                                                    timestampNow.ToString(CultureInfo.InvariantCulture),
                                                                    string.Format(e.Message)),
                                        UpdatedAt = timestampNow,
                                        StartedAt = timestampNow
                        };
                    }

                    Uri pollingUrl = pollingUrlAndRetryAfter.Item1;
                    var retryAfter = pollingUrlAndRetryAfter.Item2;

                    try
                    {
                        ScaleOutServerDatabaseSyncResult result =   await this.PollSyncStatusWithRetryAsync(
                                databaseName,
                                accessToken,
                                pollingUrl,
                                retryAfter.Delta ?? DefaultPollingInterval,
                                maxNumberOfAttempts: maxNumberOfAttempts);
                        return ScaleOutServerDatabaseSyncDetails.FromResult(result, correlationId.ToString());
                    }
                    catch (Exception e)
                    {
                        var timestampNow = DateTime.Now;

                        // Append exception message to sync details and return
                        var details = new ScaleOutServerDatabaseSyncDetails
                            {
                                Database = databaseName,
                                SyncState = DatabaseSyncState.Invalid,
                                Details = Resources.SyncASPollStatusFailureMessage.FormatInvariant(
                                    serverName,
                                    string.Empty,
                                    timestampNow.ToString(CultureInfo.InvariantCulture),
                                    string.Format(e.Message)),
                                UpdatedAt = timestampNow,
                                StartedAt = timestampNow
                            };
                        return details;
                    }
                });
        }

        private async Task<Tuple<Uri, RetryConditionHeaderValue>> PostSyncRequestAsync(
            AsAzureContext context,
            Uri syncBaseUri, 
            string databaseName,
            string accessToken)
        {
            var synchronize = string.Format((string)context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.SyncEndpoint], serverName, databaseName);
            WriteCommandDetail(string.Format("Synchronize database {0}", databaseName) + string.Format("Submitting sync request to server", serverName));

            return await Task.Run(async () =>
            {
                this.AsAzureHttpClient.resetHttpClient();
                using (var message = await AsAzureHttpClient.CallPostAsync(
                    syncBaseUri,
                    synchronize,
                    accessToken,
                    correlationId))
                {
                    message.EnsureSuccessStatusCode();
                    var pollingUrl = message.Headers.Location;
                    var retryAfter = message.Headers.RetryAfter;

                    //WriteProgress(new ProgressRecord(0, string.Format("Synchronize database {0}", databaseName), string.Format("Successfully submitted sync request. StatusCode: {0}", message.StatusCode.ToString())));
                    WriteCommandDetail(string.Format("Synchronize database {0}. ", databaseName) + string.Format("Successfully submitted sync request. StatusCode: {0}", message.StatusCode.ToString()));
                    return new Tuple<Uri, RetryConditionHeaderValue>(pollingUrl, retryAfter);
                }
            });
        }

        private async Task<ScaleOutServerDatabaseSyncResult> PollSyncStatusWithRetryAsync(string databaseName, string accessToken, Uri pollingUrl, TimeSpan pollingInterval, int maxNumberOfAttempts = 3)
        {
            return await Task.Run(async () =>
            {
                ScaleOutServerDatabaseSyncResult response = null;
                var syncCompleted = false;
                do
                {
                    var pollingSuceeded = false;
                    var retryCount = 0;
                    while (retryCount < maxNumberOfAttempts)
                    {
                        // Wait for specified polling interval other than retries.
                        if (retryCount == 0)
                        {
                            //WriteProgress(new ProgressRecord(0, string.Format("Synchronize database {0}", databaseName), string.Format("Attempt #{0}. Waiting for {1} seconds to get sync results...", retryCount, pollingInterval.TotalSeconds)));
                            await Task.Delay(pollingInterval);
                        }
                        else
                        {
                            await Task.Delay(DefaultRetryIntervalForPolling);
                        }

                        this.AsAzureHttpClient.resetHttpClient();
                        using (HttpResponseMessage message = await AsAzureHttpClient.CallGetAsync(
                            pollingUrl,
                            string.Empty,
                            accessToken,
                            correlationId))
                        {
                            syncCompleted = !message.StatusCode.Equals(HttpStatusCode.SeeOther);
                            if (syncCompleted)
                            {
                                if (message.IsSuccessStatusCode)
                                {
                                    response = JsonConvert.DeserializeObject<ScaleOutServerDatabaseSyncResult>(await message.Content.ReadAsStringAsync());
                                    //WriteProgress(new ProgressRecord(0, string.Format("Synchronize database {0}", databaseName), string.Format("Attempt #{0}, sucessfully fetch sync results...", retryCount)));
                                    break;
                                }

                                retryCount++;
                                if (retryCount >= maxNumberOfAttempts)
                                {
                                    response = new ScaleOutServerDatabaseSyncResult()
                                                   {
                                                       Database = databaseName,
                                                       SyncState = DatabaseSyncState.Invalid,
                                                       Details =
                                                           Resources
                                                               .SyncASPollStatusFailureMessage
                                                               .FormatInvariant(
                                                                   this
                                                                       .serverName,
                                                                   message
                                                                       .Headers
                                                                       .GetValues(
                                                                           "x-ms-root-activity-id")
                                                                       .SingleOrDefault(),
                                                                   message
                                                                       .Headers
                                                                       .GetValues(
                                                                           "x-ms-current-utc-date")
                                                                       .SingleOrDefault())
                                                   };
                                }
                                else
                                {
                                    // WriteWarning(string.Format("Synchronize database {0}.", databaseName) + string.Format("Attempt #{0}, failed to get sync status. StatusCode: {1}. Retrying...", retryCount, pollingInterval.TotalSeconds));
                                }
                            }
                            else
                            {
                                pollingUrl = message.Headers.Location;
                                pollingInterval = message.Headers.RetryAfter.Delta ?? pollingInterval;
                            }
                        }
                    }
                }
                while (!syncCompleted);

                return response;
            });
        }
    }
}
