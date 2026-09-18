---
external help file:
Module Name: Az.DynatraceObservability
online version: https://learn.microsoft.com/powershell/module/az.dynatraceobservability/get-azdynatracemonitoredsubscription
schema: 2.0.0
---

# Get-AzDynatraceMonitoredSubscription

## SYNOPSIS
List the subscriptions currently being monitored by the Dynatrace monitor resource.

## SYNTAX

### Get (Default)
```
Get-AzDynatraceMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDynatraceMonitoredSubscription -InputObject <IDynatraceObservabilityIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDynatraceMonitoredSubscription -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List the subscriptions currently being monitored by the Dynatrace monitor resource.

## EXAMPLES

### Example 1: List all monitored subscriptions for a Dynatrace monitor
```powershell
$subs = Get-AzDynatraceMonitoredSubscription -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup"
$subs
```

Returns all subscription monitoring entries (status, subscriptionId, log/metric rule flags) for the specified Dynatrace monitor resource.

### Example 2: Retrieve monitoring status for a specific subscription
```powershell
$subId = (Get-AzContext).Subscription.Id
Get-AzDynatraceMonitoredSubscription -MonitorName "myDynatraceMonitor" -ResourceGroupName "myResourceGroup" -SubscriptionId $subId
```

Filters the result to the provided subscription Id to quickly inspect its monitoring status and related rule settings.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IDynatraceObservabilityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.IMonitoredSubscriptionProperties

## NOTES

## RELATED LINKS

