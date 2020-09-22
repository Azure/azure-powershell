using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsManagementClient
    {
        private readonly Guid _subscriptionId;
        private readonly SynapseManagementClient _synapseManagementClient;
        private readonly SynapseSqlV3ManagementClient _synapseSqlV3ManagementClient;

        public SynapseAnalyticsManagementClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            _subscriptionId = context.Subscription.GetId();

            _synapseManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);

            _synapseSqlV3ManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseSqlV3ManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
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

        #region SQL Pool V3 operations

        public SqlPoolV3 CreateSqlPoolV3(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPoolV3 createOrUpdateParams)
        {
            try
            {
                return _synapseSqlV3ManagementClient.SqlPoolsV3.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, createOrUpdateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlPoolV3 GetSqlPoolV3(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseSqlV3ManagementClient.SqlPoolsV3.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlPoolV3 GetSqlPoolV3OrDefault(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                return GetSqlPoolV3(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch
            {
                return null;
            }
        }

        public List<SqlPoolV3> ListSqlPoolsV3(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var firstPage = this._synapseSqlV3ManagementClient.SqlPoolsV3.ListByWorkspace(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseSqlV3ManagementClient.SqlPoolsV3.ListByWorkspaceNext);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void UpdateSqlPoolV3(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPoolUpdate updateParams)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseSqlV3ManagementClient.SqlPoolsV3.Update(resourceGroupName, workspaceName, sqlPoolName, updateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteSqlPoolV3(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                if (!TestSqlPoolV3(resourceGroupName, workspaceName, sqlPoolName))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.SqlPoolDoesNotExist, sqlPoolName));
                }

                _synapseSqlV3ManagementClient.SqlPoolsV3.Delete(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestSqlPoolV3(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                GetSqlPoolV3(resourceGroupName, workspaceName, sqlPoolName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
            }
        }

        #endregion

        #region SQL Database operations

        public SqlDatabase CreateSqlDatabase(string resourceGroupName, string workspaceName, string sqlDatabaseName, SqlDatabase createOrUpdateParams)
        {
            try
            {
                return _synapseSqlV3ManagementClient.SqlDatabases.CreateOrUpdate(resourceGroupName, workspaceName, sqlDatabaseName, createOrUpdateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlDatabase GetSqlDatabase(string resourceGroupName, string workspaceName, string sqlDatabaseName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return _synapseSqlV3ManagementClient.SqlDatabases.Get(resourceGroupName, workspaceName, sqlDatabaseName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal SqlDatabase GetSqlDatabaseOrDefault(string resourceGroupName, string workspaceName, string sqlDatabaseName)
        {
            try
            {
                return GetSqlDatabase(resourceGroupName, workspaceName, sqlDatabaseName);
            }
            catch
            {
                return null;
            }
        }

        public List<SqlDatabase> ListSqlDatabases(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var firstPage = this._synapseSqlV3ManagementClient.SqlDatabases.ListByWorkspace(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseSqlV3ManagementClient.SqlDatabases.ListByWorkspaceNext);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void UpdateSqlDatabase(string resourceGroupName, string workspaceName, string sqlDatabaseName, SqlDatabaseUpdate updateParams)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseSqlV3ManagementClient.SqlDatabases.Update(resourceGroupName, workspaceName, sqlDatabaseName, updateParams);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteSqlDatabase(string resourceGroupName, string workspaceName, string sqlDatabaseName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                if (!TestSqlDatabase(resourceGroupName, workspaceName, sqlDatabaseName))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.SqlDatabaseDoesNotExist, sqlDatabaseName));
                }

                _synapseSqlV3ManagementClient.SqlDatabases.Delete(resourceGroupName, workspaceName, sqlDatabaseName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestSqlDatabase(string resourceGroupName, string workspaceName, string sqlDatabaseName)
        {
            try
            {
                GetSqlDatabase(resourceGroupName, workspaceName, sqlDatabaseName);
                return true;
            }
            catch (NotFoundException)
            {
                return false;
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

        #region integration runtime operations

        public virtual async Task<List<PSIntegrationRuntime>> ListIntegrationRuntimesAsync(SynapseEntityFilterOptions filterOptions)
        {
            try
            {
                if (string.IsNullOrEmpty(filterOptions.ResourceGroupName))
                {
                    filterOptions.ResourceGroupName = GetResourceGroupByWorkspaceName(filterOptions.WorkspaceName);
                }

                var integrationRuntimes = new List<PSIntegrationRuntime>();

                IPage<IntegrationRuntimeResource> response;
                if (filterOptions.NextLink.IsNextPageLink())
                {
                    response = await _synapseManagementClient.IntegrationRuntimes.ListByWorkspaceNextAsync(filterOptions.NextLink);
                }
                else
                {
                    response = await _synapseManagementClient.IntegrationRuntimes.ListByWorkspaceAsync(
                        filterOptions.ResourceGroupName,
                        filterOptions.WorkspaceName);
                }

                filterOptions.NextLink = response?.NextPageLink;
                if (response == null)
                {
                    return integrationRuntimes;
                }

                foreach (var integrationRuntime in response.ToList())
                {
                    var managed = integrationRuntime.Properties as ManagedIntegrationRuntime;
                    if (managed != null)
                    {
                        integrationRuntimes.Add(new PSManagedIntegrationRuntime(
                            integrationRuntime,
                            filterOptions.ResourceGroupName,
                            filterOptions.WorkspaceName));
                    }
                    else
                    {
                        var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                        if (selfHosted != null)
                        {
                            integrationRuntimes.Add(CreateSelfHostedIntegrationRuntime(
                                integrationRuntime,
                                filterOptions.ResourceGroupName,
                                filterOptions.WorkspaceName));
                        }
                        else
                        {
                            integrationRuntimes.Add(new PSIntegrationRuntime(
                                integrationRuntime,
                                filterOptions.ResourceGroupName,
                                filterOptions.WorkspaceName));
                        }
                    }
                }

                return integrationRuntimes;
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }

        }

        private PSIntegrationRuntime CreateSelfHostedIntegrationRuntime(
            IntegrationRuntimeResource integrationRuntime,
            string resourceGroupName,
            string workspaceName)
        {
            PSIntegrationRuntime psIntegrationRuntime = null;
            var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
            if (selfHosted != null)
            {
                if (selfHosted.LinkedInfo != null)
                {
                    psIntegrationRuntime = new PSLinkedIntegrationRuntime(integrationRuntime,
                            resourceGroupName,
                            workspaceName)
                    {
                        AuthorizationType = selfHosted.LinkedInfo is LinkedIntegrationRuntimeKeyAuthorization
                            ? SynapseConstants.LinkedIntegrationRuntimeKeyAuth
                            : SynapseConstants.LinkedIntegrationRuntimeRbacAuth
                    };
                }
                else
                {
                    psIntegrationRuntime = new PSSelfHostedIntegrationRuntime(integrationRuntime,
                            resourceGroupName,
                            workspaceName);
                }
            }

            return psIntegrationRuntime;
        }

        public virtual async Task<PSIntegrationRuntime> GetIntegrationRuntimeStatusAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var taskGetIntegrationRuntime = Task.Run(
                async () => await _synapseManagementClient.IntegrationRuntimes.GetAsync(
                    resourceGroupName,
                    workspaceName,
                    integrationRuntimeName));
                var taskGetStatus = Task.Run(
                    async () => await _synapseManagementClient.IntegrationRuntimeStatus.GetWithHttpMessagesAsync(
                        resourceGroupName,
                        workspaceName,
                        integrationRuntimeName));
                await Task.WhenAll(taskGetIntegrationRuntime, taskGetStatus);

                return GenerateIntegraionRuntimeObject(
                    taskGetIntegrationRuntime.Result,
                    taskGetStatus.Result.Body,
                    resourceGroupName,
                    workspaceName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }

        }

        public virtual async Task<PSIntegrationRuntime> GetIntegrationRuntimeAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var response = await _synapseManagementClient.IntegrationRuntimes.GetAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);

                return GenerateIntegraionRuntimeObject(response, null, resourceGroupName, workspaceName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
            catch (NullReferenceException)
            {
                throw new CloudException()
                {
                    Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.NotFound), "")
                };
            }
        }

        private PSIntegrationRuntime GenerateIntegraionRuntimeObject(
            IntegrationRuntimeResource integrationRuntime,
            IntegrationRuntimeStatusResponse status,
            string resourceGroupName,
            string workspaceName)
        {
            var managed = integrationRuntime.Properties as ManagedIntegrationRuntime;
            if (status == null)
            {
                PSIntegrationRuntime ir = (managed != null
                    ? new PSManagedIntegrationRuntime(integrationRuntime, resourceGroupName, workspaceName)
                    : CreateSelfHostedIntegrationRuntime(integrationRuntime, resourceGroupName, workspaceName))
                        ?? new PSIntegrationRuntime(integrationRuntime, resourceGroupName, workspaceName);

                return ir;
            }

            if (managed != null)
            {
                return new PSManagedIntegrationRuntimeStatus(
                    integrationRuntime,
                    (ManagedIntegrationRuntimeStatus)status.Properties,
                    resourceGroupName,
                    workspaceName);
            }
            else
            {
                var selfHosted = integrationRuntime.Properties as SelfHostedIntegrationRuntime;
                if (selfHosted != null)
                {
                    if (selfHosted.LinkedInfo != null)
                    {
                        return new PSLinkedIntegrationRuntimeStatus(
                            integrationRuntime,
                            (SelfHostedIntegrationRuntimeStatus)status.Properties,
                            resourceGroupName,
                            workspaceName,
                            _synapseManagementClient.DeserializationSettings,
                            selfHosted.LinkedInfo is LinkedIntegrationRuntimeKeyAuthorization
                                ? SynapseConstants.LinkedIntegrationRuntimeKeyAuth
                                : SynapseConstants.LinkedIntegrationRuntimeRbacAuth,
                            status.Name,
                            status.Properties.DataFactoryName);
                    }

                    return new PSSelfHostedIntegrationRuntimeStatus(
                        integrationRuntime,
                        (SelfHostedIntegrationRuntimeStatus)status.Properties,
                        resourceGroupName,
                        workspaceName,
                        _synapseManagementClient.DeserializationSettings);
                }
            }

            // Don't support get status for legacy integraiton runtime.
            throw new PSInvalidOperationException("This type of integration runtime is not supported by this version powershell cmdlets.");
        }

        public virtual async Task<PSIntegrationRuntimeKeys> GetIntegrationRuntimeKeyAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var response = await _synapseManagementClient.IntegrationRuntimeAuthKeys.ListWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);

                return new PSIntegrationRuntimeKeys(response.Body.AuthKey1, response.Body.AuthKey2);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task<PSIntegrationRuntimeMetrics> GetIntegrationRuntimeMetricAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var data = await _synapseManagementClient.IntegrationRuntimeMonitoringData.GetWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);

                return new PSIntegrationRuntimeMetrics(data.Body, resourceGroupName, workspaceName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task<AzureOperationResponse<IntegrationRuntimeNodeIpAddress>> GetIntegrationRuntimeNodeIpAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName,
            string nodeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return await _synapseManagementClient.IntegrationRuntimeNodeIpAddress.GetWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName,
                nodeName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task UpgradeIntegrationRuntimeAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                await _synapseManagementClient.IntegrationRuntimes.UpgradeAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task<PSIntegrationRuntimeKeys> RegenerateIntegrationRuntimeAuthKeyAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName,
            string keyName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var response =
                await _synapseManagementClient.IntegrationRuntimeAuthKeys.RegenerateWithHttpMessagesAsync(
                    resourceGroupName,
                    workspaceName,
                    integrationRuntimeName,
                    new IntegrationRuntimeRegenerateKeyParameters(keyName));

                return new PSIntegrationRuntimeKeys(response.Body.AuthKey1, response.Body.AuthKey2);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal async Task<bool> CheckIntegrationRuntimeExistsAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                PSIntegrationRuntime integrationRuntime = await this.GetIntegrationRuntimeAsync(
                    resourceGroupName,
                    workspaceName,
                    integrationRuntimeName);

                return integrationRuntime != null;
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
            catch (CloudException e)
            {
                // Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        public virtual async Task<HttpStatusCode> DeleteIntegrationRuntimeAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var response = await _synapseManagementClient.IntegrationRuntimes.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);

                return response.Response.StatusCode;
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task<HttpStatusCode> RemoveIntegrationRuntimeNodeAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName,
            string nodeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var response = await _synapseManagementClient.IntegrationRuntimeNodes.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName,
                nodeName);

                return response.Response.StatusCode;
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual PSIntegrationRuntime CreateOrUpdateIntegrationRuntime(CreatePSIntegrationRuntimeParameters parameters)
        {
            try
            {
                if (string.IsNullOrEmpty(parameters.ResourceGroupName))
                {
                    parameters.ResourceGroupName = GetResourceGroupByWorkspaceName(parameters.WorkspaceName);
                }

                PSIntegrationRuntime psIntegrationRuntime = null;

                Action createOrUpdateIntegrationRuntime = () =>
                {
                    var integrationRuntime = this.CreateOrUpdateIntegrationRuntimeAsync(
                        parameters.ResourceGroupName,
                        parameters.WorkspaceName,
                        parameters.Name,
                        parameters.IntegrationRuntimeResource).ConfigureAwait(true).GetAwaiter().GetResult();

                    var managed = integrationRuntime.Body.Properties as ManagedIntegrationRuntime;
                    if (managed != null)
                    {
                        psIntegrationRuntime = new PSManagedIntegrationRuntime(integrationRuntime.Body,
                                parameters.ResourceGroupName,
                                parameters.WorkspaceName);
                    }
                    else
                    {
                        psIntegrationRuntime = CreateSelfHostedIntegrationRuntime(integrationRuntime.Body,
                            parameters.ResourceGroupName,
                            parameters.WorkspaceName);
                    }
                };

                parameters.ConfirmAction(
                        parameters.Force,  // prompt only if the integration runtime exists
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.IntegrationRuntimeExists,
                            parameters.Name,
                            parameters.WorkspaceName),
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.UpdatingIntegrationRuntime,
                            parameters.Name,
                            parameters.WorkspaceName),
                        parameters.Name,
                        createOrUpdateIntegrationRuntime,
                        () => parameters.IsUpdate);

                return psIntegrationRuntime;
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public virtual async Task<AzureOperationResponse<IntegrationRuntimeResource>> CreateOrUpdateIntegrationRuntimeAsync(
            string resourceGroupName,
            string dataFactoryName,
            string integrationRuntimeName,
            IntegrationRuntimeResource resource)
        {
            return await _synapseManagementClient.IntegrationRuntimes.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    dataFactoryName,
                    integrationRuntimeName,
                    resource);
        }

        public virtual async Task SyncIntegrationRuntimeCredentialInNodesAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }

            await _synapseManagementClient.IntegrationRuntimeCredentials.SyncWithHttpMessagesAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName);
        }

        public JsonSerializerSettings GetSerializationSettings()
        {
            return _synapseManagementClient.SerializationSettings;
        }

        public virtual async Task<PSIntegrationRuntime> UpdateIntegrationRuntimeAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName,
            IntegrationRuntimeResource resource,
            UpdateIntegrationRuntimeRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }

            var response = await _synapseManagementClient.IntegrationRuntimes.UpdateAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName,
                request);

            return new PSSelfHostedIntegrationRuntime(
                response,
                resourceGroupName,
                workspaceName);
        }

        public virtual async Task<SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNodesAsync(
            string resourceGroupName,
            string workspaceName,
            string integrationRuntimeName,
            string nodeName,
            UpdateIntegrationRuntimeNodeRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }

            return await _synapseManagementClient.IntegrationRuntimeNodes.UpdateAsync(
                resourceGroupName,
                workspaceName,
                integrationRuntimeName,
                nodeName,
                request);
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

        private static SynapseException GetSynapseException(ErrorContractException ex)
        {
            return ex.CreateSynapseException();
        }

        private static SynapseException GetSynapseException(CloudException ex)
        {
            return ex.CreateSynapseException();
        }

        private Exception RethrowLongingRunningException(Exception e)
        {
            var ce = e as CloudException;
            if (ce?.Body != null)
            {
                return new CloudException()
                {
                    Body = new CloudError()
                    {
                        Code = ce.Body.Code,
                        Message = Resources.LongRunningStatusError + "\n" + ce.Body.Message,
                        Target = ce.Body.Target
                    },
                    Request = ce.Request,
                    Response = ce.Response,
                    RequestId = ce.RequestId
                };
            }

            return new Exception(Resources.LongRunningStatusError, e);
        }

        #endregion
    }
}
