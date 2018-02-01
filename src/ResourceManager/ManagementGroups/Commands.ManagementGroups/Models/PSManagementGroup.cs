using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroup
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public System.DateTime? UpdatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public string ParentId { get; set; }

        public string ParentDisplayName { get; set; }

        public IList<PSManagementGroupChildInfo> Children { get; private set; }


        public PSManagementGroup()
        {
        }

        public PSManagementGroup(ManagementGroup managementGroup)
        {
            if (managementGroup != null)
            {
                Id = managementGroup.Id;
                Type = managementGroup.Type;
                Name = managementGroup.Name;
                TenantId = managementGroup.TenantId;
                DisplayName = managementGroup.DisplayName;
                UpdatedTime = managementGroup.Details.UpdatedTime;
                UpdatedBy = managementGroup.Details.UpdatedBy;
                ParentId = managementGroup.Details.Parent.ParentId;
                ParentDisplayName = managementGroup.Details.Parent.DisplayName;
                if (managementGroup.Children != null)
                {
                    this.Children = managementGroup.Children.Select(child => new PSManagementGroupChildInfo(child)).ToList();
                }
            }
        }
    }
}
