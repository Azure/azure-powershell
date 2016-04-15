using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Get, "WebServices")]
    public class GetWebServices : WebServicesCmdletBase
    {
        [Parameter(
            Position = 0, 
            Mandatory = true,
            HelpMessage = "The Endpoint. For Example: foo.com")]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        [Parameter(
            Position = 1, 
            Mandatory = true,
            HelpMessage = "The Azure Subscription ID")]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(
            Position = 2, 
            Mandatory = false,
            HelpMessage = "The Resource Group Name.")]
        public string ResourceGroupName { get; set; }

        private bool isVerbose;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.WriteObject("Querying Web Services......");
            this.WriteObject(string.Format("Endpoint: {0}", this.Endpoint));
            this.WriteObject(string.Format("Subscription ID: {0}", this.SubscriptionId));
            this.WriteObject(string.Format("Resource Group Name: {0}", this.ResourceGroupName));

            this.isVerbose = this.MyInvocation.BoundParameters.ContainsKey("Verbose");
            this.WriteObject(string.Format("Verbose: {0}", this.isVerbose));
            Console.WriteLine();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            this.WriteObject("... Done!");
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            Console.WriteLine("Fetching records from AzureML...");
            this.WriteVerbose("More details here");
            this.WriteDebug("Debug Message");
            this.WriteError(new ErrorRecord(new NotImplementedException(), "error #1", ErrorCategory.InvalidData, null));
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            Console.WriteLine("Cancelling current operation...");
        }
    }
}
