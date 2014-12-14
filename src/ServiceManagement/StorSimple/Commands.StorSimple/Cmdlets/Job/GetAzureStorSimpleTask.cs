using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    using Microsoft.WindowsAzure.Management.StorSimple.Models;
    using Properties;

    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleTask"), OutputType(typeof(TaskStatusInfo))]
    public class GetAzureStorSimpleTask : StorSimpleCmdletBase
    {

        [Alias("TaskId")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageTaskId)]
        [ValidateNotNullOrEmpty]
        public string InstanceId { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var taskStatus = StorSimpleClient.GetJobStatus(InstanceId);
                this.WriteObject(taskStatus);
            }

            catch(Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}