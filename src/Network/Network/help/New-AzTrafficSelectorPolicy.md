---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-aztrafficselectorpolicy
schema: 2.0.0
---

# New-AzTrafficSelectorPolicy

## SYNOPSIS
Creates a traffic selector policy.

## SYNTAX

```
New-AzTrafficSelectorPolicy -LocalAddressRanges <string[]> -RemoteAddressRanges <string[]>
```

## DESCRIPTION
The New-AzTrafficSelectorPolicy cmdlet creates a traffic selector policy proposal to be used in a virtual network gateway connection.

## EXAMPLES

### Example 1
```
PS C:\> $trafficSelectorPolicy = New-AzTrafficSelectorPolicy -LocalAddressRanges ("10.10.10.0/24", "20.20.20.0/24") -RemoteAddressRanges ("30.30.30.0/24", "40.40.40.0/24")
PS C:\> New-AzVirtualNetworkGatewayConnection -ResourceGroupName $rgname -name $vnetConnectionName -location $location -VirtualNetworkGateway1 $vnetGateway -LocalNetworkGateway2 $localnetGateway -ConnectionType IPsec -RoutingWeight 3 -SharedKey $sharedKey -UsePolicyBasedTrafficSelectors $true -TrafficSelectorPolicies ($trafficSelectorPolicy)
```

Creating an traffic selector policy to be used for a new virtual network gateway connection.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -LocalAddressRanges
A collection of address spaces in CIDR where traffic originates from.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalAddressRanges
A collection of address spaces in CIDR where traffic originates from.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteAddressRanges
A collection of address spaces in CIDR where traffic is destined to.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSTrafficSelectorPolicy

## NOTES

## RELATED LINKS
