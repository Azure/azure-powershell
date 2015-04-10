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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class AuthorizationClient
    {
        /// <summary>
        /// This queue is used by the tests to assign fixed role assignment
        /// names every time the test runs.
        /// </summary>
        public static Queue<Guid> RoleAssignmentNames { get; set; }

        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public ActiveDirectoryClient ActiveDirectoryClient { get; set; }

        static AuthorizationClient()
        {
            RoleAssignmentNames = new Queue<Guid>();
        }

        /// <summary>
        /// Creates PoliciesClient using AzureContext instance.
        /// </summary>
        /// <param name="context">The AzureContext instance</param>
        public AuthorizationClient(AzureContext context)
        {
            ActiveDirectoryClient = new ActiveDirectoryClient(context);
            AuthorizationManagementClient = AzureSession.ClientFactory.CreateClient<AuthorizationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public PSRoleDefinition GetRoleDefinition(string roleId)
        {
            return AuthorizationManagementClient.RoleDefinitions.GetById(roleId).RoleDefinition.ToPSRoleDefinition();
        }

        /// <summary>
        /// Filters the existing role Definitions.
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>The matched role Definitions</returns>
        public List<PSRoleDefinition> FilterRoleDefinitions(string name)
        {
            List<PSRoleDefinition> result = new List<PSRoleDefinition>();

            if (string.IsNullOrEmpty(name))
            {
                result.AddRange(AuthorizationManagementClient.RoleDefinitions.List().RoleDefinitions.Select(r => r.ToPSRoleDefinition()));
            }
            else
            {
                result.Add(AuthorizationManagementClient.RoleDefinitions.List().RoleDefinitions
                    .FirstOrDefault(r => r.Properties.RoleName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .ToPSRoleDefinition());
            }

            return result;
        }

        /// <summary>
        /// Creates new role assignment.
        /// </summary>
        /// <param name="parameters">The create parameters</param>
        /// <returns>The created role assignment object</returns>
        public PSRoleAssignment CreateRoleAssignment(FilterRoleAssignmentsOptions parameters)
        {
            Guid principalId = ActiveDirectoryClient.GetObjectId(parameters.ADObjectFilter);
            Guid roleAssignmentId = RoleAssignmentNames.Count == 0 ? Guid.NewGuid() : RoleAssignmentNames.Dequeue();
            string roleDefinitionId = GetRoleRoleDefinition(parameters.RoleDefinition).Id;

            RoleAssignmentCreateParameters createParameters = new RoleAssignmentCreateParameters
            {
                Properties = new RoleAssignmentProperties() { PrincipalId = principalId, RoleDefinitionId = roleDefinitionId }
            };

            AuthorizationManagementClient.RoleAssignments.Create(parameters.Scope, roleAssignmentId, createParameters);
            return
                AuthorizationManagementClient.RoleAssignments.Get(parameters.Scope, roleAssignmentId)
                    .RoleAssignment.ToPSRoleAssignment(this, ActiveDirectoryClient);
        }

        /// <summary>
        /// Filters role assignments based on the passed options.
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <returns>The filtered role assignments</returns>
        public List<PSRoleAssignment> FilterRoleAssignments(FilterRoleAssignmentsOptions options)
        {
            List<PSRoleAssignment> result = new List<PSRoleAssignment>();
            ListAssignmentsFilterParameters parameters = new ListAssignmentsFilterParameters();

            if (options.ADObjectFilter.HasFilter)
            {
                // Filter first by principal
                parameters.PrincipalId = string.IsNullOrEmpty(options.ADObjectFilter.Id) ? ActiveDirectoryClient.GetObjectId(options.ADObjectFilter) : Guid.Parse(options.ADObjectFilter.Id);
                result.AddRange(AuthorizationManagementClient.RoleAssignments.List(parameters)
                    .RoleAssignments.Select(r => r.ToPSRoleAssignment(this, ActiveDirectoryClient)));

                // Filter out by scope
                if (!string.IsNullOrEmpty(options.Scope))
                {
                    result.RemoveAll(r => !options.Scope.StartsWith(r.Scope));                    
                }
            }
            else if (!string.IsNullOrEmpty(options.Scope))
            {
                // Filter by scope and above directly
                parameters.AtScope = true;
                result.AddRange(AuthorizationManagementClient.RoleAssignments.ListForScope(options.Scope, parameters)
                    .RoleAssignments.Select(r => r.ToPSRoleAssignment(this, ActiveDirectoryClient)));
            }
            else
            {
                result.AddRange(AuthorizationManagementClient.RoleAssignments.List(parameters)
                    .RoleAssignments.Select(r => r.ToPSRoleAssignment(this, ActiveDirectoryClient)));
            }

            if (!string.IsNullOrEmpty(options.RoleDefinition))
            {
                result = result.Where(r => r.RoleDefinitionName.Equals(options.RoleDefinition, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return result;
        }

        /// <summary>
        /// Deletes a role assignments based on the used options.
        /// </summary>
        /// <param name="options">The role assignment filtering options</param>
        /// <returns>The deleted role assignments</returns>
        public PSRoleAssignment RemoveRoleAssignment(FilterRoleAssignmentsOptions options)
        {
            PSRoleAssignment roleAssignment = FilterRoleAssignments(options).FirstOrDefault();

            if (roleAssignment != null)
            {
                AuthorizationManagementClient.RoleAssignments.DeleteById(roleAssignment.RoleAssignmentId);
            }
            else
            {
                throw new KeyNotFoundException("The provided information does not map to a role assignment.");
            }

            return roleAssignment;
        }

        /// <summary>
        /// Deletes a role definition based on the id.
        /// </summary>
        /// <param name="id">The role definition id.</param>
        /// <returns>The deleted role definition.</returns>
        public PSRoleDefinition RemoveRoleDefinition(string id)
        {
            PSRoleDefinition roleDefinition = this.GetRoleDefinition(id);
            if (roleDefinition != null)
            {
                AuthorizationManagementClient.RoleDefinitions.Delete(roleDefinition.Id);
            }
            else
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionWithIdNotFound, id));
            }

            return roleDefinition;
        }

        public PSRoleDefinition GetRoleRoleDefinition(string name)
        {
            PSRoleDefinition role = FilterRoleDefinitions(name).FirstOrDefault();

            if (role == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionNotFound, name));
            }

            return role;
        }

        /// <summary>
        /// Updates a role definiton.
        /// </summary>
        /// <param name="role">The role definition to update.</param>
        /// <returns>The updated role definition.</returns>
        public PSRoleDefinition UpdateRoleDefinition(PSRoleDefinition role)
        {
            PSRoleDefinition roleDefinition = this.GetRoleDefinition(role.Id);
            if (roleDefinition == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionWithIdNotFound, role.Id));
            }

            roleDefinition.Name = role.Name ?? roleDefinition.Name;
            roleDefinition.Actions = role.Actions ?? roleDefinition.Actions;
            roleDefinition.NotActions = role.NotActions ?? roleDefinition.NotActions;

            // TODO: confirm with ARM on what exception will be thrown when the last segment of the roleDefinition's ID is not a GUID.
            // This will be done after their API is designed.
            string[] scopes = roleDefinition.Id.Split('/');
            Guid roleDefinitionId = Guid.Parse(scopes.Last());

            // TODO: update to include assignable scopes.
            return
                AuthorizationManagementClient.RoleDefinitions.CreateOrUpdate(
                    roleDefinitionId,
                    new RoleDefinitionCreateOrUpdateParameters()
                    {
                        RoleDefinition = new RoleDefinition()
                        {
                            Id = roleDefinition.Id,
                            Name = roleDefinitionId,
                            Properties =
                                new RoleDefinitionProperties()
                                {
                                    RoleName = roleDefinition.Name,
                                    Permissions =
                                        new List<Permission>()
                                        {
                                            new Permission()
                                            {
                                                Actions = roleDefinition.Actions,
                                                NotActions = roleDefinition.NotActions
                                            }
                                        }
                                }
                        }
                    }).RoleDefinition.ToPSRoleDefinition();
        }
    }
}
