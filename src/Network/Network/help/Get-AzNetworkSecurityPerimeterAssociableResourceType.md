---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterassociableresourcetype
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterAssociableResourceType

## SYNOPSIS
Gets the list of resources that are onboarded with NSP.
These resources can be associated with a network security perimeter

## SYNTAX

```
Get-AzNetworkSecurityPerimeterAssociableResourceType -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of resources that are onboarded with NSP.
These resources can be associated with a network security perimeter

## EXAMPLES

### EXAMPLE 1
```
Get-AzNetworkSecurityPerimeterAssociableResourceType -Location eastus2euap
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of network security perimeter.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.IPerimeterAssociableResource
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterassociableresourcetype](https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterassociableresourcetype)

