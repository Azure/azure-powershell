using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using Action = System.Action;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsManagementClient
    {
        public IAzureContext Context;
        private readonly Guid _subscriptionId;
        private readonly Guid _tenantId;
        private readonly SynapseManagementClient _synapseManagementClient;
        private readonly SynapseSqlV3ManagementClient _synapseSqlV3ManagementClient;
        private ActiveDirectoryClient _activeDirectoryClient;
        private MonitorManagementClient _monitorManagementClient;
        private ResourceManagementClient _resourceManagementClient;

        public SynapseAnalyticsManagementClient(IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            Context = context;

            _subscriptionId = context.Subscription.GetId();

            _tenantId = context.Tenant.GetId();

            _synapseManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);

            _synapseSqlV3ManagementClient = SynapseCmdletBase.CreateSynapseClient<SynapseSqlV3ManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient == null)
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(Context);
                }
                return this._activeDirectoryClient;
            }

            set { this._activeDirectoryClient = value; }
        }

        public MonitorManagementClient MonitorManagementClient
        {
            get
            {
                if (_monitorManagementClient == null)
                {
                    _monitorManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<MonitorManagementClient>(Context,
                        AzureEnvironment.Endpoint.ResourceManager);
                }
                return this._monitorManagementClient;
            }

            set { this._monitorManagementClient = value; }
        }

        public ResourceManagementClient ResourceManagementClient
        {
            get
            {
                if (_resourceManagementClient == null)
                {
                    _resourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(Context,
                        AzureEnvironment.Endpoint.ResourceManager);
                }
                return this._resourceManagementClient;
            }

            set { this._resourceManagementClient = value; }
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

        public WorkspaceAadAdminInfo GetSqlActiveDirectoryAdministrators(string resourceGroupName, string workspaceName)
        {
            try
            {
                return _synapseManagementClient.WorkspaceAadAdmins.Get(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public WorkspaceAadAdminInfo CreateOrUpdateSqlActiveDirectoryAdministrators(string resourceGroupName, string workspaceName, string displayName, Guid objectId)
        {
            try
            {
                return _synapseManagementClient.WorkspaceAadAdmins.CreateOrUpdate(resourceGroupName, workspaceName, GetActiveDirectoryInformation(displayName, objectId));
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        private WorkspaceAadAdminInfo GetActiveDirectoryInformation(string displayName, Guid objectId)
        {
            // Gets the default Tenant id for the subscriptions
            Guid tenantId = _tenantId;

            // Check for a Azure Active Directory group. Recommended to always use group.
            IEnumerable<PSADGroup> groupList = null;
            PSADGroup group = null;

            var filter = new ADObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of groups from Azure Active Directory
            groupList = ActiveDirectoryClient.FilterGroups(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            if (groupList != null && groupList.Count() > 1)
            {
                // More than one group was found with that display name.
                throw new ArgumentException(string.Format(Resources.ADGroupMoreThanOneFound, displayName));
            }
            else if (groupList != null && groupList.Count() == 1)
            {
                // Only one group was found. Get the group display name and object id
                group = groupList.First();

                // Only support Security Groups
                if (group.SecurityEnabled.HasValue && !group.SecurityEnabled.Value)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidADGroupNotSecurity, displayName));
                }
            }

            // Lookup for serviceprincipals
            ODataQuery<ServicePrincipal> odataQueryFilter;

            if ((objectId != null && objectId != Guid.Empty))
            {
                var applicationIdString = objectId.ToString();
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(a => a.AppId == applicationIdString);
            }
            else
            {
                odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(a => a.DisplayName == displayName);
            }

            var servicePrincipalList = ActiveDirectoryClient.FilterServicePrincipals(odataQueryFilter);

            if (servicePrincipalList != null && servicePrincipalList.Count() > 1)
            {
                // More than one service principal was found.
                throw new ArgumentException(string.Format(Resources.ADApplicationMoreThanOneFound, displayName));
            }
            else if (servicePrincipalList != null && servicePrincipalList.Count() == 1)
            {
                // Only one user was found. Get the user display name and object id
                PSADServicePrincipal app = servicePrincipalList.First();

                if (displayName != null && string.CompareOrdinal(displayName, app.DisplayName) != 0)
                {
                    throw new ArgumentException(string.Format(Resources.ADApplicationDisplayNameMismatch, displayName, app.DisplayName));
                }

                if (group != null)
                {
                    throw new ArgumentException(string.Format(Resources.ADDuplicateGroupAndApplicationFound, displayName));
                }

                return new WorkspaceAadAdminInfo()
                {
                    Login = displayName,
                    Sid = app.ApplicationId.ToString(),
                    TenantId = tenantId.ToString()
                };
            }

            if (group != null)
            {
                return new WorkspaceAadAdminInfo()
                {
                    Login = group.DisplayName,
                    Sid = group.Id.ToString(),
                    TenantId = tenantId.ToString()
                };
            }

            // No group or service principal was found. Check for a user
            filter = new ADObjectFilterOptions()
            {
                Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                SearchString = displayName,
                Paging = true,
            };

            // Get a list of user from Azure Active Directory
            var userList = ActiveDirectoryClient.FilterUsers(filter).Where(gr => string.Equals(gr.DisplayName, displayName, StringComparison.OrdinalIgnoreCase));

            // No user was found. Check if the display name is a UPN
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    UPN = displayName,
                    Paging = true,
                };

                userList = ActiveDirectoryClient.FilterUsers(filter).Where(gr => string.Equals(gr.UserPrincipalName, displayName, StringComparison.OrdinalIgnoreCase));
            }

            // No user was found. Check if the display name is a guest user. 
            if (userList == null || userList.Count() == 0)
            {
                // Check if the display name is the UPN
                filter = new ADObjectFilterOptions()
                {
                    Id = (objectId != null && objectId != Guid.Empty) ? objectId.ToString() : null,
                    Mail = displayName,
                    Paging = true,
                };

                userList = ActiveDirectoryClient.FilterUsers(filter);
            }

            // No user was found
            if (userList == null || userList.Count() == 0)
            {
                throw new ArgumentException(string.Format(Resources.ADObjectNotFound, displayName));
            }
            else if (userList.Count() > 1)
            {
                // More than one user was found.
                throw new ArgumentException(string.Format(Resources.ADUserMoreThanOneFound, displayName));
            }
            else
            {
                // Only one user was found. Get the user display name and object id
                var obj = userList.First();

                return new WorkspaceAadAdminInfo()
                {
                    Login = displayName,
                    Sid = obj.Id.ToString(),
                    TenantId = tenantId.ToString()
                };
            }
        }

        public void DeleteSqlActiveDirectoryAdministrators(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseManagementClient.WorkspaceAadAdmins.Delete(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public WorkspaceAuditModel GetWorkspaceAudit(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var policy = _synapseManagementClient.WorkspaceManagedSqlServerExtendedBlobAuditingPolicies.Get(resourceGroupName, workspaceName);
                var model = new WorkspaceAuditModel
                {
                    ResourceGroupName = resourceGroupName,
                    WorkspaceName = workspaceName
                };
                model.DiagnosticsEnablingAuditCategory = GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    resourceGroupName, workspaceName);
                model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;

                model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
                model.PredicateExpression = policy.PredicateExpression;
                model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
                ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                    IsAuditEnabled(policy.State), policy.RetentionDays);
                DetermineTargetsState(model, policy.State);

                return model;
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void CreateOrUpdateSqlAudit(WorkspaceAuditModel model)
        {
            model.DiagnosticsEnablingAuditCategory = GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    model.ResourceGroupName, model.WorkspaceName);
            model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;

            VerifyAuditBeforePersistChanges(model);

            DiagnosticSettingsResource currentSettings = model.DiagnosticsEnablingAuditCategory?.FirstOrDefault();
            if (currentSettings == null)
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            else
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryExist(model, currentSettings);
            }
        }

        public void RemoveWorkspaceAudit(WorkspaceAuditModel model)
        {
            model = GetWorkspaceAudit(model.ResourceGroupName, model.WorkspaceName);
            model.BlobStorageTargetState = AuditStateType.Disabled;
            model.EventHubTargetState = AuditStateType.Disabled;
            model.LogAnalyticsTargetState = AuditStateType.Disabled;

            DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);

            Exception exception = null;
            while (model.DiagnosticsEnablingAuditCategory != null &&
                model.DiagnosticsEnablingAuditCategory.Any())
            {
                DiagnosticSettingsResource settings = model.DiagnosticsEnablingAuditCategory.First();
                if (IsAnotherCategoryEnabled(settings))
                {
                    if (DisableAuditCategory(model, settings) == false)
                    {
                        exception = new Exception(Resources.UpdateDiagnosticSettingsException);
                    }
                }
                else
                {
                    if (RemoveFirstDiagnosticSettings(model) == false)
                    {
                        exception = new Exception(Resources.RemoveDiagnosticSettingsException);
                    }
                }
            }

            if (exception != null)
            {
                throw exception;
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

        public List<RestorePoint> ListSqlPoolRestorePoints(string resourceGroupName, string workspaceName, string sqlPoolName)
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

        public RestorePoint CreateSqlPoolRestorePoint(string resourceGroupName, string workspaceName, string sqlPoolName, CreateSqlPoolRestorePointDefinition parameters)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                return this._synapseManagementClient.SqlPoolRestorePoints.Create(resourceGroupName, workspaceName, sqlPoolName, parameters);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public SqlPoolAuditModel GetSqlPoolAudit(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var policy = this._synapseManagementClient.ExtendedSqlPoolBlobAuditingPolicies.Get(resourceGroupName, workspaceName, sqlPoolName);
                var model = new SqlPoolAuditModel
                {
                    ResourceGroupName = resourceGroupName,
                    WorkspaceName = workspaceName,
                    SqlPoolName = sqlPoolName
                };
                model.DiagnosticsEnablingAuditCategory = GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    resourceGroupName, workspaceName, sqlPoolName);
                model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;

                model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
                model.PredicateExpression = policy.PredicateExpression;
                model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
                model.AuditAction = ExtractAuditActions(policy.AuditActionsAndGroups);
                ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                    IsAuditEnabled(policy.State), policy.RetentionDays);
                DetermineTargetsState(model, policy.State);

                return model;
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        private IList<DiagnosticSettingsResource> GetDiagnosticsEnablingAuditCategory(
            out string nextDiagnosticSettingsName,
            string resourceGroupName, string workspaceName, string sqlPoolName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
            IList<DiagnosticSettingsResource> settings =
                MonitorManagementClient.DiagnosticSettings.ListAsync(resourceUri).Result.Value;
            nextDiagnosticSettingsName = GetNextDiagnosticSettingsName(settings);
            return settings?.Where(s => IsAuditCategoryEnabled(s))?.OrderBy(s => s.Name)?.ToList();
        }

        private string GetNextDiagnosticSettingsName(IList<DiagnosticSettingsResource> settings)
        {
            int nextIndex = (settings?.Where(
                s => s.Name.StartsWith(SynapseConstants.Security.DiagnosticSettingsNamePrefix)).Select(
                s => s.Name).Select(
                name => name.Replace(SynapseConstants.Security.DiagnosticSettingsNamePrefix, string.Empty)).Select(
                number => Int32.TryParse(number, out Int32 index) ? index : 0).DefaultIfEmpty().Max() ?? 0) + 1;
            return $"{SynapseConstants.Security.DiagnosticSettingsNamePrefix}{nextIndex}";
        }

        private static bool IsAuditCategoryEnabled(DiagnosticSettingsResource settings)
        {
            return settings?.Logs?.FirstOrDefault(
                l => l.Enabled &&
                string.Equals(l.Category, SynapseConstants.Security.SQLSecurityAuditCategory)) != null;
        }

        private AuditActionGroups[] ExtractAuditActionGroups(IEnumerable<string> auditActionsAndGroups)
        {
            var groups = new List<AuditActionGroups>();
            if (auditActionsAndGroups != null)
            {
                auditActionsAndGroups.ForEach(item =>
                {
                    if (Enum.TryParse(item, true, out AuditActionGroups group))
                    {
                        groups.Add(group);
                    }
                });
            }

            return groups.ToArray();
        }

        private string[] ExtractAuditActions(IEnumerable<string> auditActionsAndGroups)
        {
            var actions = new List<string>();
            if (auditActionsAndGroups != null)
            {
                auditActionsAndGroups.ForEach(item =>
                {
                    if (!Enum.TryParse(item, true, out AuditActionGroups group))
                    {
                        actions.Add(item);
                    }
                });
            }

            return actions.ToArray();
        }

        private void ModelizeStorageInfo(WorkspaceAuditModel model,
            string storageEndpoint, bool? isSecondary, Guid? storageAccountSubscriptionId,
            bool isAuditEnabled, int? retentionDays)
        {
            if (string.IsNullOrEmpty(storageEndpoint))
            {
                return;
            }

            model.StorageKeyType = GetStorageKeyKind(isSecondary);

            if (isAuditEnabled)
            {
                if (storageAccountSubscriptionId == null || Guid.Empty.Equals(storageAccountSubscriptionId))
                {
                    storageAccountSubscriptionId = _subscriptionId;
                }

                model.StorageAccountResourceId = RetrieveStorageAccountIdAsync(
                    storageAccountSubscriptionId.Value,
                    GetStorageAccountName(storageEndpoint)).GetAwaiter().GetResult();

                model.RetentionInDays = Convert.ToUInt32(retentionDays);
            }
        }

        internal async Task<string> RetrieveStorageAccountIdAsync(Guid storageAccountSubscriptionId, string storageAccountName)
        {
            // Build a URI for calling corresponding REST-API.
            //
            var uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("/resources?api-version=2018-05-01&$filter=(subscriptionId%20eq%20'{0}')%20and%20((resourceType%20eq%20'microsoft.storage/storageaccounts')%20or%20(resourceType%20eq%20'microsoft.classicstorage/storageaccounts'))%20and%20(name%20eq%20'{1}')",
                storageAccountSubscriptionId,
                storageAccountName);

            var nextLink = uriBuilder.ToString();
            string id = null;
            while (!string.IsNullOrEmpty(nextLink))
            {
                JToken response = await SendAsync(nextLink, HttpMethod.Get, new Exception(string.Format(Properties.Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId)));
                var valuesArray = (JArray)response["value"];
                if (valuesArray.HasValues)
                {
                    var idValueToken = valuesArray[0];
                    id = (string)idValueToken["id"];
                    if (string.IsNullOrEmpty(id))
                    {
                        throw new Exception(string.Format(Resources.RetrievingStorageAccountIdUnderSubscriptionFailed, storageAccountName, storageAccountSubscriptionId));
                    }
                }
                nextLink = (string)response["nextLink"];
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new Exception(string.Format(Resources.StorageAccountNotFound, storageAccountName));
            }

            return id;
        }

        internal async Task<JToken> SendAsync(string url, HttpMethod method, Exception exceptionToThrowOnFailure)
        {
            var httpRequest = new HttpRequestMessage { Method = method, RequestUri = new Uri(url) };
            await ResourceManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var httpResponse = await ResourceManagementClient.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw exceptionToThrowOnFailure;
            }

            return JToken.Parse(await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private static string GetStorageAccountName(string storageEndpoint)
        {
            int accountNameStartIndex = storageEndpoint.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase) ? 8 : 7; // https:// or http://
            int accountNameEndIndex = storageEndpoint.IndexOf(".blob", StringComparison.InvariantCultureIgnoreCase);
            return storageEndpoint.Substring(accountNameStartIndex, accountNameEndIndex - accountNameStartIndex);
        }

        private StorageKeyKind GetStorageKeyKind(bool? isSecondary)
        {
            if (isSecondary.HasValue)
            {
                return isSecondary.Value ? StorageKeyKind.Secondary : StorageKeyKind.Primary;
            }

            return StorageKeyKind.Primary;
        }

        private bool IsAuditEnabled(BlobAuditingPolicyState state)
        {
            return state == BlobAuditingPolicyState.Enabled;
        }

        private static void DetermineTargetsState(
            WorkspaceAuditModel model,
            BlobAuditingPolicyState policyState)
        {
            if (policyState == BlobAuditingPolicyState.Disabled)
            {
                model.BlobStorageTargetState = AuditStateType.Disabled;
                model.EventHubTargetState = AuditStateType.Disabled;
                model.LogAnalyticsTargetState = AuditStateType.Disabled;
            }
            else
            {
                if (string.IsNullOrEmpty(model.StorageAccountResourceId))
                {
                    model.BlobStorageTargetState = AuditStateType.Disabled;
                }
                else
                {
                    model.BlobStorageTargetState = AuditStateType.Enabled;
                }

                if (model.IsAzureMonitorTargetEnabled == null ||
                    model.IsAzureMonitorTargetEnabled == false ||
                    model.DiagnosticsEnablingAuditCategory == null)
                {
                    model.EventHubTargetState = AuditStateType.Disabled;
                    model.LogAnalyticsTargetState = AuditStateType.Disabled;
                }
                else
                {
                    DiagnosticSettingsResource eventHubSettings = model.DiagnosticsEnablingAuditCategory.FirstOrDefault(
                        settings => !string.IsNullOrEmpty(settings.EventHubAuthorizationRuleId));
                    if (eventHubSettings == null)
                    {
                        model.EventHubTargetState = AuditStateType.Disabled;
                    }
                    else
                    {
                        model.EventHubTargetState = AuditStateType.Enabled;
                        model.EventHubName = eventHubSettings.EventHubName;
                        model.EventHubAuthorizationRuleResourceId = eventHubSettings.EventHubAuthorizationRuleId;
                    }

                    DiagnosticSettingsResource logAnalyticsSettings = model.DiagnosticsEnablingAuditCategory.FirstOrDefault(
                        settings => !string.IsNullOrEmpty(settings.WorkspaceId));
                    if (logAnalyticsSettings == null)
                    {
                        model.LogAnalyticsTargetState = AuditStateType.Disabled;
                    }
                    else
                    {
                        model.LogAnalyticsTargetState = AuditStateType.Enabled;
                        model.WorkspaceResourceId = logAnalyticsSettings.WorkspaceId;
                    }
                }
            }
        }

        public void CreateOrUpdateSqlPoolAudit(SqlPoolAuditModel model)
        {
            model.DiagnosticsEnablingAuditCategory = GetDiagnosticsEnablingAuditCategory(out string nextDiagnosticSettingsName,
                    model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName);
            model.NextDiagnosticSettingsName = nextDiagnosticSettingsName;

            VerifyAuditBeforePersistChanges(model);

            DiagnosticSettingsResource currentSettings = model.DiagnosticsEnablingAuditCategory?.FirstOrDefault();
            if (currentSettings == null)
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            else
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryExist(model, currentSettings);
            }
        }

        private void VerifyAuditBeforePersistChanges(WorkspaceAuditModel model)
        {
            if (model.BlobStorageTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.StorageAccountResourceId))
            {
                throw new PSArgumentException(Resources.StorageAccountNameParameterException, "StorageAccountName");
            }

            if (model.EventHubTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.EventHubAuthorizationRuleResourceId))
            {
                throw new PSArgumentException(Resources.EventHubAuthorizationRuleResourceIdParameterException, "EventHubAuthorizationRuleResourceId");
            }

            if (model.LogAnalyticsTargetState == AuditStateType.Enabled &&
                string.IsNullOrEmpty(model.WorkspaceResourceId))
            {
                throw new PSArgumentException(Resources.WorkspaceResourceIdParameterException, "WorkspaceResourceId");
            }

            if (model.DiagnosticsEnablingAuditCategory != null && model.DiagnosticsEnablingAuditCategory.Count > 1)
            {
                throw new Exception(string.Format(Resources.MultipleDiagnosticsException, SynapseConstants.Security.SQLSecurityAuditCategory));
            }
        }

        private void ChangeAuditWhenDiagnosticsEnablingAuditCategoryExist(
            WorkspaceAuditModel model,
            DiagnosticSettingsResource settings)
        {
            if (IsAnotherCategoryEnabled(settings))
            {
                ChangeAuditWhenMultipleCategoriesAreEnabled(model, settings);
            }
            else
            {
                ChangeAuditWhenOnlyAuditCategoryIsEnabled(model, settings);
            }
        }

        private bool IsAnotherCategoryEnabled(DiagnosticSettingsResource settings)
        {
            return settings.Logs.FirstOrDefault(l => l.Enabled &&
                !string.Equals(l.Category, SynapseConstants.Security.SQLSecurityAuditCategory)) != null ||
                settings.Metrics.FirstOrDefault(m => m.Enabled) != null;
        }

        private void ChangeAuditWhenMultipleCategoriesAreEnabled(
            WorkspaceAuditModel model,
            DiagnosticSettingsResource settings)
        {
            if (DisableAuditCategory(model, settings) == false)
            {
                throw new Exception(Resources.UpdateDiagnosticSettingsException);
            }

            try
            {
                ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            catch (Exception)
            {
                try
                {
                    EnableAuditCategory(model, settings);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void ChangeAuditWhenOnlyAuditCategoryIsEnabled(
            WorkspaceAuditModel model,
            DiagnosticSettingsResource settings)
        {
            string oldEventHubName = settings.EventHubName;
            string oldEventHubAuthorizationRuleId = settings.EventHubAuthorizationRuleId;
            string oldWorkspaceId = settings.WorkspaceId;

            if (model.EventHubTargetState == AuditStateType.Enabled ||
                model.LogAnalyticsTargetState == AuditStateType.Enabled)
            {
                EnableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(model, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
            else
            {
                DisableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(model, settings, oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId);
            }
        }

        private void EnableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(
            WorkspaceAuditModel model,
            DiagnosticSettingsResource settings,
            string oldEventHubName,
            string oldEventHubAuthorizationRuleId,
            string oldWorkspaceId)
        {
            settings.EventHubName = model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubName : null;
            settings.EventHubAuthorizationRuleId = model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubAuthorizationRuleResourceId : null;
            settings.WorkspaceId = model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                model.WorkspaceResourceId : null;

            if (UpdateDiagnosticSettings(settings, model) == false)
            {
                throw new Exception(Resources.UpdateDiagnosticSettingsException);
            }

            try
            {
                model.IsAzureMonitorTargetEnabled = true;
                if (CreateOrUpdateAudit(model) == false)
                {
                    throw new Exception(Resources.SetAuditingSettingsException);
                }
            }
            catch (Exception)
            {
                try
                {
                    settings.EventHubName = oldEventHubName;
                    settings.EventHubAuthorizationRuleId = oldEventHubAuthorizationRuleId;
                    settings.WorkspaceId = oldWorkspaceId;
                    UpdateDiagnosticSettings(settings, model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableDiagnosticsAuditWhenOnlyAuditCategoryIsEnabled(
            WorkspaceAuditModel model,
            DiagnosticSettingsResource settings,
            string oldEventHubName,
            string oldEventHubAuthorizationRuleId,
            string oldWorkspaceId)
        {
            if (RemoveFirstDiagnosticSettings(model) == false)
            {
                throw new Exception(Resources.RemoveDiagnosticSettingsException);
            }

            try
            {
                DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            catch (Exception)
            {
                try
                {
                    CreateDiagnosticSettings(oldEventHubName, oldEventHubAuthorizationRuleId, oldWorkspaceId, model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private bool EnableAuditCategory(
            dynamic model,
            DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(model, settings, true);
        }

        private bool DisableAuditCategory(
            dynamic model,
            DiagnosticSettingsResource settings)
        {
            return SetAuditCategoryState(model, settings, false);
        }

        private bool SetAuditCategoryState(
            dynamic model,
            DiagnosticSettingsResource settings,
            bool isEnabled)
        {
            var log = settings?.Logs?.FirstOrDefault(l => string.Equals(l.Category, SynapseConstants.Security.SQLSecurityAuditCategory));
            if (log != null)
            {
                log.Enabled = isEnabled;
            }

            return UpdateDiagnosticSettings(settings, model);
        }

        private bool UpdateDiagnosticSettings(
            DiagnosticSettingsResource settings,
            WorkspaceAuditModel model)
        {
            DiagnosticSettingsResource modifiedSettings;
            if (model is SqlPoolAuditModel databaseAuditModel)
            {
                modifiedSettings = MonitorManagementClient.DiagnosticSettings.CreateOrUpdate(
                    GetResourceUri(databaseAuditModel.ResourceGroupName, databaseAuditModel.WorkspaceName, databaseAuditModel.SqlPoolName),
                    settings, settings.Name);
            }
            else
            {
                modifiedSettings = MonitorManagementClient.DiagnosticSettings.CreateOrUpdate(
                    GetResourceUri(model.ResourceGroupName, model.WorkspaceName, "master"),
                    settings, settings.Name);
            }

            if (modifiedSettings == null)
            {
                return false;
            }

            List<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = new List<DiagnosticSettingsResource>();
            foreach (DiagnosticSettingsResource existingSettings in model.DiagnosticsEnablingAuditCategory)
            {
                if (!string.Equals(modifiedSettings.Id, existingSettings.Id))
                {
                    diagnosticsEnablingAuditCategory.Add(existingSettings);
                }
                else if (IsAuditCategoryEnabled(modifiedSettings))
                {
                    diagnosticsEnablingAuditCategory.Add(modifiedSettings);
                }
            }

            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory.Any() ? diagnosticsEnablingAuditCategory : null;
            return true;
        }

        private void ChangeAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            WorkspaceAuditModel model)
        {
            if (model.EventHubTargetState == AuditStateType.Enabled ||
                model.LogAnalyticsTargetState == AuditStateType.Enabled)
            {
                EnableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
            else
            {
                DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);
            }
        }

        private void EnableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            WorkspaceAuditModel model)
        {
            if (CreateDiagnosticSettings(
                model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubName : null,
                model.EventHubTargetState == AuditStateType.Enabled ?
                model.EventHubAuthorizationRuleResourceId : null,
                model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                model.WorkspaceResourceId : null,
                model) == false)
            {
                throw new Exception(Resources.CreateDiagnosticSettingsException);
            }

            try
            {
                model.IsAzureMonitorTargetEnabled = true;
                if (CreateOrUpdateAudit(model) == false)
                {
                    throw new Exception(Resources.SetAuditingSettingsException);
                }
            }
            catch (Exception)
            {
                try
                {
                    RemoveFirstDiagnosticSettings(model);
                }
                catch (Exception) { }

                throw;
            }
        }

        private void DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(
            WorkspaceAuditModel model)
        {
            model.IsAzureMonitorTargetEnabled = null;
            if (CreateOrUpdateAudit(model) == false)
            {
                throw new Exception(Resources.SetAuditingSettingsException);
            }
        }

        private bool CreateDiagnosticSettings(
            string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            WorkspaceAuditModel model)
        {
            DiagnosticSettingsResource settings;
            if (model is SqlPoolAuditModel databaseAuditModel)
            {
                settings = CreateDiagnosticSettings(databaseAuditModel.NextDiagnosticSettingsName,
                    eventHubName, eventHubAuthorizationRuleId, workspaceId,
                    databaseAuditModel.ResourceGroupName, databaseAuditModel.WorkspaceName, databaseAuditModel.SqlPoolName);
            }
            else
            {
                settings = CreateDiagnosticSettings(model.NextDiagnosticSettingsName,
                    eventHubName, eventHubAuthorizationRuleId, workspaceId,
                    model.ResourceGroupName, model.WorkspaceName);
            }

            if (settings == null)
            {
                return false;
            }

            IList<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = model.DiagnosticsEnablingAuditCategory;
            if (diagnosticsEnablingAuditCategory == null)
            {
                diagnosticsEnablingAuditCategory = new List<DiagnosticSettingsResource>();
            }

            diagnosticsEnablingAuditCategory.Add(settings);
            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory;
            return true;
        }

        private DiagnosticSettingsResource CreateDiagnosticSettings(
            string settingsName, string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            string resourceGroupName, string workspaceName, string sqlPoolName = "master")
        {
            string resoureUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
            DiagnosticSettingsResource settings = new DiagnosticSettingsResource
            {
                Logs = new List<LogSettings>(),
                Metrics = new List<MetricSettings>(),
                EventHubName = eventHubName,
                EventHubAuthorizationRuleId = eventHubAuthorizationRuleId,
                WorkspaceId = workspaceId
            };

            try
            {
                IList<DiagnosticSettingsCategoryResource> supportedCategories =
                    MonitorManagementClient.DiagnosticSettingsCategory.ListAsync(resoureUri).Result.Value;
                if (supportedCategories != null)
                {
                    foreach (DiagnosticSettingsCategoryResource category in supportedCategories)
                    {
                        if (category.CategoryType == CategoryType.Metrics)
                        {
                            settings.Metrics.Add(new MetricSettings(false, null, category.Name));
                        }
                        else
                        {
                            settings.Logs.Add(
                                new LogSettings(
                                    string.Equals(category.Name, SynapseConstants.Security.SQLSecurityAuditCategory),
                                    category.Name));
                        }
                    }
                }
            }
            catch (AggregateException ex)
            {
                if (!(ex.InnerException is ErrorResponseException ex1) ||
                    ex1.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw ex.InnerException ?? ex;
                }
            }

            if (!settings.Logs.Any(l => string.Equals(l.Category, SynapseConstants.Security.SQLSecurityAuditCategory)))
            {
                settings.Logs.Add(new LogSettings(true, SynapseConstants.Security.SQLSecurityAuditCategory));
            }

            return MonitorManagementClient.DiagnosticSettings.CreateOrUpdateAsync(
                resoureUri, settings, settingsName).Result;
        }

        private bool CreateOrUpdateAudit(WorkspaceAuditModel model)
        {
            return (model is SqlPoolAuditModel dbModel) ?
                SetAudit(dbModel) : SetAudit(model);
        }

        private bool SetAudit(SqlPoolAuditModel model)
        {
            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                SqlPoolBlobAuditingPolicy policy = new SqlPoolBlobAuditingPolicy();
                PolicizeAuditModel(model, policy);
                return _synapseManagementClient.SqlPoolBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName, policy)
                    .ConfigureAwait(true).GetAwaiter().GetResult().Response.IsSuccessStatusCode;
            }
            else
            {
                ExtendedSqlPoolBlobAuditingPolicy policy = new ExtendedSqlPoolBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };

                PolicizeAuditModel(model, policy);
                return _synapseManagementClient.ExtendedSqlPoolBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName, policy)
                    .ConfigureAwait(true).GetAwaiter().GetResult().Response.IsSuccessStatusCode;
            }
        }

        private bool SetAudit(WorkspaceAuditModel model)
        {
            if (string.IsNullOrEmpty(model.PredicateExpression))
            {
                var policy = new ServerBlobAuditingPolicy();
                PolicizeAuditModel(model, policy);
                // TODO operation error
                return _synapseManagementClient.WorkspaceSManagedqlServerBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(model.ResourceGroupName, model.WorkspaceName, policy)
                    .ConfigureAwait(true).GetAwaiter().GetResult().Response.IsSuccessStatusCode;
            }
            else
            {
                var policy = new ExtendedServerBlobAuditingPolicy
                {
                    PredicateExpression = model.PredicateExpression
                };
                PolicizeAuditModel(model, policy);
                return _synapseManagementClient.WorkspaceManagedSqlServerExtendedBlobAuditingPolicies.CreateOrUpdateWithHttpMessagesAsync(model.ResourceGroupName, model.WorkspaceName, policy)
                    .ConfigureAwait(true).GetAwaiter().GetResult().Response.IsSuccessStatusCode;
            }
        }

        private void PolicizeAuditModel(WorkspaceAuditModel model, dynamic policy)
        {
            policy.State = model.BlobStorageTargetState == AuditStateType.Enabled ||
                           model.EventHubTargetState == AuditStateType.Enabled ||
                           model.LogAnalyticsTargetState == AuditStateType.Enabled ?
                           BlobAuditingPolicyState.Enabled : BlobAuditingPolicyState.Disabled;

            policy.IsAzureMonitorTargetEnabled = model.IsAzureMonitorTargetEnabled;
            if (model is SqlPoolAuditModel dbModel)
            {
                policy.AuditActionsAndGroups = ExtractAuditActionsAndGroups(dbModel.AuditActionGroup, dbModel.AuditAction);
            }
            else
            {
                policy.AuditActionsAndGroups = ExtractAuditActionsAndGroups(model.AuditActionGroup);
            }

            if (model.BlobStorageTargetState == AuditStateType.Enabled)
            {
                const string separator = "subscriptions/";
                string storageAccountResourceId = model.StorageAccountResourceId.Substring(model.StorageAccountResourceId.IndexOf(separator) + separator.Length);
                string[] segments = storageAccountResourceId.Split('/');
                Guid storageAccountSubscriptionId = Guid.Parse(segments[0]);
                string storageAccountName = segments[6];
                policy.StorageEndpoint = string.Format("https://{0}.blob.{1}", storageAccountName, Context.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix));
                policy.StorageAccountSubscriptionId = storageAccountSubscriptionId;

                if (IsStorageAccountInVNet(model.StorageAccountResourceId))
                {
                    Guid? principalId = AssignServerIdentityIfNotAssigned(model.ResourceGroupName, model.WorkspaceName);
                    AssignRoleForServerIdentityOnStorageIfNotAssigned(model.StorageAccountResourceId, principalId.Value, default(Guid));
                }
                else
                {
                    policy.IsStorageSecondaryKeyInUse = model.StorageKeyType == StorageKeyKind.Secondary;
                    policy.StorageAccountAccessKey = RetrieveStorageKeysAsync(
                        model.StorageAccountResourceId).GetAwaiter().GetResult()[model.StorageKeyType == StorageKeyKind.Secondary ? StorageKeyKind.Secondary : StorageKeyKind.Primary];
                }

                if (model.RetentionInDays != null)
                {
                    policy.RetentionDays = (int)model.RetentionInDays;
                }
            }
        }

        private static IList<string> ExtractAuditActionsAndGroups(AuditActionGroups[] auditActionGroup, string[] auditAction = null)
        {
            var actionsAndGroups = new List<string>();
            if (auditAction != null)
            {
                actionsAndGroups.AddRange(auditAction);
            }

            auditActionGroup.ToList().ForEach(aag => actionsAndGroups.Add(aag.ToString()));
            if (actionsAndGroups.Count == 0) // default audit actions and groups in case nothing was defined by the user
            {
                actionsAndGroups.Add("SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("FAILED_DATABASE_AUTHENTICATION_GROUP");
                actionsAndGroups.Add("BATCH_COMPLETED_GROUP");
            }

            return actionsAndGroups;
        }

        private bool IsStorageAccountInVNet(string storageAccountResourceId)
        {
            if (IsClassicStorage(storageAccountResourceId))
            {
                return false;
            }

            string uri = $"{Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString()}{storageAccountResourceId}?api-version=2019-06-01";
            Exception exception = new Exception(
                string.Format(Resources.RetrievingStorageAccountPropertiesFailed,
                storageAccountResourceId));
            JToken storageAccountPropertiesToken = SendAsync(uri, HttpMethod.Get, exception).Result;
            return GetNetworkAclsDefaultAction(storageAccountPropertiesToken, exception).Equals("Deny");
        }

        private bool IsClassicStorage(string storageAccountResourceId)
        {
            return storageAccountResourceId.Contains("Microsoft.ClassicStorage/storageAccounts");
        }

        private string GetNetworkAclsDefaultAction(JToken storageAccountPropertiesToken, Exception exceptionToThrowOnFailure)
        {
            JToken value;
            try
            {
                value = storageAccountPropertiesToken["properties"]["networkAcls"]["defaultAction"];
            }
            catch (Exception)
            {
                throw exceptionToThrowOnFailure;
            }

            return value?.ToString();
        }

        public Guid? AssignServerIdentityIfNotAssigned(string resourceGroupName, string workspaceName)
        {
            var workspaceInfo = _synapseManagementClient.Workspaces.Get(resourceGroupName, workspaceName);
            if (workspaceInfo.Identity == null ||
                workspaceInfo.Identity.Type != ResourceIdentityType.SystemAssigned)
            {
                workspaceInfo.Identity = new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned
                };
                workspaceInfo = _synapseManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workspaceInfo);
            }

            try
            {
                return new Guid(workspaceInfo.Identity.PrincipalId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void AssignRoleForServerIdentityOnStorageIfNotAssigned(string storageAccountResourceId, Guid principalId, Guid roleAssignmentId)
        {
            if (IsRoleAssignedForServerIdentitiyOnStorage(storageAccountResourceId, principalId))
            {
                return;
            }

            roleAssignmentId = roleAssignmentId == default(Guid) ? Guid.NewGuid() : roleAssignmentId;
            Uri endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            string uri = $"{endpoint}/{storageAccountResourceId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}?api-version=2018-01-01-preview";

            string roleDefinitionId = $"/subscriptions/{GetStorageAccountSubscription(storageAccountResourceId)}/providers/Microsoft.Authorization/roleDefinitions/ba92f5b4-2d11-453d-a403-e96b0029c9fe";
            string content = $"{{\"properties\": {{ \"roleDefinitionId\": \"{roleDefinitionId}\", \"principalId\": \"{principalId}\", \"principalType\": \"ServicePrincipal\"}}}}";

            int numberOfTries = 20;
            const int SecondsToWaitBetweenTries = 20;
            HttpResponseMessage response = null;
            bool isARetry = false;
            System.Net.HttpStatusCode responseStatusCode;
            string responseContent = null;
            do
            {
                if (isARetry)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(SecondsToWaitBetweenTries));
                }

                HttpRequestMessage httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                };
                ResourceManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                response = ResourceManagementClient.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new Exception(string.Format(Resources.AddingStorageBlobDataContributorRoleForStorageAccountIsForbidden, storageAccountResourceId));
                }

                responseStatusCode = response.StatusCode;
                responseContent = response.Content.ReadAsStringAsync().Result;
                numberOfTries--;
                isARetry = true;
            } while (numberOfTries > 0);

            throw new Exception(string.Format(Resources.FailedToAddRoleAssignmentForStorageAccount, storageAccountResourceId, responseStatusCode.ToString(), responseContent));
        }

        private bool IsRoleAssignedForServerIdentitiyOnStorage(string storageAccountResourceId, Guid principalId)
        {
            string StorageBlobDataContributorId = "ba92f5b4-2d11-453d-a403-e96b0029c9fe";
            Uri endpoint = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager);
            string uri = $"{endpoint}/{storageAccountResourceId}/providers/Microsoft.Authorization/roleAssignments/?api-version=2018-01-01-preview&$filter=assignedTo('{principalId}')";
            JToken roleDefinitionsToken = SendAsync(uri, HttpMethod.Get,
                new Exception(string.Format(Resources.FailedToGetRoleAssignmentsForStorageAccount, storageAccountResourceId))).Result;
            try
            {
                JArray roleDefinitionsArray = (JArray)roleDefinitionsToken["value"];
                return roleDefinitionsArray.Any((token =>
                {
                    JToken roleDefinitionId = token["properties"]["roleDefinitionId"];
                    return roleDefinitionId != null && roleDefinitionId.ToString().Contains(StorageBlobDataContributorId);
                }));
            }
            catch (Exception) { }

            return false;
        }

        private static string GetStorageAccountSubscription(string storageAccountResourceId)
        {
            const string separator = "subscriptions/";
            int subscriptionStartIndex = storageAccountResourceId.IndexOf(separator) + separator.Length;
            return storageAccountResourceId.Substring(subscriptionStartIndex, Guid.Empty.ToString().Length);
        }

        internal async Task<Dictionary<StorageKeyKind, string>> RetrieveStorageKeysAsync(string storageAccountId)
        {
            var isClassicStorage = IsClassicStorage(storageAccountId);

            // Build a URI for calling corresponding REST-API
            //
            var uriBuilder = new StringBuilder(Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString());
            uriBuilder.AppendFormat("{0}/listKeys?api-version={1}",
                storageAccountId,
                isClassicStorage ? "2016-11-01" : "2017-06-01");

            // Define an exception to be thrown on failure.
            //
            var exception = new Exception(string.Format(Resources.RetrievingStorageAccountKeysFailed, storageAccountId));

            // Call the URI and get storage account keys.
            //
            var storageAccountKeysResponse = await SendAsync(uriBuilder.ToString(), HttpMethod.Post, exception);

            // Extract keys out of response.
            //
            var storageAccountKeys = new Dictionary<StorageKeyKind, string>();
            string primaryKey;
            string secondaryKey;
            if (isClassicStorage)
            {
                primaryKey = (string)storageAccountKeysResponse["primaryKey"];
                secondaryKey = (string)storageAccountKeysResponse["secondaryKey"];
            }
            else
            {
                var storageAccountKeysArray = (JArray)storageAccountKeysResponse["keys"];
                if (storageAccountKeysArray == null)
                {
                    throw exception;
                }

                primaryKey = (string)storageAccountKeysArray[0]["value"];
                secondaryKey = (string)storageAccountKeysArray[1]["value"];
            }

            if (string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
            {
                throw exception;
            }

            storageAccountKeys.Add(StorageKeyKind.Primary, primaryKey);
            storageAccountKeys.Add(StorageKeyKind.Secondary, secondaryKey);
            return storageAccountKeys;
        }

        private bool RemoveFirstDiagnosticSettings(dynamic model)
        {
            IList<DiagnosticSettingsResource> diagnosticsEnablingAuditCategory = model.DiagnosticsEnablingAuditCategory;
            DiagnosticSettingsResource settings = diagnosticsEnablingAuditCategory.FirstOrDefault();
            if (settings == null ||
                (model is SqlPoolAuditModel dbModel ?
                RemoveDiagnosticSettings(settings.Name, dbModel.ResourceGroupName, dbModel.WorkspaceName, dbModel.SqlPoolName) :
                RemoveDiagnosticSettings(settings.Name, model.ResourceGroupName, model.WorkspaceName)) == false)
            {
                return false;
            }

            diagnosticsEnablingAuditCategory.RemoveAt(0);
            model.DiagnosticsEnablingAuditCategory = diagnosticsEnablingAuditCategory.Any() ? diagnosticsEnablingAuditCategory : null;
            return true;
        }

        private bool RemoveDiagnosticSettings(string settingsName, string resourceGroupName,
            string workspaceName, string sqlPoolName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
            return MonitorManagementClient.DiagnosticSettings.DeleteWithHttpMessagesAsync(
                resourceUri, settingsName).Result.Response.IsSuccessStatusCode;
        }

        public void RemoveSqlPoolAudit(SqlPoolAuditModel model)
        {
            model = GetSqlPoolAudit(model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName);

            model.BlobStorageTargetState = AuditStateType.Disabled;
            model.EventHubTargetState = AuditStateType.Disabled;
            model.LogAnalyticsTargetState = AuditStateType.Disabled;

            DisableDiagnosticsAuditWhenDiagnosticsEnablingAuditCategoryDoNotExist(model);

            Exception exception = null;
            while (model.DiagnosticsEnablingAuditCategory != null &&
                model.DiagnosticsEnablingAuditCategory.Any())
            {
                DiagnosticSettingsResource settings = model.DiagnosticsEnablingAuditCategory.First();
                if (IsAnotherCategoryEnabled(settings))
                {
                    if (DisableAuditCategory(model, settings) == false)
                    {
                        exception = new Exception(Resources.UpdateDiagnosticSettingsException);
                    }
                }
                else
                {
                    if (RemoveFirstDiagnosticSettings(model) == false)
                    {
                        exception = new Exception(Resources.RemoveDiagnosticSettingsException);
                    }
                }
            }

            if (exception != null)
            {
                throw exception;
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

        private string GetResourceUri(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            return $"/subscriptions/{_subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}";
        }

        #endregion
    }
}
