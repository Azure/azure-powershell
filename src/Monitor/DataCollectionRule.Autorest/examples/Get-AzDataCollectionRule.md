### Example 1: Get data collection rules by subscription ID
```powershell
Get-AzDataCollectionRule
```

```output
Etag                                   Kind Location Name              ResourceGroupName
----                                   ---- -------- ----              -----------------
"d500e99c-0000-0100-0000-650d68320000"      eastus   myCollectionRule1 AMCS-TEST
"d50031d9-0000-0100-0000-650d6b1f0000"      eastus   myCollectionRule2 AMCS-TEST
```

This command gets list of data collection rules by specified subscription.

### Example 2: List by resource group
```powershell
Get-AzDataCollectionRule -ResourceGroupName AMCS-TEST
```

```output
Etag                                   Kind Location Name              ResourceGroupName
----                                   ---- -------- ----              -----------------
"d500e99c-0000-0100-0000-650d68320000"      eastus   myCollectionRule1 AMCS-TEST
"d50031d9-0000-0100-0000-650d6b1f0000"      eastus   myCollectionRule2 AMCS-TEST
```

This command gets list of data collection rules by specified resource group.

### Example 3: Get specific rule with specified resource group
```powershell
Get-AzDataCollectionRule -ResourceGroupName AMCS-TEST -Name myCollectionRule1
```

```output
DataCollectionEndpointId                  : 
DataFlow                                  : {{
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "destinations": [ "azureMonitorMetrics-default" ]
                                            }}
DataSourceDataImportEventHubConsumerGroup : 
DataSourceDataImportEventHubName          : 
DataSourceDataImportEventHubStream        : 
DataSourceExtension                       : 
DataSourceIisLog                          : 
DataSourceLogFile                         : 
DataSourcePerformanceCounter              : {{
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 15,
                                              "counterSpecifiers": [ "\\\\Processor(_Total)\\\\% Processor Time", "\\\\Memory\\\\Committed Bytes", "\\\\LogicalDisk(_Total)\\\\Free
                                            Megabytes", "\\\\PhysicalDisk(_Total)\\\\Avg. Disk Queue Length" ],
                                              "name": "cloudTeamCoreCounters"
                                            }, {
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 30,
                                              "counterSpecifiers": [ "\\\\Process(_Total)\\\\Thread Count" ],
                                              "name": "appTeamExtraCounters"
                                            }}
DataSourcePlatformTelemetry               : 
DataSourcePrometheusForwarder             : 
DataSourceSyslog                          : 
DataSourceWindowsEventLog                 : {{
                                              "streams": [ "Microsoft-WindowsEvent" ],
                                              "xPathQueries": [ "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]" ],   
                                              "name": "appTeam1AppEvents"
                                            }}
DataSourceWindowsFirewallLog              : 
Description                               : 
DestinationAzureMonitorMetricName         : azureMonitorMetrics-default
DestinationEventHub                       : 
DestinationEventHubsDirect                : 
DestinationLogAnalytic                    : 
DestinationMonitoringAccount              : 
DestinationStorageAccount                 : 
DestinationStorageBlobsDirect             : 
DestinationStorageTablesDirect            : 
Etag                                      : "d500e99c-0000-0100-0000-650d68320000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1   
IdentityPrincipalId                       : 
IdentityTenantId                          : 
IdentityType                              : 
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-9a6169afee634c13baa880dee8c5eb97
Kind                                      : 
Location                                  : eastus
MetadataProvisionedBy                     : 
MetadataProvisionedByResourceId           : 
Name                                      : myCollectionRule1
ProvisioningState                         : Succeeded
ResourceGroupName                         : AMCS-TEST
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 9/22/2023 9:18:41 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 9/22/2023 10:10:57 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```

This command gets specific data collection rule with specified resource group.