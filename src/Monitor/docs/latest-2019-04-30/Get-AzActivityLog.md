---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-azactivitylog
schema: 2.0.0
---

# Get-AzActivityLog

## SYNOPSIS
Provides the list of records from the activity logs.

## SYNTAX

### List (Default)
```
Get-AzActivityLog [-SubscriptionId <String[]>] [-Caller <String>] [-EndTime <DateTime>]
 [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CorrelationId
```
Get-AzActivityLog -CorrelationId <String> [-SubscriptionId <String[]>] [-Caller <String>]
 [-EndTime <DateTime>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ResourceGroupName
```
Get-AzActivityLog -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Caller <String>]
 [-EndTime <DateTime>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzActivityLog -ResourceId <String> [-SubscriptionId <String[]>] [-Caller <String>] [-EndTime <DateTime>]
 [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ResourceProvider
```
Get-AzActivityLog -ResourceProvider <String> [-SubscriptionId <String[]>] [-Caller <String>]
 [-EndTime <DateTime>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Provides the list of records from the activity logs.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Caller
The Caller of the events to fetch

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorrelationId
The Correlation ID

```yaml
Type: System.String
Parameter Sets: CorrelationId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EndTime
The end time filter for the events

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The Resource group name

```yaml
Type: System.String
Parameter Sets: ResourceGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceId
The Resource ID

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceProvider
The Resource Provider name

```yaml
Type: System.String
Parameter Sets: ResourceProvider
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StartTime
The start time filter for the events

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Status
The Status of the events to fetch

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The Azure subscription Id.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData

## ALIASES

### Get-AzLog

## NOTES

## RELATED LINKS

