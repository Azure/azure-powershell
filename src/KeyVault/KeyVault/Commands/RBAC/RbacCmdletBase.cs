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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    public class RbacCmdletBase : KeyVaultCmdletBase
    {
        private ActiveDirectoryClient _activeDirectoryClient;

        protected ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {
                if (_activeDirectoryClient != null) return _activeDirectoryClient;
                try
                {
                    _activeDirectoryClient = new ActiveDirectoryClient(DefaultProfile.DefaultContext);
                }
                catch
                {
                    _activeDirectoryClient = null;
                }
                return _activeDirectoryClient;
            }

            set { _activeDirectoryClient = value; }
        }

        internal static class ParameterSet
        {
            public const string DefinitionIdObjectId = "DefinitionIdObjectId";
            public const string DefinitionIdSignInName = "DefinitionIdSignInName";
            public const string DefinitionIdApplicationId = "DefinitionIdApplicationId";
            public const string DefinitionNameObjectId = "DefinitionNameObjectId";
            public const string DefinitionNameSignInName = "DefinitionNameSignInName";
            public const string DefinitionNameApplicationId = "DefinitionNameApplicationId";
            public const string InputObject = "InputObject";
            public const string RoleAssignmentName = "AssignmentName";
        }

        /// <summary>
        /// Get details of the role assignment -- principal name, role definition name, etc.,
        /// and assign them back in the role assignment object.
        /// </summary>
        /// <param name="assignment"></param>
        protected void GetAssignmentDetails(PSKeyVaultRoleAssignment assignment, string hsmName, string scope)
        {
            // get all role definition
            var definitions = Track2DataClient.GetHsmRoleDefinitions(hsmName, scope);

            // get info about assignee
            var assignee = ModelExtensions.GetDetailsFromADObjectId(assignment.PrincipalId, ActiveDirectoryClient);
            (assignment.DisplayName, assignment.ObjectType) = assignee;

            // traverse role definitions to find the correct one
            assignment.RoleDefinitionName = definitions
                .FirstOrDefault(definition => string.Equals(definition.Id, assignment.RoleDefinitionId, StringComparison.OrdinalIgnoreCase))
                ?.RoleName;
        }
    }
}
