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

using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsSparkClient
    {
        private readonly SparkBatchClient _sparkBatchClient;
        private readonly SparkSessionClient _sparkSessionClient;

        public SynapseAnalyticsSparkClient(string workspaceName, string sparkPoolName, IAzureContext context)
        {
            if (context == null)
            {
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _sparkBatchClient = new SparkBatchClient(uri, sparkPoolName, new AzureSessionCredential(context));
            _sparkSessionClient = new SparkSessionClient(uri, sparkPoolName, new AzureSessionCredential(context));
        }

        #region Spark batch job operations

        public SparkBatchJob SubmitSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool waitForCompletion)
        {
            var batch = _sparkBatchClient.StartCreateSparkBatchJob(sparkBatchJobOptions, detailed: true);
            if (!waitForCompletion)
            {
                return GetSparkBatchJob(int.Parse(batch.Id));
            }

            return batch.Poll().Value;
        }

        public SparkBatchJob PollSparkBatchJobExecution(
            SparkBatchJob batch,
            int pollingIntervalInSeconds = 0,
            int timeoutInSeconds = 0,
            Action<string> writeLog = null)
        {
            return Poll(
                batch,
                b => b.Result.ToString(),
                b => b.State,
                b => this.GetSparkBatchJob(b.Id),
                SparkJobLivyState.BatchExecutionFinalStates,
                pollingInMilliseconds: pollingIntervalInSeconds * 1000,
                timeoutInMilliseconds: timeoutInSeconds * 1000,
                writeLog: (b) => writeLog?.Invoke(string.Format(Resources.WaitJobState, b.State)));
        }

        public List<SparkBatchJob> ListSparkBatchJobs(bool detailed = true)
        {
            var batches = new List<SparkBatchJob>();
            int from = 0;
            int currentPageSize;
            int pageSize = SynapseConstants.PageSize;
            do
            {
                var page = _sparkBatchClient.GetSparkBatchJobs(from: from, size: pageSize, detailed: detailed);
                currentPageSize = page.Value.Total;
                from += currentPageSize;
                batches.AddRange(page.Value.Sessions);
            } while (currentPageSize == pageSize);
            return batches;
        }

        public SparkBatchJob GetSparkBatchJob(int batchId)
        {
            return _sparkBatchClient.GetSparkBatchJob(batchId, detailed: true);
        }

        public void CancelSparkBatchJob(int batchId, bool waitForCompletion)
        {
            _sparkBatchClient.CancelSparkBatchJob(batchId);
            if (waitForCompletion)
            {
                var batchJob = GetSparkBatchJob(batchId);
                PollSparkBatchJobExecution(batchJob);
            }
        }

        #endregion

        #region Spark session operations

        public SparkSession CreateSparkSession(SparkSessionOptions sparkSessionOptions)
        {
            var session = _sparkSessionClient.StartCreateSparkSession(sparkSessionOptions);
            return session.Poll().Value;
        }

        public SparkSession PollSparkSession(
            SparkSession session,
            IList<string> livyReadyStates = null)
        {
            if (livyReadyStates == null)
            {
                livyReadyStates = SparkJobLivyState.SessionSubmissionFinalStates;
            }

            return Poll(
                session,
                s => s.Result.ToString(),
                s => s.State,
                s => this.GetSparkSession(s.Id),
                livyReadyStates);
        }

        public SparkSession GetSparkSession(int sessionId)
        {
            return _sparkSessionClient.GetSparkSession(sessionId, detailed: true);
        }

        public List<SparkSession> ListSparkSessionsByName(string sessionName)
        {
            return ListSparkSessions().Where(s => !string.IsNullOrEmpty(s.Name) && s.Name.Equals(sessionName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<SparkSession> ListSparkSessions(bool detailed = true)
        {
            var sessions = new List<SparkSession>();
            int from = 0;
            int currentPageSize;
            int pageSize = SynapseConstants.PageSize;
            do
            {
                var page = _sparkSessionClient.GetSparkSessions(from: from, size: pageSize, detailed: detailed);
                currentPageSize = page.Value.Total;
                from += currentPageSize;
                sessions.AddRange(page.Value.Sessions);
            } while (currentPageSize == pageSize);

            return sessions;
        }

        public void StopSparkSession(int sessionId, bool waitForCompletion)
        {
            _sparkSessionClient.CancelSparkSession(sessionId);
            if (waitForCompletion)
            {
                var session = GetSparkSession(sessionId);
                PollSparkSession(session, SparkJobLivyState.SessionCancellationFinalStates);
            }
        }

        public void ResetSparkSessionTimeout(int sessionId)
        {
            _sparkSessionClient.ResetSparkSessionTimeout(sessionId);
        }

        #endregion

        #region Spark session statement operations

        public SparkStatement SubmitSparkSessionStatement(int sessionId, SparkStatementOptions sparkStatementOptions)
        {
            var statement = _sparkSessionClient.StartCreateSparkStatement(sessionId, sparkStatementOptions);
            return statement.Poll().Value;
        }

        public SparkStatement GetSparkSessionStatement(int sessionId, int statementId)
        {
            return _sparkSessionClient.GetSparkStatement(sessionId, statementId);
        }

        public List<SparkStatement> ListSparkSessionStatements(int sessionId)
        {
            return _sparkSessionClient.GetSparkStatements(sessionId).Value.Statements.ToList();
        }

        public void CancelSparkSessionStatement(string workspaceName, string sparkPoolName, int sessionId, int statementId)
        {
            if (sessionId == SynapseConstants.UnknownId)
            {
                var session = this.ListSparkSessions(detailed: false)
                    .FirstOrDefault(s =>
                    {
                        try
                        {
                            var stmt = this.GetSparkSessionStatement(s.Id, statementId);
                            return SparkSessionStatementLivyState.CancellableStates.Contains(stmt.State);
                        }
                        catch
                        {
                            // TODO: should only handle not found exception
                            return false;
                        }
                    });

                if (session == null)
                {
                    throw new AzPSInvalidOperationException(string.Format(
                        Properties.Resources.FailedToDiscoverSparkStatement,
                        statementId,
                        workspaceName,
                        sparkPoolName));
                }

                sessionId = session.Id;
            }

            _sparkSessionClient.CancelSparkStatement(sessionId, statementId);
        }

        #endregion

        #region helpers

        private static T Poll<T>(
            T job,
            Func<T, string> getJobState,
            Func<T, string> getLivyState,
            Func<T, T> refresh,
            IList<string> livyReadyStates,
            bool isFinalState = true,
            int pollingInMilliseconds = 0,
            int timeoutInMilliseconds = 0,
            Action<T> writeLog = null)
        {
            var timeWaitedInMilliSeconds = 0;
            if (pollingInMilliseconds == 0)
            {
                pollingInMilliseconds = SynapseConstants.DefaultPollingInterval;
            }

            while (IsJobRunning(getJobState(job), getLivyState(job), livyReadyStates, isFinalState))
            {
                if (timeoutInMilliseconds > 0 && timeWaitedInMilliSeconds >= timeoutInMilliseconds)
                {
                    throw new TimeoutException();
                }

                writeLog?.Invoke(job);
                //TestMockSupport.Delay(pollingInMilliseconds);
                System.Threading.Thread.Sleep(pollingInMilliseconds);
                timeWaitedInMilliSeconds += pollingInMilliseconds;

                // TODO: handle retryable excetpion
                job = refresh(job);
            }

            return job;
        }

        private static bool IsJobRunning(string jobState, string livyState, IList<string> livyStates, bool isFinalState = true)
        {
            if (SparkJobState.Succeeded.Equals(jobState, StringComparison.OrdinalIgnoreCase)
                || SparkJobState.Failed.Equals(jobState, StringComparison.OrdinalIgnoreCase)
                || SparkJobState.Cancelled.Equals(jobState, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return isFinalState ? !livyStates.Contains(livyState) : livyStates.Contains(livyState);
        }

        #endregion

    }
}
