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
using System.Collections;
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
        public const string UnknownType = "Unknown";

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
                    IsCustom = role.RoleType == CustomRole ? true : false,
                    Condition = (role.Permissions != null && role.Permissions.Count > 0) ? role.Permissions[0].Condition : null,
                    ConditionVersion = (role.Permissions != null && role.Permissions.Count > 0) ? role.Permissions[0].ConditionVersion : null
                };
            }

            return roleDefinition;
        }

        public static PSRoleAssignment ToPSRoleAssignment(this RoleAssignment assignment, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, string scopeForRoleDefinition = null)
        {
            PSRoleDefinition roleDefinition = null;
            PSADObject adObject = null;

            // Get role definition name information by role definition ID
            try
            {
                if (string.IsNullOrEmpty(scopeForRoleDefinition))
                {
                    roleDefinition = policyClient.GetRoleDefinition(assignment.RoleDefinitionId);
                }
                else
                {
                    roleDefinition = policyClient.GetRoleDefinition(assignment.RoleDefinitionId.GetGuidFromId(), scopeForRoleDefinition);
                }
            }
            catch (CloudException ce) when (ce.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //Swallow unauthorized errors on RoleDefinition when displaying RoleAssignments
            }

            // Get ab object
            try
            {
                adObject = activeDirectoryClient.GetObjectByObjectId(assignment.PrincipalId);
            }
            catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException oe)
            {
                if (oe.IsAuthorizationDeniedException() || oe.IsNotFoundException())
                {
                    adObject = new PSADObject() { Id = assignment.PrincipalId, Type = UnknownType};
                }
                //Swallow exceptions when displaying active directive object
            }

            return new PSRoleAssignment()
            {
                RoleAssignmentName = assignment.Name,
                RoleAssignmentId = assignment.Id,
                Scope = assignment.Scope,
                DisplayName = adObject?.DisplayName,
                SignInName = adObject is PSADUser user ? user.UserPrincipalName : null,
                RoleDefinitionName = roleDefinition?.Name,
                RoleDefinitionId = assignment.RoleDefinitionId.GuidFromFullyQualifiedId(),
                ObjectId = assignment.PrincipalId,
                // Use information from adObject first, assignment.PrincipalType is a cached information
                ObjectType = adObject?.Type ?? assignment.PrincipalType,
                // CanDelegate's value is absent from RoleAssignment
                // CanDelegate = null,
                Description = assignment.Description,
                ConditionVersion = assignment.ConditionVersion,
                Condition = assignment.Condition
            };
        }

        /// <summary>
        /// Convert classic administrator to PSRoleAssignment
        /// </summary>
        /// <param name="classicAdministrator">Current classic administrator</param>
        /// <param name="currentSubscriptionId">Current subscription id</param>
        /// <returns></returns>
        public static PSRoleAssignment ToPSRoleAssignment(this ClassicAdministrator classicAdministrator, string currentSubscriptionId)
        {
            return new PSRoleAssignment()
            {
                RoleDefinitionName = classicAdministrator.Role,
                DisplayName = classicAdministrator.EmailAddress,
                SignInName = classicAdministrator.EmailAddress,
                Scope = AuthorizationHelper.GetSubscriptionScope(currentSubscriptionId),
                ObjectType = classicAdministrator.Type ?? "User"
            };
        }

        /// <summary>
        /// Convert role assignments to PSRoleAssignments. To avoid too much 'Get' operation, list assignments in one query
        /// </summary>
        /// <param name="assignments"></param>
        /// <param name="policyClient"></param>
        /// <param name="activeDirectoryClient"></param>
        /// <param name="scopeForRoleDefinitions"></param>
        /// <returns></returns>
        public static IEnumerable<PSRoleAssignment> ToPSRoleAssignments(this IEnumerable<RoleAssignment> assignments, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient, string scopeForRoleDefinitions = null)
        {
            List<PSRoleAssignment> psAssignments = new List<PSRoleAssignment>();

            // The size of assignments is 0
            if (assignments == null || !assignments.Any())
            {
                return psAssignments;
            }

            // The size of assignments is 1
            if (assignments.Count() == 1)
            {
                // Get assignment
                psAssignments.Add(assignments.FirstOrDefault()?.ToPSRoleAssignment(policyClient, activeDirectoryClient, scopeForRoleDefinitions));
                return psAssignments;
            }

            // The size of assignments > 1
            // List role definitions first
            IEnumerable<PSRoleDefinition> roleDefinitions = null;
            try
            {
                roleDefinitions = policyClient.ListRoleDefinitionsForScope(scopeForRoleDefinitions);
            }
            catch (CloudException ce) when (ce.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Swallow 'Unauthorized' exception
                roleDefinitions = new List<PSRoleDefinition>();
            }

            // List ad objects
            List<string> objectIds = assignments.Select(r => r.PrincipalId).Distinct().ToList();
            List<PSADObject> adObjects = null;
            try
            {
                adObjects = GetAdObjectsByObjectIds(objectIds, activeDirectoryClient);
            }
            catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
            {
                // Swallow OdataErrorException
                adObjects = new List<PSADObject>();
            }

            // Union role definition and ad objects
            foreach (RoleAssignment assignment in assignments)
            {
                assignment.RoleDefinitionId = assignment.RoleDefinitionId.GuidFromFullyQualifiedId();
                PSADObject adObject = adObjects.SingleOrDefault(o => o.Id == assignment.PrincipalId) ?? new PSADObject() { Id = assignment.PrincipalId, Type = UnknownType };
                PSRoleDefinition roleDefinition = roleDefinitions.SingleOrDefault(r => r.Id == assignment.RoleDefinitionId) ?? new PSRoleDefinition() { Id = assignment.RoleDefinitionId };
                var psRoleAssignment = new PSRoleAssignment()
                {
                    RoleAssignmentName = assignment.Name,
                    RoleAssignmentId = assignment.Id,
                    DisplayName = adObject.DisplayName,
                    RoleDefinitionId = assignment.RoleDefinitionId,
                    RoleDefinitionName = roleDefinition.Name,
                    Scope = assignment.Scope,
                    ObjectId = assignment.PrincipalId,
                    // Use information from adObject first, assignment.PrincipalType is a cached information
                    ObjectType = adObject?.Type ?? assignment.PrincipalType,
                    Description = assignment.Description,
                    Condition = assignment.Condition,
                    ConditionVersion = assignment.ConditionVersion,
                };

                if (adObject is PSADUser user)
                {
                    psRoleAssignment.SignInName = user.UserPrincipalName;
                }
                psAssignments.Add(psRoleAssignment);
            }

            return psAssignments;
        }

        private static List<PSADObject> GetAdObjectsByObjectIds(List<string> objectIds, ActiveDirectoryClient activeDirectoryClient)
        {
            if (null == objectIds || 0 == objectIds.Count())
            {
                return new List<PSADObject>();
            }
            else if (1 == objectIds.Count())
            {
                return new List<PSADObject>() { activeDirectoryClient.GetObjectByObjectId(objectIds.FirstOrDefault()) };
            }else
            {
                return activeDirectoryClient.GetObjectsByObjectIds(objectIds);
            }
        }

        private static IEnumerable<PSPrincipal> ToPSPrincipals(this IEnumerable<Principal> principals, IEnumerable<PSADObject> adObjects)
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
                    var adObject = adObjects.SingleOrDefault(o => o.Id == pid.ToString()) ?? new PSADObject() { Id = pid.ToString()};
                    psPrincipals.Add(new PSPrincipal { DisplayName = adObject?.DisplayName, ObjectType = p.Type, ObjectId = new Guid(p.Id) });
                }
            }
            return psPrincipals;
        }

        public static PSDenyAssignment ToPSDenyAssignment(this DenyAssignment assignment, ActiveDirectoryClient activeDirectoryClient)
        {
            var psda = new PSDenyAssignment()
            {
                Id = assignment.Id,
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

            // Get principals' information in one query
            var objectIds = assignment.Principals.Where(p => Guid.Parse(p.Id) != Guid.Empty).Select(p => p.Id).ToList();
            objectIds.AddRange(assignment.ExcludePrincipals.Where(ep => Guid.Parse(ep.Id) != Guid.Empty).Select(ep => ep.Id));
            objectIds = objectIds.Distinct().ToList();
            List<PSADObject> adObjects = null;

            try
            {
                adObjects = GetAdObjectsByObjectIds(objectIds, activeDirectoryClient);
            }
            catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
            {
                // Swallow OdataErrorException
                adObjects = new List<PSADObject>();
            }

            psda.Principals = assignment.Principals.ToPSPrincipals(adObjects).ToList();
            psda.ExcludePrincipals = assignment.ExcludePrincipals.ToPSPrincipals(adObjects).ToList();

            return psda;
        }

        public static IEnumerable<PSDenyAssignment> ToPSDenyAssignments(this IEnumerable<DenyAssignment> assignments, ActiveDirectoryClient activeDirectoryClient)
        {
            var psAssignments = new List<PSDenyAssignment>();
            if (assignments == null || !assignments.Any())
            {
                return psAssignments;
            }

            if (assignments.Count() == 1)
            {
                // Get assignment
                psAssignments.Add(assignments.FirstOrDefault()?.ToPSDenyAssignment(activeDirectoryClient));
                return psAssignments;
            }

            // Get principals' information in one query
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
                adObjects = GetAdObjectsByObjectIds(objectIds, activeDirectoryClient);
            }
            catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
            {
                // Swallow OdataErrorException
                adObjects = new List<PSADObject>();
            }

            foreach (var da in assignments)
            {
                var psda = new PSDenyAssignment()
                {
                    Id = da.Id,
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

                psda.Principals = da.Principals.ToPSPrincipals(adObjects).ToList();
                psda.ExcludePrincipals = da.ExcludePrincipals.ToPSPrincipals(adObjects).ToList();

                psAssignments.Add(psda);
            }

            return psAssignments;
        }
    }
}
