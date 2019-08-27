---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-aztenantactivitylog
schema: 2.0.0
---

# Get-AzTenantActivityLog

## SYNOPSIS
Gets the Activity Logs for the Tenant.
Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).
One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

## SYNTAX

### List (Default)
```
Get-AzTenantActivityLog [-Caller <String>] [-EndTime <DateTime>] [-EventChannel <String>]
 [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### CorrelationId
```
Get-AzTenantActivityLog -CorrelationId <String> [-Caller <String>] [-EndTime <DateTime>]
 [-EventChannel <String>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ResourceGroupName
```
Get-AzTenantActivityLog -ResourceGroupName <String> [-Caller <String>] [-EndTime <DateTime>]
 [-EventChannel <String>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzTenantActivityLog -ResourceId <String> [-Caller <String>] [-EndTime <DateTime>] [-EventChannel <String>]
 [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ResourceProvider
```
Get-AzTenantActivityLog -ResourceProvider <String> [-Caller <String>] [-EndTime <DateTime>]
 [-EventChannel <String>] [-StartTime <DateTime>] [-Status <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the Activity Logs for the Tenant.
Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).
One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.

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

### -EventChannel
The event channel.
Possible values are 'Admin' and 'Operation'

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData

## ALIASES

## NOTES

## RELATED LINKS

