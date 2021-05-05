﻿using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                throw new AzPSInvalidOperationException(Resources.InvalidDefaultSubscription);
            }

            string suffix = context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointSuffix);
            Uri uri = new Uri("https://" + workspaceName + "." + suffix);
            _roleAssignmentsClient = new RoleAssignmentsClient(uri, new AzureSessionCredential(context));
            _roleDefinitionsClient = new RoleDefinitionsClient(uri, new AzureSessionCredential(context));
            _activeDirectoryClient = new ActiveDirectoryClient(context);
        }

        public IReadOnlyList<RoleAssignmentDetails> ListRoleAssignments(string roleDefinitionId = null, string objectId = null, string scope = null)
        {
            return _roleAssignmentsClient.ListRoleAssignments(roleDefinitionId, objectId, scope).Value.Value;
        }

        public RoleAssignmentDetails GetRoleAssignmentById(string roleAssignmentId)
        {
            return _roleAssignmentsClient.GetRoleAssignmentById(roleAssignmentId);
        }

        public RoleAssignmentDetails CreateRoleAssignment(string roleAssignmentId, string roleDefinitionId, string objectId, string scope)
        {
            return _roleAssignmentsClient.CreateRoleAssignment(roleAssignmentId, new Guid(roleDefinitionId), new Guid(objectId), scope);
        }

        public void DeleteRoleAssignmentById(string roleAssignmentId)
        {
            _roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignmentId);
        }

        public void DeleteRoleAssignmentByName(string workspaceName, string roleDefinitionId, string objectId, string scope)
        {
            var roleAssignments = _roleAssignmentsClient.ListRoleAssignments(roleDefinitionId, objectId).Value.Value
                .Where(ra => string.IsNullOrEmpty(scope) || scope.Equals(ra.Scope, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (roleAssignments.Count == 0)
            {
                throw new AzPSResourceNotFoundCloudException(String.Format(Resources.WorkspaceRoleAssignmentNotFound, workspaceName));
            }
            else if (roleAssignments.Count == 1)
            {
                string roleAssignmentId = roleAssignments[0].Id;
                _roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignmentId);
            }
            else
            {
                throw new AzPSInvalidOperationException(String.Format(Resources.WorkspaceRoleAssignmentMoreThanOneFound, workspaceName, string.Join(", ", roleAssignments.Select(ra => ra.Id))));
            }
        }

        public IReadOnlyList<string> ListRoleScopes()
        {
            return _roleDefinitionsClient.ListScopes().Value;
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
                throw new AzPSInvalidOperationException(String.Format(Resources.UserNameDoesNotExist, signInName));
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
                throw new AzPSInvalidOperationException(String.Format(Resources.ServicePrincipalNameDoesNotExist, servicePrincipalName));
            }

            return servicePrincipal.ObjectId;
        }

        public string GetRoleDefinitionIdFromRoleDefinitionName(string roleDefinitionName)
        {
            if (string.IsNullOrEmpty(roleDefinitionName))
            {
                return null;
            }

            var roleDefinition = _roleDefinitionsClient.ListRoleDefinitions().Value.SingleOrDefault(element => element.Name.Equals(roleDefinitionName, StringComparison.OrdinalIgnoreCase));
            if (roleDefinition == null)
            {
                throw new AzPSInvalidOperationException(String.Format(Resources.RoleDefinitionNameDoesNotExist, roleDefinitionName));
            }

            return roleDefinition.Id.ToString();
        }

        public string GetRoleAssignmentScope(string workspaceName, string itemType, string item)
        {
            if (string.IsNullOrEmpty(workspaceName))
            {
                throw new AzPSArgumentNullException("Parameter cannot be null", workspaceName);
            }

            if (!string.IsNullOrEmpty(itemType) && !string.IsNullOrEmpty(item))
            {
                return $"workspaces/{workspaceName}/{itemType}/{item}";
            }
            else
            {
                return $"workspaces/{workspaceName}";
            }
        }
    }
}
