---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringcdnprefix
schema: 2.0.0
---

# Get-AzPeeringCdnPrefix

## SYNOPSIS
Lists all of the advertised prefixes for the specified peering location

## SYNTAX

```
Get-AzPeeringCdnPrefix [-SubscriptionId <String[]>] -PeeringLocation <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all of the advertised prefixes for the specified peering location

## EXAMPLES

### Example 1: Get Cdn prefixes
```powershell
Get-AzPeeringCdnPrefix -PeeringLocation Seattle
```

```output
Prefix          AzureRegion AzureService IsPrimaryRegion BgpCommunity
------          ----------- ------------ --------------- ------------
20.157.110.0/24 West US 2   AzureCompute True            8069:51026
20.157.118.0/24 West US 2   AzureCompute True            8069:51026
20.157.125.0/24 West US 2   AzureCompute True            8069:51026
20.157.180.0/24 West US 2   AzureStorage True            8069:52026
20.157.25.0/24  West US 2   AzureCompute True            8069:51026
20.157.50.0/23  West US 2   AzureStorage True            8069:52026
20.47.120.0/23  West US 2   AzureCompute True            8069:51026
20.47.62.0/23   West US 2   AzureStorage True            8069:52026
```

Get all cdn prefixes for subscription

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

### -PeeringLocation
The peering location.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.ICdnPeeringPrefix

## NOTES

## RELATED LINKS
