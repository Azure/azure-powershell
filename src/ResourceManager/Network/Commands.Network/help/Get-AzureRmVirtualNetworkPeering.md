---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 463DDBA8-0F93-483D-A4B6-3B055968CDE8
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkPeering

## SYNOPSIS
Gets the virtual network peering.

## SYNTAX

```
Get-AzureRmVirtualNetworkPeering -VirtualNetworkName <String> -ResourceGroupName <String> [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmVirtualNetworkPeering** cmdlet gets the virtual network peering.

## EXAMPLES

### Example 1: Get a peering between two virtual networks
```
PS C:\>Get-AzureRmVirtualNetworkPeering -Name "LinkToVNet2" -VirtualNetwork "MyVirtualNetwork" -ResourceGroupName "MyResourceGroup"
```

This command gets a previously created virtual network peering named LinkToVNet2 located in MyVirtualNetwork in the resource group named MyResourceGroup.

## PARAMETERS

### -Name
Specifies the virtual network peering name.

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
Specifies the resource group name that the virtual network peering belongs to.

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

### -VirtualNetworkName
Specifies the virtual network name that this cmdlet gets.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkPeering

## NOTES

## RELATED LINKS

[Add-AzureRmVirtualNetworkPeering](./Add-AzureRmVirtualNetworkPeering.md)

[Remove-AzureRmVirtualNetworkPeering](./Remove-AzureRmVirtualNetworkPeering.md)

[Set-AzureRmVirtualNetworkPeering](./Set-AzureRmVirtualNetworkPeering.md)


