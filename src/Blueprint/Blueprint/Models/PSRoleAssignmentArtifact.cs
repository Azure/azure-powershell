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

using Microsoft.Azure.Management.Blueprint.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSRoleAssignmentArtifact : PSArtifact
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> DependsOn { get; set; }
        public string RoleDefinitionId { get; set; }
        public object PrincipleIds { get; set; }
        public string ResourceGroup { get; set; }

        internal static PSRoleAssignmentArtifact FromArtifactModel(RoleAssignmentArtifact artifact, string scope)
        {
            var psArtifact = new PSRoleAssignmentArtifact
            {
                Id = artifact.Id,
                Type = artifact.Type,
                Name = artifact.Name,
                DisplayName = artifact.DisplayName,
                Description = artifact.Description,
                RoleDefinitionId = artifact.RoleDefinitionId,
                DependsOn = new List<string>(),
                PrincipleIds = artifact.PrincipalIds, 
                ResourceGroup = artifact.ResourceGroup
            };

            psArtifact.DependsOn = artifact.DependsOn.Select(x => x) as List<string>;

            return psArtifact;
        }
    }
}
