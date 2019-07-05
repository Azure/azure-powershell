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
    [Cmdlet(VerbsLifecycle.Stop , ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob", SupportsShouldProcess = true, DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(String))]
    public class StopDataBoxJob : AzureDataBoxCmdletBase
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Reason For Cancellation")]
        [ValidateNotNullOrEmpty]
        public string Reason { get; set; }

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

            if (jobResource.IsCancellable != null && (bool)jobResource.IsCancellable)
            {
                //CancellationReason cancellationReason = new CancellationReason(Reason);

                // Initiate to cancel job
                if (ShouldProcess(this.Name))
                {
                    JobsOperationsExtensions.Cancel(
                        DataBoxManagementClient.Jobs,
                        ResourceGroupName,
                        Name,
                        Reason);
                }
                
               
                WriteObject("Successfully Cancelled the Databox Job");
            }
            else if(jobResource.Status == StageName.Cancelled)
            {
                WriteObject("This Databox Job is already Cancelled");
            }
            else
            {
                WriteObject("This Databox Job cannot be Cancelled");
            }
        }


    }


}
