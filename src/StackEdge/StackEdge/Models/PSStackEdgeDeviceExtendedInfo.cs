using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using StackEdgeDeviceExtendedInfo = Microsoft.Azure.Management.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeDeviceExtendedInfo
    {
        [Ps1Xml(Label = "EncryptedCIK Thumbprint", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDeviceExtendedInfo.EncryptionKeyThumbprint")]
        [Ps1Xml(Label = "ResourceKey", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDeviceExtendedInfo.ResourceKey")]
        public StackEdgeDeviceExtendedInfo StackEdgeDeviceExtendedInfo;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 2, GroupByThis = false)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 1)]
        public string DeviceName;

        public string Name;

        public string ResourceKey;

        public string Id;
        [Ps1Xml(Label = "EncryptedCIK", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDeviceExtendedInfo.EncryptionKey")]
        public string EncryptionKey;

        public PSStackEdgeDeviceExtendedInfo()
        {
            StackEdgeDeviceExtendedInfo = new StackEdgeDeviceExtendedInfo();
        }

        public PSStackEdgeDeviceExtendedInfo(StackEdgeDeviceExtendedInfo stackEdgeDeviceExtendedInfo)
        {
            this.StackEdgeDeviceExtendedInfo = stackEdgeDeviceExtendedInfo ??
                                                 throw new ArgumentNullException("stackEdgeDeviceExtendedInfo");
            this.Id = StackEdgeDeviceExtendedInfo.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(stackEdgeDeviceExtendedInfo.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.DeviceName;
            this.EncryptionKey = StackEdgeDeviceExtendedInfo.EncryptionKey;
            this.ResourceKey = StackEdgeDeviceExtendedInfo.ResourceKey;
        }
    }
}