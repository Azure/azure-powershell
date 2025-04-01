---
external help file: Az.TimeSeriesInsights-help.xml
Module Name: Az.TimeSeriesInsights
online version: https://learn.microsoft.com/powershell/module/az.timeseriesinsights/new-aztimeseriesinsightseventsource
schema: 2.0.0
---

# New-AzTimeSeriesInsightsEventSource

## SYNOPSIS
create an event source under the specified environment.

## SYNTAX

### eventhub (Default)
```
New-AzTimeSeriesInsightsEventSource -Name <String> -EnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Kind <String> -Location <String> [-Tag <Hashtable>] -ConsumerGroupName <String>
 -EventHubName <String> -KeyName <String> -EventSourceResourceId <String> -ServiceBusNameSpace <String>
 -SharedAccessKey <SecureString> [-TimeStampPropertyName <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzTimeSeriesInsightsEventSource -Name <String> -EnvironmentInputObject <ITimeSeriesInsightsIdentity>
 -Kind <String> -Location <String> [-LocalTimestampFormat <String>] [-Tag <Hashtable>]
 [-TimeZoneOffsetPropertyName <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### iothub
```
New-AzTimeSeriesInsightsEventSource -Name <String> -EnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Kind <String> -Location <String> [-Tag <Hashtable>] -ConsumerGroupName <String>
 -KeyName <String> -EventSourceResourceId <String> -SharedAccessKey <SecureString>
 [-TimeStampPropertyName <String>] -IoTHubName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzTimeSeriesInsightsEventSource -Name <String> -EnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzTimeSeriesInsightsEventSource -Name <String> -EnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create an event source under the specified environment.

## EXAMPLES

### Example 1: Create an eventhub event source under the specified environment
```powershell
New-AzEventHubNamespace -Name spacename002 -ResourceGroupName testgroup -Location eastus
$ev = New-AzEventHub -ResourceGroupName testgroup -NamespaceName spacename002 -Name hubname001 -MessageRetentionInDays 3 -PartitionCount 2
$ks = Get-AzEventHubKey -ResourceGroupName testgroup -NamespaceName spacename002 -AuthorizationRuleName RootManageSharedAccessKey
$k  = $ks.PrimaryKey | ConvertTo-SecureString -AsPlainText -Force
New-AzTimeSeriesInsightsEventSource -ResourceGroupName testgroup -Name estest001 -EnvironmentName tsitest001 -Kind Microsoft.EventHub -ConsumerGroupName testgroup -Location eastus -KeyName RootManageSharedAccessKey -ServiceBusNameSpace spacename002 -EventHubName hubname001 -EventSourceResourceId $ev.id -SharedAccessKey $k
```

```output
Kind               Location Name      Type
----               -------- ----      ----
Microsoft.EventHub eastus   estest001 Microsoft.TimeSeriesInsights/Environments/EventSources
```

This command creates an eventhub event source under the specified environment.

### Example 2: Create an iothub event source under the specified environment
```powershell
$ev = New-AzIotHub -ResourceGroupName testgroup -Location eastus -Name iotname001 -SkuName S1 -Units 100
$ks = Get-AzIotHubKey -ResourceGroupName testgroup -Name iotname001
$k  = $ks[0].PrimaryKey | ConvertTo-SecureString -AsPlainText -Force
New-AzTimeSeriesInsightsEventSource -ResourceGroupName testgroup -Name iots001 -EnvironmentName tsitest001 -Kind Microsoft.IoTHub -ConsumerGroupName testgroup -Location eastus -KeyName RootManageSharedAccessKey -IoTHubName iotname001 -EventSourceResourceId $ev.id -SharedAccessKey $k
```

```output
Location Name    Type                                                   Kind
-------- ----    ----                                                   ----
eastus   iots001 Microsoft.TimeSeriesInsights/Environments/EventSources Microsoft.IoTHub
```

This command creates an iothub event source under the specified environment.

## PARAMETERS

### -ConsumerGroupName
The name of the event/iot hub's consumer group that holds the partitions from which events will be read.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub
Aliases:

Required: True
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

### -EnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.ITimeSeriesInsightsIdentity
Parameter Sets: CreateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EnvironmentName
The name of the Time Series Insights environment associated with the specified resource group.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubName
The name of the event hub.

```yaml
Type: System.String
Parameter Sets: eventhub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSourceResourceId
The resource id of the event source in Azure Resource Manager.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IoTHubName
The name of the iot hub.

```yaml
Type: System.String
Parameter Sets: iothub
Aliases:

Required: True
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

### -KeyName
The name of the SAS key that grants the Time Series Insights service access to the event/iot hub.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the event source.

```yaml
Type: System.String
Parameter Sets: eventhub, CreateViaIdentityEnvironmentExpanded, iothub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalTimestampFormat
An enum that represents the format of the local timestamp property that needs to be set.

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityEnvironmentExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.

```yaml
Type: System.String
Parameter Sets: eventhub, CreateViaIdentityEnvironmentExpanded, iothub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the event source.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EventSourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of an Azure Resource group.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceBusNameSpace
The name of the service bus that contains the event hub.

```yaml
Type: System.String
Parameter Sets: eventhub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedAccessKey
The value of the shared access key that grants the Time Series Insights service read access to the event/iot hub.

```yaml
Type: System.Security.SecureString
Parameter Sets: eventhub, iothub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Key-value pairs of additional properties for the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: eventhub, CreateViaIdentityEnvironmentExpanded, iothub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeStampPropertyName
The event property that will be used as the event source's timestamp.

```yaml
Type: System.String
Parameter Sets: eventhub, iothub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZoneOffsetPropertyName
The event property that will be contain the offset information to calculate the local timestamp.
When the LocalTimestampFormat is Iana, the property name will contain the name of the column which contains IANA Timezone Name (eg: Americas/Los Angeles).
When LocalTimestampFormat is Timespan, it contains the name of property which contains values representing the offset (eg: P1D or 1.00:00:00)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityEnvironmentExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.ITimeSeriesInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.IEventSourceResource

## NOTES

## RELATED LINKS
