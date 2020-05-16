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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class UpdateAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DefaultConsistencyLevelHelpMessage)]
        [PSArgumentCompleter("BoundedStaleness", "ConsistentPrefix", "Eventual", "Session", "Strong")]
        public string DefaultConsistencyLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public bool? EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public bool? EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public bool? EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IpRangeFilterHelpMessage)]
        [ValidateNotNull]
        public string[] IpRangeFilter { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = Constants.MaxStalenessIntervalInSecondsHelpMessage)]
        public int? MaxStalenessIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.MaxStalenessPrefixHelpMessage)]
        public int? MaxStalenessPrefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TagHelpMessage)]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.VirtualNetworkRuleHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] VirtualNetworkRule { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.VirtualNetworkRuleObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkRule[] VirtualNetworkRuleObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DisableKeyBasedMetadataWriteAccessHelpMessage)]
        public bool? DisableKeyBasedMetadataWriteAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PublicNetworkAccessHelpMessage)]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.KeyVaultUriHelpMessage)]
        public string KeyVaultKeyUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            DatabaseAccountGetResults readDatabase = CosmosDBManagementClient.DatabaseAccounts.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;

            DatabaseAccountUpdateParameters databaseAccountUpdateParameters = new DatabaseAccountUpdateParameters(locations: readDatabase.Locations, location: readDatabase.WriteLocations.ElementAt(0).LocationName);
            if (EnableMultipleWriteLocations != null)
            {
                databaseAccountUpdateParameters.EnableMultipleWriteLocations = EnableMultipleWriteLocations;
            }
            if (EnableVirtualNetwork != null)
            {
                databaseAccountUpdateParameters.IsVirtualNetworkFilterEnabled = EnableVirtualNetwork;
            }
            if (EnableAutomaticFailover != null)
            {
                databaseAccountUpdateParameters.EnableAutomaticFailover = EnableAutomaticFailover;
            }
            if (DisableKeyBasedMetadataWriteAccess != null)
            {
                databaseAccountUpdateParameters.DisableKeyBasedMetadataWriteAccess = DisableKeyBasedMetadataWriteAccess;
            }
            if (PublicNetworkAccess != null)
            {
                databaseAccountUpdateParameters.PublicNetworkAccess = PublicNetworkAccess;
            }
            if (KeyVaultKeyUri != null)
            {
                databaseAccountUpdateParameters.KeyVaultKeyUri = KeyVaultKeyUri;
            }

            if (!string.IsNullOrEmpty(DefaultConsistencyLevel))
            {
                ConsistencyPolicy consistencyPolicy = new ConsistencyPolicy();
                {
                    switch (DefaultConsistencyLevel)
                    {
                        case "Strong":
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.Strong;
                            break;
                        case "Session":
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.Session;
                            break;
                        case "Eventual":
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.Eventual;
                            break;
                        case "ConsistentPrefix":
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.ConsistentPrefix;
                            break;
                        case "BoundedStaleness":
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.BoundedStaleness;
                            consistencyPolicy.MaxIntervalInSeconds = MaxStalenessIntervalInSeconds;
                            consistencyPolicy.MaxStalenessPrefix = MaxStalenessPrefix;
                            break;
                        default:
                            consistencyPolicy.DefaultConsistencyLevel = Management.CosmosDB.Models.DefaultConsistencyLevel.Session;
                            break;
                    }

                    databaseAccountUpdateParameters.ConsistencyPolicy = consistencyPolicy;
                }
            }

            if (Tag != null)
            {
                Dictionary<string, string> tags = new Dictionary<string, string>();
                
                foreach (string key in Tag.Keys)
                {
                    tags.Add(key, Tag[key].ToString());
                }

                databaseAccountUpdateParameters.Tags = tags;
            }

            if (VirtualNetworkRule != null || VirtualNetworkRuleObject != null)
            {
                Collection<VirtualNetworkRule> virtualNetworkRule = new Collection<VirtualNetworkRule>();
                if (VirtualNetworkRule != null && VirtualNetworkRule.Length > 0)
                {
                    foreach (string id in VirtualNetworkRule)
                    {
                        virtualNetworkRule.Add(new VirtualNetworkRule(id: id));
                    }
                }
                if (VirtualNetworkRuleObject != null && VirtualNetworkRuleObject.Length > 0)
                {
                    foreach (PSVirtualNetworkRule psVirtualNetworkRule in VirtualNetworkRuleObject)
                    {
                        virtualNetworkRule.Add(PSVirtualNetworkRule.ToSDKModel(psVirtualNetworkRule));
                    }
                }
                databaseAccountUpdateParameters.VirtualNetworkRules = virtualNetworkRule;
            }

            if (IpRangeFilter != null)
            {
                string IpRangeFilterAsString = IpRangeFilter?.Aggregate(string.Empty, (output, next) => string.Concat(output, (!string.IsNullOrWhiteSpace(output) && !string.IsNullOrWhiteSpace(next) ? "," : string.Empty), next)) ?? string.Empty;
                databaseAccountUpdateParameters.IpRangeFilter = IpRangeFilterAsString;
            }

            if (ShouldProcess(Name, "Updating Database Account"))
            {
                DatabaseAccountGetResults cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.UpdateWithHttpMessagesAsync(ResourceGroupName, Name, databaseAccountUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(cosmosDBAccount));
            }

            return;
        }
    }
}
