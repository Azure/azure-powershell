using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeJob
    {
        [Ps1Xml(Label = "Type", Target = ViewControl.Table, ScriptBlock = "$_.job.JobType", Position = 3)]
        [Ps1Xml(Label = "Status", Target = ViewControl.Table, ScriptBlock = "$_.job.Status", Position = 4)]
        [Ps1Xml(Label = "CurrentStage", Target = ViewControl.Table, ScriptBlock = "$_.job.CurrentStage", Position = 5)]
        public Job Job;

        public string Id;
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name;
        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 1)]
        public string DeviceName;
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 2)]
        public string ResourceGroupName;

        public PSStackEdgeJob()
        {
            Job = new Job();
        }

        public PSStackEdgeJob(Job job)
        {
            this.Job = job ?? throw new ArgumentNullException("job");
            this.Id = job.Id;
            var dataBoxResourceIdentifier = new StackEdgeResourceIdentifier(this.Id);
            this.Name = dataBoxResourceIdentifier.Name;
            this.DeviceName = dataBoxResourceIdentifier.DeviceName;
            this.ResourceGroupName = dataBoxResourceIdentifier.ResourceGroupName;
        }
    }
}