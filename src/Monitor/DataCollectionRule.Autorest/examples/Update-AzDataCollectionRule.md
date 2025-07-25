### Example 1: Update tag for data collection rule 
```powershell
$syslog = New-AzSyslogDataSourceObject -FacilityName syslog -LogLevel Alert,Critical,Emergency -Name syslogBase -Stream Microsoft-Syslog
Update-AzDataCollectionRule -Name myCollectionRule1 -ResourceGroupName Monitor-ActionGroup -DataSourceSyslog $syslog
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
DataSourceSyslog                          : {{
                                              "streams": [ "Microsoft-Syslog" ],
                                              "facilityNames": [ "syslog" ],
                                              "logLevels": [ "Alert", "Critical", "Emergency" ],
                                              "name": "syslogBase"
                                            }}
DataSourceWindowsEventLog                 : {{
                                              "streams": [ "Microsoft-WindowsEvent" ],
                                              "xPathQueries": [ "System![System[(Level = 1 or Level = 2 or Level = 3)]]", "Application!*[System[(Level = 1 or Level = 2   
                                            or Level = 3)]]" ],
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
Etag                                      : "9200a3d3-0000-0100-0000-654c72ae0000"
Id                                        : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-ActionGroup/providers/Microsoft.Insights/dataColle 
                                            ctionRules/myCollectionRule1
IdentityPrincipalId                       : 
IdentityTenantId                          : 
IdentityType                              : 
IdentityUserAssignedIdentity              : {
                                            }
ImmutableId                               : dcr-e30a8188813f426d962ef7053a3d1be4
Kind                                      : 
Location                                  : eastus
MetadataProvisionedBy                     : 
MetadataProvisionedByResourceId           : 
Name                                      : myCollectionRule1
ProvisioningState                         : Succeeded
ResourceGroupName                         : Monitor-ActionGroup
StreamDeclaration                         : {
                                            }
SystemDataCreatedAt                       : 11/9/2023 5:04:01 AM
SystemDataCreatedBy                       : v-jiaji@microsoft.com
SystemDataCreatedByType                   : User
SystemDataLastModifiedAt                  : 11/9/2023 5:48:29 AM
SystemDataLastModifiedBy                  : v-jiaji@microsoft.com
SystemDataLastModifiedByType              : User
Tag                                       : {
                                            }
Type                                      : Microsoft.Insights/dataCollectionRules
```

This command updates data collection rule.