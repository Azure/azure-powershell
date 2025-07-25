using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBService", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(void), typeof(bool))]
    public class RemoveAzCosmosDBService : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.ServiceName)]
        public string ServiceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        [ValidateNotNull]
        public PSServiceGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ServiceName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            if (ShouldProcess(ServiceName, "Deleting CosmosDB Service"))
            {
                CosmosDBManagementClient.Service.DeleteWithHttpMessagesAsync(ResourceGroupName, AccountName, ServiceName).GetAwaiter().GetResult();

                if (PassThru)
                    WriteObject(true);
            }

            return;
        }
    }
}
