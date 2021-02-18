using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using BandwidthSchedule = Microsoft.Azure.Management.DataBoxEdge.Models.BandwidthSchedule;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeBandWidthSchedule
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.bandwidthSchedule.Name", Position = 0)]
        [Ps1Xml(Label = "StartTime", Target = ViewControl.Table, ScriptBlock = "$_.bandwidthSchedule.Start")]
        [Ps1Xml(Label = "StopTime", Target = ViewControl.Table, ScriptBlock = "$_.bandwidthSchedule.Stop")]
        public BandwidthSchedule BandwidthSchedule;

        [Ps1Xml(Label = "RateInMbps", Target = ViewControl.Table,
            Position = 1)]
        public string RateInMbpsDisplay => this.BandwidthSchedule.RateInMbps == 0
            ? "Unlimited"
            : BandwidthSchedule.RateInMbps.ToString();


        [Ps1Xml(Label = "DaysOfWeek", Target = ViewControl.Table)]
        public string Days => string.Join(",", this.BandwidthSchedule.Days);

        public string Id;
        public string ResourceGroupName { get; set; }
        public string Name { get; set; }
        public string DeviceName { get; set; }


        public PSStackEdgeBandWidthSchedule()
        {
            BandwidthSchedule = new BandwidthSchedule();
        }

        public PSStackEdgeBandWidthSchedule(BandwidthSchedule bandwidthSchedule)
        {
            this.BandwidthSchedule = bandwidthSchedule ?? throw new ArgumentNullException("bandwidthSchedule");
            this.Id = bandwidthSchedule.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(bandwidthSchedule.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
        }
    }
}