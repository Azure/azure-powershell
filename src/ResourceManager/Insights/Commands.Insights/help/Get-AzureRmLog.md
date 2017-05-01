---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
ms.assetid: 85492E00-3776-4F20-A444-9C28CC6154B7
online version: 
schema: 2.0.0
---

# Get-AzureRmLog

## SYNOPSIS
Gets a log of events.

## SYNTAX

### Query on CorrelationId
```
Get-AzureRmLog [-StartTime <DateTime>] [-EndTime <DateTime>] [-Status <String>] [-Caller <String>]
 [-DetailedOutput] [-CorrelationId] <String> [-MaxEvents <Int32>] [<CommonParameters>]
```

### Query on ResourceIdName
```
Get-AzureRmLog [-StartTime <DateTime>] [-EndTime <DateTime>] [-Status <String>] [-Caller <String>]
 [-DetailedOutput] [-ResourceId] <String> [-MaxEvents <Int32>] [<CommonParameters>]
```

### Query on ResourceGroupProvider
```
Get-AzureRmLog [-StartTime <DateTime>] [-EndTime <DateTime>] [-Status <String>] [-Caller <String>]
 [-DetailedOutput] [-ResourceGroup] <String> [-MaxEvents <Int32>] [<CommonParameters>]
```

### Query on ResourceProvider
```
Get-AzureRmLog [-StartTime <DateTime>] [-EndTime <DateTime>] [-Status <String>] [-Caller <String>]
 [-DetailedOutput] [-ResourceProvider] <String> [-MaxEvents <Int32>] [<CommonParameters>]
```

### Query at subscription level
```
Get-AzureRmLog [-StartTime <DateTime>] [-EndTime <DateTime>] [-Status <String>] [-Caller <String>]
 [-DetailedOutput] [-MaxEvents <Int32>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmLog** cmdlet gets a log of events.
The events can be associated with the current subscription ID, correlation ID, resource group, resource ID, or resource provider.

## EXAMPLES

### Example 1: Get an event log by subscription ID
```
PS C:\>Get-AzureRmLog
```

This command lists all the events associated with the user's subscription ID that took place in the last hour.

### Example 2: Get an event log by subscription ID with a maximum number of events
```
PS C:\>Get-AzureRmLog -MaxEvents 100
```

This command lists a maximum of 100 events associated with the user's subscription ID that took place in the last hour.

### Example 3: Get an event log by subscription ID with a start time
```
PS C:\>Get-AzureRmLog -StartTime 2015-01-01T10:30
```

This command lists all of the events associated with the user's subscription ID that took place on or after 2015-01-01T10:30 local time.

### Example 4: Get an event log by subscription ID with a start time and end time
```
PS C:\>Get-AzureRmLog -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

This command lists all of the events associated with the user's subscription ID that took place on or after 2015-01-01T10:30 local time, and before 2015-01-01T11:30 local time.

### Example 5: Get an event log by correlation ID
```
PS C:\>Get-AzureRmLog -CorrelationId "60c694d0-e46f-4c12-bed1-9b7aef541c23"
```

This command lists all the events associated with the specified correlation ID that took place in the last hour.

### Example 6: Get an event log by correlation ID with a maximum number of events
```
PS C:\>Get-AzureRmLog -CorrelationId "60c694d0-e46f-4c12-bed1-9b7aef541c23" -MaxEvents 100
```

This command lists a maximum of 100 events associated with the specified correlation ID that took place in the last hour.

### Example 7: Get an event log by correlation ID and start time
```
PS C:\>Get-AzureRmLog -CorrelationId "60c694d0-e46f-4c12-bed1-9b7aef541c23" -StartTime 2015-01-15T04:30:00
```

This command lists all the events associated with the specified correlation ID that took place on or after 2015-01-01T10:30 local time.

### Example 8: Get an event log by correlation ID with start time and end time
```
PS C:\>Get-AzureRmLog -CorrelationId "60c694d0-e46f-4c12-bed1-9b7aef541c23" -StartTime 2015-01-15T04:30:00 -EndTime 2015-01-15T12:30:00
```

This command lists all the events associated with the specified correlation ID that took place on or after 2015-01-01T10:30 local time, but before 2015-01-01T11:30 local time.

### Example 9: Get an event log for a resource group
```
PS C:\>Get-AzureRmLog -ResourceGroup "Contoso-Web-CentralUS"
```

This command lists all the events associated with the specified resource group that took place in the last hour.

### Example 10: Get an event log for a resource group with a maximum number of events
```
PS C:\>Get-AzureRmLog -ResourceGroup "Contoso-Web-CentralUS" -MaxEvents 100
```

This command lists a maximum of 100 events associated with the specified resource group that took place in the last hour.

### Example 11: Get an event log for a resource group by start time
```
PS C:\>Get-AzureRmLog -ResourceGroup "Contoso-Web-CentralUS" -StartTime 2015-01-01T10:30
```

This command lists all the events associated with the specified resource group that took place on or after 2015-01-01T10:30 local time.

### Example 12: Get an event log for a resource group with a start time and end time
```
PS C:\>Get-AzureRmLog -ResourceGroup "Contoso-Web-CentralUS" -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

This command lists all the events associated with the specified resource group that took place on or after 2015-01-01T10:30 local time, but before 2015-01-01T11:30 local time.

### Example 13: Get an event log by resource ID
```
PS C:\>Get-AzureRmLog -ResourceId "/subscriptions/623d50f1-4fa8-4e46-a967-a9214aed43ab/ResourceGroups/Contoso-Web-CentralUS/providers/Microsoft.Web/ServerFarms/Contoso1"
```

This command lists all the events associated with the specified resource ID that took place in the last hour.

### Example 14: Get an event log by resource ID with a maximum number of events
```
PS C:\>Get-AzureRmLog -ResourceId "/subscriptions/623d50f1-4fa8-4e46-a967-a9214aed43ab/ResourceGroups/Contoso-Web-CentralUS/providers/Microsoft.Web/ServerFarms/Contoso1" -MaxEvents 100
```

This command lists maximum of 100 events associated with the specified resource ID that took place in the last hour.

### Example 15: Get an event log by resource ID with a start time
```
PS C:\>Get-AzureRmLog -ResourceId "/subscriptions/623d50f1-4fa8-4e46-a967-a9214aed43ab/ResourceGroups/Contoso-Web-CentralUS/providers/Microsoft.Web/ServerFarms/Contoso1" -StartTime 2015-01-01T10:30
```

This command lists all the events associated with the specified resource ID that took place on or after 2015-01-01T10:30 local time.

### Example 16: Get an event log by resource ID with a start time and end time
```
PS C:\>Get-AzureRmLog -ResourceId "/subscriptions/623d50f1-4fa8-4e46-a967-a9214aed43ab/ResourceGroups/Contoso-Web-CentralUS/providers/Microsoft.Web/ServerFarms/Contoso1" -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

This command lists all the events associated with the specified resource ID that took place on or after 2015-01-01T10:30 local time, but before 2015-01-01T11:30 local time.

### Example 17: Get an event log by resource provider
```
PS C:\>Get-AzureRmLog -ResourceProvider "Microsoft.Web"
```

This command lists all the events associated with the specified resource provider that took place in the last hour.

### Example 18: Get an event log by resource provider with a maximum number of events
```
PS C:\>Get-AzureRmLog -ResourceProvider "Microsoft.Web" -MaxEvents 100
```

This command lists maximum of 100 events associated with the specified resource provider that took place in the last hour.

### Example 19: Get an event log by resource provider with a start time
```
PS C:\>Get-AzureRmLog -ResourceProvider "Microsoft.Web" -StartTime 2015-01-01T10:30
```

This command lists all the events associated with the specified resource provider that took place on or after 2015-01-01T10:30 local time.

### Example 20: Get an event log by resource provider with a start time and end time
```
PS C:\>Get-AzureRmLog -ResourceProvider "Microsoft.Web" -StartTime 2015-01-01T10:30 -EndTime 2015-01-01T11:30
```

This command lists all the events associated with the specified resource provider that took place on or after 2015-01-01T10:30 local time, but before 2015-01-01T11:30 local time.

## PARAMETERS

### -Caller
Specifies a caller.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CorrelationId
Specifies the correlation ID.
This parameter is required.

```yaml
Type: String
Parameter Sets: Query on CorrelationId
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DetailedOutput
Indicates that this cmdlet displays detailed output.
By default, output is summarized.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EndTime
Specifies the end time of the query in local time.
The default value is the current time.
The value must be later than *StartTime*, but not by more than 15 days.

You can use the Get-Date cmdlet to get a **DateTime** object.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxEvents
Specifies the total number of events to fetch for the specified filter.
The default value is 1000.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
Specifies the name of the resource group.

```yaml
Type: String
Parameter Sets: Query on ResourceGroupProvider
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Specifies the resource ID.

```yaml
Type: String
Parameter Sets: Query on ResourceIdName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceProvider
Specifies a filter by resource provider.

```yaml
Type: String
Parameter Sets: Query on ResourceProvider
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the start time of the query in local time.
The default value is *EndTime* minus one hour.

You can use the Get-Date cmdlet to get a **DateTime** object.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Status
Specifies the status.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### None

## NOTES

## RELATED LINKS

