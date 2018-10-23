---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/remove-azurermdelegation
schema: 2.0.0
---

# Remove-AzureRmDelegation

## SYNOPSIS
Removes a service delegation from the provided subnet.

## SYNTAX

```
Remove-AzureRmDelegation -Name <String> -Subnet <PSSubnet> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmDelegation** cmdlet takes in a Subnet with delegations and removes the named delegation from that subnet.

## EXAMPLES

### Example 1
```powershell
# Add a delegation to an existing subnet
PS C:\> $vnet = Get-AzureRmVirtualNetwork -Name "myVNet" -ResourceGroupName "myResourceGroup"
PS C:\> $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "mySubnet" -VirtualNetwork $vnet
PS C:\> $subnet = Add-AzureRmDelegation -Name "myDelegation" -ServiceName "Microsoft.Sql/servers" -Subnet $subnet
PS C:\> Set-AzureRmVirtualNetwork $vnet

# Remove the delegation
PS C:\> $vnet = Get-AzureRmVirtualNetwork -Name "myVNet" -ResourceGroupName "myResourceGroup"
PS C:\> $subnet = Get-AzureRmVirtualNetworkSubnetConfig -Name "mySubnet" -VirtualNetwork $vnet
PS C:\> $subnet = Remove-AzureRmDelegation -Name "myDelegation" -Subnet $subnet
PS C:\> Set-AzureRmVirtualNetwork $vnet
```

In this example, the first half (found under _"Add a delegation to an existing subnet"_) is identical to [Add-AzureRmDelegation](./Add-AzureRmDelegation.md). In the second half, the first two cmdlets retrieve the subnet of interest, refreshing the local copy with what's on the server. The third cmdlet removes the delegation that was created in the first half from _mySubnet_ and stores the updated subnet in _$subnet_. The final cmdlet updates the server with the removed delegation.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the delegation

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

### -ServiceName
The name of the service to which the subnet should be delegated

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

### -Subnet
The subnet from which to remove the delegation

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSSubnet
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSSubnet
### System.String
## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSSubnet
## NOTES

## RELATED LINKS

[Add-AzureRmDelegation](./Add-AzureRmDelegation.md)
[Get-AzureRmDelegation](./Get-AzureRmDelegation.md)
[New-AzureRmDelegation](./New-AzureRmDelegation.md)
[Get-AzureRmVirtualNetwork](./Get-AzureRmVirtualNetwork.md)
[Get-AzureRmVirtualNetworkSubnetConfig](./Get-AzureRmVirtualNetworkSubnetConfig.md)
[Set-AzureRmVirtualNetwork](./Set-AzureRmVirtualNetwork.md)