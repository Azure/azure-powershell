using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Alert = Microsoft.Azure.Management.DataBoxEdge.Models.Alert;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeAlert
    {
        [Ps1Xml(Label = "Title", Target = ViewControl.Table, ScriptBlock = "$_.alert.Title", Position = 0)]
        [Ps1Xml(Label = "Recommendation", Target = ViewControl.Table, ScriptBlock = "$_.alert.Recommendation", Position = 3)]
        public Alert Alert;

        [Ps1Xml(Label = "AppearedDateTime", Target = ViewControl.Table,
            Position = 2)]
        public DateTime? AppearedDateTime;

        [Ps1Xml(Label = "Severity", Target = ViewControl.Table, Position = 1)]
        public string Severity;
        public string Id;
        public string Name;
        public string DeviceName;
        public string ResourceGroupName;
        public IDictionary<string, string> DetailedInformation;

        public PSStackEdgeAlert()
        {
            Alert = new Alert();
        }

        public PSStackEdgeAlert(Alert alert)
        {
            this.Alert = alert ?? throw new ArgumentNullException("alert");
            this.Id = alert.Id;
            var dataBoxResourceIdentifier = new StackEdgeResourceIdentifier(this.Id);
            this.Name = dataBoxResourceIdentifier.Name;
            this.DeviceName = dataBoxResourceIdentifier.DeviceName;
            this.ResourceGroupName = dataBoxResourceIdentifier.ResourceGroupName;
            this.DetailedInformation = alert.DetailedInformation;
            this.AppearedDateTime = alert.AppearedAtDateTime;
            this.Severity = alert.Severity;
        }
    }
}