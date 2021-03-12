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
        private readonly RoleAssignmentsClient _roleAssignmentsClient;
        private readonly RoleDefinitionsClient _roleDefinitionsClient;
        private readonly ActiveDirectoryClient _activeDirectoryClient;

        public SynapseAnalyticsRoleClient(string workspaceName, IAzureContext context)
        {
            if (context == null)
            {
                throw new SynapseException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _roleAssignmentsClient = new RoleAssignmentsClient(uri, new AzureSessionCredential(context));
            _roleDefinitionsClient = new RoleDefinitionsClient(uri, new AzureSessionCredential(context));
            _activeDirectoryClient = new ActiveDirectoryClient(context);
        }

        public RoleAssignmentDetailsList ListRoleAssignments(string roleDefinitionId = null, string objectId = null, string continuationToken = null)
        {
            return _roleAssignmentsClient.ListRoleAssignments(roleDefinitionId, objectId, continuationToken).Value;
        }

        public RoleAssignmentDetails GetRoleAssignmentById(string roleAssignmentId)
        {
            return _roleAssignmentsClient.GetRoleAssignmentById(roleAssignmentId);
        }

        public RoleAssignmentDetails CreateRoleAssignment(string roleAssignmentId, string RoleDefinitionId, string objectId, string scope)
        {
            return _roleAssignmentsClient.CreateRoleAssignment(roleAssignmentId, new Guid(RoleDefinitionId), new Guid(objectId), scope);
        }

        public void DeleteRoleAssignmentById(string roleAssignmentId)
        {
            _roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignmentId);
        }

        public void DeleteRoleAssignmentByName(string roleDefinitionId, string objectId)
        {
            string roleAssignmentId = roleDefinitionId + "-" + objectId;
            _roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignmentId);
        }

        public IReadOnlyList<SynapseRoleDefinition> GetRoleDefinitions()
        {
            return _roleDefinitionsClient.ListRoleDefinitions().Value;
        }

        public SynapseRoleDefinition GetRoleDefinitionById(string roleId)
        {
            return _roleDefinitionsClient.GetRoleDefinitionById(roleId).Value;
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
            var roleDefinition = _roleDefinitionsClient.ListRoleDefinitions().Value.SingleOrDefault(element => element.Name == roleDefinitionName);
            if (roleDefinition == null)
            {
                throw new InvalidOperationException(String.Format(Resources.RoleDefinitionNameDoesNotExist, roleDefinitionName));
            }
            return roleDefinition.Id.ToString();
        }
    }
}
