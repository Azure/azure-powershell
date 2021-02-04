using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Model;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Commands.Synapse.VulnerabilityAssessment.Model;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.Storage.Version2017_10_01;
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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TriggerType = Microsoft.Azure.Commands.Synapse.VulnerabilityAssessment.Model.TriggerType;
using Action = System.Action;
using ResourceIdentityType = Microsoft.Azure.Management.Synapse.Models.ResourceIdentityType;

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
        private ResourceManagementClient _resourceManagementClient;
        private StorageManagementClient _storageManagementClient;

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

        public StorageManagementClient StorageManagementClient
        {
            get
            {
                if (_storageManagementClient == null)
                {
                    _storageManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(Context,
                        AzureEnvironment.Endpoint.ResourceManager);
                }
                return this._storageManagementClient;
            }

            set { this._storageManagementClient = value; }
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

        #region Workspace SQL Active Directory Administrator

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

        #endregion

        #region Auditing

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

                model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
                model.PredicateExpression = policy.PredicateExpression;
                model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
                model.AuditAction = ExtractAuditActions(policy.AuditActionsAndGroups);
                ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                    IsAuditEnabled(policy.State), policy.RetentionDays);
                model.BlobStorageTargetState = policy.State == BlobAuditingPolicyState.Enabled ? AuditStateType.Enabled : AuditStateType.Disabled;

                return model;
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        private AuditActionGroup[] ExtractAuditActionGroups(IEnumerable<string> auditActionsAndGroups)
        {
            var groups = new List<AuditActionGroup>();
            if (auditActionsAndGroups != null)
            {
                auditActionsAndGroups.ForEach(item =>
                {
                    if (Enum.TryParse(item, true, out AuditActionGroup group))
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
                    if (!Enum.TryParse(item, true, out AuditActionGroup group))
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

        public void CreateOrUpdateSqlPoolAudit(SqlPoolAuditModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.PredicateExpression))
                {
                    SqlPoolBlobAuditingPolicy policy = new SqlPoolBlobAuditingPolicy();
                    PolicizeAuditModel(model, policy);
                    _synapseManagementClient.SqlPoolBlobAuditingPolicies.CreateOrUpdate(model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName, policy);
                }
                else
                {
                    ExtendedSqlPoolBlobAuditingPolicy policy = new ExtendedSqlPoolBlobAuditingPolicy
                    {
                        PredicateExpression = model.PredicateExpression
                    };

                    PolicizeAuditModel(model, policy);
                    _synapseManagementClient.ExtendedSqlPoolBlobAuditingPolicies.CreateOrUpdate(model.ResourceGroupName, model.WorkspaceName, model.SqlPoolName, policy);
                }
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        private void PolicizeAuditModel(WorkspaceAuditModel model, dynamic policy)
        {
            policy.State = model.BlobStorageTargetState == AuditStateType.Enabled ?
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

        private static IList<string> ExtractAuditActionsAndGroups(AuditActionGroup[] auditActionGroup, string[] auditAction = null)
        {
            var actionsAndGroups = new List<string>();
            if (auditAction != null)
            {
                actionsAndGroups.AddRange(auditAction);
            }

            auditActionGroup?.ToList().ForEach(aag => actionsAndGroups.Add(aag.ToString()));
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

        internal dynamic GetSqlAuditing(string resourceGroupName, string workspaceName, string sqlPoolName = null)
        {
            if (sqlPoolName == null)
            {
                return _synapseManagementClient.WorkspaceManagedSqlServerBlobAuditingPolicies.Get(resourceGroupName, workspaceName);
            }
            else
            {
                return _synapseManagementClient.SqlPoolBlobAuditingPolicies.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
        }

        public void RemoveSqlPoolAudit(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                SqlPoolBlobAuditingPolicy policy = GetSqlAuditing(resourceGroupName, workspaceName, sqlPoolName);
                policy.State = BlobAuditingPolicyState.Disabled;
                _synapseManagementClient.SqlPoolBlobAuditingPolicies.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, policy);
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

                model.IsAzureMonitorTargetEnabled = policy.IsAzureMonitorTargetEnabled;
                model.PredicateExpression = policy.PredicateExpression;
                model.AuditActionGroup = ExtractAuditActionGroups(policy.AuditActionsAndGroups);
                ModelizeStorageInfo(model, policy.StorageEndpoint, policy.IsStorageSecondaryKeyInUse, policy.StorageAccountSubscriptionId,
                    IsAuditEnabled(policy.State), policy.RetentionDays);
                model.BlobStorageTargetState = policy.State == BlobAuditingPolicyState.Enabled ? AuditStateType.Enabled : AuditStateType.Disabled;

                return model;
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void CreateOrUpdateWorkspaceAudit(WorkspaceAuditModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.PredicateExpression))
                {
                    var policy = new ServerBlobAuditingPolicy();
                    PolicizeAuditModel(model, policy);
                    _synapseManagementClient.WorkspaceManagedSqlServerBlobAuditingPolicies.CreateOrUpdate(model.ResourceGroupName, model.WorkspaceName, policy);
                }
                else
                {
                    var policy = new ExtendedServerBlobAuditingPolicy
                    {
                        PredicateExpression = model.PredicateExpression
                    };
                    PolicizeAuditModel(model, policy);
                    _synapseManagementClient.WorkspaceManagedSqlServerExtendedBlobAuditingPolicies.CreateOrUpdate(model.ResourceGroupName, model.WorkspaceName, policy);
                }
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void RemoveWorkspaceAudit(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                ServerBlobAuditingPolicy policy = GetSqlAuditing(resourceGroupName, workspaceName);
                policy.State = BlobAuditingPolicyState.Disabled;
                _synapseManagementClient.WorkspaceManagedSqlServerBlobAuditingPolicies.CreateOrUpdate(resourceGroupName, workspaceName, policy);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        #endregion

        #region Threat Detection

        public ServerSecurityAlertPolicy GetWorkspaceThreatDetectionPolicy(string resourceGroupName, string workspaceName)
        {
            try
            {
                return _synapseManagementClient.WorkspaceManagedSqlServerSecurityAlertPolicy.Get(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public Dictionary<StorageKeyKind, string> GetStorageKeys(string storageEndpoint)
        {
            var storageName = GetStorageAccountName(storageEndpoint);
            var resourceGroup = GetStorageResourceGroup(storageName);
            return GetStorageKeys(resourceGroup, storageName);
        }

        private static class StorageAccountType
        {
            public const string ClassicStorage = "Microsoft.ClassicStorage/storageAccounts";
            public const string Storage = "Microsoft.Storage/storageAccounts";
        }

        public string GetStorageResourceGroup(string storageAccountName)
        {
            foreach (var storageAccountType in new[] { StorageAccountType.ClassicStorage, StorageAccountType.Storage })
            {
                var resourceGroup = GetStorageResourceGroup(
                    ResourceManagementClient,
                    storageAccountName,
                    storageAccountType);

                if (resourceGroup != null)
                {
                    return resourceGroup;
                }
            }

            throw new Exception(string.Format(Properties.Resources.StorageAccountNotFound, storageAccountName));
        }

        private static string GetStorageResourceGroup(
            ResourceManagementClient resourcesClient,
            string storageAccountName,
            string resourceType)
        {
            var query = new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(r => r.ResourceType == resourceType);
            var res = resourcesClient.Resources.List(query);
            var allResources = new List<GenericResource>(res);
            var account = allResources.Find(r => r.Name == storageAccountName);
            if (account == null)
            {
                return null;
            }

            var resId = account.Id;
            var segments = resId.Split('/');
            var indexOfResourceGroup = new List<string>(segments).IndexOf("resourceGroups") + 1;
            return segments[indexOfResourceGroup];
        }

        private Dictionary<StorageKeyKind, string> GetStorageKeys(string resourceGroupName, string storageAccountName)
        {
            try
            {
                return GetStorageKeysAsync(resourceGroupName, storageAccountName).GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                throw new Exception(string.Format(Resources.StorageAccountNotFound, storageAccountName), e);
            }
        }

        private async Task<Dictionary<StorageKeyKind, string>> GetStorageKeysAsync(string resourceGroupName, string storageAccountName)
        {
            var url = Context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager).ToString();
            if (!url.EndsWith("/"))
            {
                url = url + "/";
            }
            // TODO: Remove IfDef
#if NETSTANDARD
            url = url + "subscriptions/" + (StorageManagementClient.SubscriptionId != null ? StorageManagementClient.SubscriptionId.Trim() : "");
#else
            url = url + "subscriptions/" + (client.Credentials.SubscriptionId != null ? client.Credentials.SubscriptionId.Trim() : "");
#endif
            url = url + "/resourceGroups/" + resourceGroupName;
            url = url + "/providers/Microsoft.ClassicStorage/storageAccounts/" + storageAccountName;
            url = url + "/listKeys?api-version=2014-06-01";

            var httpRequest = new HttpRequestMessage { Method = HttpMethod.Post, RequestUri = new Uri(url) };

            await StorageManagementClient.Credentials.ProcessHttpRequestAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var httpResponse = await StorageManagementClient.HttpClient.SendAsync(httpRequest, CancellationToken.None).ConfigureAwait(false);
            var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = new Dictionary<StorageKeyKind, string>();
            try
            {
                var responseDoc = JToken.Parse(responseContent);
                var primaryKey = (string)responseDoc["primaryKey"];
                var secondaryKey = (string)responseDoc["secondaryKey"];
                if (string.IsNullOrEmpty(primaryKey) || string.IsNullOrEmpty(secondaryKey))
                {
                    throw new Exception(); // this is caught by the synced wrapper
                }

                result.Add(StorageKeyKind.Primary, primaryKey);
                result.Add(StorageKeyKind.Secondary, secondaryKey);
                return result;
            }
            catch
            {
                return GetV2Keys(resourceGroupName, storageAccountName);
            }
        }

        private Dictionary<StorageKeyKind, string> GetV2Keys(string resourceGroupName, string storageAccountName)
        {
            var r = StorageManagementClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
            // TODO: Remove IfDef
#if NETSTANDARD
            var k1 = r.Keys[0].Value;
            var k2 = r.Keys[1].Value;
#else
            string k1 = r.StorageAccountKeys.Key1;
            string k2 = r.StorageAccountKeys.Key2;
#endif
            var result = new Dictionary<StorageKeyKind, String>
            {
                {StorageKeyKind.Primary, k1}, {StorageKeyKind.Secondary, k2}
            };
            return result;
        }

        public ServerSecurityAlertPolicy SetWorkspaceThreatDetectionPolicy(string resourceGroupName, string workspaceName, ServerSecurityAlertPolicy policy)
        {
            try
            {
                return _synapseManagementClient.WorkspaceManagedSqlServerSecurityAlertPolicy.CreateOrUpdate(resourceGroupName, workspaceName, policy);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void RemoveWorkspaceThreatDetectionPolicy(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var policy = GetWorkspaceThreatDetectionPolicy(resourceGroupName, workspaceName);
                policy.State = SecurityAlertPolicyState.Disabled;
                _synapseManagementClient.WorkspaceManagedSqlServerSecurityAlertPolicy.CreateOrUpdate(resourceGroupName, workspaceName, policy);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public SqlPoolSecurityAlertPolicy GetSqlPoolThreatDetectionPolicy(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                return _synapseManagementClient.SqlPoolSecurityAlertPolicies.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public SqlPoolSecurityAlertPolicy SetSqlPoolThreatDetectionPolicy(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPoolSecurityAlertPolicy policy)
        {
            try
            {
                return _synapseManagementClient.SqlPoolSecurityAlertPolicies.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, policy);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void RemoveSqlPoolThreatDetectionPolicy(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                var policy = GetSqlPoolThreatDetectionPolicy(resourceGroupName, workspaceName, sqlPoolName);
                policy.State = SecurityAlertPolicyState.Disabled;
                _synapseManagementClient.SqlPoolSecurityAlertPolicies.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, policy);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        #endregion

        #region Vulnerability Assessment

        public ServerVulnerabilityAssessment GetWorkspaceVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName)
        {
            try
            {
                return _synapseManagementClient.WorkspaceManagedSqlServerVulnerabilityAssessments.Get(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public struct StorageContainerInfo
        {
            public string StorageAccountAccessKey;
            public string StorageContainerPath;
        }

        public StorageContainerInfo GetStorageContainerInfo(string resourceGroupName, string storageAccountName, string containerName)
        {
            var storageAccountObject = StorageManagementClient.StorageAccounts.GetProperties(resourceGroupName, storageAccountName);
            var keysObject = StorageManagementClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);
            // TODO: Remove IfDef
#if NETSTANDARD
            var storageAccountBlobPrimaryEndpoints = storageAccountObject.PrimaryEndpoints.Blob;
            var key = keysObject.Keys.FirstOrDefault().Value;
#else
            var storageAccountBlobPrimaryEndpoints = storageAccountObject.StorageAccount.PrimaryEndpoints.Blob;
            var key = keysObject.StorageAccountKeys.Key1;
#endif
            return new StorageContainerInfo
            {
                StorageAccountAccessKey = key,
                StorageContainerPath = string.Format("{0}{1}", storageAccountBlobPrimaryEndpoints, containerName)
            };
        }

        public ServerVulnerabilityAssessment CreateOrUpdateWorkspaceVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName, ServerVulnerabilityAssessment parameters)
        {
            try
            {
                return _synapseManagementClient.WorkspaceManagedSqlServerVulnerabilityAssessments.CreateOrUpdate(resourceGroupName, workspaceName, parameters);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void RemoveWorkspaceVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseManagementClient.WorkspaceManagedSqlServerVulnerabilityAssessments.Delete(resourceGroupName, workspaceName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public SqlPoolVulnerabilityAssessment GetSqlPoolVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                return _synapseManagementClient.SqlPoolVulnerabilityAssessments.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public SqlPoolVulnerabilityAssessment CreateOrUpdateSqlPoolVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName, string sqlPoolName, SqlPoolVulnerabilityAssessment parameters)
        {
            try
            {
                return _synapseManagementClient.SqlPoolVulnerabilityAssessments.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, parameters);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void RemoveSqlPoolVulnerabilityAssessmentSettings(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                _synapseManagementClient.SqlPoolVulnerabilityAssessments.Delete(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        #endregion

        #region Advanced Threat Protection

        public void EnableWorkspaceVa(string resourceGroupName, string workspaceName, string workspaceLocation, string deploymentName)
        {
            AutoEnableVa(resourceGroupName, workspaceName, workspaceLocation, "DeployWorkspaceVaTemplate.json", deploymentName);
        }

        private void AutoEnableVa(string resourceGroupName, string workspaceName, string workspaceLocation, string templateName, string deploymentName)
        {
            // Generate deployment name if it was not provided
            if (string.IsNullOrEmpty(deploymentName))
            {
                deploymentName = "EnableVA_" + workspaceName + "_" + Guid.NewGuid().ToString("N");
            }

            // Trim deployment name as it has a maximum of 64 chars
            if (deploymentName.Length > 64)
            {
                deploymentName = deploymentName.Substring(0, 64);
            }

            Dictionary<string, object> parametersDictionary = new Dictionary<string, object>
            {
                {"workspaceName", new Dictionary<string, object> { {"value", workspaceName } }},
                {"location", new Dictionary<string, object> { {"value", workspaceLocation } }},
            };
            string parameters = Newtonsoft.Json.JsonConvert.SerializeObject(parametersDictionary, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
                Formatting = Formatting.Indented
            });

            var properties = new DeploymentProperties
            {
                Mode = DeploymentMode.Incremental,
                Parameters = JObject.Parse(parameters),
                Template = JObject.Parse(GetArmTemplateContent(templateName)),
            };

            Deployment deployment = new Deployment(properties);

            ResourceManagementClient.Deployments.CreateOrUpdate(resourceGroupName, deploymentName, deployment);
        }

        private string GetArmTemplateContent(string templateName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(templateName));
            string template;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }
            }

            return template;
        }

        #endregion

        #region Transparent Data Encryption

        public TransparentDataEncryption GetSqlPoolTransparentDataEncryption(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                return _synapseManagementClient.SqlPoolTransparentDataEncryptions.Get(resourceGroupName, workspaceName, sqlPoolName);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public TransparentDataEncryption SetSqlPoolTransparentDataEncryption(string resourceGroupName, string workspaceName, string sqlPoolName, TransparentDataEncryption parameters)
        {
            try
            {
                return _synapseManagementClient.SqlPoolTransparentDataEncryptions.CreateOrUpdate(resourceGroupName, workspaceName, sqlPoolName, parameters);
            }
            catch (CloudException ex)
            {
                throw GetSynapseException(ex);
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
            catch (ErrorContractException ex)
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
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void StartVulnerabilityAssessmentScan(string resourceGroup, string workspaceName, string sqlPoolName, string scanId)
        {
            try
            {
                _synapseManagementClient.SqlPoolVulnerabilityAssessmentScans.InitiateScan(resourceGroup, workspaceName, sqlPoolName, scanId);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
          
        }
        internal PSVulnerabilityAssessmentScanRecordModel GetVulnerabilityAssessmentScanRecord(string resourceGroupName, string workspaceName, string sqlPoolName, string scanId)
        {
            try
            {
                var result = _synapseManagementClient.SqlPoolVulnerabilityAssessmentScans.Get(resourceGroupName, workspaceName, sqlPoolName, scanId);
                return ConvertVulnerabilityAssessmentScanRecord(resourceGroupName, workspaceName, sqlPoolName, result);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        internal List<PSVulnerabilityAssessmentScanRecordModel> ListVulnerabilityAssessmentScanRecords(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                var firstPage = _synapseManagementClient.SqlPoolVulnerabilityAssessmentScans.List(resourceGroupName, workspaceName, sqlPoolName);
                return ListResources(firstPage, _synapseManagementClient.SqlPoolVulnerabilityAssessmentScans.ListNext).Select(scanRecord => ConvertVulnerabilityAssessmentScanRecord(resourceGroupName, workspaceName, sqlPoolName, scanRecord)).ToList();
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public PSVulnerabilityAssessmentScanExportModel ConvertSqlPoolVulnerabilityAssessmentScan(string resourceGroupName, string workSpaceName,
           string sqlPoolName, string scanId)
        {
            var response = _synapseManagementClient.SqlPoolVulnerabilityAssessmentScans.Export(resourceGroupName, workSpaceName, sqlPoolName, scanId);
            return new PSVulnerabilityAssessmentScanExportModel(resourceGroupName, workSpaceName, sqlPoolName, scanId, response.ExportedReportLocation);
        }

        private PSVulnerabilityAssessmentScanRecordModel ConvertVulnerabilityAssessmentScanRecord(string resourceGroup, string workSpace, string sqlPool, VulnerabilityAssessmentScanRecord scanRecord)
        {
            TriggerType scanTriggerType;
            Enum.TryParse(scanRecord.TriggerType, true, out scanTriggerType);

            return new PSVulnerabilityAssessmentScanRecordModel()
            {
                ResourceGroupName = resourceGroup,
                workspaceName = workSpace,
                sqlPoolName = sqlPool,
                ScanId = scanRecord.ScanId,
                TriggerType = scanTriggerType,
                State = scanRecord.State,
                StartTime = scanRecord.StartTime,
                EndTime = scanRecord.EndTime,
                Errors = scanRecord.Errors?.Select(scanError =>
                  new PSVulnerabilityAssessmentScanErrorModel()
                  {
                      Code = scanError.Code,
                      Message = scanError.Message
                  }).ToList(),
                ScanResultsLocationPath = scanRecord.StorageContainerPath,
                NumberOfFailedSecurityChecks = scanRecord.NumberOfFailedSecurityChecks
            };
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
            catch (ErrorContractException ex)
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
            catch (ErrorContractException ex)
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
            catch (ErrorContractException ex)
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
            throw new NotImplementedException("SQL pool rename operation is not supported.");
            //try
            //{
            //    if (string.IsNullOrEmpty(resourceGroupName))
            //    {
            //        resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
            //    }

            //    this._synapseManagementClient.SqlPools.Rename(
            //        resourceGroupName,
            //        workspaceName,
            //        sqlPoolName,
            //        new ResourceMoveDefinition
            //        {
            //            Id = Utils.ConstructResourceId(
            //                _synapseManagementClient.SubscriptionId,
            //                resourceGroupName,
            //                ResourceTypes.SqlPool,
            //                newSqlPoolName,
            //                $"workspaces/{workspaceName}")
            //        });
            //}
            //catch (ErrorContractException ex)
            //{
            //    throw GetSynapseException(ex);
            //}
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
            catch (ErrorContractException ex)
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
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        #endregion

        #region SQL Pool Backup

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
            catch (ErrorContractException ex)
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
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public void DeleteSqlPoolRestorePoint(string resourceGroupName, string workspaceName, string sqlPoolName, string sqlPoolRestorePointCreationDate)
        {
            try
            {
                if (string.IsNullOrEmpty(resourceGroupName))
                {
                    resourceGroupName = GetResourceGroupByWorkspaceName(workspaceName);
                }

                if (!TestSqlPoolRestorePoint(resourceGroupName, workspaceName, sqlPoolName, sqlPoolRestorePointCreationDate))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.SqlPoolRestorePointDoesNotExist, sqlPoolRestorePointCreationDate));
                }

                this._synapseManagementClient.SqlPoolRestorePoints.Delete(resourceGroupName, workspaceName, sqlPoolName, sqlPoolRestorePointCreationDate);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public bool TestSqlPoolRestorePoint(string resourceGroupName, string workspaceName, string sqlPoolName, string sqlPoolRestorePointName)
        {
            try
            {
                RestorePoint respoint = this._synapseManagementClient.SqlPoolRestorePoints.Get(resourceGroupName,
                    workspaceName,
                    sqlPoolName,
                    sqlPoolRestorePointName);

                return respoint != null;
            }
            catch (NotFoundException)
            {
                return false;
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

        public PSRecoverableSqlPool GetRecoverableSqlPool(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            try
            {
                var recoverableSqlPool = this._synapseManagementClient.WorkspaceManagedSqlServerRecoverableSqlpools.Get(resourceGroupName, workspaceName, sqlPoolName);

                return new PSRecoverableSqlPool(recoverableSqlPool);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public List<RecoverableSqlPool> ListRecoverableSqlPool(string resourceGroupName, string workspaceName)
        {
            try
            {
                var firstPage =  this._synapseManagementClient.WorkspaceManagedSqlServerRecoverableSqlpools.List(resourceGroupName, workspaceName);
                return ListResources(firstPage, _synapseManagementClient.WorkspaceManagedSqlServerRecoverableSqlpools.ListNext);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public PSRestorableDroppedSqlPool GetDroppedSqlPoolBackup(string resourceGroupName, string workspaceName, string sqlPoolAndTimeName)
        {
            try
            {
                var restorableDroppedSqlPool = this._synapseManagementClient.RestorableDroppedSqlPools.Get(resourceGroupName, workspaceName, sqlPoolAndTimeName);

                return new PSRestorableDroppedSqlPool(restorableDroppedSqlPool);
            }
            catch (ErrorContractException ex)
            {
                throw GetSynapseException(ex);
            }
        }

        public List<RestorableDroppedSqlPool> ListDroppedSqlPoolBackups (string resourceGroupName, string workspaceName)
        {
            try
            {
                var restorableDroppedSqlPoolList = this._synapseManagementClient.RestorableDroppedSqlPools.ListByWorkspace(resourceGroupName, workspaceName);
                return restorableDroppedSqlPoolList.ToList();
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

                var data = await _synapseManagementClient.IntegrationRuntimeMonitoringData.ListWithHttpMessagesAsync(
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

        #endregion
    }
}
