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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccount))]
    public class NewAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DefaultConsistencyLevelHelpMessage)]
        [PSArgumentCompleter("BoundedStaleness", "ConsistentPrefix", "Eventual", "Session", "Strong")]
        public string DefaultConsistencyLevel { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public SwitchParameter EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public SwitchParameter EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public SwitchParameter EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.IpRangeFilterHelpMessage)]
        public string[] IpRangeFilter { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.LocationHelpMessage)]
        public string[] Location { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.MaxStalenessIntervalInSecondsHelpMessage)]
        public int? MaxStalenessIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.MaxStalenessPrefixHelpMessage)]
        public int? MaxStalenessPrefix { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.TagHelpMessage)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.VirtualNetworkRuleHelpMessage)]
        public string[] VirtualNetworkRule { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ApiKindHelpMessage)]
        [PSArgumentCompleter("GlobalDocumentDB", "MongoDB")]
        public string ApiKind { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.DisableKeyBasedMetadataWriteAccessHelpMessage)]
        public SwitchParameter DisableKeyBasedMetadataWriteAccess { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, ValueFromPipeline = true, HelpMessage = Constants.CorsHelpMessage)]
        public PSCorsRule[] Cors { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            ConsistencyPolicy consistencyPolicy = new ConsistencyPolicy();
            {
                switch(DefaultConsistencyLevel)
                {
                    case "Strong":
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.Strong;
                        break;

                    case "Session":
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.Session;
                        break;

                    case "Eventual":
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.Eventual;
                        break;

                    case "ConsistentPrefix":
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.ConsistentPrefix;
                        break;

                    case "BoundedStaleness":
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.BoundedStaleness;
                        consistencyPolicy.MaxIntervalInSeconds = MaxStalenessIntervalInSeconds;
                        consistencyPolicy.MaxStalenessPrefix = MaxStalenessPrefix;
                        break;

                    default:
                        consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.Session;
                        break;

                }
            }

            DatabaseAccountKind kind = null;
            if(ApiKind != null)
            {
                if (ApiKind.Equals("GlobalDocumentDB"))
                    kind = DatabaseAccountKind.GlobalDocumentDB;
                else if (ApiKind.Equals("MongoDB"))
                    kind = DatabaseAccountKind.MongoDB;
                else
                    kind = DatabaseAccountKind.Others;
            }
            else
                kind = DatabaseAccountKind.GlobalDocumentDB;

            string writeLocation = null;
            Collection<Location> LocationCollection = new Collection<Location>();
            if(Location != null)
            {
                int failoverPriority = 0;
                foreach(string l in Location)
                {
                    Location loc = new Location(locationName:l, failoverPriority: failoverPriority);
                    LocationCollection.Add(loc);
                    if (failoverPriority == 0)
                        writeLocation = l;
                    failoverPriority++;
                }
            }
            else
            {
                writeLocation = "East US";
            }

            Dictionary<string, string> tags = new Dictionary<string, string>();
            if (Tag != null)
            {
                foreach (string key in Tag.Keys)
                {
                    tags.Add(key, Tag[key].ToString());
                }
            }

            Collection<VirtualNetworkRule> virtualNetworkRule = new Collection<VirtualNetworkRule>();
            if(VirtualNetworkRule != null)
            {
                foreach(string id in VirtualNetworkRule)
                {
                    VirtualNetworkRule vNetRule = new VirtualNetworkRule(id: id);
                    virtualNetworkRule.Add(vNetRule);
                }
            }

            string IpRangeFilterAsString = null;
            if (IpRangeFilter != null)
            {

                for (int i = 0; i < IpRangeFilter.Length; i++)
                {
                    if (i == 0)
                    {
                        IpRangeFilterAsString = IpRangeFilter[0];
                    }
                    else
                        IpRangeFilterAsString = string.Concat(IpRangeFilterAsString, ",", IpRangeFilter[i]);
                }
            }

            DatabaseAccountCreateUpdateParametersInner databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParametersInner(locations:LocationCollection, location: writeLocation, name:Name, kind:ApiKind, consistencyPolicy:consistencyPolicy, tags:tags, ipRangeFilter:IpRangeFilterAsString);
            databaseAccountCreateUpdateParameters.EnableMultipleWriteLocations = EnableMultipleWriteLocations;
            databaseAccountCreateUpdateParameters.IsVirtualNetworkFilterEnabled = EnableVirtualNetwork;
            databaseAccountCreateUpdateParameters.EnableAutomaticFailover = EnableAutomaticFailover;
            databaseAccountCreateUpdateParameters.VirtualNetworkRules = virtualNetworkRule;

            
            try
            {
                DatabaseAccountInner cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.BeginCreateOrUpdateAsync(ResourceGroupName, Name, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult();
                WriteObject(cosmosDBAccount);
            }
            catch (Exception e)
            {
                WriteObject("Exception in sdk call" + e.ToString());
            }
        }
    }
}
