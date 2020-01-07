using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using DataBoxEdgeTrackingInfo = Microsoft.Azure.Management.DataBoxEdge.Models.TrackingInfo;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeOrderTrackingInfo
    {
        [Ps1Xml(Label = "CarrierName", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeDevice.CarrierName", Position = 0)]
        [Ps1Xml(Label = "SerialNumber", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeDevice.SerialNumber", Position = 1)]
        [Ps1Xml(Label = "TrackingUrl", Target = ViewControl.Table,
            ScriptBlock = "$_.dataBoxEdgeDevice.TrackingUrl", Position = 2)]
        public DataBoxEdgeTrackingInfo DataBoxEdgeTrackingInfo;

        public string Id;

        public PSDataBoxEdgeOrderTrackingInfo()
        {
            DataBoxEdgeTrackingInfo = new DataBoxEdgeTrackingInfo();
        } 

        public PSDataBoxEdgeOrderTrackingInfo(DataBoxEdgeTrackingInfo dataBoxEdgeTrackingInfo)
        {
            if (dataBoxEdgeTrackingInfo == null)
            {
                throw new ArgumentNullException("dataBoxEdgeTrackingInfo");
            }

            this.DataBoxEdgeTrackingInfo = dataBoxEdgeTrackingInfo;
        }
    }
}