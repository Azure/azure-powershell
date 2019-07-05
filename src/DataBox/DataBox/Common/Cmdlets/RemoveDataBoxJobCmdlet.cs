using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob", SupportsShouldProcess = true , DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(String))]
    public class RemoveDataBoxJob : AzureDataBoxCmdletBase
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }


        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(GetByResourceIdParameterSet))
            {
                this.ResourceGroupName = ResourceIdHandler.GetResourceGroupName(ResourceId);
                this.Name = ResourceIdHandler.GetResourceName(ResourceId);
            }
            // Gets information about the specified job.
            JobResource jobResource = JobsOperationsExtensions.Get(DataBoxManagementClient.Jobs, ResourceGroupName, Name, "details");

            if (jobResource.Status == StageName.Cancelled || jobResource.Status == StageName.Completed || jobResource.Status == StageName.CompletedWithErrors)
            {
                // Initiate to delete job
                if (ShouldProcess(this.Name))
                {
                    JobsOperationsExtensions.Delete(
                        DataBoxManagementClient.Jobs,
                        ResourceGroupName,
                        Name);

                    WriteObject("Successfully Deleted the Databox Job");
                }
                

            }
            else
            {
                WriteObject("This Databox Job cannot be Deleted");
            }
        }


    }


}
