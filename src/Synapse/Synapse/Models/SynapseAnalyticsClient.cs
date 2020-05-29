using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Azure.Synapse;
using Microsoft.Azure.Synapse.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ResourceMoveDefinition = Microsoft.Azure.Management.Synapse.Models.ResourceMoveDefinition;
using RestorePoint = Microsoft.Azure.Management.Synapse.Models.RestorePoint;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsClient
    {
        private readonly Guid _subscriptionId;
        private readonly SynapseManagementClient _synapseManagementClient;
        private readonly SynapseClient _synapseClient;

        public SynapseAnalyticsClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.GetId();

            _synapseManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);

            _synapseClient = SynapseCmdletBase.CreateSynapseClient<SynapseClient>(context,
                AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix, true);
        }

        #region Workspace operations

        public Workspace CreateOrUpdateWorkspace(string resourceGroupName, string workspaceName, Workspace createOrUpdateParams)
        {
            try
            {
                return _synapseManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, createOrUpdateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal Workspace GetWorkspace(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseManagementClient.Workspaces.Get(resourceGroupName, workspaceName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal Workspace GetWorkspaceOrDefault(string resourceGroupName, string workspaceName)
        {
            try
            {
                return GetWorkspace(resourceGroupName, workspaceName);
            }
            catch
            {
                return null;
            }
        }

        public List<Workspace> ListWorkspaces(string resourceGroupName = null)
        {
            try
            {
                var firstPage = string.IsNullOrEmpty(resourceGroupName)
                     ? _synapseManagementClient.Workspaces.List()
                     : _synapseManagementClient.Workspaces.ListByResourceGroup(resourceGroupName);

                return ListResources(firstPage, _synapseManagementClient.Workspaces.ListNext);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteWorkspace(string resourceGroupName, string workspaceName)
        {

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
            }

            if (!TestWorkspace(resourceGroupName, workspaceName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.WorkspaceDoesNotExist, workspaceName));
            }

            try
            {
                _synapseManagementClient.Workspaces.Delete(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // parent resource not found, indicates the workspace is deleted successfully.
                    // TODO: investigate why this error is thrown.
                }
                else
                {
                    throw GetSynapseException(ex);
                }
            }
        }

        public IpFirewallRuleInfo CreateOrUpdateWorkspaceFirewallRule(
            string resourceGroupName,
            string workspaceName,
            string ruleName,
            IpFirewallRuleInfo createOrUpdateParams)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }
                return _synapseManagementClient.IpFirewallRules.CreateOrUpdate(
                    resourceGroupName,
                    workspaceName,
                    ruleName,
                    createOrUpdateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public IpFirewallRuleInfo GetFirewallRule(string resourceGroupName, string workspaceName, string ruleName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseManagementClient.IpFirewallRules.Get(resourceGroupName, workspaceName, ruleName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public List<IpFirewallRuleInfo> ListFirewallRules(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var firstPage = _synapseManagementClient.IpFirewallRules.ListByWorkspace(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseManagementClient.IpFirewallRules.ListByWorkspaceNext);
            }
            catch
            {
                throw new NotFoundException(string.Format(Properties.Resources.FailedToDiscoverFirewallRuleByWorkspace, workspaceName));
            }
        }

        public void DeleteFirewallRule(string resourceGroupName, string workspaceName, string ruleName)
        {

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
            }

            if (!TestWorkspace(resourceGroupName, workspaceName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.WorkspaceDoesNotExist, workspaceName));
            }


            if (!TestFirewallRule(resourceGroupName, workspaceName, ruleName))
            {
                throw new InvalidOperationException(string.Format(Properties.Resources.FirewallRuleDoesNotExist, ruleName));
            }

            try
            {
                _synapseManagementClient.IpFirewallRules.Delete(resourceGroupName, workspaceName, ruleName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestWorkspace(string resourceGroupName, string workspaceName)
        {
            try
            {
                GetWorkspace(resourceGroupName, workspaceName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public bool TestFirewallRule(string resourceGroupName, string workspaceName, string ruleName)
        {
            try
            {
                GetFirewallRule(resourceGroupName, workspaceName, ruleName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public string GetResourceGroupByWorkspaceName(string workspaceName)
        {
            try
            {
                var workspaceId = ListWorkspaces()
                        .Find(x => x.Name.Equals(workspaceName, StringComparison.InvariantCultureIgnoreCase))
                        .Id;

                return new ResourceIdentifier(workspaceId).ResourceGroupName;
            }
            catch
            {
                throw new NotFoundException(string.Format(Properties.Resources.FailedToDiscoverResourceGroup, workspaceName, _subscriptionId));
            }
        }

        #endregion

        #region SQL pool operations

        public SqlPool CreateSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPool createOrUpdateParams)
        {
            try
            {
                return _synapseManagementClient.SqlPools.Create(resourceGroupName, workspaceName, sqlPoolName, createOrUpdateParams);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlPool GetSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseManagementClient.SqlPools.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlPool GetSqlPoolOrDefault(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                return GetSqlPool(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch
            {
                return null;
            }
        }

        public List<SqlPool> ListSqlPools(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var firstPage = this._synapseManagementClient.SqlPools.ListByWorkspace(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseManagementClient.SqlPools.ListByWorkspaceNext);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void UpdateSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPoolPatchInfo updateParams)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseManagementClient.SqlPools.Update(resourceGroupName, workspaceName, sqlPoolName, updateParams);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                if (!TestSqlPool(resourceGroupName, workspaceName, sqlPoolName))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.SqlPoolDoesNotExist, sqlPoolName));
                }

                _synapseManagementClient.SqlPools.Delete(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                GetSqlPool(resourceGroupName, workspaceName, sqlPoolName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        public void RenameSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName, string newSqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                this._synapseManagementClient.SqlPools.Rename(
                    resourceGroupName,
                    workspaceName,
                    sqlPoolName,
                    new ResourceMoveDefinition
                    {
                        Id = Utils.ConstructResourceId(
                            _synapseManagementClient.SubscriptionId,
                            resourceGroupName,
                            ResourceTypes.SqlPool,
                            newSqlPoolName,
                            $"workspaces/{workspaceName}")
                    });
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void PauseSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                this._synapseManagementClient.SqlPools.Pause(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void ResumeSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                this._synapseManagementClient.SqlPools.Resume(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal List<RestorePoint> ListSqlPoolRestorePoints(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return this._synapseManagementClient.SqlPoolRestorePoints.List(
                    resourceGroupName,
                    workspaceName,
                    sqlPoolName)
                    .ToList();
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        #endregion

        #region Spark pool operations

        public BigDataPoolResourceInfo CreateOrUpdateSparkPool(string resourceGroupName, string workspaceName, string sparkPoolName, BigDataPoolResourceInfo createOrUpdateParams)
        {
            try
            {
                return _synapseManagementClient.BigDataPools.CreateOrUpdate(resourceGroupName, workspaceName, sparkPoolName, createOrUpdateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal BigDataPoolResourceInfo GetSparkPool(string resourceGroupName, string workspaceName, string sparkPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseManagementClient.BigDataPools.Get(resourceGroupName, workspaceName, sparkPoolName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public List<BigDataPoolResourceInfo> ListSparkPools(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var firstPage = this._synapseManagementClient.BigDataPools.ListByWorkspace(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseManagementClient.BigDataPools.ListByWorkspaceNext);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteSparkPool(string resourceGroupName, string workspaceName, string sparkPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                if (!TestSparkPool(resourceGroupName, workspaceName, sparkPoolName))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.SparkPoolDoesNotExist, sparkPoolName));
                }

                _synapseManagementClient.BigDataPools.Delete(resourceGroupName, workspaceName, sparkPoolName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestSparkPool(string resourceGroupName, string workspaceName, string sparkPoolName)
        {
            try
            {
                GetSparkPool(resourceGroupName, workspaceName, sparkPoolName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        #endregion

        #region Spark batch job operations

        public ExtendedLivyBatchResponse SubmitSparkBatchJob(string workspaceName, string sparkPoolName, ExtendedLivyBatchRequest livyRequest, bool waitForCompletion)
        {
            var batch = _synapseClient.SparkBatch.Create(workspaceName, sparkPoolName, livyRequest, detailed:true);
            if (!waitForCompletion)
            {
                return batch;
            }

            return PollSparkBatchJobSubmission(workspaceName, sparkPoolName, batch);
        }

        public ExtendedLivyBatchResponse PollSparkBatchJobSubmission(string workspaceName, string sparkPoolName, ExtendedLivyBatchResponse batch)
        {
            return Poll(
                batch,
                b => b.Result,
                b => b.State,
                b => this.GetSparkBatchJob(workspaceName, sparkPoolName, b.Id.Value),
                SparkJobLivyState.BatchSubmissionFinalStates);
        }

        public ExtendedLivyBatchResponse PollSparkBatchJobExecution(
            string workspaceName,
            string sparkPoolName,
            ExtendedLivyBatchResponse batch,
            int pollingIntervalInSeconds = 0,
            int timeoutInSeconds = 0,
            Action<string> writeLog = null)
        {
            return Poll(
                batch,
                b => b.Result,
                b => b.State,
                b => this.GetSparkBatchJob(workspaceName, sparkPoolName, b.Id.Value),
                SparkJobLivyState.BatchExecutionFinalStates,
                pollingInMilliseconds: pollingIntervalInSeconds * 1000,
                timeoutInMilliseconds: timeoutInSeconds * 1000,
                writeLog: (b) => writeLog?.Invoke(string.Format(Resources.WaitJobState, b.State)));
        }

        public List<ExtendedLivyBatchResponse> ListSparkBatchJobs(string workspaceName, string sparkPoolName, bool detailed = true)
        {
            var batches = new List<ExtendedLivyBatchResponse>();
            int from = 0;
            int currentPageSize;
            int pageSize = SynapseConstants.PageSize;
            do
            {
                var page = _synapseClient.SparkBatch.List(workspaceName, sparkPoolName, detailed: detailed, fromParameter: from, size: pageSize);
                currentPageSize = page.Total.Value;
                from += currentPageSize;
                batches.AddRange(page.Sessions.ToList());
            } while (currentPageSize == pageSize);
            return batches;
        }

        public ExtendedLivyBatchResponse GetSparkBatchJob(string workspaceName, string sparkPoolName, int batchId)
        {
            return _synapseClient.SparkBatch.Get(workspaceName, sparkPoolName, batchId, detailed:true);
        }

        public void CancelSparkBatchJob(string workspaceName, string sparkPoolName, int batchId, bool waitForCompletion)
        {
            _synapseClient.SparkBatch.Delete(workspaceName, sparkPoolName, batchId);
            if (waitForCompletion)
            {
                var batchJob = GetSparkBatchJob(workspaceName, sparkPoolName, batchId);
                PollSparkBatchJobExecution(workspaceName, sparkPoolName, batchJob);
            }
        }

        #endregion

        #region Spark session operations

        public ExtendedLivySessionResponse CreateSparkSession(string workspaceName, string sparkPoolName, ExtendedLivySessionRequest livyRequest, bool waitForCompletion)
        {
            var session = _synapseClient.SparkSession.Create(workspaceName, sparkPoolName, livyRequest);
            if (!waitForCompletion)
            {
                return session;
            }

            return PollSparkSession(workspaceName, sparkPoolName, session);
        }

        public ExtendedLivySessionResponse PollSparkSession(
            string workspaceName,
            string sparkPoolName,
            ExtendedLivySessionResponse session,
            IList<string> livyReadyStates = null)
        {
            if (livyReadyStates == null)
            {
                livyReadyStates = SparkJobLivyState.SessionSubmissionFinalStates;
            }

            return Poll(
                session,
                s => s.Result,
                s => s.State,
                s => this.GetSparkSession(workspaceName, sparkPoolName, s.Id.Value),
                livyReadyStates);
        }

        public ExtendedLivySessionResponse GetSparkSession(string workspaceName, string sparkPoolName, int sessionId)
        {
            return _synapseClient.SparkSession.Get(workspaceName, sparkPoolName, sessionId, detailed:true);
        }

        public List<ExtendedLivySessionResponse> ListSparkSessionsByName(string workspaceName, string sparkPoolName, string sessionName)
        {
            return ListSparkSessions(workspaceName, sparkPoolName).Where(s => !string.IsNullOrEmpty(s.Name) && s.Name.Equals(sessionName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<ExtendedLivySessionResponse> ListSparkSessions(string workspaceName, string sparkPoolName, bool detailed = true)
        {
            var sessions = new List<ExtendedLivySessionResponse>();
            int from = 0;
            int currentPageSize;
            int pageSize = SynapseConstants.PageSize;
            do
            {
                var page = _synapseClient.SparkSession.List(workspaceName, sparkPoolName, detailed: detailed, fromParameter: from, size: pageSize);
                currentPageSize = page.Total.Value;
                from += currentPageSize;
                sessions.AddRange(page.Sessions.ToList());
            } while (currentPageSize == pageSize);

            return sessions;
        }

        public void StopSparkSession(string workspaceName, string sparkPoolName, int sessionId, bool waitForCompletion)
        {
            _synapseClient.SparkSession.Delete(workspaceName, sparkPoolName, sessionId);
            if (waitForCompletion)
            {
                var session = GetSparkSession(workspaceName, sparkPoolName, sessionId);
                PollSparkSession(workspaceName, sparkPoolName, session, SparkJobLivyState.SessionCancellationFinalStates);
            }
        }

        public void ResetSparkSessionTimeout(string workspaceName, string sparkPoolName, int sessionId)
        {
            _synapseClient.SparkSession.ResetTimeout(workspaceName, sparkPoolName, sessionId);
        }

        #endregion

        #region Spark session statement operations

        public LivyStatementResponseBody SubmitSparkSessionStatement(string workspaceName, string sparkPoolName, int sessionId, LivyStatementRequestBody livyRequest, bool waitForCompletion)
        {
            var statement = _synapseClient.SparkSession.CreateStatement(workspaceName, sparkPoolName, sessionId, livyRequest);
            if (!waitForCompletion)
            {
                return statement;
            }

            return PollSparkSessionStatement(workspaceName, sparkPoolName, sessionId, statement);
        }

        public LivyStatementResponseBody PollSparkSessionStatement(string workspaceName, string sparkPoolName, int sessionId, LivyStatementResponseBody statement)
        {
            return Poll(
                statement,
                s => null,
                s => s.State,
                s => this.GetSparkSessionStatement(workspaceName, sparkPoolName, sessionId, s.Id.Value),
                SparkSessionStatementLivyState.ExecutingStates,
                isFinalState:false);
        }

        public LivyStatementResponseBody GetSparkSessionStatement(string workspaceName, string sparkPoolName, int sessionId, int statementId)
        {
            return _synapseClient.SparkSession.GetStatement(workspaceName, sparkPoolName, sessionId, statementId);
        }

        public List<LivyStatementResponseBody> ListSparkSessionStatements(string workspaceName, string sparkPoolName, int sessionId)
        {
            return _synapseClient.SparkSession.ListStatements(workspaceName, sparkPoolName, sessionId).Statements.ToList();
        }

        public void CancelSparkSessionStatement(string workspaceName, string sparkPoolName, int sessionId, int statementId)
        {
            if (sessionId == SynapseConstants.UnknownId)
            {
                var session = this.ListSparkSessions(workspaceName, sparkPoolName, detailed:false)
                    .FirstOrDefault(s =>
                    {
                        try
                        {
                            var stmt = this.GetSparkSessionStatement(workspaceName, sparkPoolName, s.Id.Value, statementId);
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
                    throw new SynapseException(string.Format(
                        Properties.Resources.FailedToDiscoverSparkStatement,
                        statementId,
                        workspaceName,
                        sparkPoolName));
                }

                sessionId = session.Id.Value;
            }

            _synapseClient.SparkSession.DeleteStatement(workspaceName, sparkPoolName, sessionId, statementId);
        }

        #endregion

        #region helpers

        private static List<T> ListResources<T>(
            IPage<T> firstPage,
            Func<string, IPage<T>> listNext)
        {
            var resourceList = new List<T>();
            var response = firstPage;
            resourceList.AddRange(response);

            while (!string.IsNullOrEmpty(response.NextPageLink))
            {
                response = listNext(response.NextPageLink);
                resourceList.AddRange(response);
            }

            return resourceList;
        }

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

        private static SynapseException GetSynapseException(ErrorContractException ex)
        {
            return ex.CreateSynapseException();
        }

        private static SynapseException GetSynapseException(CloudException ex)
        {
            return ex.CreateSynapseException();
        }

        #endregion
    }
}