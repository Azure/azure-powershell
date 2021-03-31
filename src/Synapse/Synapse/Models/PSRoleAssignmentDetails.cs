using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public string RoleAssignmentId { get; set; }

        public string RoleDefinitionId { get; set; }

        public string ObjectId { get; set; }

        public string Scope { get; set; }
    }
}
