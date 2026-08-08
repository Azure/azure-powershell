---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/remove-aztrafficmanagertrafficmanagerusermetricskey
schema: 2.0.0
---

# Remove-AzTrafficManagerTrafficManagerUserMetricsKey

## SYNOPSIS
Delete a subscription-level key used for Real User Metrics collection.

## SYNTAX

```
Remove-AzTrafficManagerTrafficManagerUserMetricsKey -SubscriptionId <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Delete a subscription-level key used for Real User Metrics collection.

## EXAMPLES

### Example 1: Delete the Real User Metrics key
```powershell
Remove-AzTrafficManagerTrafficManagerUserMetricsKey
```

Deletes the subscription-level key used for Real User Metrics (RUM) collection. After deletion, RUM data will no longer be collected.

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

### Az.TrafficManager.Models.IDeleteOperationResult

## NOTES

## RELATED LINKS

