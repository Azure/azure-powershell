using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlUserDefinedFunction", SupportsShouldProcess = true), OutputType(typeof(void), typeof(bool))]
    public class RemoveAzCosmosDBSqlUserDefinedFunction : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.UserDefinedFunctionNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlUserDefinedFunctionObjectHelpMessage)]
        public PSSqlUserDefinedFunctionGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
                DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
                ContainerName = ResourceIdentifierExtensions.GetSqlContainerName(resourceIdentifier);
            }

            try
            {
                CosmosDBManagementClient.SqlResources.DeleteSqlUserDefinedFunctionWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name).GetAwaiter().GetResult();
                
                if (PassThru)
                    WriteObject(bool.TrueString);
            }
            catch
            {
                if(PassThru)
                    WriteObject(bool.FalseString);
            }

            return;
        }
    }
}
