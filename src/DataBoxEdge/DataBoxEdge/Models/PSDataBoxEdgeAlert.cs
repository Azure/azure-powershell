﻿using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Alert = Microsoft.Azure.Management.EdgeGateway.Models.Alert;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeAlert
    {
        [Ps1Xml(Label = "Title", Target = ViewControl.Table, ScriptBlock = "$_.alert.Title", Position = 0)]
        public Alert Alert;

        [Ps1Xml(Label = "AppearedDateTime", Target = ViewControl.Table,
            Position = 2)]
        public DateTime? ApeearedDateTime;

        [Ps1Xml(Label = "Severity", Target = ViewControl.Table, Position = 1)]
        public string Severity;
        public string Id;
        public string Name;
        public string DeviceName;
        public string ResourceGroupName;
        public IDictionary<string, string> DetailedInformation;

        public PSDataBoxEdgeAlert()
        {
            Alert = new Alert();
        }

        public PSDataBoxEdgeAlert(Alert alert)
        {
            this.Alert = alert ?? throw new ArgumentNullException("alert");
            this.Id = alert.Id;
            var dataBoxResourceIdentifier = new DataBoxEdgeResourceIdentifier(this.Id);
            this.Name = dataBoxResourceIdentifier.Name;
            this.DeviceName = dataBoxResourceIdentifier.DeviceName;
            this.ResourceGroupName = dataBoxResourceIdentifier.ResourceGroupName;
            this.DetailedInformation = alert.DetailedInformation;
            this.ApeearedDateTime = alert.AppearedAtDateTime;
            this.Severity = alert.Severity;
        }
    }
}