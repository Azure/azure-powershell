using Azure.Analytics.Synapse.AccessControl.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRoleAssignmentDetails
    {
        public PSRoleAssignmentDetails(RoleAssignmentDetails roleAssignmentDetails)
        {
            this.RoleAssignmentId = roleAssignmentDetails.Id;
            this.RoleDefinitionId = roleAssignmentDetails.RoleDefinitionId?.ToString();
            this.ObjectId = roleAssignmentDetails.PrincipalId?.ToString();
            this.Scope = roleAssignmentDetails.Scope;
            this.principalType = roleAssignmentDetails.PrincipalType;
        }

        public string RoleAssignmentId { get; set; }

        public string RoleDefinitionId { get; set; }

        public string ObjectId { get; set; }

        public string Scope { get; set; }

        public string principalType { get; set; }
    }
}
