using System;
using Microsoft.Azure.Management.ManagementGroups.Models;
namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupInfoProperties
    {
        public Guid? TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public PSManagementGroupDetails Details { get; private set; }

        public PSManagementGroupInfoProperties()
        {

        }

        public PSManagementGroupInfoProperties(ManagementGroupInfoProperties managementGroupProperties)
        {
            this.TenantId = managementGroupProperties.TenantId;
            this.DisplayName = managementGroupProperties.DisplayName;
        }
    }
}