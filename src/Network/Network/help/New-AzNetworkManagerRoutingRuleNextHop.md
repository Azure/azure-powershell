---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkmanagerroutingrulenexthop
schema: 2.0.0
---

# New-AzNetworkManagerRoutingRuleNextHop

## SYNOPSIS
Creates a network manager routing rule next hop.

## SYNTAX

```
New-AzNetworkManagerRoutingRuleNextHop [-NextHopAddress <String>] -NextHopType <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerRoutingRuleNextHop** cmdlet creates a network manager routing rule next hop.

## EXAMPLES

### Example 1
```powershell
New-AzNetworkManagerRoutingRuleNextHop -NextHopAddress "ApiManagement" -NextHopType "ServiceTag"
```

```output
NextHopAddress	   NextHopType
------------------ -----------------
ApiManagement      ServiceTag
```

Creates a network manager service tag routing rule next hop.

### Example 2
```powershell
New-AzNetworkManagerRoutingRuleNextHop -NextHopAddress "10.0.0.1" -NextHopType "AddressPrefix"
```

```output
NextHopAddress	   NextHopType
------------------ -----------------
10.0.0.1		   AddressPrefix
```

Creates a network manager routing rule next hop object.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextHopAddress
NextHopAddress

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextHopType
NextHopAddress NextHopType.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Internet, NoNextHop, VirtualAppliance, VirtualNetworkGateway, VnetLocal

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerRoutingRuleDestination

## NOTES

## RELATED LINKS
