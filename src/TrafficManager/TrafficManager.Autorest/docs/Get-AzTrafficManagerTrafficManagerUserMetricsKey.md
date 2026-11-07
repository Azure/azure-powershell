---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/get-aztrafficmanagertrafficmanagerusermetricskey
schema: 2.0.0
---

# Get-AzTrafficManagerTrafficManagerUserMetricsKey

## SYNOPSIS
Get the subscription-level key used for Real User Metrics collection.

## SYNTAX

```
Get-AzTrafficManagerTrafficManagerUserMetricsKey -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Get the subscription-level key used for Real User Metrics collection.

## EXAMPLES

### Example 1: Get the Real User Metrics key
```powershell
Get-AzTrafficManagerTrafficManagerUserMetricsKey
```

```output
Key  : 00000000000000000000000000000000
Name : default
```

Gets the subscription-level key used for Real User Metrics (RUM) collection.

## PARAMETERS

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Az.TrafficManager.Models.IUserMetricsModel

## NOTES

## RELATED LINKS

