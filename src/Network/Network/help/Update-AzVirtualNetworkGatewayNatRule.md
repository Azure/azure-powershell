---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/update-azvirtualnetworkgatewaynatrule
schema: 2.0.0
---

# Update-AzVirtualNetworkGatewayNatRule

## SYNOPSIS
Updates a Virtual Network Gateway NatRule.

## SYNTAX

### ByVirtualNetworkGatewayNatRuleName (Default)
```
Update-AzVirtualNetworkGatewayNatRule -ResourceGroupName <String> -ParentResourceName <String> -Name <String>
 [-InternalMapping <String[]>] [-ExternalMapping <String[]>] [-InternalPortRange <String[]>]
 [-ExternalPortRange <String[]>] [-IpConfigurationId <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualNetworkGatewayNatRuleResourceId
```
Update-AzVirtualNetworkGatewayNatRule -ResourceId <String> [-InternalMapping <String[]>]
 [-ExternalMapping <String[]>] [-InternalPortRange <String[]>] [-ExternalPortRange <String[]>]
 [-IpConfigurationId <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualNetworkGatewayNatRuleObject
```
Update-AzVirtualNetworkGatewayNatRule -InputObject <PSVirtualNetworkGatewayNatRule>
 [-InternalMapping <String[]>] [-ExternalMapping <String[]>] [-InternalPortRange <String[]>]
 [-ExternalPortRange <String[]>] [-IpConfigurationId <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**Update-AzVirtualNetworkGatewayNatRule** cmdlet sets or updates a virtual network gateway nat rule.

## EXAMPLES

### Example 1:
```powershell
$natRule1 = Get-AzVirtualNetworkGatewayNatRule -ResourceGroupName "rg1" -Name "natRule1" -ParentResourceName "gw1"
Update-AzVirtualNetworkGatewayNatRule -InputObject $natRule1 -ExternalMapping @("30.0.0.0/16") -InternalMapping @("25.0.0.0/16") -IpConfigurationId "/subscriptions/7afd8f92-c220-4f53-886e-1df53a69afd4/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworkGateways/gw1/ipConfigurations/default"
 ```

```output
Name              : natRule1
ProvisioningState : Succeeded
Type              : Static
Mode              : IngressSnat
InternalMappings  : [
                      {
                        "AddressSpace": "25.0.0.0/16"
                      }
                    ]
ExternalMappings  : [
                      {
                        "AddressSpace": "30.0.0.0/16"
                      }
                    ]
IpConfigurationId : /subscriptions/7afd8f92-c220-4f53-886e-1df53a69afd4/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworkGateways/gw1/ipConfigurations/default
Id                : /subscriptions/7afd8f92-c220-4f53-886e-1df53a69afd4/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworkGateways/gw1/natRules/natRule1
Etag              : W/"5150d788-e165-42ba-99c4-8138a545fce9"
```

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalPortRange
The list of external port range mappings for NAT subnets

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The VirtualNetworkGatewayNatRule object to update.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayNatRule
Parameter Sets: ByVirtualNetworkGatewayNatRuleObject
Aliases: VirtualNetworkGatewayNatRule

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InternalMapping
The list of private IP address subnet internal mappings for NAT

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InternalPortRange
The list of internal port range mappings for NAT subnets

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpConfigurationId
The IP Configuration ID this NAT rule applies to

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualNetworkGatewayNatRuleName
Aliases: ResourceName, VirtualNetworkGatewayNatRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
The parent resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualNetworkGatewayNatRuleName
Aliases: ParentVirtualNetworkGatewayName, VirtualNetworkGatewayName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualNetworkGatewayNatRuleName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the VirtualNetworkGatewayNatRule object to update.

```yaml
Type: System.String
Parameter Sets: ByVirtualNetworkGatewayNatRuleResourceId
Aliases: VirtualNetworkGatewayNatRuleResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayNatRule

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkGatewayNatRule

## NOTES

## RELATED LINKS

[Get-AzVirtualNetworkGatewayNatRule](./Get-AzVirtualNetworkGatewayNatRule.md)

[Remove-AzVirtualNetworkGatewayNatRule](./Remove-AzVirtualNetworkGatewayNatRule.md)

[New-AzVirtualNetworkGatewayNatRule](./New-AzVirtualNetworkGatewayNatRule.md)
