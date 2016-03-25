using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Get, "AvailableOperations")]
    public class GetAvailableOperations : WebServicesCmdletBase
    {
        [Parameter(
             Position = 0,
             Mandatory = true,
             HelpMessage = "The Endpoint. For Example: foo.com")]
        [ValidateNotNullOrEmpty]
        public string Endpoint { get; set; }

        private bool isVerbose;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.WriteObject("Querying the Endpoint......");
            this.WriteObject(string.Format("Endpoint: {0}", this.Endpoint));

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
