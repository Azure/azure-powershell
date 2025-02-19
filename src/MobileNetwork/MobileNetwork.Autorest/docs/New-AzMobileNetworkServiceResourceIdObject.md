---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkServiceResourceIdObject
schema: 2.0.0
---

# New-AzMobileNetworkServiceResourceIdObject

## SYNOPSIS
Create an in-memory object for ServiceResourceId.

## SYNTAX

```
New-AzMobileNetworkServiceResourceIdObject -Id <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServiceResourceId.

## EXAMPLES

### Example 1: Create an in-memory object for ServiceResourceId.
```powershell
New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service"
```

```output
Id
--
/subscriptions/{subId}/resourceGroups/azps_test_group/providers/Microsoft.MobileNetwork/mobileNetworks/azps-mn/services/azps-mn-service
```

Create an in-memory object for ServiceResourceId.

## PARAMETERS

### -Id
Service resource ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ServiceResourceId

## NOTES

## RELATED LINKS

