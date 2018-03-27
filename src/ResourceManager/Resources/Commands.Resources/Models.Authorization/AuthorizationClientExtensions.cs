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

using Hyak.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Management.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    internal static class AuthorizationClientExtensions
    {
        public const string CustomRole = "CustomRole";
        public const string AuthorizationDeniedException = "Authorization_RequestDenied";

        public static IEnumerable<RoleAssignment> FilterRoleAssignmentsOnRoleId(this IEnumerable<RoleAssignment> assignments, string roleId)
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                return assignments.Where(a => a.RoleDefinitionId.GuidFromFullyQualifiedId() == roleId.GuidFromFullyQualifiedId());
            }

            return assignments;
        }

        public static PSRoleDefinition ToPSRoleDefinition(this RoleDefinition role)
        {
            PSRoleDefinition roleDefinition = null;

            if (role != null)
            {
                roleDefinition = new PSRoleDefinition
                {
                    Name = role.RoleName,
                    Actions = new List<string>(role.Permissions.SelectMany(r => r.Actions)),
                    NotActions = new List<string>(role.Permissions.SelectMany(r => r.NotActions)),
                    DataActions = new List<string>(role.Permissions.SelectMany(r => r.DataActions)),
                    NotDataActions = new List<string>(role.Permissions.SelectMany(r => r.NotDataActions)),
                    Id = role.Id.GuidFromFullyQualifiedId(),
                    AssignableScopes = role.AssignableScopes.ToList(),
                    Description = role.Description,
                    IsCustom = role.RoleType == CustomRole ? true : false
                };
            }

            return roleDefinition;
        }

        public static PSRoleAssignment ToPSRoleAssignment(this RoleAssignment assignment, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals = true)
        {
            List<PSRoleDefinition> roleDefinitions = null;

            try
            {
                roleDefinitions = new List<PSRoleDefinition> { policyClient.GetRoleDefinition(assignment.RoleDefinitionId) };
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Swallow unauthorized errors on RoleDefinition when displaying RoleAssignments
                    roleDefinitions = new List<PSRoleDefinition>();
                }
                else
                {
                    throw;
                }
            }

            IEnumerable<RoleAssignment> assignments = new List<RoleAssignment> { assignment };

            return assignments.ToPSRoleAssignments(roleDefinitions, policyClient, activeDirectoryClient, excludeAssignmentsForDeletedPrincipals).SingleOrDefault();
        }

        public static IEnumerable<PSRoleAssignment> ToPSRoleAssignments(this IEnumerable<RoleAssignment> assignments, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, string scopeForRoleDefinitions, bool excludeAssignmentsForDeletedPrincipals = true)
        {
            List<PSRoleDefinition> roleDefinitions = null;

            try
            {
                roleDefinitions = policyClient.GetAllRoleDefinitionsAtScopeAndBelow(scopeForRoleDefinitions);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Swallow unauthorized errors on RoleDefinition when displaying RoleAssignments
                    roleDefinitions = new List<PSRoleDefinition>();
                }
                else
                {
                    throw;
                }
            }

            return assignments.ToPSRoleAssignments(roleDefinitions, policyClient, activeDirectoryClient, excludeAssignmentsForDeletedPrincipals);
        }

        private static IEnumerable<PSRoleAssignment> ToPSRoleAssignments(this IEnumerable<RoleAssignment> assignments, List<PSRoleDefinition> roleDefinitions, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals)
        {
            List<PSRoleAssignment> psAssignments = new List<PSRoleAssignment>();
            if (assignments == null || !assignments.Any())
            {
                return psAssignments;
            }

            List<string> objectIds = new List<string>();
            objectIds.AddRange(assignments.Select(r => r.PrincipalId.ToString()));
            objectIds = objectIds.Distinct().ToList();
            List<PSADObject> adObjects = null;
            try
            {
                adObjects = activeDirectoryClient.GetObjectsByObjectId(objectIds);
            }
            catch (CloudException ce) when (IsAuthorizationDeniedException(ce))
            {
                throw new InvalidOperationException(ProjectResources.InSufficientGraphPermission);
            }

            foreach (RoleAssignment assignment in assignments)
            {
                assignment.RoleDefinitionId = assignment.RoleDefinitionId.GuidFromFullyQualifiedId();
                PSADObject adObject = adObjects.SingleOrDefault(o => o.Id == Guid.Parse(assignment.PrincipalId)) ??
                    new PSADObject() { Id = Guid.Parse(assignment.PrincipalId) };
                PSRoleDefinition roleDefinition = roleDefinitions.SingleOrDefault(r => r.Id == assignment.RoleDefinitionId) ?? 
                    new PSRoleDefinition() { Id = assignment.RoleDefinitionId };
                bool delegationFlag = assignment.CanDelegate.HasValue ? (bool)assignment.CanDelegate : false;
                if (adObject is PSADUser)
                {
                    psAssignments.Add(new PSRoleAssignment()
                    {
                        RoleAssignmentId = assignment.Id,
                        DisplayName = adObject.DisplayName,
                        RoleDefinitionId = roleDefinition.Id,
                        RoleDefinitionName = roleDefinition.Name,
                        Scope = assignment.Scope,
                        SignInName = ((PSADUser)adObject).UserPrincipalName,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type,
                        CanDelegate = delegationFlag
                    });
                }
                else if (adObject is PSADGroup)
                {
                    psAssignments.Add(new PSRoleAssignment()
                    {
                        RoleAssignmentId = assignment.Id,
                        DisplayName = adObject.DisplayName,
                        RoleDefinitionId = roleDefinition.Id,
                        RoleDefinitionName = roleDefinition.Name,
                        Scope = assignment.Scope,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type,
                        CanDelegate = delegationFlag
                    });
                }
                else if (adObject is PSADServicePrincipal)
                {
                    psAssignments.Add(new PSRoleAssignment()
                    {
                        RoleAssignmentId = assignment.Id,
                        DisplayName = adObject.DisplayName,
                        RoleDefinitionId = roleDefinition.Id,
                        RoleDefinitionName = roleDefinition.Name,
                        Scope = assignment.Scope,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type,
                        CanDelegate = delegationFlag
                    });
                }
                else if (!excludeAssignmentsForDeletedPrincipals)
                {
                    psAssignments.Add(new PSRoleAssignment()
                    {
                        RoleAssignmentId = assignment.Id,
                        DisplayName = adObject.DisplayName,
                        RoleDefinitionId = roleDefinition.Id,
                        RoleDefinitionName = roleDefinition.Name,
                        Scope = assignment.Scope,
                        ObjectId = adObject.Id,
                        CanDelegate = delegationFlag
                    });
                }

                // Ignore the assignment if principal does not exists and excludeAssignmentsForDeletedPrincipals is set to true
            }

            return psAssignments;
        }

        public static PSRoleAssignment ToPSRoleAssignment(this ClassicAdministrator classicAdministrator, string currentSubscriptionId)
        {
            return new PSRoleAssignment()
            {
                RoleDefinitionName = classicAdministrator.Role,
                DisplayName = classicAdministrator.EmailAddress,
                SignInName = classicAdministrator.EmailAddress,
                Scope = AuthorizationHelper.GetSubscriptionScope(currentSubscriptionId),
                ObjectType = "User"
            };
        }

        private static string GuidFromFullyQualifiedId(this string Id)
        {
            return Id.TrimEnd('/').Substring(Id.LastIndexOf('/') + 1);
        }

        private static bool IsAuthorizationDeniedException(CloudException ce)
        {
            if (ce.Response != null && ce.Response.StatusCode == HttpStatusCode.Unauthorized &&
                ce.Error != null && ce.Error.Code != null && string.Equals(ce.Error.Code, AuthorizationDeniedException, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
