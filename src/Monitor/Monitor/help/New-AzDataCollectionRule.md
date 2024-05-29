---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azdatacollectionrule
schema: 2.0.0
---

# New-AzDataCollectionRule

## SYNOPSIS
Create a data collection rule.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataCollectionRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-DataCollectionEndpointId <String>] [-DataFlow <IDataFlow[]>]
 [-DataSourceDataImportEventHubConsumerGroup <String>] [-DataSourceDataImportEventHubName <String>]
 [-DataSourceDataImportEventHubStream <String>] [-DataSourceExtension <IExtensionDataSource[]>]
 [-DataSourceIisLog <IIisLogsDataSource[]>] [-DataSourceLogFile <ILogFilesDataSource[]>]
 [-DataSourcePerformanceCounter <IPerfCounterDataSource[]>]
 [-DataSourcePlatformTelemetry <IPlatformTelemetryDataSource[]>]
 [-DataSourcePrometheusForwarder <IPrometheusForwarderDataSource[]>] [-DataSourceSyslog <ISyslogDataSource[]>]
 [-DataSourceWindowsEventLog <IWindowsEventLogDataSource[]>]
 [-DataSourceWindowsFirewallLog <IWindowsFirewallLogsDataSource[]>] [-Description <String>]
 [-DestinationAzureMonitorMetricName <String>] [-DestinationEventHub <IEventHubDestination[]>]
 [-DestinationEventHubsDirect <IEventHubDirectDestination[]>]
 [-DestinationLogAnalytic <ILogAnalyticsDestination[]>]
 [-DestinationMonitoringAccount <IMonitoringAccountDestination[]>]
 [-DestinationStorageAccount <IStorageBlobDestination[]>]
 [-DestinationStorageBlobsDirect <IStorageBlobDestination[]>]
 [-DestinationStorageTablesDirect <IStorageTableDestination[]>] [-IdentityType <String>] [-Kind <String>]
 [-StreamDeclaration <Hashtable>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDataCollectionRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDataCollectionRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a data collection rule.

## EXAMPLES

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

## PARAMETERS

### -DataCollectionEndpointId
The resource ID of the data collection endpoint that this rule can be used with.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataFlow
The specification of data flows.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataFlow[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceDataImportEventHubConsumerGroup
Event Hub consumer group name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceDataImportEventHubName
A friendly name for the data source.
This name should be unique across all data sources (regardless of type) within the data collection rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceDataImportEventHubStream
The stream to collect from EventHub

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceExtension
The list of Azure VM extension data source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IExtensionDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceIisLog
The list of IIS logs source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IIisLogsDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceLogFile
The list of Log files source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ILogFilesDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePerformanceCounter
The list of performance counter data source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPerfCounterDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePlatformTelemetry
The list of platform telemetry configurations

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPlatformTelemetryDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePrometheusForwarder
The list of Prometheus forwarder data source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPrometheusForwarderDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceSyslog
The list of Syslog data source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ISyslogDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceWindowsEventLog
The list of Windows Event Log data source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IWindowsEventLogDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceWindowsFirewallLog
The list of Windows Firewall logs source configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IWindowsFirewallLogsDataSource[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Description of the data collection rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationAzureMonitorMetricName
A friendly name for the destination.
This name should be unique across all destinations (regardless of type) within the data collection rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationEventHub
List of Event Hubs destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IEventHubDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationEventHubsDirect
List of Event Hubs Direct destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IEventHubDirectDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationLogAnalytic
List of Log Analytics destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ILogAnalyticsDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationMonitoringAccount
List of monitoring account destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IMonitoringAccountDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageAccount
List of storage accounts destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageBlobsDirect
List of Storage Blob Direct destinations.
To be used only for sending data directly to store from the agent.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageTablesDirect
List of Storage Table Direct destinations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageTableDestination[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the data collection rule.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataCollectionRuleName, RuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StreamDeclaration
Declaration of custom streams used in this rule.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleResource

## NOTES

## RELATED LINKS
