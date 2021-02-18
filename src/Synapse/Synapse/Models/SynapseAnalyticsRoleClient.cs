using Azure;
using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseAnalyticsRoleClient
    {
        private readonly AccessControlClient _accessControlClient;
        private readonly ActiveDirectoryClient _activeDirectoryClient;

        public SynapseAnalyticsRoleClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _accessControlClient = new AccessControlClient(uri, new AzureSessionCredential(context));
            _activeDirectoryClient = new ActiveDirectoryClient(context);
        }

        public IReadOnlyList<RoleAssignmentDetails> ListRoleAssignments(string roleDefinitionId = null, string objectId = null, string continuationToken = null)
        {
            return _accessControlClient.GetRoleAssignments(roleDefinitionId, objectId, continuationToken).Value;
        }

        public RoleAssignmentDetails GetRoleAssignmentById(string roleAssignmentId)
        {
            return _accessControlClient.GetRoleAssignmentById(roleAssignmentId);
        }

        public RoleAssignmentDetails CreateRoleAssignment(string roleDefinitionId, string objectId)
        {
            RoleAssignmentOptions roleAssignmentOptions = new RoleAssignmentOptions(roleDefinitionId, objectId);
            return _accessControlClient.CreateRoleAssignment(roleAssignmentOptions).Value;
        }

        public void DeleteRoleAssignmentById(string roleAssignmentId)
        {
            _accessControlClient.DeleteRoleAssignmentById(roleAssignmentId);
        }

        public void DeleteRoleAssignmentByName(string roleDefinitionId, string objectId)
        {
            string roleAssignmentId = roleDefinitionId + "-" + objectId;
            _accessControlClient.DeleteRoleAssignmentById(roleAssignmentId);
        }

        public Pageable<SynapseRole> GetRoleDefinitions()
        {
            return _accessControlClient.GetRoleDefinitions();
        }

        public SynapseRole GetRoleDefinitionById(string roleId)
        {
            return _accessControlClient.GetRoleDefinitionById(roleId).Value;
        }

        public string GetObjectIdFromSignInName(string signInName)
        {
            if (string.IsNullOrEmpty(signInName))
            {
                return null;
            }
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<User>(s => s.UserPrincipalName == signInName);
            var user = _activeDirectoryClient.GraphClient.Users.List(odataQueryFilter.ToString()).SingleOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException(String.Format(Resources.UserNameDoesNotExist, signInName));
            }
            return user.ObjectId;
        }

        public string GetObjectIdFromServicePrincipalName(string servicePrincipalName)
        {
            if (string.IsNullOrEmpty(servicePrincipalName))
            {
                return null;
            }
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(servicePrincipalName));
            var servicePrincipal = _activeDirectoryClient.GraphClient.ServicePrincipals.List(odataQueryFilter.ToString()).SingleOrDefault();
            if (servicePrincipal == null)
            {
                throw new InvalidOperationException(String.Format(Resources.ServicePrincipalNameDoesNotExist, servicePrincipalName));
            }
            return servicePrincipal.ObjectId;
        }

        public string GetRoleDefinitionIdFromRoleDefinitionName(string roleDefinitionName)
        {
            if (string.IsNullOrEmpty(roleDefinitionName))
            {
                return null;
            }
            var roleDefinition = _accessControlClient.GetRoleDefinitions().SingleOrDefault(element => element.Name == roleDefinitionName);
            if (roleDefinition == null)
            {
                throw new InvalidOperationException(String.Format(Resources.RoleDefinitionNameDoesNotExist, roleDefinitionName));
            }
            return roleDefinition.Id;
        }
    }
}
