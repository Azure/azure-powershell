using System;
using System.Management.Automation;
using PSResourceManagerModels = Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(VerbsCommon.Get, "WebService")]
    public class GetWebService : WebServicesCmdletBase
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.WriteObject("Querying Web Service......");
            this.WriteObject(string.Format("Endpoint: {0}", this.RPService));
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

        public override void ExecuteCmdlet()
        {
            Console.WriteLine("===================================");
            base.ExecuteCmdlet();
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Subscription ID: {0}", DefaultProfile.Context.Subscription.Id);

            PSResourceManagerModels.ResourcesClient rcClient = new PSResourceManagerModels.ResourcesClient(DefaultProfile.Context);
            // Console.WriteLine("Credentials: {0}", rcClient.AuthorizationManagementClient.Credentials);
            // Console.WriteLine("Subscription ID in Credentials: {0}", rcClient.AuthorizationManagementClient.Credentials.SubscriptionId);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("===================================");
        }
    }
}
