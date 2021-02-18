using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Role = Microsoft.Azure.Management.DataBoxEdge.Models.Role;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeRole
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table,
            ScriptBlock = "$_.role.Name")]
        [Ps1Xml(Label = "IoTHostHub", Target = ViewControl.Table,
            ScriptBlock = "$_.role.IoTDeviceDetails.IoTHostHub")]
        [Ps1Xml(Label = "Platform", Target = ViewControl.Table,
            ScriptBlock = "$_.role.HostPlatform")]
        [Ps1Xml(Label = "Status", Target = ViewControl.Table,
            ScriptBlock = "$_.role.RoleStatus")]
        [Ps1Xml(Label = "IotEdgeDeviceId", Target = ViewControl.Table,
            ScriptBlock = "$_.role.IoTEdgeDeviceDetails.DeviceId")]
        [Ps1Xml(Label = "IotDeviceId", Target = ViewControl.Table,
            ScriptBlock = "$_.role.IoTDeviceDetails.DeviceId")]
        public Role Role;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table)]
        public string ResourceGroupName;

        public string DeviceName { get; set; }

        public string Id;
        public string Name;

        public PSDataBoxEdgeRole()
        {
            Role = new Role();
        }

        public PSDataBoxEdgeRole(Role role)
        {
            this.Role = role ?? throw new ArgumentNullException("role");
            this.Id = role.Id;
            var resourceIdentifier = new DataBoxEdgeResourceIdentifier(role.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
        }
    }
}