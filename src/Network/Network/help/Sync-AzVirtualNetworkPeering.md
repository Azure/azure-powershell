---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/sync-azvirtualnetworkpeering
schema: 2.0.0
---

# Sync-AzVirtualNetworkPeering

## SYNOPSIS
Command to sync the address space on the peering link if the remote virtual network has a new address space.

## SYNTAX

### Fields (Default)
```
Sync-AzVirtualNetworkPeering -VirtualNetworkName <String> -ResourceGroupName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Object
```
Sync-AzVirtualNetworkPeering -VirtualNetworkPeering <PSVirtualNetworkPeering>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updating the address space on peered virtual networks is now supported. However, to sync the latest address space on the peering link, this commandlet needs to be called on the (peered) remote virtual network. When invoked, it would sync the address space on the peering link with the latest address space of the (peered) remote virtual network.

## EXAMPLES

### Example 1
```powershell
Sync-AzVirtualNetworkPeering -Name 'peering2' -VirtualNetworkName 'vnet1' -ResourceGroupName 'rg1'
```

Syncs the address space on the peering, peering2 in the virtual network, vnet1 within the resource group, rg1.

### Example 2
```powershell
$s1h1 = Get-AzVirtualNetworkPeering -Name 'spoke1-hub1' -VirtualNetworkName 'spoke1' -ResourceGroupName 'HUB1-RG'
$s1h1 | Sync-AzVirtualNetworkPeering
```

The first commandlet gets the virtual network peering. The second piped commandlet applies the sync operation on the peering.

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

### -Name
The virtual network peering name.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkName
The virtual network name.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkPeering
The virtual network peering

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkPeering
Parameter Sets: Object
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkPeering

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkPeering

## NOTES

## RELATED LINKS

[Add-AzVirtualNetworkPeering](./Add-AzVirtualNetworkPeering.md)

[Get-AzVirtualNetworkPeering](./Get-AzVirtualNetworkPeering.md)

[Remove-AzVirtualNetworkPeering](./Remove-AzVirtualNetworkPeering.md)

[Set-AzVirtualNetworkPeering](./Set-AzVirtualNetworkPeering.md)
