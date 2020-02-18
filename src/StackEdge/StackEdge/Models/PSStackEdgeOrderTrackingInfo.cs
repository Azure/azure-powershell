using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using StackEdgeTrackingInfo = Microsoft.Azure.Management.DataBoxEdge.Models.TrackingInfo;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeOrderTrackingInfo
    {
        [Ps1Xml(Label = "CarrierName", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDevice.CarrierName", Position = 0)]
        [Ps1Xml(Label = "SerialNumber", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDevice.SerialNumber", Position = 1)]
        [Ps1Xml(Label = "TrackingUrl", Target = ViewControl.Table,
            ScriptBlock = "$_.stackEdgeDevice.TrackingUrl", Position = 2)]
        public StackEdgeTrackingInfo StackEdgeTrackingInfo;

        public string Id;

        public PSStackEdgeOrderTrackingInfo()
        {
            StackEdgeTrackingInfo = new StackEdgeTrackingInfo();
        } 

        public PSStackEdgeOrderTrackingInfo(StackEdgeTrackingInfo stackEdgeTrackingInfo)
        {
            if (stackEdgeTrackingInfo == null)
            {
                throw new ArgumentNullException("stackEdgeTrackingInfo");
            }

            this.StackEdgeTrackingInfo = stackEdgeTrackingInfo;
        }
    }
}