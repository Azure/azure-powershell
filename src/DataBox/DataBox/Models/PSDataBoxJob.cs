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
        [Ps1Xml(Label = "JobResource.Name", Target = ViewControl.Table, ScriptBlock = "$_.JobResource.Name")]
        [Ps1Xml(Label = "JobResource.Sku.Name", Target = ViewControl.Table, ScriptBlock = "$_.JobResource.Sku.Name")]
        [Ps1Xml(Label = "JobResource.Status", Target = ViewControl.Table, ScriptBlock = "$_.JobResource.Status")]
        [Ps1Xml(Label = "JobResource.StartTime", Target = ViewControl.Table, ScriptBlock = "$_.JobResource.StartTime")]
        [Ps1Xml(Label = "JobResource.Location", Target = ViewControl.Table, ScriptBlock = "$_.JobResource.Location")]
        public JobResource JobResource;

        [Ps1Xml(Label = "ResourceGroup", Target = ViewControl.Table)]
        public string ResourceGroup;

        public string Id;

        public PSDataBoxJob()
        {
            JobResource = new JobResource();
        }
        
        public PSDataBoxJob(JobResource jobResource)
        {
            if (jobResource == null)
            {
                throw new ArgumentNullException("jobResource");
            }

            this.JobResource = jobResource;
            this.ResourceGroup = ResourceIdHandler.GetResourceGroupName(jobResource.Id);
            this.Id = jobResource.Id;
        }
    }
}
