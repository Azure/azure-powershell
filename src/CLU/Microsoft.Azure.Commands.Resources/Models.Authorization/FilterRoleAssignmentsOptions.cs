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

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class FilterRoleAssignmentsOptions
    {
        public string RoleDefinitionName { get; set; }

        /// <summary>
        /// RoleDefinitionId Guid
        /// </summary>
        public string RoleDefinitionId { get; set; }

        private string scope;

        public string Scope
        {
            get
            {
                string result;
                string resourceIdentifier = ResourceIdentifier.ToString();

                if (!string.IsNullOrEmpty(scope))
                {
                    result = scope;
                }
                else if (!string.IsNullOrEmpty(resourceIdentifier))
                {
                    result = resourceIdentifier;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            set
            {
                scope = value;
            }
        }

        public ResourceIdentifier ResourceIdentifier { get; set; }

        public ADObjectFilterOptions ADObjectFilter { get; set; }

        public bool ExpandPrincipalGroups { get; set; }

        public bool IncludeClassicAdministrators { get; set; }

        public bool ExcludeAssignmentsForDeletedPrincipals { get; set; }
    }
}