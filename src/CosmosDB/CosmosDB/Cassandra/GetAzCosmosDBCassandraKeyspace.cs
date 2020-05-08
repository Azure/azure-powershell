﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCassandraKeyspace", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSCassandraKeyspaceGetResults))]
    public class GetAzCosmosDBCassandraKeyspace : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.KeyspaceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                AccountName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(Name))
            {
                CassandraKeyspaceGetResults cassandraKeyspaceGetResults = CosmosDBManagementClient.CassandraResources.GetCassandraKeyspaceWithHttpMessagesAsync(ResourceGroupName, AccountName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSCassandraKeyspaceGetResults(cassandraKeyspaceGetResults));
            }
            else
            {
                IEnumerable<CassandraKeyspaceGetResults> cassandraKeyspaces = CosmosDBManagementClient.CassandraResources.ListCassandraKeyspacesWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;
                
                foreach (CassandraKeyspaceGetResults cassandraKeyspace in cassandraKeyspaces)
                    WriteObject(new PSCassandraKeyspaceGetResults(cassandraKeyspace));
            }

            return;
        }
    }
}
