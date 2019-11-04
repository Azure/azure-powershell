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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using System.Linq;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccount))]
    public class UpdateAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        public PSDatabaseAccount InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DefaultConsistencyLevelHelpMessage)]
        [PSArgumentCompleter("BoundedStaleness", "ConsistentPrefix", "Eventual", "Session", "Strong")]
        public string DefaultConsistencyLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public bool EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public bool EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public bool EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IpRangeFilterHelpMessage)]
        public string[] IpRangeFilter { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = Constants.MaxStalenessIntervalInSecondsHelpMessage)]
        public int? MaxStalenessIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MaxStalenessPrefixHelpMessage)]
        public int? MaxStalenessPrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TagHelpMessage)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.VirtualNetworkRuleHelpMessage)]
        public string[] VirtualNetworkRule { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            DatabaseAccountInner readDatabase = CosmosDBManagementClient.DatabaseAccounts.GetAsync(ResourceGroupName, Name).GetAwaiter().GetResult();

            DatabaseAccountCreateUpdateParametersInner databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParametersInner(locations: readDatabase.ReadLocations, location: readDatabase.WriteLocations.ElementAt(0).LocationName, name: Name);
            databaseAccountCreateUpdateParameters.EnableMultipleWriteLocations = EnableMultipleWriteLocations;
            databaseAccountCreateUpdateParameters.IsVirtualNetworkFilterEnabled = EnableVirtualNetwork;
            databaseAccountCreateUpdateParameters.EnableAutomaticFailover = EnableAutomaticFailover;

            if (DefaultConsistencyLevel != null)
            {
                ConsistencyPolicy consistencyPolicy = new ConsistencyPolicy();
                {
                    switch (DefaultConsistencyLevel)
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
                            {
                                consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.ConsistentPrefix;
                                break;
                            }

                        case "BoundedStaleness":
                            {
                                consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.BoundedStaleness;
                                consistencyPolicy.MaxIntervalInSeconds = MaxStalenessIntervalInSeconds;
                                consistencyPolicy.MaxStalenessPrefix = MaxStalenessPrefix;
                                break;
                            }

                        default:
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel.Session;
                            break;
                    }
                    databaseAccountCreateUpdateParameters.ConsistencyPolicy = consistencyPolicy;
                }
            }

            if (Tag != null)
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                foreach (string key in Tag.Keys)
                {
                    tags.Add(key, Tag[key].ToString());
                }
                databaseAccountCreateUpdateParameters.Tags = tags;
            }

            if (VirtualNetworkRule != null)
            {
                Collection<VirtualNetworkRule> virtualNetworkRule = new Collection<VirtualNetworkRule>();

                foreach (string id in VirtualNetworkRule)
                {
                    VirtualNetworkRule vNetRule = new VirtualNetworkRule(id: id);
                    virtualNetworkRule.Add(vNetRule);
                }

                databaseAccountCreateUpdateParameters.VirtualNetworkRules = virtualNetworkRule;
            }

            if (IpRangeFilter != null)
            {
                string IpRangeFilterAsString = null;

                for (int i = 0; i < IpRangeFilter.Length; i++)
                {
                    if(i==0)
                    {
                        IpRangeFilterAsString = IpRangeFilter[0];
                    }
                    else
                    IpRangeFilterAsString = string.Concat(IpRangeFilterAsString, ",", IpRangeFilter[i]);
                }
                databaseAccountCreateUpdateParameters.IpRangeFilter = IpRangeFilterAsString;
            }

            DatabaseAccountInner cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.BeginCreateOrUpdateAsync(ResourceGroupName, Name, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult();
            WriteObject(cosmosDBAccount);

            return;
        }
    }
}
