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
    [Cmdlet(VerbsLifecycle.Stop , "AzDataBoxJob"), OutputType(typeof(String))]
    public class StopDataBoxJob : AzureDataBoxCmdletBase
    {

       
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


        public override void ExecuteCmdlet()
        {
            // Gets information about the specified job.
            JobResource jobResource = JobsOperationsExtensions.Get(DataBoxManagementClient.Jobs, ResourceGroupName, Name, "details");

            if (jobResource.IsCancellable != null && (bool)jobResource.IsCancellable)
            {
                //CancellationReason cancellationReason = new CancellationReason(Reason);

                // Initiate to cancel job
                JobsOperationsExtensions.Cancel(
                    DataBoxManagementClient.Jobs,
                    ResourceGroupName,
                    Name,
                    Reason);
               
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
