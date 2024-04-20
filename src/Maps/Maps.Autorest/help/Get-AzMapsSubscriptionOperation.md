---
external help file:
Module Name: Az.Maps
online version: https://learn.microsoft.com/powershell/module/az.maps/get-azmapssubscriptionoperation
schema: 2.0.0
---

# Get-AzMapsSubscriptionOperation

## SYNOPSIS
List operations available for the Maps Resource Provider

## SYNTAX

```
Get-AzMapsSubscriptionOperation [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
List operations available for the Maps Resource Provider

## EXAMPLES

### Example 1: List operations available for the Maps Resource Provider
```powershell
Get-AzMapsSubscriptionOperation
```

```output
IsDataAction Name                                                                          Origin
------------ ----                                                                          ------
             Microsoft.Maps/resourceTypes/read
             Microsoft.Maps/unregister/action
             Microsoft.Maps/operations/read
             Microsoft.Maps/register/action
             Microsoft.Maps/accounts/write
             Microsoft.Maps/accounts/read
             Microsoft.Maps/accounts/delete
             Microsoft.Maps/accounts/listKeys/action
             Microsoft.Maps/accounts/regenerateKey/action
             Microsoft.Maps/accounts/eventGridFilters/delete
             Microsoft.Maps/accounts/eventGridFilters/read
             Microsoft.Maps/accounts/eventGridFilters/write
             Microsoft.Maps/accounts/providers/Microsoft.Insights/metricDefinitions/read   system
             Microsoft.Maps/accounts/providers/Microsoft.Insights/diagnosticSettings/read  system
             Microsoft.Maps/accounts/providers/Microsoft.Insights/diagnosticSettings/write system
True         Microsoft.Maps/accounts/services/render/read
True         Microsoft.Maps/accounts/services/geolocation/read
True         Microsoft.Maps/accounts/services/mobility/read
True         Microsoft.Maps/accounts/services/route/read
True         Microsoft.Maps/accounts/services/search/read
True         Microsoft.Maps/accounts/services/timezone/read
True         Microsoft.Maps/accounts/services/traffic/read
True         Microsoft.Maps/accounts/services/weather/read
True         Microsoft.Maps/accounts/services/data/read
True         Microsoft.Maps/accounts/services/data/delete
True         Microsoft.Maps/accounts/services/data/write
True         Microsoft.Maps/accounts/services/spatial/read
True         Microsoft.Maps/accounts/services/spatial/write
True         Microsoft.Maps/accounts/services/turnbyturn/read
True         Microsoft.Maps/accounts/services/elevation/read
True         Microsoft.Maps/accounts/services/dataordering/read
True         Microsoft.Maps/accounts/services/dataordering/write
True         Microsoft.Maps/accounts/services/analytics/read
True         Microsoft.Maps/accounts/services/analytics/delete
True         Microsoft.Maps/accounts/services/analytics/write
             Microsoft.Maps/accounts/creators/write
             Microsoft.Maps/accounts/creators/read
             Microsoft.Maps/accounts/creators/delete
```

This command lists operations available for the Maps Resource Provider.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail

## NOTES

## RELATED LINKS

