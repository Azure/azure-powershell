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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    /// <summary>
    /// Cmdlet to sync Analysis Services server databases.
    /// </summary>
    [Cmdlet("Sync", ResourceManager.Common.AzureRMConstants.AzurePrefix + "AnalysisServicesInstance", SupportsShouldProcess = true)]
    [Alias("Sync-AzureAsInstance", "Sync-AzAsInstance")]
    [OutputType(typeof(ScaleOutServerDatabaseSyncDetails))]
    public class SynchronizeAzureAzureAnalysisServer : AsAzureDataplaneCmdletBase
    {
        /// <summary>
        /// Default time interval to wait between polls for sync status.
        /// </summary>
        public static TimeSpan DefaultRetryIntervalForPolling = TimeSpan.FromSeconds(10);

        [Parameter(
            Mandatory = true,
            HelpMessage = "Identity of the database need to be synchronized",
            Position = 1,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string Database { get; set; }

        /// <summary>
        /// Default time interval to wait before first poll for sync status.
        /// </summary>
        private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Http Header name for root activity id.
        /// </summary>
        private readonly string RootActivityIdHeaderName = "x-ms-root-activity-id";

        /// <summary>
        /// Http Header name for current UTC date and time.
        /// </summary>
        private readonly string CurrentUtcDateHeaderName = "x-ms-current-utc-date";

        /// <summary>
        /// Correlation ID for http requests.
        /// </summary>
        private Guid correlationId = Guid.Empty;

        /// <summary>
        /// The root activity id for this sync activity.
        /// </summary>
        private string syncRequestRootActivityId = string.Empty;

        /// <summary>
        /// Time stamp for the sync request.
        /// </summary>
        private string syncRequestTimeStamp = string.Empty;

        /// <inheritdoc cref="AzurePSCmdlet.ExecuteCmdlet"/>
        public override void ExecuteCmdlet()
        {
            if (!ShouldProcess(Instance, Resources.SynchronizingAnalysisServicesServer))
            {
                return;
            }

            WriteProgress(new ProgressRecord(0, "Sync-AzAnalysisServicesInstance.", string.Format("Successfully authenticated for '{0}' environment.", DnsSafeHost)));
            correlationId = Guid.NewGuid();
            Uri clusterBaseUri = new Uri(string.Format("{0}{1}{2}", Uri.UriSchemeHttps, Uri.SchemeDelimiter, DnsSafeHost));
            ScaleOutServerDatabaseSyncDetails syncResult = null;

            try
            {
                WriteObject(string.Format("Sending sync request for database '{0}' to server '{1}'. Correlation Id: '{2}'.", Database, Instance, correlationId.ToString()));
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
                    ServerName,
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

        /// <inheritdoc cref="AsAzureDataplaneCmdletBase.BeginProcessing"/>
        protected override void BeginProcessing()
        {
            this._dataCollectionProfile = new AzurePSDataCollectionProfile(false);
            base.BeginProcessing();
        }

        /// <inheritdoc cref="AzurePSCmdlet.SetupDebuggingTraces"/>
        protected override void SetupDebuggingTraces()
        {
            // nothing to do here.
        }

        /// <inheritdoc cref="AzurePSCmdlet.TearDownDebuggingTraces"/>
        protected override void TearDownDebuggingTraces()
        {
            // nothing to do here.
        }

        /// <inheritdoc cref="AzurePSCmdlet.SetupHttpClientPipeline"/>
        protected override void SetupHttpClientPipeline()
        {
            // nothing to do here.
        }

        /// <inheritdoc cref="AzurePSCmdlet.TearDownHttpClientPipeline"/>
        protected override void TearDownHttpClientPipeline()
        {
            // nothing to do here.
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
                var syncEndpoint = string.Format(AsAzureEndpoints.SynchronizeEndpointPathFormat, this.ServerName, databaseName);
                this.AsAzureDataplaneClient.ResetHttpClient();
                using (var message = await AsAzureDataplaneClient.CallPostAsync(syncBaseUri, syncEndpoint, correlationId))
                {
                    this.syncRequestRootActivityId = message.Headers.Contains(RootActivityIdHeaderName) ? message.Headers.GetValues(RootActivityIdHeaderName).FirstOrDefault() : string.Empty;
                    this.syncRequestTimeStamp = message.Headers.Contains(CurrentUtcDateHeaderName) ? message.Headers.GetValues(CurrentUtcDateHeaderName).FirstOrDefault() : string.Empty;

                    if (message.StatusCode != HttpStatusCode.Accepted)
                    {
                        var timestampNow = DateTime.Now;

                        // Return sync details with exception message as details
                        return new ScaleOutServerDatabaseSyncDetails
                        {
                            CorrelationId = correlationId.ToString(),
                            Database = databaseName,
                            SyncState = DatabaseSyncState.Invalid,
                            Details = Resources.PostSyncRequestFailureMessage.FormatInvariant(
                                                                    ServerName,
                                                                    this.syncRequestRootActivityId,
                                                                    this.syncRequestTimeStamp,
                                                                    await message.Content.ReadAsStringAsync()),
                            UpdatedAt = timestampNow,
                            StartedAt = timestampNow
                        };
                    }

                    pollingUrlAndRetryAfter = new Tuple<Uri, RetryConditionHeaderValue>(message.Headers.Location, message.Headers.RetryAfter);
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
        /// Worker Method for the synchronize request.
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

                    this.AsAzureDataplaneClient.ResetHttpClient();
                    using (HttpResponseMessage message = await AsAzureDataplaneClient.CallGetAsync(pollingUrl, string.Empty, correlationId))
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
    }
}
