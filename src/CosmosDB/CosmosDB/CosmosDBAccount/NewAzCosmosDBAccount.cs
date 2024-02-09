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
using System.Collections.ObjectModel;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using SDKModel = Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class NewAzCosmosDBAccount : NewOrUpdateAzCosmosDBAccount, IDynamicParameters
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.EnableAutomaticFailoverHelpMessage)]
        public SwitchParameter EnableAutomaticFailover { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableMultipleWriteLocationsHelpMessage)]
        public SwitchParameter EnableMultipleWriteLocations { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.EnableVirtualNetworkHelpMessage)]
        public SwitchParameter EnableVirtualNetwork { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.IsRestoreRequestHelpMessage)]
        public SwitchParameter FromPointInTimeBackup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ApiKindHelpMessage)]
        [PSArgumentCompleter("Sql", "MongoDB", "Gremlin", "Cassandra", "Table")]
        public string ApiKind { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DisableKeyBasedMetadataWriteAccessHelpMessage)]
        public SwitchParameter DisableKeyBasedMetadataWriteAccess { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.EnableFreeTierHelpMessage)]
        public bool? EnableFreeTier { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.LocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.LocationObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSLocation[] LocationObject { get; set; }

        // As of 03082022, using this list only for Mongo Accounts >= 3.6
        [Parameter(Mandatory = false, HelpMessage = Constants.LocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] Capabilities { get; set; }

        public override void ExecuteCmdlet()
        {
            DatabaseAccountGetResults databaseAccountGetResults = null;
            try
            {
                databaseAccountGetResults = CosmosDBManagementClient.DatabaseAccounts.Get(ResourceGroupName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (databaseAccountGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            ConsistencyPolicy consistencyPolicy = base.PopoulateConsistencyPolicy(DefaultConsistencyLevel, MaxStalenessIntervalInSeconds, MaxStalenessPrefix);
            string writeLocation = null;
            Collection<Location> LocationCollection = new Collection<Location>();

            if (Location != null && Location.Length > 0)
            {
                int failoverPriority = 0;
                foreach (string l in Location)
                {
                    Location loc = new Location(locationName: l, failoverPriority: failoverPriority);
                    LocationCollection.Add(loc);
                    if (failoverPriority == 0)
                    {
                        writeLocation = l;
                    }

                    failoverPriority++;
                }
            }
            else if (LocationObject != null && LocationObject.Length > 0)
            {
                if (writeLocation != null)
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

            Dictionary<string, string> tags = new Dictionary<string, string>();
            if (Tag != null)
            {
                tags = base.PopulateTags(Tag);
            }

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

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations: LocationCollection, location: writeLocation, name: Name, tags: tags);
            if (FromPointInTimeBackup)
            {
                PSRestoreParameters restoreParameters = restoreContext.GetRestoreParameters(CosmosDBManagementClient);
                if (restoreParameters == null)
                {
                    WriteWarning("Please provide valid parameters to restore");
                    return;
                }

                databaseAccountCreateUpdateParameters.CreateMode = CreateMode.Restore;
                databaseAccountCreateUpdateParameters.RestoreParameters = restoreParameters.ToSDKModel();
            }

            databaseAccountCreateUpdateParameters.ConsistencyPolicy = consistencyPolicy;
            databaseAccountCreateUpdateParameters.EnableMultipleWriteLocations = EnableMultipleWriteLocations;
            databaseAccountCreateUpdateParameters.IsVirtualNetworkFilterEnabled = EnableVirtualNetwork;
            databaseAccountCreateUpdateParameters.EnableAutomaticFailover = EnableAutomaticFailover;
            databaseAccountCreateUpdateParameters.VirtualNetworkRules = virtualNetworkRule;
            databaseAccountCreateUpdateParameters.DisableKeyBasedMetadataWriteAccess = DisableKeyBasedMetadataWriteAccess;
            databaseAccountCreateUpdateParameters.PublicNetworkAccess = PublicNetworkAccess;
            databaseAccountCreateUpdateParameters.EnableFreeTier = EnableFreeTier;
            databaseAccountCreateUpdateParameters.EnableAnalyticalStorage = EnableAnalyticalStorage;
            databaseAccountCreateUpdateParameters.EnableBurstCapacity = EnableBurstCapacity;
            databaseAccountCreateUpdateParameters.EnableMaterializedViews = EnableMaterializedViews;
            Collection<string> networkAclBypassResourceId = NetworkAclBypassResourceId != null ? new Collection<string>(NetworkAclBypassResourceId) : new Collection<string>();
            databaseAccountCreateUpdateParameters.NetworkAclBypassResourceIds = networkAclBypassResourceId;
            databaseAccountCreateUpdateParameters.EnablePriorityBasedExecution = EnablePriorityBasedExecution;
            databaseAccountCreateUpdateParameters.DefaultPriorityLevel = DefaultPriorityLevel;

            if (IpRule != null && IpRule.Length > 0)
            {
                databaseAccountCreateUpdateParameters.IpRules = base.PopulateIpRules(IpRule);
            }

            if (KeyVaultKeyUri != null)
            {
                databaseAccountCreateUpdateParameters.KeyVaultKeyUri = KeyVaultKeyUri;
            }

            if (NetworkAclBypass != null)
            {
                databaseAccountCreateUpdateParameters.NetworkAclBypass =
                    NetworkAclBypass == "AzureServices" ? SDKModel.NetworkAclBypass.AzureServices : SDKModel.NetworkAclBypass.None;
            }

            if (!string.IsNullOrEmpty(ApiKind))
            {
                if (ApiKind.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
                {
                    bool isServerVersion32 = false;

                    if (ServerVersion != null)
                    {
                        databaseAccountCreateUpdateParameters.ApiProperties = new ApiProperties
                        {
                            ServerVersion = ServerVersion
                        };

                        isServerVersion32 = String.Equals("3.2", ServerVersion);
                    }

                    // Add Mongo Capabilities for ServerVersion > 3.2
                    if (!isServerVersion32 && Capabilities != null && Capabilities.Length > 0)
                    {
                        List<Capability> capabilitiesList = new List<Capability>();

                        foreach (string capability in Capabilities)
                        {
                            capabilitiesList.Add(new Capability { Name = capability });
                        }

                        databaseAccountCreateUpdateParameters.Capabilities = capabilitiesList;
                    }
                }
                else
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

            if (!string.IsNullOrEmpty(BackupPolicyType))
            {
                if (BackupPolicyType.Equals(PSBackupPolicy.PeriodicModeBackupType, StringComparison.OrdinalIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(ContinuousTier))
                    {
                        WriteWarning("Cannot accept ContinuousBackupTier parameter for PeriodicModeBackupType");
                        return;
                    }

                    databaseAccountCreateUpdateParameters.BackupPolicy = new PeriodicModeBackupPolicy()
                    {
                        PeriodicModeProperties = new PeriodicModeProperties()
                        {
                            BackupIntervalInMinutes = BackupIntervalInMinutes,
                            BackupRetentionIntervalInHours = BackupRetentionIntervalInHours,
                            BackupStorageRedundancy = BackupStorageRedundancy
                        }
                    };
                }
                else if (BackupPolicyType.Equals(PSBackupPolicy.ContinuousModeBackupType, StringComparison.OrdinalIgnoreCase))
                {
                    if (BackupIntervalInMinutes.HasValue || BackupRetentionIntervalInHours.HasValue || !string.IsNullOrEmpty(BackupStorageRedundancy))
                    {
                        WriteWarning("Cannot accept BackupInterval or BackupRetention or BackupStorageRedundancy parameters for ContinuousModeBackupType");
                        return;
                    }

                    databaseAccountCreateUpdateParameters.BackupPolicy = new ContinuousModeBackupPolicy
                    {
                        ContinuousModeProperties = new ContinuousModeProperties()
                        {
                            Tier = ContinuousTier
                        }
                    };
                }
                else
                {
                    WriteWarning("Invalid BackupPolicyType provided");
                    return;
                }
            }
            else if (BackupIntervalInMinutes.HasValue || BackupRetentionIntervalInHours.HasValue || !string.IsNullOrEmpty(BackupStorageRedundancy))
            {
                databaseAccountCreateUpdateParameters.BackupPolicy = new PeriodicModeBackupPolicy()
                {
                    PeriodicModeProperties = new PeriodicModeProperties()
                    {
                        BackupIntervalInMinutes = BackupIntervalInMinutes,
                        BackupRetentionIntervalInHours = BackupRetentionIntervalInHours,
                        BackupStorageRedundancy = BackupStorageRedundancy
                    }
                };
            }

            // Update analytical storage schema type.
            databaseAccountCreateUpdateParameters.AnalyticalStorageConfiguration = CreateAnalyticalStorageConfiguration(AnalyticalStorageSchemaType);

            if (ShouldProcess(Name, "Creating Database Account"))
            {
                DatabaseAccountGetResults cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, Name, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(cosmosDBAccount));
            }

            return;
        }

        public new object GetDynamicParameters()
        {
            if (FromPointInTimeBackup)
            {
                restoreContext = new RestoreRequestDynamicParameters();
                return restoreContext;
            }

            return null;
        }

        private RestoreRequestDynamicParameters restoreContext;
    }
}
