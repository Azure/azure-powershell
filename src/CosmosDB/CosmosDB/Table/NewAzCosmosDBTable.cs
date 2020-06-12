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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBTable", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSTableGetResults), typeof(ConflictingResourceException))]
    public class NewAzCosmosDBTable : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.TableNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TableThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                AccountName = resourceIdentifier.ResourceName;
            }

            TableGetResults readTableGetResults = null;
            try
            {
                readTableGetResults = CosmosDBManagementClient.TableResources.GetTable(ResourceGroupName, AccountName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readTableGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            CreateUpdateOptions options = ThroughputHelper.PopulateCreateUpdateOptions(Throughput, AutoscaleMaxThroughput);

            TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
            {
                Resource = new TableResource
                {
                    Id = Name
                },
                Options = options
            };

            if (ShouldProcess(Name, "Creating a new CosmosDB Table"))
            {
                TableGetResults tableGetResults = CosmosDBManagementClient.TableResources.CreateUpdateTableWithHttpMessagesAsync(ResourceGroupName, AccountName, Name, tableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSTableGetResults(tableGetResults));
            }

            return;
        }
    }
}
