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
            this.RoleDefinitionId = roleAssignmentDetails.RoleId;
            this.ObjectId = roleAssignmentDetails.PrincipalId;
        }

        public string RoleAssignmentId { get; set; }

        public string RoleDefinitionId { get; set; }

        public string ObjectId { get; set; }
    }
}
