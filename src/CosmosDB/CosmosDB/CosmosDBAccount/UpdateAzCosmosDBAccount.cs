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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Microsoft.Azure.Management.CosmosDB.Models;
using System;
using SDKModel = Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class UpdateAzCosmosDBAccount : NewOrUpdateAzCosmosDBAccount
    {
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public bool? EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public bool? EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public bool? EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DisableKeyBasedMetadataWriteAccessHelpMessage)]
        public bool? DisableKeyBasedMetadataWriteAccess { get; set; }

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
            if (EnableAnalyticalStorage != null)
            {
                databaseAccountUpdateParameters.EnableAnalyticalStorage = EnableAnalyticalStorage;
            }
            if (NetworkAclBypass != null)
            {
                databaseAccountUpdateParameters.NetworkAclBypass = 
                    NetworkAclBypass == "AzureServices" ? SDKModel.NetworkAclBypass.AzureServices : SDKModel.NetworkAclBypass.None;
            }

            if (!string.IsNullOrEmpty(DefaultConsistencyLevel))
            {
               databaseAccountUpdateParameters.ConsistencyPolicy = base.PopoulateConsistencyPolicy(DefaultConsistencyLevel, MaxStalenessIntervalInSeconds, MaxStalenessPrefix);
            }

            if (Tag != null)
            {
                databaseAccountUpdateParameters.Tags = base.PopulateTags(Tag);
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

            if (IpRule != null)
            {
                // not checking IpRules.Length > 0, to handle the removal of IpRules case
                databaseAccountUpdateParameters.IpRules = base.PopulateIpRules(IpRule);
            }

            if (ServerVersion != null)
            {
                if (databaseAccountUpdateParameters.ApiProperties == null)
                {
                    databaseAccountUpdateParameters.ApiProperties = new ApiProperties();
                }

                databaseAccountUpdateParameters.ApiProperties.ServerVersion = ServerVersion;
            }

            if (NetworkAclBypassResourceId != null)
            {
                Collection<string> networkAclBypassResourceId = new Collection<string>(NetworkAclBypassResourceId);
                databaseAccountUpdateParameters.NetworkAclBypassResourceIds = networkAclBypassResourceId;
            }

            if (BackupIntervalInMinutes.HasValue || BackupRetentionIntervalInHours.HasValue)
            {
                if (readDatabase.BackupPolicy is PeriodicModeBackupPolicy)
                {
                    databaseAccountUpdateParameters.BackupPolicy = new PeriodicModeBackupPolicy()
                    {
                        PeriodicModeProperties = new PeriodicModeProperties()
                        {
                            BackupIntervalInMinutes = BackupIntervalInMinutes,
                            BackupRetentionIntervalInHours = BackupRetentionIntervalInHours
                        }
                    };
                }
                else
                {
                    WriteWarning("Can accept BackupInterval or BackupRetention parameters only for accounts with PeriodicMode backup policy");
                    return;
                }
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
