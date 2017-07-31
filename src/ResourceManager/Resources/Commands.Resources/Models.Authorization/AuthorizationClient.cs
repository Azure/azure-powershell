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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// This queue is used by the tests to assign fixed role definition
        /// names every time the test runs.
        /// </summary>
        public static Queue<Guid> RoleDefinitionNames { get; set; }


        public IAuthorizationManagementClient AuthorizationManagementClient { get; set; }

        public ActiveDirectoryClient ActiveDirectoryClient { get; set; }

        static AuthorizationClient()
        {
            RoleAssignmentNames = new Queue<Guid>();
            RoleDefinitionNames = new Queue<Guid>();
        }

        /// <summary>
        /// Creates PoliciesClient using AzureContext instance.
        /// </summary>
        /// <param name="context">The AzureContext instance</param>
        public AuthorizationClient(IAzureContext context)
        {
            ActiveDirectoryClient = new ActiveDirectoryClient(context);
            AuthorizationManagementClient = AzureSession.Instance.ClientFactory
#if !NETSTANDARD
                .CreateClient<AuthorizationManagementClient>
#else
                .CreateArmClient<AuthorizationManagementClient>
#endif
                (context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Gets a single role definition by a fully qualified role Id
        /// </summary>
        /// <param name="roleId">Fully qualified roleId</param>
        public PSRoleDefinition GetRoleDefinition(string roleId)
        {
            return AuthorizationManagementClient.RoleDefinitions.GetById(roleId)
#if !NETSTANDARD
                .RoleDefinition
#endif
                .ToPSRoleDefinition();
        }

        /// <summary>
        /// Gets a single role definition by the role Id guid.
        /// </summary>
        /// <param name="roleId">RoleId guid</param>
        public PSRoleDefinition GetRoleDefinition(Guid roleId, string scope)
        {
            return AuthorizationManagementClient.RoleDefinitions
#if !NETSTANDARD
                .Get(roleId, scope).RoleDefinition
#else
                .Get(scope, roleId.ToString())
#endif
                .ToPSRoleDefinition();
        }

        /// <summary>
        /// Filters the existing role Definitions.
        /// If name is not provided, all role definitions are fetched.
        /// </summary>
        /// <param name="name">The role name</param>
        /// <returns>The matched role Definitions</returns>
        public List<PSRoleDefinition> FilterRoleDefinitions(string name, string scope, bool scopeAndBelow = false)
        {
            List<PSRoleDefinition> result = new List<PSRoleDefinition>();
#if !NETSTANDARD
            ListDefinitionFilterParameters parameters = new ListDefinitionFilterParameters
            {
                RoleName = name,
                AtScopeAndBelow = scopeAndBelow
            };

            result.AddRange(AuthorizationManagementClient.RoleDefinitions.List(scope, parameters).RoleDefinitions.Select(r => r.ToPSRoleDefinition()));
#else

            Rest.Azure.OData.ODataQuery<RoleDefinitionFilter> odataFilter = null;

            if (scopeAndBelow)
            {
                odataFilter = new Rest.Azure.OData.ODataQuery<RoleDefinitionFilter>(item => item.AtScopeAndBelow() && item.RoleName == name);
            }
            else
            {
                odataFilter = new Rest.Azure.OData.ODataQuery<RoleDefinitionFilter>(item => item.RoleName == name);
            }

            result.AddRange(AuthorizationManagementClient.RoleDefinitions.List(
                        scope,
                        odataFilter)
                  .Select(r => r.ToPSRoleDefinition()));

#endif
            return result;
        }

        public List<PSRoleDefinition> FilterRoleDefinitions(FilterRoleDefinitionOptions options)
        {
            if (options.RoleDefinitionId != Guid.Empty)
            {
                return new List<PSRoleDefinition> { GetRoleDefinition(options.RoleDefinitionId, options.Scope) };
            }
            else if (options.CustomOnly)
            {
                // Special case - if custom only flag is specified then you don't need to lookup on a specific id or name since it will be a bit redundant
                return FilterRoleDefinitionsByCustom(options.Scope, options.ScopeAndBelow);
            }
            else
            {
                // If RoleDefinition name is not specified (null/empty), service will handle it and return all roles
                return FilterRoleDefinitions(options.RoleDefinitionName, options.Scope, options.ScopeAndBelow);
            }
        }


        /// <summary>
        /// Fetches all existing role Definitions.
        /// </summary>
        /// <returns>role Definitions</returns>
        public List<PSRoleDefinition> GetAllRoleDefinitionsAtScopeAndBelow(string scope)
        {
            List<PSRoleDefinition> result = new List<PSRoleDefinition>();
#if !NETSTANDARD
            result.AddRange(AuthorizationManagementClient.RoleDefinitions.List(scope,
                new ListDefinitionFilterParameters { AtScopeAndBelow = true })
                .RoleDefinitions
#else
            result.AddRange(AuthorizationManagementClient.RoleDefinitions.List(scope??"",
            new Rest.Azure.OData.ODataQuery<RoleDefinitionFilter>(filter => filter.AtScopeAndBelow()))
#endif
                .Select(r => r.ToPSRoleDefinition()));
            return result;
        }

        /// <summary>
        /// Filters the existing role Definitions by CustomRole.
        /// </summary>
        /// <returns>The custom role Definitions</returns>
        public List<PSRoleDefinition> FilterRoleDefinitionsByCustom(string scope, bool scopeAndBelow)
        {
            List<PSRoleDefinition> result = new List<PSRoleDefinition>();
            result.AddRange(AuthorizationManagementClient.RoleDefinitions.List(
                    scope,
#if !NETSTANDARD
                    parameters: new ListDefinitionFilterParameters { AtScopeAndBelow = scopeAndBelow })
                .RoleDefinitions
#else
                    scopeAndBelow ? new Rest.Azure.OData.ODataQuery<RoleDefinitionFilter>(filter => filter.AtScopeAndBelow()) : null)
#endif
                .Where(r => r.Properties.Type == AuthorizationClientExtensions.CustomRole)
                .Select(r => r.ToPSRoleDefinition()));
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
            string scope = parameters.Scope;
            string roleDefinitionId = !string.IsNullOrEmpty(parameters.RoleDefinitionName)
                ? AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(scope, GetSingleRoleDefinitionByName(parameters.RoleDefinitionName, scope).Id)
                : AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(scope, parameters.RoleDefinitionId);
#if !NETSTANDARD
            RoleAssignmentCreateParameters createParameters = new RoleAssignmentCreateParameters
            {
                Properties = new RoleAssignmentProperties
                {
                    PrincipalId = principalId,
                    RoleDefinitionId = roleDefinitionId
                }
            };

            RoleAssignment assignment = AuthorizationManagementClient.RoleAssignments.Create(parameters.Scope, roleAssignmentId, createParameters).RoleAssignment;
#else
            var createParameters = new RoleAssignmentProperties
            {
                PrincipalId = principalId.ToString(),
                RoleDefinitionId = roleDefinitionId
            };

            RoleAssignment assignment = AuthorizationManagementClient.RoleAssignments.Create(
                parameters.Scope, 
                roleAssignmentId.ToString(), createParameters);
#endif
            return assignment.ToPSRoleAssignment(this, ActiveDirectoryClient);
        }

        /// <summary>
        /// Filters role assignments based on the passed options.
        /// </summary>
        /// <param name="options">The filtering options</param>
        /// <param name="currentSubscription">The current subscription</param>
        /// <returns>The filtered role assignments</returns>
#if !NETSTANDARD
        public List<PSRoleAssignment> FilterRoleAssignments(FilterRoleAssignmentsOptions options, string currentSubscription)
        {
            List<PSRoleAssignment> result = new List<PSRoleAssignment>();
            List<RoleAssignment> roleAssignments = new List<RoleAssignment>();
            ListAssignmentsFilterParameters parameters = new ListAssignmentsFilterParameters();

            PSADObject adObject = null;
            if (options.ADObjectFilter.HasFilter)
            {
                if (string.IsNullOrEmpty(options.ADObjectFilter.Id) || options.ExpandPrincipalGroups || options.IncludeClassicAdministrators)
                {
                    adObject = ActiveDirectoryClient.GetADObject(options.ADObjectFilter);

                    if (adObject == null)
                    {
                        throw new KeyNotFoundException(ProjectResources.PrincipalNotFound);
                    }
                }

                // Filter first by principal
                if (options.ExpandPrincipalGroups)
                {                   
                    if (!(adObject is PSADUser))
                    {
                        throw new InvalidOperationException(ProjectResources.ExpandGroupsNotSupported);
                    }

                    parameters.AssignedToPrincipalId = adObject.Id;
                }
                else
                {
                    parameters.PrincipalId = string.IsNullOrEmpty(options.ADObjectFilter.Id) ? adObject.Id : Guid.Parse(options.ADObjectFilter.Id);
                }

                var tempResult = AuthorizationManagementClient.RoleAssignments.List(parameters);
                roleAssignments.AddRange(tempResult.RoleAssignments.ToList());

                while (!string.IsNullOrWhiteSpace(tempResult.NextLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListNext(tempResult.NextLink);
                    roleAssignments.AddRange(tempResult.RoleAssignments.ToList());
                }

                // Filter out by scope
                if (!string.IsNullOrWhiteSpace(options.Scope))
                {
                    roleAssignments.RemoveAll(r => !options.Scope.StartsWith(r.Properties.Scope, StringComparison.InvariantCultureIgnoreCase));
                }
            }
            else if (!string.IsNullOrEmpty(options.Scope))
            {
                // Filter by scope and above directly
                parameters.AtScope = true;

                var tempResult = AuthorizationManagementClient.RoleAssignments.ListForScope(options.Scope, parameters);
                roleAssignments.AddRange(tempResult.RoleAssignments.ToList());

                while (!string.IsNullOrWhiteSpace(tempResult.NextLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListForScopeNext(tempResult.NextLink);
                    roleAssignments.AddRange(tempResult.RoleAssignments.ToList());
                }
            }
            else
            {
                var tempResult = AuthorizationManagementClient.RoleAssignments.List(parameters);
                roleAssignments.AddRange(tempResult.RoleAssignments.ToList());

                while (!string.IsNullOrWhiteSpace(tempResult.NextLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListNext(tempResult.NextLink);
                    roleAssignments.AddRange(tempResult.RoleAssignments.ToList());
                }
            }

            // To look for RoleDefinitions at the stated scope - if scope is Null then default to subscription scope
            string scopeForRoleDefinitions = string.IsNullOrEmpty(options.Scope) ? AuthorizationHelper.GetSubscriptionScope(currentSubscription) : options.Scope;

            result.AddRange(roleAssignments.FilterRoleAssignmentsOnRoleId(options.RoleDefinitionId)
                .ToPSRoleAssignments(this, ActiveDirectoryClient, scopeForRoleDefinitions, options.ExcludeAssignmentsForDeletedPrincipals));

            if (!string.IsNullOrEmpty(options.RoleDefinitionName))
            {
                result = result.Where(r => r.RoleDefinitionName.Equals(options.RoleDefinitionName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (options.IncludeClassicAdministrators)
            {
                // Get classic administrator access assignments 
                List<ClassicAdministrator> classicAdministrators = AuthorizationManagementClient.ClassicAdministrators.List().ClassicAdministrators.ToList();
                List<PSRoleAssignment> classicAdministratorsAssignments = classicAdministrators.Select(a => a.ToPSRoleAssignment(currentSubscription)).ToList();

                // Filter by principal if provided
                if (options.ADObjectFilter.HasFilter)
                {
                    if (!(adObject is PSADUser))
                    {
                        throw new InvalidOperationException(ProjectResources.IncludeClassicAdminsNotSupported);
                    }

                    var userObject = adObject as PSADUser;
                    classicAdministratorsAssignments = classicAdministratorsAssignments.Where(c =>
                           c.DisplayName.Equals(userObject.UserPrincipalName, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                result.AddRange(classicAdministratorsAssignments);
            }

            return result;
        }
#else
        public List<PSRoleAssignment> FilterRoleAssignments(FilterRoleAssignmentsOptions options, string currentSubscription)
        {
            List<PSRoleAssignment> result = new List<PSRoleAssignment>();
            string assignedToPrincipalId = null;
            string principalId = null;

            PSADObject adObject = null;
            if (options.ADObjectFilter.HasFilter)
            {
                adObject = ActiveDirectoryClient.GetADObject(options.ADObjectFilter);
                if (adObject == null)
                {
                    throw new KeyNotFoundException(ProjectResources.PrincipalNotFound);
                }

                // Filter first by principal
                if (options.ExpandPrincipalGroups)
                {
                    if (!(adObject is PSADUser))
                    {
                        throw new InvalidOperationException(ProjectResources.ExpandGroupsNotSupported);
                    }

                    assignedToPrincipalId = adObject.Id.ToString();
                }
                else
                {
                    principalId = string.IsNullOrEmpty(options.ADObjectFilter.Id.ToString()) ? adObject.Id.ToString() : options.ADObjectFilter.Id;
                }

                var tempResult = AuthorizationManagementClient.RoleAssignments.List(
                    new Rest.Azure.OData.ODataQuery<RoleAssignmentFilter>(f => f.PrincipalId == principalId && f.AssignedTo(assignedToPrincipalId)));
                result.AddRange(tempResult.FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                    .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));

                while (!string.IsNullOrWhiteSpace(tempResult.NextPageLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListNext(tempResult.NextPageLink);
                    result.AddRange(tempResult.FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                        .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));
                }

                // Filter out by scope
                if (!string.IsNullOrEmpty(options.Scope))
                {
                    result.RemoveAll(r => !options.Scope.StartsWith(r.Scope, StringComparison.OrdinalIgnoreCase));
                }
            }
            else if (!string.IsNullOrEmpty(options.Scope))
            {
                // Filter by scope and above directly
                var tempResult = AuthorizationManagementClient.RoleAssignments.ListForScope(
                    options.Scope,
                    new Rest.Azure.OData.ODataQuery<RoleAssignmentFilter>(
                        f => f.AtScope() && f.PrincipalId == principalId && f.AssignedTo(assignedToPrincipalId)));

                result.AddRange(tempResult.FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                    .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));

                while (!string.IsNullOrWhiteSpace(tempResult.NextPageLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListForScopeNext(tempResult.NextPageLink);
                    result.AddRange(tempResult.FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                        .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));
                }
            }
            else
            {
                var tempResult = AuthorizationManagementClient.RoleAssignments.List(
                    new Rest.Azure.OData.ODataQuery<RoleAssignmentFilter>(f => f.PrincipalId == principalId && f.AssignedTo(assignedToPrincipalId)));
                result.AddRange(tempResult
                     .FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                     .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));

                while (!string.IsNullOrWhiteSpace(tempResult.NextPageLink))
                {
                    tempResult = AuthorizationManagementClient.RoleAssignments.ListNext(tempResult.NextPageLink);
                    result.AddRange(tempResult
                   .FilterRoleAssignmentsOnRoleId(AuthorizationHelper.ConstructFullyQualifiedRoleDefinitionIdFromScopeAndIdAsGuid(currentSubscription, options.RoleDefinitionId))
                   .ToPSRoleAssignments(this, ActiveDirectoryClient, options.Scope, options.ExcludeAssignmentsForDeletedPrincipals));
                }
            }

            if (!string.IsNullOrEmpty(options.RoleDefinitionName))
            {
                result = result.Where(r => r.RoleDefinitionName.Equals(options.RoleDefinitionName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (options.IncludeClassicAdministrators)
            {
                // Get classic administrator access assignments 
                List<ClassicAdministrator> classicAdministrators = AuthorizationManagementClient.ClassicAdministrators
                    .List(AuthorizationManagementClient.ApiVersion).ToList();
                List<PSRoleAssignment> classicAdministratorsAssignments = classicAdministrators.Select(a => a.ToPSRoleAssignment(currentSubscription)).ToList();

                // Filter by principal if provided
                if (options.ADObjectFilter.HasFilter)
                {
                    if (!(adObject is PSADUser))
                    {
                        throw new InvalidOperationException(ProjectResources.IncludeClassicAdminsNotSupported);
                    }

                    var userObject = adObject as PSADUser;
                    classicAdministratorsAssignments = classicAdministratorsAssignments.Where(c =>
                           c.DisplayName.Equals(userObject.UserPrincipalName, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                result.AddRange(classicAdministratorsAssignments);
            }

            return result;
        }
#endif
        /// <summary>
        /// Deletes a role assignments based on the used options.
        /// </summary>
        /// <param name="options">The role assignment filtering options</param>
        /// <param name="subscriptionId">Current subscription id</param>
        /// <returns>The deleted role assignments</returns>
        public IEnumerable<PSRoleAssignment> RemoveRoleAssignment(FilterRoleAssignmentsOptions options, string subscriptionId)
        {
            // Match role assignments at exact scope. Ideally, atmost 1 roleAssignment should match the criteria 
            // but an edge case can have multiple role assignments to the same role or multiple role assignments to different roles, with same name.
            // The FilterRoleAssignments takes care of paging internally
            IEnumerable<PSRoleAssignment> roleAssignments = FilterRoleAssignments(options, currentSubscription: subscriptionId)
                                                .Where(ra => ra.Scope == options.Scope.TrimEnd('/'));

            if (roleAssignments == null || !roleAssignments.Any())
            {
                throw new KeyNotFoundException("The provided information does not map to a role assignment.");
            }
            else if (roleAssignments.Count() == 1)
            {
                AuthorizationManagementClient.RoleAssignments.DeleteById(roleAssignments.Single().RoleAssignmentId);
            }
            else
            {
                // All assignments are to the same roleDefinition Id.
                if (roleAssignments.All(a => a.RoleDefinitionId == roleAssignments.First().RoleDefinitionId))
                {
                    foreach (var assignment in roleAssignments)
                    {
                        AuthorizationManagementClient.RoleAssignments.DeleteById(assignment.RoleAssignmentId);
                    }
                }
                else
                {
                    // Assignments to different roleDefintion Ids. This can happen only if roleDefinition name was provided and multiple roles exists with same name.
                    throw new InvalidOperationException(string.Format(ProjectResources.MultipleRoleDefinitionsFoundWithSameName, options.RoleDefinitionName));
                }
            }

            return roleAssignments;
        }

        public PSRoleDefinition GetSingleRoleDefinitionByName(string name, string scope)
        {
            List<PSRoleDefinition> roles = FilterRoleDefinitions(name, scope);

            if (roles == null || !roles.Any())
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionNotFound, name));
            }
            else if (roles.Count > 1)
            {
                throw new InvalidOperationException(string.Format(ProjectResources.MultipleRoleDefinitionsFoundWithSameName, name));
            }

            return roles.First();
        }

        /// <summary>
        /// Deletes a role definition based on the id.
        /// </summary>
        /// <param name="roleDefinitionId">The role definition id to delete</param>
        /// <param name="subscriptionId">Current subscription id</param>
        /// <returns>The deleted role definition.</returns>
        public PSRoleDefinition RemoveRoleDefinition(Guid roleDefinitionId, string scope)
        {
            PSRoleDefinition roleDefinition = this.GetRoleDefinition(roleDefinitionId, scope);
            if (roleDefinition != null)
            {
                return AuthorizationManagementClient.RoleDefinitions
#if !NETSTANDARD
                    .Delete(roleDefinitionId, scope).RoleDefinition
#else
                    .Delete(scope, roleDefinitionId.ToString())
#endif
                    .ToPSRoleDefinition();
            }
            else
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionWithIdNotFound, roleDefinitionId));
            }
        }

        /// <summary>
        /// Deletes a role definition based on the name.
        /// </summary>
        /// <param name="roleDefinitionName">The role definition name.</param>
        /// <returns>The deleted role definition.</returns>
        public PSRoleDefinition RemoveRoleDefinition(string roleDefinitionName, string scope)
        {
            PSRoleDefinition roleDefinition = this.GetSingleRoleDefinitionByName(roleDefinitionName, scope);
            return AuthorizationManagementClient.RoleDefinitions
#if !NETSTANDARD
                .Delete(Guid.Parse(roleDefinition.Id), scope).RoleDefinition
#else
                .Delete(scope, roleDefinition.Id)
#endif
                .ToPSRoleDefinition();
        }

        public PSRoleDefinition RemoveRoleDefinition(FilterRoleDefinitionOptions options)
        {
            if (options.RoleDefinitionId != Guid.Empty)
            {
                return this.RemoveRoleDefinition(options.RoleDefinitionId, options.Scope);
            }
            else if (!string.IsNullOrEmpty(options.RoleDefinitionName))
            {
                return this.RemoveRoleDefinition(options.RoleDefinitionName, options.Scope);
            }
            else
            {
                throw new InvalidOperationException("RoleDefinition Name or Id should be specified.");
            }
        }

        /// <summary>
        /// Updates a role definiton.
        /// </summary>
        /// <param name="roleDefinition">The role definition to update.</param>
        /// <returns>The updated role definition.</returns>
        public PSRoleDefinition UpdateRoleDefinition(PSRoleDefinition roleDefinition)
        {
            Guid roleDefinitionId;
            if (!Guid.TryParse(roleDefinition.Id, out roleDefinitionId))
            {
                throw new InvalidOperationException(ProjectResources.RoleDefinitionIdShouldBeAGuid);
            }

            ValidateRoleDefinition(roleDefinition);

            PSRoleDefinition fetchedRoleDefinition = this.GetRoleDefinition(roleDefinitionId, roleDefinition.AssignableScopes.First());
            if (fetchedRoleDefinition == null)
            {
                throw new KeyNotFoundException(string.Format(ProjectResources.RoleDefinitionWithIdNotFound, roleDefinition.Id));
            }

            return this.CreateOrUpdateRoleDefinition(roleDefinitionId, roleDefinition);
        }

        /// <summary>
        /// Creates a new role definition.
        /// </summary>
        /// <param name="roleDefinition">The role definition to create.</param>
        /// <returns>The created role definition.</returns>
        public PSRoleDefinition CreateRoleDefinition(PSRoleDefinition roleDefinition)
        {
            ValidateRoleDefinition(roleDefinition);

            Guid newRoleDefinitionId = RoleDefinitionNames.Count == 0 ? Guid.NewGuid() : RoleDefinitionNames.Dequeue();
            return this.CreateOrUpdateRoleDefinition(newRoleDefinitionId, roleDefinition);
        }

        private PSRoleDefinition CreateOrUpdateRoleDefinition(Guid roleDefinitionId, PSRoleDefinition roleDefinition)
        {
            PSRoleDefinition roleDef = null;
#if !NETSTANDARD
            var parameters = new RoleDefinitionCreateOrUpdateParameters()
            {
                RoleDefinition = new RoleDefinition()
                {
                    Name = roleDefinitionId,
                    Properties = new RoleDefinitionProperties()
                    {
                        AssignableScopes = roleDefinition.AssignableScopes,
                        Description = roleDefinition.Description,
                        Permissions = new List<Permission>()
                        {
                            new Permission()
                            {
                                Actions = roleDefinition.Actions,
                                NotActions = roleDefinition.NotActions
                            }
                        },
                        RoleName = roleDefinition.Name,
                        Type = "CustomRole"
                    }
                }
            };
#else
            var parameters = new RoleDefinition()
            {
                Name = roleDefinitionId.ToString(),
                Properties = new RoleDefinitionProperties()
                {
                    AssignableScopes = roleDefinition.AssignableScopes,
                    Description = roleDefinition.Description,
                    Permissions = new List<Permission>()
                        {
                            new Permission()
                            {
                                Actions = roleDefinition.Actions,
                                NotActions = roleDefinition.NotActions
                            }
                        },
                    RoleName = roleDefinition.Name,
                    Type = "CustomRole"
                }
            };
#endif
            try
            {
                roleDef = AuthorizationManagementClient.RoleDefinitions.CreateOrUpdate(
#if !NETSTANDARD
					roleDefinitionId, roleDefinition.AssignableScopes.First(), 
#else
					roleDefinition.AssignableScopes.First(), roleDefinitionId.ToString(),
#endif
					parameters)
#if !NETSTANDARD
					.RoleDefinition
#endif
					.ToPSRoleDefinition();
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.Unauthorized && 
                    ce.Error.Code.Equals("TenantNotAllowed", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new InvalidOperationException("The tenant is not currently authorized to create/update Custom role definition. Please refer to http://aka.ms/customrolespreview for more details");
                }

                throw;
            }

            return roleDef;
        }

        private static void ValidateRoleDefinition(PSRoleDefinition roleDefinition)
        {
            if (string.IsNullOrWhiteSpace(roleDefinition.Name))
            {
                throw new ArgumentException(ProjectResources.InvalidRoleDefinitionName);
            }

            if (string.IsNullOrWhiteSpace(roleDefinition.Description))
            {
                throw new ArgumentException(ProjectResources.InvalidRoleDefinitionDescription);
            }

            if (roleDefinition.AssignableScopes == null || !roleDefinition.AssignableScopes.Any() || roleDefinition.AssignableScopes.Any(s => string.IsNullOrWhiteSpace(s)))
            {
                throw new ArgumentException(ProjectResources.InvalidAssignableScopes);
            }

            if (roleDefinition.Actions == null || !roleDefinition.Actions.Any())
            {
                throw new ArgumentException(ProjectResources.InvalidActions);
            }
        }

        public static void ValidateScope(string scope, bool allowEmpty)
        {
            if (allowEmpty && string.IsNullOrEmpty(scope))
                return;

            if (scope.Length == 0 || !scope.StartsWith("/"))
            {
                throw new ArgumentException(string.Format(ProjectResources.ScopeShouldBeginWithSubscriptionsOrProviders, scope));
            }

            // "/" is a valid scope.
            if (string.Compare(scope, "/") == 0)
            {
                return;
            }

            var parts = scope.Substring(1).Split('/');   // Skip the leading '/'

            if (parts.Contains(string.Empty))
            {
                throw new ArgumentException(string.Format(ProjectResources.ScopeShouldHaveNoEmptyPart, scope));
            }

            int count = parts.Count();

            if (count % 2 != 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.ScopeShouldHaveEvenNumberOfParts, scope));
            }

            // For Scope that on tenant level, without subscriptions, should start with "providers"
            // in this case we only ensure that the number of parts is even.
            if (string.Compare(parts[0], "providers", true) == 0)
            {
                return;
            }
            else if (string.Compare(parts[0], "subscriptions", true) != 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.ScopeShouldBeginWithSubscriptionsOrProviders, scope));
            }

            // Now check the case that scope begins with '/subscriptions'

            if (count >= 4 && string.Compare(parts[2], "resourceGroups", true) != 0)
            {
                throw new ArgumentException(string.Format(ProjectResources.ScopeShouldBeginWithSubscriptionsAndResourceGroups, scope));
            }

            if (count >= 6)
            {
                if (string.Compare(parts[4], "providers", true) != 0)
                {
                    throw new ArgumentException(string.Format(ProjectResources.ScopeShouldBeginWithSubscriptionsAndResourceGroupsAndProviders, scope));
                }

                if (count < 8)
                {
                    throw new ArgumentException(string.Format(ProjectResources.ScopeShouldHaveAtLeastOnePairOfResourceTypeAndName, scope));
                }
            }

        }
    }
}
