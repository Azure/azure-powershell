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

using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Management.Authorization.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    internal static class AuthorizationClientExtensions
    {
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
                    Id = role.Id
                };
            }

            return roleDefinition;
        }

        public static PSRoleAssignment ToPSRoleAssignment(this RoleAssignment role, AuthorizationClient policyClient, ActiveDirectoryClient activeDirectoryClient)
        {
            PSRoleDefinition roleDefinition = policyClient.GetRoleDefinition(role.Properties.RoleDefinitionId);
            PSADObject adObject = activeDirectoryClient.GetADObject(new ADObjectFilterOptions { Id = role.Properties.PrincipalId.ToString() }) ?? new PSADObject() { Id = role.Properties.PrincipalId };

            if (adObject is PSADUser)
            {
                return new PSUserRoleAssignment()
                {
                    RoleAssignmentId = role.Id,
                    DisplayName = adObject.DisplayName,
                    Actions = roleDefinition.Actions,
                    NotActions = roleDefinition.NotActions,
                    RoleDefinitionName = roleDefinition.Name,
                    Scope = role.Properties.Scope,
                    UserPrincipalName = ((PSADUser)adObject).UserPrincipalName,
                    Mail = ((PSADUser)adObject).Mail,
                    ObjectId = adObject.Id
                };
            }
            else if (adObject is PSADGroup)
            {
                return new PSGroupRoleAssignment()
                {
                    RoleAssignmentId = role.Id,
                    DisplayName = adObject.DisplayName,
                    Actions = roleDefinition.Actions,
                    NotActions = roleDefinition.NotActions,
                    RoleDefinitionName = roleDefinition.Name,
                    Scope = role.Properties.Scope,
                    Mail = ((PSADGroup)adObject).Mail,
                    ObjectId = adObject.Id
                };
            }
            else if (adObject is PSADServicePrincipal)
            {
                return new PSServiceRoleAssignment()
                {
                    RoleAssignmentId = role.Id,
                    DisplayName = adObject.DisplayName,
                    Actions = roleDefinition.Actions,
                    NotActions = roleDefinition.NotActions,
                    RoleDefinitionName = roleDefinition.Name,
                    Scope = role.Properties.Scope,
                    ServicePrincipalName = ((PSADServicePrincipal)adObject).ServicePrincipalName,
                    ObjectId = adObject.Id
                };
            }
            else
            {
                return new PSRoleAssignment()
                {
                    RoleAssignmentId = role.Id,
                    DisplayName = adObject.DisplayName,
                    Actions = roleDefinition.Actions,
                    NotActions = roleDefinition.NotActions,
                    RoleDefinitionName = roleDefinition.Name,
                    Scope = role.Properties.Scope,
                    ObjectId = adObject.Id
                };
            }
        }
    }
}
