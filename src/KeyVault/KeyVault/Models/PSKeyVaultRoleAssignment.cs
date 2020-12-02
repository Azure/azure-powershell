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

using Azure.Security.KeyVault.Administration.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultRoleAssignment
    {
        //
        // Summary:
        //     The role assignment ID.
        public string Id { get; }
        //
        // Summary:
        //     The role assignment name.
        public string Name { get; }
        //
        // Summary:
        //     The role assignment type.
        public string Type { get; }
        //
        // Summary:
        //     The role assignment scope.
        public string Scope { get; }
        //
        // Summary:
        //     The role definition ID.
        public string RoleDefinitionId { get; }
        //
        // Summary:
        //     The principal ID.
        public string PrincipalId { get; }

        /// <summary>
        /// Name of the HSM where the role assignment belongs to.
        /// Note: hsm name is not included in the service's respones;
        /// It is added to support powershell piping;
        /// It needs to be maintained by client-side code.
        /// </summary>
        public string HsmName { get; private set; }

        /// <summary>
        /// Display name of the principal.
        /// </summary>
        public string DisplayName { get; internal set; }

        /// <summary>
        /// Type of the principal, e.g. User / Service Principal / Group.
        /// </summary>
        public string ObjectType { get; internal set; }

        /// <summary>
        /// Display name of the role definition.
        /// </summary>
        public string RoleDefinitionName { get; internal set; }

        public PSKeyVaultRoleAssignment(KeyVaultRoleAssignment roleAssignment, string hsmName)
        {
            Id = roleAssignment.Id;
            Name = roleAssignment.Name;
            Type = roleAssignment.Type;
            Scope = roleAssignment.Properties.Scope;
            RoleDefinitionId = roleAssignment.Properties.RoleDefinitionId;
            PrincipalId = roleAssignment.Properties.PrincipalId;
            HsmName = hsmName;
        }
    }
}