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
//using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources.Resource;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainer" , SupportsShouldProcess = true), OutputType(typeof(void))]
    public class RemoveAzCosmosDBSqlContainer : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ContainerNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        public PSSqlContainer InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.SqlContainerId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                DatabaseName = resourceIdentifier.ResourceName;
                AccountName = resourceIdentifier.ParentResource;
            }

            try
            {
                var response = CosmosClient.DatabaseAccounts.BeginDeleteSqlContainerWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name).Result;
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
