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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinGraphThroughput", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSThroughputSettingsGetResults))]
    public class UpdateAzCosmosDBGremlinGraphThroughput : UpdateAzCosmosDBThroughput
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GraphNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.GremlinDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinDatabaseGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.GremlinGraphObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinGraphGetResults InputObject { get; set; }

        public override void PopulateFromParentObject() 
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            DatabaseName = resourceIdentifier.ResourceName;
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public override void PopulateFromInputObject() 
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = resourceIdentifier.ResourceName;
            DatabaseName = ResourceIdentifierExtensions.GetGremlinDatabaseName(resourceIdentifier);
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
        }

        public override void CallSDKMethod(ThroughputSettingsUpdateParameters throughputSettingsUpdateParameters) 
        {
            if (ShouldProcess(Name, "Updating the throughput value of a CosmosDB Gremlin Graph"))
            {
                ThroughputSettingsGetResults throughputSettingsGetResults = CosmosDBManagementClient.GremlinResources.UpdateGremlinGraphThroughputWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, throughputSettingsUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSThroughputSettingsGetResults(throughputSettingsGetResults));
            }
        }
    }
}
