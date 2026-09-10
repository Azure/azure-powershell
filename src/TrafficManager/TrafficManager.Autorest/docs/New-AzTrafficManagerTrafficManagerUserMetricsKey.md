---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/new-aztrafficmanagertrafficmanagerusermetricskey
schema: 2.0.0
---

# New-AzTrafficManagerTrafficManagerUserMetricsKey

## SYNOPSIS
Create a subscription-level key used for Real User Metrics collection.

## SYNTAX

```
New-AzTrafficManagerTrafficManagerUserMetricsKey -SubscriptionId <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a subscription-level key used for Real User Metrics collection.

## EXAMPLES

### Example 1: Create a Real User Metrics key
```powershell
New-AzTrafficManagerTrafficManagerUserMetricsKey
```

```output
Key  : 00000000000000000000000000000000
Name : default
```

Creates a new subscription-level key for Real User Metrics (RUM) collection. If a key already exists, it is regenerated.

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

### Az.TrafficManager.Models.IUserMetricsModel

## NOTES

## RELATED LINKS

