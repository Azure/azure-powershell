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

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Instance, Resources.SynchronizingAnalysisServicesServer))
            {
                var context = AsAzureClientSession.Instance.Profile.Context;
                AsAzureClientSession.Instance.Login(context, null);
                string accessToken = this.TokenCacheItemProvider.GetTokenFromTokenCache(AsAzureClientSession.TokenCache, context.Account.UniqueId);

                Uri syncBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, context.Environment.Name));

                var syncResults = Task.WhenAll(Databases.Select(databaseName => SynchronizeDatabaseAsync(context, syncBaseUri, databaseName, accessToken))).Result;

                if (syncResults.Any(syncResult => !syncResult.SyncState.Equals(DatabaseSyncState.Completed)))
                {
                    var e = new SynchronizationFailedException();
                    WriteError(GenerateErrorRecordFromSyncDetails(e, syncResults));
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
            var synchronize = string.Format((string)context.Environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.SyncEndpoint], serverName, databaseName);

            Func<ScaleOutServerDatabaseSyncDetails> GetDefaultSyncDetails = () => new ScaleOutServerDatabaseSyncDetails
                {
                    Database = databaseName,
                    SyncState = DatabaseSyncState.Invalid,
                    Details = Resources.SyncASPollStatusFailureMessage.FormatInvariant(
                        string.Empty,
                        string.Empty,
                        DateTime.Now.ToString(CultureInfo.InvariantCulture))
                };

            return await Task.Run(async () =>
                {
                    Tuple<Uri, RetryConditionHeaderValue> pollingUrlAndRetryAfter = new Tuple<Uri, RetryConditionHeaderValue>(null, null);
                    try
                    {
                        pollingUrlAndRetryAfter = await PostSyncRequestAsync(syncBaseUri, synchronize, accessToken);
                    }
                    catch (Exception e)
                    {
                        // Return sync details with exception message as details
                        return new ScaleOutServerDatabaseSyncDetails
                                   {
                                       Database = databaseName,
                                       SyncState = DatabaseSyncState.Invalid,
                                       Details = e.Message
                                   };
                    }

                    Uri pollingUrl = pollingUrlAndRetryAfter.Item1;
                    var retryAfter = pollingUrlAndRetryAfter.Item2;

                    try
                    {
                        ScaleOutServerDatabaseSyncResult result =
                            await this.PollSyncStatusWithRetryAsync(
                                databaseName,
                                accessToken,
                                pollingUrl,
                                retryAfter.Delta ?? DefaultPollingInterval,
                                maxNumberOfAttempts: maxNumberOfAttempts);
                        return ScaleOutServerDatabaseSyncDetails.FromResult(result);
                    }
                    catch (Exception e)
                    {
                        // Append exception message to sync details and return
                        var details = GetDefaultSyncDetails();
                        var sb = new StringBuilder(details.Details);
                        sb.AppendLine(e.Message);
                        details.Details = sb.ToString();
                        return details;
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
                using (var message = await AsAzureHttpClient.CallPostAsync(
                    syncBaseUri,
                    synchronize,
                    accessToken))
                {
                    message.EnsureSuccessStatusCode();
                    var pollingUrl = message.Headers.Location;
                    var retryAfter = message.Headers.RetryAfter;
                    return new Tuple<Uri, RetryConditionHeaderValue>(pollingUrl, retryAfter);
                }
            });
        }

        private async Task<ScaleOutServerDatabaseSyncResult> PollSyncStatusWithRetryAsync(string databaseName, string accessToken, Uri pollingUrl, TimeSpan pollingInterval, int maxNumberOfAttempts = 3)
        {
            return await Task.Run(async () =>
            {
                ScaleOutServerDatabaseSyncResult response = null;
                var done = false;
                do
                {
                    var numberOfAttempts = 0;
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

                                numberOfAttempts++;
                                if (numberOfAttempts >= maxNumberOfAttempts)
                                {
                                    response = new ScaleOutServerDatabaseSyncResult()
                                                   {
                                                       Database = databaseName,
                                                       SyncState =
                                                           DatabaseSyncState
                                                               .Invalid,
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
                            }
                            else
                            {
                                pollingUrl = message.Headers.Location;
                                pollingInterval = message.Headers.RetryAfter.Delta ?? pollingInterval;
                            }
                        }
                    }
                }
                while (!done);

                return response;
            });
        }
    }
}
