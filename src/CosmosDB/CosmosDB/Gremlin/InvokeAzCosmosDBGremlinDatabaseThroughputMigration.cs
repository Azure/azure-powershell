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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinDatabaseThroughputMigration", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSThroughputSettingsGetResults))]
    public class InvokeAzCosmosDBGremlinDatabaseThroughputMigration : MigrateAzCosmosDBThroughput
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.GremlinDatabaseObjectHelpMessage)]
        [ValidateNotNull]
        public PSGremlinDatabaseGetResults InputObject { get; set; }

        public override void PopulateFromParentObject() 
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            AccountName = resourceIdentifier.ResourceName;
        }

        public override void PopulateFromInputObject() 
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
            ResourceGroupName = resourceIdentifier.ResourceGroupName;
            Name = resourceIdentifier.ResourceName;
            AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);

        }

        public override void MigrateToAutoscaleSDKMethod()
        {
            if (ShouldProcess(Name, "Migrating the CosmosDB Gremlin Database throughput to Autoscale Provisioning Policy."))
            {
                ThroughputSettingsGetResults throughputSettingsGetResults =
                    CosmosDBManagementClient.GremlinResources.MigrateGremlinDatabaseToAutoscale(
                    ResourceGroupName,
                    AccountName,
                    Name);

                WriteObject(new PSThroughputSettingsGetResults(throughputSettingsGetResults));
            }
        }

        public override void MigrateToManualSDKMethod()
        {
            if (ShouldProcess(Name, "Migrating the CosmosDB Gremlin Database throughput to Manual Provisioning Policy."))
            {
                ThroughputSettingsGetResults throughputSettingsGetResults =
                    CosmosDBManagementClient.GremlinResources.MigrateGremlinDatabaseToManualThroughput(
                    ResourceGroupName,
                    AccountName,
                    Name);

                WriteObject(new PSThroughputSettingsGetResults(throughputSettingsGetResults));
            }
        }

    }
}
