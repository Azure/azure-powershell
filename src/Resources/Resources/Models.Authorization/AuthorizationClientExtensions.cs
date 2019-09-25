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
using Microsoft.Azure.Commands.ActiveDirectory;
using Microsoft.Azure.Management.Authorization.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    internal static class AuthorizationClientExtensions
    {
        private const string AllPrincipals = "All Principals";
        private const string SystemDefined = "SystemDefined";
        public const string CustomRole = "CustomRole";
        public const string AuthorizationDeniedException = "Authorization_RequestDenied";
        public const string DeletedObject = "Unknown";

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
            IEnumerable<PSRoleDefinition> roleDefinitions = null;
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

                public static IEnumerable<PSDenyAssignment> ToPSDenyAssignments(this IEnumerable<DenyAssignment> assignments, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals = true)
        {
            var psAssignments = new List<PSDenyAssignment>();
            if (assignments == null || !assignments.Any())
            {
                return psAssignments;
            }

            var objectIds = new List<string>();
            foreach (var da in assignments)
            {
                objectIds.AddRange(da.Principals.Where(p => Guid.Parse(p.Id) != Guid.Empty).Select(p => p.Id));
                objectIds.AddRange(da.ExcludePrincipals.Where(ep => Guid.Parse(ep.Id) != Guid.Empty).Select(ep => ep.Id));
            }

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

            foreach (var da in assignments)
            {
                var psda = new PSDenyAssignment()
                {
                    Id = da.Id.GuidFromFullyQualifiedId(),
                    DenyAssignmentName = da.DenyAssignmentName,
                    Description = da.Description,
                    Actions = new List<string>(da.Permissions.SelectMany(p => p.Actions)),
                    NotActions = new List<string>(da.Permissions.SelectMany(p => p.NotActions)),
                    DataActions = new List<string>(da.Permissions.SelectMany(p => p.DataActions)),
                    NotDataActions = new List<string>(da.Permissions.SelectMany(p => p.NotDataActions)),
                    Scope = da.Scope,
                    DoNotApplyToChildScopes = da.DoNotApplyToChildScopes ?? false,
                    IsSystemProtected = da.IsSystemProtected ?? false,
                };

                psda.Principals = da.Principals.ToPSPrincipals(adObjects, excludeAssignmentsForDeletedPrincipals).ToList();
                psda.ExcludePrincipals = da.ExcludePrincipals.ToPSPrincipals(adObjects, excludeAssignmentsForDeletedPrincipals).ToList();

                psAssignments.Add(psda);
            }

            return psAssignments;
        }

        public static PSDenyAssignment ToPSDenyAssignment(this DenyAssignment assignment, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals = true)
        {
            var objectIds = new List<string>();
            objectIds.AddRange(assignment.Principals.Where(p => Guid.Parse(p.Id) != Guid.Empty).Select(p => p.Id));
            objectIds.AddRange(assignment.ExcludePrincipals.Where(ep => Guid.Parse(ep.Id) != Guid.Empty).Select(ep => ep.Id));
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

            var psda = new PSDenyAssignment()
            {
                Id = assignment.Id.GuidFromFullyQualifiedId(),
                DenyAssignmentName = assignment.DenyAssignmentName,
                Description = assignment.Description,
                Actions = new List<string>(assignment.Permissions.SelectMany(p => p.Actions)),
                NotActions = new List<string>(assignment.Permissions.SelectMany(p => p.NotActions)),
                DataActions = new List<string>(assignment.Permissions.SelectMany(p => p.DataActions)),
                NotDataActions = new List<string>(assignment.Permissions.SelectMany(p => p.NotDataActions)),
                Scope = assignment.Scope,
                DoNotApplyToChildScopes = assignment.DoNotApplyToChildScopes ?? false,
                IsSystemProtected = assignment.IsSystemProtected ?? false,
            };

            psda.Principals = assignment.Principals.ToPSPrincipals(adObjects, excludeAssignmentsForDeletedPrincipals).ToList();
            psda.ExcludePrincipals = assignment.ExcludePrincipals.ToPSPrincipals(adObjects, excludeAssignmentsForDeletedPrincipals).ToList();

            return psda;
        }

        private static IEnumerable<PSPrincipal> ToPSPrincipals(this IEnumerable<Principal> principals, IEnumerable<PSADObject> adObjects, bool excludeAssignmentsForDeletedPrincipals)
        {
            var psPrincipals = new List<PSPrincipal>();
            foreach (var p in principals)
            {
                var pid = Guid.Parse(p.Id);
                if (pid == Guid.Empty)
                {
                    psPrincipals.Add(new PSPrincipal { DisplayName = AllPrincipals, ObjectType = SystemDefined, ObjectId = new Guid(p.Id) });
                }
                else
                {
                    var adObject = adObjects.SingleOrDefault(o => o.Id == pid.ToString()) ?? new PSADObject() { Id = pid.ToString() };

                    if ((adObject is PSADUser)
                        || (adObject is PSADGroup)
                        || (adObject is PSADServicePrincipal)
                        || !excludeAssignmentsForDeletedPrincipals)
                    {
                        psPrincipals.Add(new PSPrincipal { DisplayName = adObject.DisplayName, ObjectType = p.Type, ObjectId = new Guid(p.Id) });
                    }
                }
            }

            return psPrincipals;
        }

        private static IEnumerable<PSRoleAssignment> ToPSRoleAssignments(this IEnumerable<RoleAssignment> assignments, IEnumerable<PSRoleDefinition> roleDefinitions, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, bool excludeAssignmentsForDeletedPrincipals)
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
                PSADObject adObject = adObjects.SingleOrDefault(o => o.Id == assignment.PrincipalId) ??
                    new PSADObject() { Id = assignment.PrincipalId };
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
                        CanDelegate = delegationFlag,
                        ObjectType = DeletedObject
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
