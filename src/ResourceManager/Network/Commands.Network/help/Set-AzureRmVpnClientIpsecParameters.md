---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermvpnclientipsecparameters
schema: 2.0.0
---

# Set-AzureRmVpnClientIpsecParameters

## SYNOPSIS
Sets the vpn ipsec parameters for existing virtual network gateway.

## SYNTAX

```
Set-AzureRmVpnClientIpsecParameters -VirtualNetworkGatewayName <String> -ResourceGroupName <String>
 -VpnClientIPsecParameters <PSVpnClientIPsecParameters> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmVpnClientIpsecParameters** cmdlet sets the vpn ipsec parameters for existing virtual network gateway.
When Virtual network gateway is created, it sets the set of default vpn ipsec policies on Gateway. In case, Point to site user wants to use certain custom ipsec policy to connect to VPN Gateway, user has to set that ipsec policy on VPN Gateway first. **Set-AzureRmVpnClientIpsecParameters** provides a way to do that.

## EXAMPLES

### Example 1 : Sets a custom vpn ipsec policy to existing virtual network gateway.
```powershell
PS C:\>$vpnclientipsecparams = New-AzureRmVpnClientIpsecParameters -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTimeSeconds 86473 -SADataSizeKilobytes 429498 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup2 -PfsGroup PFS2
PS C:\> $setvpnIpsecParams = Set-AzureRmVpnClientIpsecParameters -VirtualNetworkGatewayName "ContosoLocalGateway" -ResourceGroupName "ContosoResourceGroup" -VpnClientIPsecParameters $vpnclientipsecparams
```
This example sets custom vpn ipsec policy to existing virtual network gateway named ContosoVirtualGateway from Resource group named ContosoResourceGroup. The parameter:VpnClientIPsecParameters value can be constructed using PS command let:New-AzureRmVpnClientIpsecParameters as shown above.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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
The virtual network gateway name.

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

### -VpnClientIPsecParameters
Vpn client ipsec parameters. This parameter value can be constructed using PS command let:New-AzureRmVpnClientIpsecParameters

```yaml
Type: PSVpnClientIPsecParameters
Parameter Sets: (All)
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

###  
This cmdlet accepts pipelined instances of the **Microsoft.Azure.Commands.Network.Models.PSVpnClientIPsecParameters** object.

## OUTPUTS

###  
This cmdlet modifies existing instances of the **Microsoft.Azure.Commands.Network.Models.PSVpnClientIPsecParameters** object.


## NOTES

## RELATED LINKS

[New-AzureRmVpnClientIpsecParameters](./New-AzureRmVpnClientIpsecParameters.md)
