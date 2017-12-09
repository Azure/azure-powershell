using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupChildInfo
    {
        public string ChildType { get; set; }

        public string ChildId { get; set; }

        public string DisplayName { get; set; }

        public System.Guid? TenantId { get; set; }

        public IList<PSManagementGroupChildInfo> Children { get; set; }

        public PSManagementGroupChildInfo()
        {

        }

        public PSManagementGroupChildInfo(ManagementGroupChildInfo childInfo)
        {
            if (childInfo != null)
            {
                this.ChildType = childInfo.ChildType;
                this.ChildId = childInfo.ChildId;
                this.DisplayName = childInfo.DisplayName;
                this.TenantId = childInfo.TenantId;
                if (childInfo.Children != null)
                {
                    this.Children = childInfo.Children.Select(child => new PSManagementGroupChildInfo(child)).ToList();
                }
            }
        }
    }
}