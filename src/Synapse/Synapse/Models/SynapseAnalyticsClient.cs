using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CloudException = Microsoft.Rest.Azure.CloudException;
using ResourceMoveDefinition = Microsoft.Azure.Management.Synapse.Models.ResourceMoveDefinition;
using RestorePoint = Microsoft.Azure.Management.Synapse.Models.RestorePoint;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsClient
    {
        private readonly Guid _subscriptionId;
        private readonly SynapseManagementClient _synapseManagementClient;
        private SparkBatchClient _sparkBatchClient;
        private SparkSessionClient _sparkSessionClient;

        public SynapseAnalyticsClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.GetId();

            _synapseManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);

            //_synapseClient = SynapseCmdletBase.CreateSynapseClient<SynapseClient>(context,
            //    AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix, true);

        }

        public void CreateSparkBatchClient(string workspaceName, string sparkPoolName, IAzureContext context)
        {
            // ".dev.azuresynapse.net"
            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            this._sparkBatchClient = new SparkBatchClient(uri, sparkPoolName, new AzureSessionCredential(context));
        }

        public void CreateSparkSessionClient(string workspaceName, string sparkPoolName, IAzureContext context)
        {
            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            this._sparkSessionClient = new SparkSessionClient(uri, sparkPoolName, new AzureSessionCredential(context));
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

        public SparkBatchJob SubmitSparkBatchJob(SparkBatchJobOptions sparkBatchJobOptions, bool waitForCompletion)
        {
            var batch = _sparkBatchClient.CreateSparkBatchJob(sparkBatchJobOptions, detailed: true);
            if (!waitForCompletion)
            {
                return batch;
            }
            
            return PollSparkBatchJobSubmission(batch);
        }

        public SparkBatchJob PollSparkBatchJobSubmission(SparkBatchJob batch)
        {
            return Poll(
                batch,
                b => b.Result.ToString(),
                b => b.State,
                b => this.GetSparkBatchJob(b.Id),
                SparkJobLivyState.BatchSubmissionFinalStates);
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

        public SparkSession CreateSparkSession(SparkSessionOptions sparkSessionOptions, bool waitForCompletion)
        {
            var session = _sparkSessionClient.CreateSparkSession(sparkSessionOptions);
            if (!waitForCompletion)
            {
                return session;
            }

            return PollSparkSession(session);
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

        public SparkStatement SubmitSparkSessionStatement(int sessionId, SparkStatementOptions sparkStatementOptions, bool waitForCompletion)
        {
            var statement = _sparkSessionClient.CreateSparkStatement(sessionId, sparkStatementOptions);
            if (!waitForCompletion)
            {
                return statement;
            }

            return PollSparkSessionStatement(sessionId, statement);
        }

        public SparkStatement PollSparkSessionStatement(int sessionId, SparkStatement statement)
        {
            return Poll(
                statement,
                s => null,
                s => s.State,
                s => this.GetSparkSessionStatement(sessionId, s.Id),
                SparkSessionStatementLivyState.ExecutingStates,
                isFinalState:false);
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
                var session = this.ListSparkSessions(detailed:false)
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
                    throw new SynapseException(string.Format(
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