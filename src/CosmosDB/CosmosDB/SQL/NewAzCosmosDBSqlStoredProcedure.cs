// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlStoredProcedure", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlStoredProcedureGetResults), typeof(ConflictingResourceException))]
    public class NewAzCosmosDBSqlStoredProcedure : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.StoredProcedureNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.StoredProcedureBodyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Body { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlContainerGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ContainerName = resourceIdentifier.ResourceName;
                DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            SqlStoredProcedureGetResults readSqlStoredProcedureGetResults = null;
            try
            {
                readSqlStoredProcedureGetResults = CosmosDBManagementClient.SqlResources.GetSqlStoredProcedure(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readSqlStoredProcedureGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters
            {
                Resource = new SqlStoredProcedureResource
                {
                    Id = Name,
                    Body = Body
                },
                Options = new CreateUpdateOptions() //passing empty object as options cannot be null
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB Sql Stored Procedure"))
            {
                SqlStoredProcedureGetResults sqlStoredProcedureGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlStoredProcedureWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlStoredProcedureGetResults(sqlStoredProcedureGetResults));
            }

            return;
        }
    }
}
