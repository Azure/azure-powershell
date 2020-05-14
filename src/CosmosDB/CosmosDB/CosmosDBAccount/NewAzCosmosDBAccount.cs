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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class NewAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DefaultConsistencyLevelHelpMessage)]
        [PSArgumentCompleter("BoundedStaleness", "ConsistentPrefix", "Eventual", "Session", "Strong")]
        public string DefaultConsistencyLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public SwitchParameter EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public SwitchParameter EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public SwitchParameter EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.IpRangeFilterHelpMessage)]
        [ValidateNotNull]
        public string[] IpRangeFilter { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.LocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.LocationObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSLocation[] LocationObject { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = Constants.VirtualNetworkRuleObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkRule[] VirtualNetworkRuleObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ApiKindHelpMessage)]
        [PSArgumentCompleter("Sql", "MongoDB", "Gremlin", "Cassandra", "Table")]
        public string ApiKind { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PublicNetworkAccessHelpMessage)]
        [PSArgumentCompleter("Disabled", "Enabled")]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DisableKeyBasedMetadataWriteAccessHelpMessage)]
        public SwitchParameter DisableKeyBasedMetadataWriteAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.KeyVaultUriHelpMessage)]
        public string KeyVaultKeyUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            ConsistencyPolicy consistencyPolicy = new ConsistencyPolicy();
            {
                switch(DefaultConsistencyLevel)
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
            }

            string writeLocation = null;
            Collection<Location> LocationCollection = new Collection<Location>();

            if(Location != null && Location.Length > 0)
            {
                int failoverPriority = 0;
                foreach(string l in Location)
                {
                    Location loc = new Location(locationName:l, failoverPriority: failoverPriority);
                    LocationCollection.Add(loc);
                    if (failoverPriority == 0)
                    {
                        writeLocation = l;
                    }

                    failoverPriority++;
                }
            }
            else if(LocationObject != null && LocationObject.Length > 0)
            {
                if(writeLocation != null)
                {
                    WriteWarning("Cannot accept Location and LocationObject simultaneously as parameters");
                    return;
                }

                foreach (PSLocation psLocation in LocationObject)
                {
                    LocationCollection.Add(PSLocation.ToSDKModel(psLocation));
                    if (psLocation.FailoverPriority == 0)
                    {
                        writeLocation = psLocation.LocationName;
                    }
                }
            }

            if(string.IsNullOrEmpty(writeLocation))
            {
                WriteWarning("Cannot create Account without a Write Location.");
                return;
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
            if (VirtualNetworkRule != null && VirtualNetworkRule.Length > 0)
            {
                foreach (string id in VirtualNetworkRule)
                {
                    virtualNetworkRule.Add(new VirtualNetworkRule(id: id));
                }
            }
            if(VirtualNetworkRuleObject != null && VirtualNetworkRuleObject.Length > 0) 
            { 
                foreach (PSVirtualNetworkRule psVirtualNetworkRule in VirtualNetworkRuleObject)
                {
                    virtualNetworkRule.Add(PSVirtualNetworkRule.ToSDKModel(psVirtualNetworkRule));
                }
            }

            string IpRangeFilterAsString = null;
            if (IpRangeFilter != null && IpRangeFilter.Length > 0)
            {
                IpRangeFilterAsString = IpRangeFilter?.Aggregate(string.Empty, (output, next) => string.Concat(output, (!string.IsNullOrWhiteSpace(output) && !string.IsNullOrWhiteSpace(next) ? "," : string.Empty), next)) ?? string.Empty;
            }

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations:LocationCollection, location: writeLocation, name:Name, consistencyPolicy:consistencyPolicy, tags:tags, ipRangeFilter:IpRangeFilterAsString);
            databaseAccountCreateUpdateParameters.EnableMultipleWriteLocations = EnableMultipleWriteLocations;
            databaseAccountCreateUpdateParameters.IsVirtualNetworkFilterEnabled = EnableVirtualNetwork;
            databaseAccountCreateUpdateParameters.EnableAutomaticFailover = EnableAutomaticFailover;
            databaseAccountCreateUpdateParameters.VirtualNetworkRules = virtualNetworkRule;
            databaseAccountCreateUpdateParameters.DisableKeyBasedMetadataWriteAccess = DisableKeyBasedMetadataWriteAccess;
            databaseAccountCreateUpdateParameters.IpRangeFilter = IpRangeFilterAsString;
            databaseAccountCreateUpdateParameters.PublicNetworkAccess = PublicNetworkAccess;
            
            if (KeyVaultKeyUri != null)
            {
                databaseAccountCreateUpdateParameters.KeyVaultKeyUri = KeyVaultKeyUri;
            }

            if (!string.IsNullOrEmpty(ApiKind))
            {
                if (!ApiKind.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
                {
                    switch (ApiKind)
                    {
                        case "Cassandra":
                            databaseAccountCreateUpdateParameters.Capabilities = new List<Capability> { new Capability { Name = "EnableCassandra" } };
                            break;
                        case "Gremlin":
                            databaseAccountCreateUpdateParameters.Capabilities = new List<Capability> { new Capability { Name = "EnableGremlin" } };
                            break;
                        case "Table":
                            databaseAccountCreateUpdateParameters.Capabilities = new List<Capability> { new Capability { Name = "EnableTable" } };
                            break;
                        case "Sql":
                            break;
                    }

                    ApiKind = null;
                }
            }
            else
            {
                ApiKind = "GlobalDocumentDB";
            }
            databaseAccountCreateUpdateParameters.Kind = ApiKind;

            if (ShouldProcess(Name, "Creating Database Account"))
            {
                DatabaseAccountGetResults cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(cosmosDBAccount));
            }

            return;
        }
    }
}
