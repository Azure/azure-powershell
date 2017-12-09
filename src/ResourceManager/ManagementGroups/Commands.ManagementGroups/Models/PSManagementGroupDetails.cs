using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupDetails
    {
        public double? Version { get; set; }

        public System.DateTime? UpdatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public PSParentGroupInfo Parent { get; set; }

        public PSManagementGroupDetails()
        {
            
        }

        public PSManagementGroupDetails(ManagementGroupDetails details)
        {
            if (details != null)
            {
                this.Version = details.Version;
                this.UpdatedTime = details.UpdatedTime;
                this.UpdatedBy = details.UpdatedBy;
                this.Parent = new PSParentGroupInfo(details.Parent);
            }
        }

    }
}