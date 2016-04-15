using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsData.Update, "WebService")]
    public class PatchWebService : WebServicesCmdletBase
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.WriteObject("Patching Web Service......");
            this.WriteObject(string.Format("RPService: {0}", this.RPService));
            this.WriteObject(string.Format("Subscription ID: {0}", this.SubscriptionId));
            this.WriteObject(string.Format("Resource Group Name: {0}", this.ResourceGroupName));
            this.WriteObject(string.Format("Web Service Name: {0}", this.WebServiceName));

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
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            Console.WriteLine("Cancelling current operation...");
        }
    }
}
