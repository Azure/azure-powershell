using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupInfo
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public PSManagementGroupInfo()
        {
        }

        public PSManagementGroupInfo(ManagementGroupInfo managementGroupInfo)
        {
            if (managementGroupInfo != null)
            {
                Id = managementGroupInfo.Id;
                Type = managementGroupInfo.Type;
                Name = managementGroupInfo.Name;
                TenantId = managementGroupInfo.TenantId;
                DisplayName = managementGroupInfo.DisplayName;
            }
        }
    }
}