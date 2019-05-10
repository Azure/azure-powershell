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
