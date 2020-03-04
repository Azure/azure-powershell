using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using EdgeDevice = Microsoft.Azure.Management.DataBoxEdge.Models.DataBoxEdgeDevice;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeDevice
    {
        [Ps1Xml(Label = "Model", Target = ViewControl.Table,
            ScriptBlock = "$_.edgeDevice.Sku.Name", Position = 2)]
        [Ps1Xml(Label = "Location", Target = ViewControl.Table,
            ScriptBlock = "$_.edgeDevice.Location", Position = 4)]
        public EdgeDevice EdgeDevice;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 3, GroupByThis = false)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name;

        public string Id;

        public PSStackEdgeDeviceExtendedInfo ExtendedInfo;
        public PSStackEdgeUpdateSummary UpdateSummary;
        public List<PSStackEdgeAlert> Alert;
        public IList<PSStackEdgeNetworkAdapter> NetworkSetting;

        public PSStackEdgeDevice()
        {
            EdgeDevice = new EdgeDevice();
        }

        public PSStackEdgeDevice(EdgeDevice edgeDevice)
        {
            if (edgeDevice == null)
            {
                throw new ArgumentNullException("edgeDevice");
            }

            this.EdgeDevice = edgeDevice;
            this.Id = edgeDevice.Id;
            var stackEdgeResourceIdentifier = new StackEdgeResourceIdentifier(edgeDevice.Id);
            this.ResourceGroupName = stackEdgeResourceIdentifier.ResourceGroupName;
            this.Name = stackEdgeResourceIdentifier.Name;
            
        }
    }
}