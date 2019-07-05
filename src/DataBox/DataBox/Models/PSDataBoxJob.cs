using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.Azure.Commands.DataBox.Common;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models
{
    public class PSDataBoxJob
    {
        [Ps1Xml(Label = "jobResource.Name", Target = ViewControl.Table, ScriptBlock = "$_.jobResource.Name")]
        [Ps1Xml(Label = "jobResource.Sku.Name", Target = ViewControl.Table, ScriptBlock = "$_.jobResource.Sku.Name")]
        [Ps1Xml(Label = "jobResource.Status", Target = ViewControl.Table, ScriptBlock = "$_.jobResource.Status")]
        [Ps1Xml(Label = "jobResource.StartTime", Target = ViewControl.Table, ScriptBlock = "$_.jobResource.StartTime")]
        [Ps1Xml(Label = "jobResource.Location", Target = ViewControl.Table, ScriptBlock = "$_.jobResource.Location")]
        public JobResource jobResource;

        [Ps1Xml(Label = "ResourceGroup", Target = ViewControl.Table)]
        public string ResourceGroup;

        public string Id;

        public PSDataBoxJob()
        {
            jobResource = new JobResource();
        }
        
        public PSDataBoxJob(JobResource jobResource)
        {
            if (jobResource == null)
            {
                throw new ArgumentNullException("jobResource");
            }

            this.jobResource = jobResource;
            this.ResourceGroup = ResourceIdHandler.GetResourceGroupName(jobResource.Id);
            this.Id = jobResource.Id;
        }
    }
}
