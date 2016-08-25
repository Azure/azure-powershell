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
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Management.Authorization.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    internal static class AuthorizationClientExtensions
    {
        public const string CustomRole = "CustomRole";

        public static IEnumerable<RoleAssignment> FilterRoleAssignmentsOnRoleId(this IEnumerable<RoleAssignment> assignments, string roleId)
        {
            if (!string.IsNullOrEmpty(roleId))
            {
                return assignments.Where(a => a.Properties.RoleDefinitionId.GuidFromFullyQualifiedId() == roleId);
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
                    Name = role.Properties.RoleName,
                    Actions = new List<string>(role.Properties.Permissions.SelectMany(r => r.Actions)),
                    NotActions = new List<string>(role.Properties.Permissions.SelectMany(r => r.NotActions)),
                    Id = role.Id.GuidFromFullyQualifiedId(),
                    AssignableScopes = role.Properties.AssignableScopes.ToList(),
                    Description = role.Properties.Description,
                    IsCustom = role.Properties.Type == CustomRole ? true : false
                };
            }

            return roleDefinition;
        }

        public static PSRoleAssignment ToPSRoleAssignment(this RoleAssignment assignment, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals = true)
        {
            List<PSRoleDefinition> roleDefinitions = null;

            try
            {
                roleDefinitions = new List<PSRoleDefinition> { policyClient.GetRoleDefinition(assignment.Properties.RoleDefinitionId) };
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
            objectIds.AddRange(assignments.Select(r => r.Properties.PrincipalId.ToString()));
            List<PSADObject> adObjects = activeDirectoryClient.GetObjectsByObjectId(objectIds);

            foreach (RoleAssignment assignment in assignments)
            {
                assignment.Properties.RoleDefinitionId = assignment.Properties.RoleDefinitionId.GuidFromFullyQualifiedId();
                PSADObject adObject = adObjects.SingleOrDefault(o => o.Id == assignment.Properties.PrincipalId) ?? new PSADObject() { Id = assignment.Properties.PrincipalId };
                PSRoleDefinition roleDefinition = roleDefinitions.SingleOrDefault(r => r.Id == assignment.Properties.RoleDefinitionId) ?? new PSRoleDefinition() { Id = assignment.Properties.RoleDefinitionId };

                if (adObject is PSADUser)
                {
                    psAssignments.Add(new PSRoleAssignment()
                    {
                        RoleAssignmentId = assignment.Id,
                        DisplayName = adObject.DisplayName,
                        RoleDefinitionId = roleDefinition.Id,
                        RoleDefinitionName = roleDefinition.Name,
                        Scope = assignment.Properties.Scope,
                        SignInName = ((PSADUser)adObject).UserPrincipalName,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type
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
                        Scope = assignment.Properties.Scope,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type
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
                        Scope = assignment.Properties.Scope,
                        ObjectId = adObject.Id,
                        ObjectType = adObject.Type
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
                        Scope = assignment.Properties.Scope,
                        ObjectId = adObject.Id,
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
                RoleDefinitionName = classicAdministrator.Properties.Role,
                DisplayName = classicAdministrator.Properties.EmailAddress,
                SignInName = classicAdministrator.Properties.EmailAddress,
                Scope = AuthorizationHelper.GetSubscriptionScope(currentSubscriptionId),
                ObjectType = "User"
            };
        }

        private static string GuidFromFullyQualifiedId(this string Id)
        {
            return Id.TrimEnd('/').Substring(Id.LastIndexOf('/') + 1);
        }
    }
}
