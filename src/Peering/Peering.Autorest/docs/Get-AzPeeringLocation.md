---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringlocation
schema: 2.0.0
---

# Get-AzPeeringLocation

## SYNOPSIS
Lists all of the available peering locations for the specified kind of peering.

## SYNTAX

```
Get-AzPeeringLocation -Kind <PeeringLocationsKind> [-SubscriptionId <String[]>]
 [-DirectPeeringType <PeeringLocationsDirectPeeringType>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the available peering locations for the specified kind of peering.

## EXAMPLES

### Example 1: Get all direct peering locations
```powershell
Get-AzPeeringLocation -Kind Direct
```

```output
Get-AzPeeringLocation -Kind Direct

Name             Country AzureRegion         Kind
----             ------- -----------         ----
Amsterdam        NL      West Europe         Direct
Ashburn          US      East US             Direct
Athens           GR      France Central      Direct
Atlanta          US      East US 2           Direct
Auckland         NZ      Australia East      Direct
Barcelona        ES      France Central      Direct
Berlin           DE      West Europe         Direct
...
```

Gets all peering locations for direct peers

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

### -DirectPeeringType
The type of direct peering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.PeeringLocationsDirectPeeringType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the peering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.PeeringLocationsKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringLocation

## NOTES

## RELATED LINKS

