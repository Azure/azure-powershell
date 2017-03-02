---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkGatewayBgpPeerStatus

## SYNOPSIS
Retrieves status information for a virtual network gateway's BGP peers

## SYNTAX

```
Get-AzureRmVirtualNetworkGatewayBgpPeerStatus -VirtualNetworkGatewayName <String> -ResourceGroupName <String>
 [-Peer <String>] [<CommonParameters>]
```

## DESCRIPTION
Enumerates BGP peers for a virtual network gateway, and gives information on each peer's status. 

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVirtualNetworkGatewayBgpPeerStatus -ResourceGroupName "resourceGroup" -VirtualNetworkGatewayName "gatewayName"
```

Displays a list of BGP peers configured for the gateway named "gatewayName" in resource group "resourceGroup"

## PARAMETERS

### -Peer
IP of the peer to retrieve status for

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Virtual network gateway resource group's name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
Virtual network gateway name

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBgpPeerStatus

## NOTES

## RELATED LINKS

