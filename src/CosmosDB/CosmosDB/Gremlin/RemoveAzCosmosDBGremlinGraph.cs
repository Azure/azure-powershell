using System;
using System.Management.Automation; 
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinGraph", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(void), typeof(bool))]
    public class RemoveAzCosmosDBGremlinGraph : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.GraphNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.GremlinGraphObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinGraphGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
                DatabaseName = ResourceIdentifierExtensions.GetGremlinDatabaseName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            if (ShouldProcess(Name, "Deleting CosmosDB Gremlin Graph"))
            {
                CosmosDBManagementClient.GremlinResources.DeleteGremlinGraphWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name).GetAwaiter().GetResult();

                if (PassThru)
                    WriteObject(true);
            }

            return;
        }
    }
}
