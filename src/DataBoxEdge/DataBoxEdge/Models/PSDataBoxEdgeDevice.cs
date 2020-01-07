using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using DataBoxEdgeDevice = Microsoft.Azure.Management.DataBoxEdge.Models.DataBoxEdgeDevice;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeDevice
    {
        [Ps1Xml(Label = "Model", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeDevice.Sku.Name", Position = 2)]
        [Ps1Xml(Label = "Location", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeDevice.Location", Position = 4)]
        public DataBoxEdgeDevice DataBoxEdgeDevice;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 3, GroupByThis = false)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name;

        public string Id;

        public PSDataBoxEdgeDevice()
        {
            DataBoxEdgeDevice = new DataBoxEdgeDevice();
        }

        public PSDataBoxEdgeDevice(DataBoxEdgeDevice dataBoxEdgeDevice)
        {
            if (dataBoxEdgeDevice == null)
            {
                throw new ArgumentNullException("dataBoxEdgeDevice");
            }

            this.DataBoxEdgeDevice = dataBoxEdgeDevice;
            this.Id = dataBoxEdgeDevice.Id;
            var dataBoxEdgeResourceIdentifier = new DataBoxEdgeResourceIdentifier(dataBoxEdgeDevice.Id);
            this.ResourceGroupName = dataBoxEdgeResourceIdentifier.ResourceGroupName;
            this.Name = dataBoxEdgeResourceIdentifier.Name;
            
        }
    }
}