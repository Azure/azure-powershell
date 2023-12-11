---
external help file:
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azdatacollectionrule
schema: 2.0.0
---

# Update-AzDataCollectionRule

## SYNOPSIS
Update a data collection rule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataCollectionRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DataCollectionEndpointId <String>] [-DataFlow <IDataFlow[]>]
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
 [-Location <String>] [-StreamDeclaration <Hashtable>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataCollectionRule -InputObject <IDataCollectionRuleIdentity> [-DataCollectionEndpointId <String>]
 [-DataFlow <IDataFlow[]>] [-DataSourceDataImportEventHubConsumerGroup <String>]
 [-DataSourceDataImportEventHubName <String>] [-DataSourceDataImportEventHubStream <String>]
 [-DataSourceExtension <IExtensionDataSource[]>] [-DataSourceIisLog <IIisLogsDataSource[]>]
 [-DataSourceLogFile <ILogFilesDataSource[]>] [-DataSourcePerformanceCounter <IPerfCounterDataSource[]>]
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
 [-Location <String>] [-StreamDeclaration <Hashtable>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a data collection rule.

## EXAMPLES

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

## PARAMETERS

### -DataCollectionEndpointId
The resource ID of the data collection endpoint that this rule can be used with.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataFlow
The specification of data flows.
To construct, see NOTES section for DATAFLOW properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataFlow[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceExtension
The list of Azure VM extension data source configurations.
To construct, see NOTES section for DATASOURCEEXTENSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IExtensionDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceIisLog
The list of IIS logs source configurations.
To construct, see NOTES section for DATASOURCEIISLOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IIisLogsDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceLogFile
The list of Log files source configurations.
To construct, see NOTES section for DATASOURCELOGFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ILogFilesDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePerformanceCounter
The list of performance counter data source configurations.
To construct, see NOTES section for DATASOURCEPERFORMANCECOUNTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPerfCounterDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePlatformTelemetry
The list of platform telemetry configurations
To construct, see NOTES section for DATASOURCEPLATFORMTELEMETRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPlatformTelemetryDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourcePrometheusForwarder
The list of Prometheus forwarder data source configurations.
To construct, see NOTES section for DATASOURCEPROMETHEUSFORWARDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IPrometheusForwarderDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceSyslog
The list of Syslog data source configurations.
To construct, see NOTES section for DATASOURCESYSLOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ISyslogDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceWindowsEventLog
The list of Windows Event Log data source configurations.
To construct, see NOTES section for DATASOURCEWINDOWSEVENTLOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IWindowsEventLogDataSource[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataSourceWindowsFirewallLog
The list of Windows Firewall logs source configurations.
To construct, see NOTES section for DATASOURCEWINDOWSFIREWALLLOG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IWindowsFirewallLogsDataSource[]
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationEventHub
List of Event Hubs destinations.
To construct, see NOTES section for DESTINATIONEVENTHUB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IEventHubDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationEventHubsDirect
List of Event Hubs Direct destinations.
To construct, see NOTES section for DESTINATIONEVENTHUBSDIRECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IEventHubDirectDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationLogAnalytic
List of Log Analytics destinations.
To construct, see NOTES section for DESTINATIONLOGANALYTIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.ILogAnalyticsDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationMonitoringAccount
List of monitoring account destinations.
To construct, see NOTES section for DESTINATIONMONITORINGACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IMonitoringAccountDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageAccount
List of storage accounts destinations.
To construct, see NOTES section for DESTINATIONSTORAGEACCOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestination[]
Parameter Sets: (All)
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
To construct, see NOTES section for DESTINATIONSTORAGEBLOBSDIRECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageBlobDestination[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationStorageTablesDirect
List of Storage Table Direct destinations.
To construct, see NOTES section for DESTINATIONSTORAGETABLESDIRECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IStorageTableDestination[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
The kind of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.IDataCollectionRuleResource

## NOTES

## RELATED LINKS

