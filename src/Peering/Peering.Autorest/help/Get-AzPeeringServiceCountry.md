---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringservicecountry
schema: 2.0.0
---

# Get-AzPeeringServiceCountry

## SYNOPSIS
Lists all of the available countries for peering service.

## SYNTAX

```
Get-AzPeeringServiceCountry [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the available countries for peering service.

## EXAMPLES

### Example 1: Lists all the peering service countries
```powershell
Get-AzPeeringServiceCountry
```

```output
Name
----
Australia
Belgium
Brazil
Canada
Denmark
Finland
France
Germany
Hong Kong
Japan
Kenya
Korea, South
Malaysia
Netherlands
New Zealand
...
```

Lists the countries available for peering service.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IResource

## NOTES

## RELATED LINKS

