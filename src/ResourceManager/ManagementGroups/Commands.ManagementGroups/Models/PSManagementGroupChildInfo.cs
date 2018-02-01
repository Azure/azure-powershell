using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupChildInfo
    {
        public string ChildType { get; set; }
        public string DisplayName { get; set; }
        public string ChildId { get; set; }

        public IList<PSManagementGroupChildInfo> Children { get; set; }

        public PSManagementGroupChildInfo()
        {

        }

        public PSManagementGroupChildInfo(ManagementGroupChildInfo childInfo)
        {
            if (childInfo != null)
            {
                this.ChildType = childInfo.ChildType;
                this.DisplayName = childInfo.DisplayName;
                this.ChildId = childInfo.ChildId;
                if (childInfo.Children != null)
                {
                    this.Children = childInfo.Children.Select(child => new PSManagementGroupChildInfo(child)).ToList();
                }
            }
        }
    }
}