using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ManagementGroups.Models;

namespace Microsoft.Azure.Commands.ManagementGroups.Models
{
    public class PSManagementGroupProperties
    {
        public Guid? TenantId { get; private set; }

        public string DisplayName { get; private set; }

        public PSManagementGroupDetails Details { get; private set; }

        public IList<PSManagementGroupChildInfo> Children { get; private set; }

        public PSManagementGroupProperties()
        {

        }

        public PSManagementGroupProperties(ManagementGroupProperties managementGroupProperties)
        {
            this.TenantId = managementGroupProperties.TenantId;
            this.DisplayName = managementGroupProperties.DisplayName;
            this.Details = new PSManagementGroupDetails(managementGroupProperties.Details);
            if (managementGroupProperties.Children != null)
            {
                this.Children = managementGroupProperties.Children.Select(child => new PSManagementGroupChildInfo(child)).ToList();
            }
        }
    }
}