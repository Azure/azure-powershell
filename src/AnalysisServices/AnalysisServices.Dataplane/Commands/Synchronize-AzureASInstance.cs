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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to log into an Analysis Services environment
    /// </summary>
    [Cmdlet("Sync", ResourceManager.Common.AzureRMConstants.AzurePrefix + "AnalysisServicesInstance", SupportsShouldProcess = true)]
    [Alias("Sync-AzureAsInstance", "Sync-AzAsInstance")]
    [OutputType(typeof(ScaleOutServerDatabaseSyncDetails))]
    public class SynchronizeAzureAzureAnalysisServer : AsAzureDataplaneCmdletBase
    {
        private static TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        public static TimeSpan DefaultRetryIntervalForPolling = TimeSpan.FromSeconds(10);

        private readonly string RootActivityIdHeaderName = "x-ms-root-activity-id";

        private readonly string CurrentUtcDateHeaderName = "x-ms-current-utc-date";

        private ClusterResolutionResult clusterResolveResult;

        private Guid correlationId;

        private string syncRequestRootActivityId;

        private string syncRequestTimeStamp;

        [Parameter(
            Mandatory = true,
            HelpMessage = "Identity of the database need to be synchronized",
            Position = 1,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Database { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public SynchronizeAzureAzureAnalysisServer()
        {
            this.syncRequestRootActivityId = string.Empty;
            this.correlationId = Guid.Empty;
            this.syncRequestTimeStamp = string.Empty;
        }

        protected override IAzureContext DefaultContext
        {
            get
            {
                // Nothing to do with Azure Resource Management context
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
            this._dataCollectionProfile = new AzurePSDataCollectionProfile(false);
            base.BeginProcessing();
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
        protected override void InitializeQosEvent()
        {
            // No data collection for this commandlet
        }

        public override void ExecuteCmdlet()
        {
            if (!ShouldProcess(Instance, Resources.SynchronizingAnalysisServicesServer))
            {
                return;
            }

            correlationId = Guid.NewGuid();

            WriteObject(string.Format("Sending sync request for database '{0}' to server '{1}'. Correlation Id: '{2}'.", Database, Instance, correlationId.ToString()));

            var clusterResolveResult = ClusterResolve(ServerName);
            var virtualServerName = clusterResolveResult.CoreServerName.Split(":".ToCharArray())[0];
            if (!ServerName.Equals(virtualServerName) && !clusterResolveResult.CoreServerName.EndsWith(":rw"))
            {
                throw new SynchronizationFailedException("Sync request can only be sent to the management endpoint");
            }

            this.clusterResolveResult = clusterResolveResult;
            Uri clusterBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, clusterResolveResult.ClusterFQDN));

            ScaleOutServerDatabaseSyncDetails syncResult = null;
            try
            {
                WriteProgress(new ProgressRecord(0, "Sync-AzAnalysisServicesInstance.", string.Format("Successfully authenticated for '{0}' environment.", DnsSafeHost)));
                syncResult = SynchronizeDatabaseAsync(clusterBaseUri, Database).GetAwaiter().GetResult();
            }
            catch (AggregateException aex)
            {
                foreach (var innerException in aex.Flatten().InnerExceptions)
                {
                    WriteExceptionError(innerException);
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }

            if (syncResult == null)
            {
                throw new SynchronizationFailedException(string.Format(Resources.SyncASPollStatusUnknownMessage.FormatInvariant(
                    this.clusterResolveResult.CoreServerName,
                    correlationId,
                    DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    string.Format("RootActivityId: {0}, Date Time UTC: {1}", syncRequestRootActivityId, syncRequestTimeStamp))));
            }

            if (syncResult.SyncState != DatabaseSyncState.Completed)
            {
                var serializedDetails = JsonConvert.SerializeObject(syncResult);
                throw new SynchronizationFailedException(serializedDetails);
            }

            if (PassThru.IsPresent)
            {
                WriteObject(syncResult, true);
            }
        }

        /// <summary>
        /// Worker Method for the synchronize request.
        /// </summary>
        /// <param name="syncBaseUri">Base Uri for sync</param>
        /// <param name="databaseName">Database name</param>
        /// <returns></returns>
        private async Task<ScaleOutServerDatabaseSyncDetails> SynchronizeDatabaseAsync(
            Uri syncBaseUri,
            string databaseName)
        {
            Tuple<Uri, RetryConditionHeaderValue> pollingUrlAndRetryAfter = new Tuple<Uri, RetryConditionHeaderValue>(null, null);
            ScaleOutServerDatabaseSyncDetails syncResult = null;

            return await Task.Run(async () =>
            {
                try
                {
                    var syncEndpoint = string.Format(AsAzureEndpoints.SynchronizeEndpointPathFormat, this.ServerName, databaseName);
                    this.AsAzureDataplaneClient.resetHttpClient();
                    using (var message = await AsAzureDataplaneClient.CallPostAsync(
                        baseUri: syncBaseUri,
                        requestUrl: syncEndpoint,
                        correlationId: correlationId))
                    {
                        this.syncRequestRootActivityId = message.Headers.Contains(RootActivityIdHeaderName) ? message.Headers.GetValues(RootActivityIdHeaderName).FirstOrDefault() : string.Empty;
                        this.syncRequestTimeStamp = message.Headers.Contains(CurrentUtcDateHeaderName) ? message.Headers.GetValues(CurrentUtcDateHeaderName).FirstOrDefault() : string.Empty;

                        message.EnsureSuccessStatusCode();

                        if (message.StatusCode != HttpStatusCode.Accepted)
                        {
                            var timestampNow = DateTime.Now;
                            syncResult = new ScaleOutServerDatabaseSyncDetails
                            {
                                CorrelationId = correlationId.ToString(),
                                Database = databaseName,
                                SyncState = DatabaseSyncState.Completed,
                                Details = string.Format("Http status code: {0}. Nothing readonly instances found to replicate databases.", message.StatusCode),
                                UpdatedAt = timestampNow,
                                StartedAt = timestampNow
                            };

                            return syncResult;
                        }

                        pollingUrlAndRetryAfter = new Tuple<Uri, RetryConditionHeaderValue>(message.Headers.Location, message.Headers.RetryAfter);
                    }

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
                                                                this.clusterResolveResult.CoreServerName,
                                                                this.syncRequestRootActivityId,
                                                                this.syncRequestTimeStamp,
                                                                string.Format(e.Message)),
                        UpdatedAt = timestampNow,
                        StartedAt = timestampNow
                    };
                }

                Uri pollingUrl = pollingUrlAndRetryAfter.Item1;
                var retryAfter = pollingUrlAndRetryAfter.Item2;

                try
                {
                    ScaleOutServerDatabaseSyncResult result = await this.PollSyncStatusWithRetryAsync(
                            databaseName,
                            pollingUrl,
                            retryAfter.Delta ?? DefaultPollingInterval);
                    syncResult = ScaleOutServerDatabaseSyncDetails.FromResult(result, correlationId.ToString());
                }
                catch (Exception e)
                {
                    var timestampNow = DateTime.Now;

                    // Append exception message to sync details and return
                    syncResult = new ScaleOutServerDatabaseSyncDetails
                    {
                        CorrelationId = correlationId.ToString(),
                        Database = databaseName,
                        SyncState = DatabaseSyncState.Invalid,
                        Details = Resources.SyncASPollStatusFailureMessage.FormatInvariant(
                                ServerName,
                                string.Empty,
                                timestampNow.ToString(CultureInfo.InvariantCulture),
                                string.Format(e.StackTrace)),
                        UpdatedAt = timestampNow,
                        StartedAt = timestampNow
                    };
                }

                return syncResult;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName">Database name</param>
        /// <param name="pollingUrl">URL for polling</param>
        /// <param name="pollingInterval">Polling interval set by the post response</param>
        /// <param name="maxNumberOfAttempts">Max number of attempts for each poll before the attempt is declared a failure</param>
        /// <returns></returns>
        private async Task<ScaleOutServerDatabaseSyncResult> PollSyncStatusWithRetryAsync(string databaseName, Uri pollingUrl, TimeSpan pollingInterval, int maxNumberOfAttempts = 3)
        {
            return await Task.Run(async () =>
            {
                ScaleOutServerDatabaseSyncResult response = null;
                var syncCompleted = false;
                var retryCount = 0;

                while (!syncCompleted && retryCount < maxNumberOfAttempts)
                {
                    // Wait for specified polling interval other than retries.
                    if (retryCount == 0)
                    {
                        await Task.Delay(pollingInterval);
                    }
                    else
                    {
                        await Task.Delay(DefaultRetryIntervalForPolling);
                    }

                    this.AsAzureDataplaneClient.resetHttpClient();
                    using (HttpResponseMessage message = await AsAzureDataplaneClient.CallGetAsync(
                        baseUri: pollingUrl,
                        requestUrl: string.Empty,
                        correlationId: correlationId))
                    {
                        bool shouldRetry = false;
                        if (message.IsSuccessStatusCode && message.Content != null)
                        {
                            var responseString = await message.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ScaleOutServerDatabaseSyncResult>(responseString);

                            if (response != null)
                            {
                                var state = response.SyncState;
                                if (state == DatabaseSyncState.Completed || state == DatabaseSyncState.Failed)
                                {
                                    syncCompleted = true;
                                }
                                else
                                {
                                    pollingUrl = message.Headers.Location ?? pollingUrl;
                                    pollingInterval = message.Headers.RetryAfter.Delta ?? pollingInterval;
                                }
                            }
                            else
                            {
                                shouldRetry = true;
                            }
                        }
                        else
                        {
                            shouldRetry = true;
                        }

                        if (shouldRetry)
                        {
                            retryCount++;
                            response = new ScaleOutServerDatabaseSyncResult()
                            {
                                Database = databaseName,
                                SyncState = DatabaseSyncState.Invalid
                            };

                            response.Details = string.Format(
                                "Http Error code: {0}. Message: {1}",
                                message.StatusCode.ToString(),
                                message.Content != null ? await message.Content.ReadAsStringAsync() : string.Empty);

                            if (message.StatusCode >= (HttpStatusCode)400 && message.StatusCode <= (HttpStatusCode)499)
                            {
                                break;
                            }
                        }
                        else
                        {
                            retryCount = 0;
                        }
                    }
                }

                return response;
            });
        }

        /// <summary>
        /// Resolves the cluster to which the request needs to be sent for the current environment.
        /// </summary>
        /// <param name="serverName"></param>
        /// <returns>The <see cref="ClusterResolutionResult"/>.</returns>
        private ClusterResolutionResult ClusterResolve(string serverName)
        {
            Uri clusterResolveBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, DnsSafeHost));
            return ClusterResolve(clusterResolveBaseUri, serverName);
        }
    }
}
