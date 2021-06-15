---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvirtualnetworkgatewaynatrule
schema: 2.0.0
---

# New-AzVirtualNetworkGatewayNatRule

## SYNOPSIS
Creates the virtual network gateway natRule object.

## SYNTAX

```
New-AzVirtualNetworkGatewayNatRule -Name <String> -Type <String> -Mode <String> -InternalMapping <String[]>
 -ExternalMapping <String[]> [-IpConfigurationId <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
**New-AzVirtualNetworkGatewayNatRule** cmdlet creates a PSVirtualNetworkGatewayNatRule object which represents natRules property in your virtual network gateway.

## EXAMPLES

### Example 1
```
$gateway = Get-AzVirtualNetworkGateway -ResourceGroupName myRg -Name gw1
$natRule = New-AzVirtualNetworkGatewayNatRule -Name "natRule1" -Type "Static" -Mode "IngressSnat" -InternalMapping @("25.0.0.0/16") -ExternalMapping @("30.0.0.0/16")
Set-AzVirtualNetworkGateway -VirtualNetworkGateway $gateway -NatRule $natRule
```
The first command gets a virtual network gateway named gw1 that belongs to resource group myRg and stores it to the variable named $gateway
The second command creates a new PSVirtualNetworkGatewayNatRuleirtual object.
The third command updates the virtual network gateway gw1 with the with newly added natRule.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalMapping
The list of private IP address subnet external mappings for NAT

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InternalMapping
The list of private IP address subnet internal mappings for NAT

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpConfigurationId
The IP Configuration ID this NAT rule applies to

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
The Source NAT direction of a VPN NAT

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: EgressSnat, IngressSnat

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName, VirtualNetworkGatewayNatRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of NAT rule for VPN NAT

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Static, Dynamic

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayNatRule

## NOTES

## RELATED LINKS

[Get-AzVirtualNetworkGatewayNatRule](./Get-AzVirtualNetworkGatewayNatRule.md)

[Remove-AzVirtualNetworkGatewayNatRule](./Remove-AzVirtualNetworkGatewayNatRule.md)

[Update-AzVirtualNetworkGatewayNatRule](./Update-AzVirtualNetworkGatewayNatRule.md)
