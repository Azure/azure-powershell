using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupInfo
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public PSManagementGroupInfoProperties Properties { get; private set; }

        public PSManagementGroupInfo()
        {
        }

        public PSManagementGroupInfo(ManagementGroupInfo managementGroup)
        {
            if (managementGroup != null)
            {
                Id = managementGroup.Id;
                Type = managementGroup.Type;
                Name = managementGroup.Name;
                Properties = new PSManagementGroupInfoProperties(managementGroup.Properties);
            }
        }
    }
}