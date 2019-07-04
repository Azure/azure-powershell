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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob"), OutputType(typeof(String))]
    public class RemoveDataBoxJob : AzureDataBoxCmdletBase
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

            if (jobResource.Status == StageName.Cancelled || jobResource.Status == StageName.Completed || jobResource.Status == StageName.CompletedWithErrors)
            {
                // Initiate to delete job
                JobsOperationsExtensions.Delete(
                  DataBoxManagementClient.Jobs,
                  ResourceGroupName,
                  Name);

                WriteObject("Successfully Deleted the Databox Job");

            }
            else
            {
                WriteObject("This Databox Job cannot be Deleted");
            }
        }


    }


}
