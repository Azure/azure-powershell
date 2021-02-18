using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using UpdateSummary = Microsoft.Azure.Management.DataBoxEdge.Models.UpdateSummary;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeUpdateSummary
    {
        [Ps1Xml(Label = "Current Version", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.DeviceVersionNumber", Position = 1)]
        [Ps1Xml(Label = "Friendly name", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.FriendlyDeviceVersionName", Position = 2)]
        [Ps1Xml(Label = "Last Software Scan", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.LastCompletedScanJobDateTime", Position = 3)]
        [Ps1Xml(Label = "Last Software Update", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.LastCompletedInstallJobDateTime", Position = 4)]
        [Ps1Xml(Label = "Pending Updates", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.TotalNumberOfUpdatesAvailable", Position = 5)]
        [Ps1Xml(Label = "Pending Update Titles", Target = ViewControl.Table,
            ScriptBlock = "$_.updateSummary.UpdateTitles", Position = 6)]

        public UpdateSummary UpdateSummary;

        public string ResourceGroupName { get; set; }

        public string Name;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 0)]
        public string DeviceName;

        public string Id;

        public PSStackEdgeUpdateSummary()
        {
            UpdateSummary = new UpdateSummary();
        }

        public PSStackEdgeUpdateSummary(UpdateSummary updateSummary)
        {
            if (updateSummary == null)
            {
                throw new ArgumentNullException(nameof(updateSummary));
            }

            this.UpdateSummary = updateSummary;
            this.Id = UpdateSummary.Id;
            var stackEdgeResourceIdentifier = new StackEdgeResourceIdentifier(UpdateSummary.Id);
            this.ResourceGroupName = stackEdgeResourceIdentifier.ResourceGroupName;
            this.DeviceName = stackEdgeResourceIdentifier.DeviceName;
            this.Name = stackEdgeResourceIdentifier.Name;
        }
    }

}