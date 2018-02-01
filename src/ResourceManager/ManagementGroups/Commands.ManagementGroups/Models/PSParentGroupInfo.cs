using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSParentGroupInfo
    {
        public string ParentId { get; set; }

        public string DisplayName { get; set; }

        public PSParentGroupInfo()
        {
            
        }

        public PSParentGroupInfo(ParentGroupInfo parentGroupInfo)
        {
            if (parentGroupInfo != null)
            {
                this.ParentId = parentGroupInfo.ParentId;
                this.DisplayName = parentGroupInfo.DisplayName;
            }
        }
    }
}