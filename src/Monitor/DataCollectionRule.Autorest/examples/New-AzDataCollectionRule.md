### Example 1: Create a data collection rule with json file
```powershell
New-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName AMCS-TEST -JsonFilePath .\test\jsonfile\ruleTest1.json
# Note: content of .\test\jsonfile\ruleTest1.json
# {
#     "location": "eastus",
#     "properties": {
#         "dataSources": {
#             "performanceCounters": [
#             {
#                 "streams": [
#                     "Microsoft-InsightsMetrics"
#                 ],
#                 "samplingFrequencyInSeconds": 60,
#                 "counterSpecifiers": [
#                     "\\Processor(_Total)\\% Processor Time"
#                 ],
#                 "name": "perfCounter01"
#             },
#             {
#                 "name": "cloudTeamCoreCounters",
#                 "streams": [
#                   "Microsoft-Perf"
#                 ],
#                 "samplingFrequencyInSeconds": 15,
#                 "counterSpecifiers": [
#                   "\\Processor(_Total)\\% Processor Time",
#                   "\\Memory\\Committed Bytes",
#                   "\\LogicalDisk(_Total)\\Free Megabytes",
#                   "\\PhysicalDisk(_Total)\\Avg. Disk Queue Length"
#                 ]
#               }
#             ]
#         },
#         "destinations": {
#             "azureMonitorMetrics": {
#               "name": "azureMonitorMetrics-default"
#             }
#         },
#         "dataFlows": [
#             {
#                 "streams": [
#                     "Microsoft-InsightsMetrics"
#             ],
#                 "destinations": [
#                     "azureMonitorMetrics-default"
#             ]
#             }
#         ]
#     }
# }
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
                                              "streams": [ "Microsoft-InsightsMetrics" ],
                                              "samplingFrequencyInSeconds": 60,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time" ],
                                              "name": "perfCounter01"
                                            }, {
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 15,
                                              "counterSpecifiers": [ "\\Processor(_Total)\\% Processor Time", "\\Memory\\Committed Bytes", "\\LogicalDisk(_Total)\\Free Megabytes",
                                            "\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" ],
                                              "name": "cloudTeamCoreCounters"
                                            }}
DataSourcePlatformTelemetry               : 
DataSourcePrometheusForwarder             : 
DataSourceSyslog                          : 
DataSourceWindowsEventLog                 : 
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
Etag                                      : "bb02d25d-0000-0100-0000-65017aed0000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/myCollectionRule1   
IdentityPrincipalId                       : 
IdentityTenantId                          : 
IdentityType                              : 
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-2eebbe7e7a974226b2ef938194ada574
Kind                                      : 
Location                                  : eastus
MetadataProvisionedBy                     : 
MetadataProvisionedByResourceId           : 
Name                                      : myCollectionRule1
ProvisioningState                         : Succeeded
ResourceGroupName                         : AMCS-TEST
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 9/13/2023 9:03:39 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 9/13/2023 9:03:39 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```

This command creates a data collection rules for the current subscription.

### Example 2: Create a data collection rule with objects
```powershell
$dataflow = New-AzDataFlowObject -Stream Microsoft-InsightsMetrics -Destination azureMonitorMetrics-default
$windowsEvent = New-AzWindowsEventLogDataSourceObject -Name appTeam1AppEvents -Stream Microsoft-WindowsEvent -XPathQuery "System![System[(Level = 1 or Level = 2 or Level = 3)]]","Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]"
$performanceCounter1 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Processor(_Total)\\% Processor Time","\\Memory\\Committed Bytes","\\LogicalDisk(_Total)\\Free Megabytes","\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" -Name cloudTeamCoreCounters -SamplingFrequencyInSecond 15 -Stream Microsoft-Perf
$performanceCounter2 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Process(_Total)\\Thread Count" -Name appTeamExtraCounters -SamplingFrequencyInSecond 30 -Stream Microsoft-Perf
New-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName AMCS-TEST -Location eastus -DataFlow $dataflow -DataSourcePerformanceCounter $performanceCounter1,$performanceCounter2 -DataSourceWindowsEventLog $windowsEvent -DestinationAzureMonitorMetricName "azureMonitorMetrics-default"
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
                                              "counterSpecifiers": [ "\\\\Processor(_Total)\\\\% Processor Time", "\\\\Memory\\\\Committed Bytes",
                                            "\\\\LogicalDisk(_Total)\\\\Free Megabytes", "\\\\PhysicalDisk(_Total)\\\\Avg. Disk Queue Length" ],
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
                                              "xPathQueries": [ "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2 or   
                                            Level = 3)]]" ],
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
Etag                                      : "d400a6a6-0000-0100-0000-650d5bf20000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/my 
                                            CollectionRule1
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
SystemDataLastModifiedAt                  : 9/22/2023 9:18:41 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```

This command creates a data collection rules for the current subscription.

### Example 3: Create a data collection rule with syslog
```powershell
$dataflow2 = New-AzDataFlowObject -Stream Microsoft-Perf,Microsoft-Syslog -Destination centralWorkspace
$performanceCounter3 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Processor(_Total)\\% Processor Time","\\Memory\\Committed Bytes","\\LogicalDisk(_Total)\\Free Megabytes","\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" -Name cloudTeamCoreCounters -SamplingFrequencyInSecond 15 -Stream Microsoft-Perf
$performanceCounter4 = New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Process(_Total)\\Thread Count" -Name appTeamExtraCounters -SamplingFrequencyInSecond 30 -Stream Microsoft-Perf
$windowsEvent1 = New-AzWindowsEventLogDataSourceObject -Name cloudSecurityTeamEvents -Stream Microsoft-WindowsEvent -XPathQuery "Security!*"
$windowsEvent2 = New-AzWindowsEventLogDataSourceObject -Name appTeam1AppEvents -Stream Microsoft-WindowsEvent -XPathQuery "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]"
$logAnalytics = New-AzLogAnalyticsDestinationObject -Name centralWorkspace -WorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.operationalinsights/workspaces/amcs-logtest-ws
$cronlog = New-AzSyslogDataSourceObject -FacilityName cron -LogLevel Debug,Critical,Emergency -Name cronSyslog -Stream Microsoft-Syslog
$syslog = New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
New-AzDataCollectionRule -Name myCollectionRule2 -ResourceGroupName AMCS-TEST -Location eastus -DataFlow $dataflow2 -DataSourcePerformanceCounter $performanceCounter3,$performanceCounter4 -DataSourceWindowsEventLog $windowsEvent1,$windowsEvent2 -DestinationLogAnalytic $logAnalytics -DataSourceSyslog $cronlog,$syslog
```

```output
DataCollectionEndpointId                  : 
DataFlow                                  : {{
                                              "streams": [ "Microsoft-Perf", "Microsoft-Syslog" ],
                                              "destinations": [ "centralWorkspace" ]
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
                                              "counterSpecifiers": [ "\\\\Processor(_Total)\\\\% Processor Time", "\\\\Memory\\\\Committed Bytes",
                                            "\\\\LogicalDisk(_Total)\\\\Free Megabytes", "\\\\PhysicalDisk(_Total)\\\\Avg. Disk Queue Length" ],
                                              "name": "cloudTeamCoreCounters"
                                            }, {
                                              "streams": [ "Microsoft-Perf" ],
                                              "samplingFrequencyInSeconds": 30,
                                              "counterSpecifiers": [ "\\\\Process(_Total)\\\\Thread Count" ],
                                              "name": "appTeamExtraCounters"
                                            }}
DataSourcePlatformTelemetry               : 
DataSourcePrometheusForwarder             : 
DataSourceSyslog                          : {{
                                              "streams": [ "Microsoft-Syslog" ],
                                              "facilityNames": [ "cron" ],
                                              "logLevels": [ "Debug", "Critical", "Emergency" ],
                                              "name": "cronSyslog"
                                            }, {
                                              "streams": [ "Microsoft-Syslog" ],
                                              "facilityNames": [ "syslog" ],
                                              "logLevels": [ "Alert", "Critical", "Emergency" ],
                                              "name": "syslogBase"
                                            }}
DataSourceWindowsEventLog                 : {{
                                              "streams": [ "Microsoft-WindowsEvent" ],
                                              "xPathQueries": [ "Security!*" ],
                                              "name": "cloudSecurityTeamEvents"
                                            }, {
                                              "streams": [ "Microsoft-WindowsEvent" ],
                                              "xPathQueries": [ "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2 or   
                                            Level = 3)]]" ],
                                              "name": "appTeam1AppEvents"
                                            }}
DataSourceWindowsFirewallLog              : 
Description                               : 
DestinationAzureMonitorMetricName         : 
DestinationEventHub                       : 
DestinationEventHubsDirect                : 
DestinationLogAnalytic                    : {{
                                              "workspaceResourceId": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/amcs-test/providers/microsoft.opera 
                                            tionalinsights/workspaces/amcs-logtest-ws",
                                              "workspaceId": "a7393094-14a9-4674-8cec-ca9eb7213f44",
                                              "name": "centralWorkspace"
                                            }}
DestinationMonitoringAccount              : 
DestinationStorageAccount                 : 
DestinationStorageBlobsDirect             : 
DestinationStorageTablesDirect            : 
Etag                                      : "d50031d9-0000-0100-0000-650d6b1f0000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/AMCS-TEST/providers/Microsoft.Insights/dataCollectionRules/my 
                                            CollectionRule2
IdentityPrincipalId                       : 
IdentityTenantId                          : 
IdentityType                              : 
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-498912db79844083aef3aef50d8429ac
Kind                                      : 
Location                                  : eastus
MetadataProvisionedBy                     : 
MetadataProvisionedByResourceId           : 
Name                                      : myCollectionRule2
ProvisioningState                         : Succeeded
ResourceGroupName                         : AMCS-TEST
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 9/22/2023 10:23:26 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 9/22/2023 10:23:26 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```

This command creates a data collection rules for the current subscription.

