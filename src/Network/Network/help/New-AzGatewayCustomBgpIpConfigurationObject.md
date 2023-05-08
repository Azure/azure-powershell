---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azgatewaycustombgpipconfigurationobject
schema: 2.0.0
---

# New-AzGatewayCustomBgpIpConfigurationObject

## SYNOPSIS
creates a new GatewayCustomBgpIpConfigurationObject.

## SYNTAX

```
New-AzGatewayCustomBgpIpConfigurationObject -IpConfigurationId <String> -CustomBgpIpAddress <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzGatewayCustomBgpIpConfigurationObject** creates a GatewayCustomBgpIpConfigurationObject which represents GatewayCustomBgpIpAddress property in your virtual network gateway connection.

## EXAMPLES

### Example 1 Create a AzGatewayCustomBgpIpConfigurationObject VirtualNetworkGatewayConnection
```powershell
$address = New-AzGatewayCustomBgpIpConfigurationObject -IpConfigurationId "/subscriptions/83704d68-d560-4c67-b1c7-12404db89dc3/resourceGroups/khbaheti_PS_testing/providers/Microsoft.Network/virtualNetworkGateways/testGw/ipConfigurations/default" -CustomBgpIpAddress "169.254.21.1"
```

### Example 2 Create a AzGatewayCustomBgpIpConfigurationObject VpnsiteLinkConnection
```powershell
$vpnGateway = Get-AzVpnGateway -ResourceGroupName PS_testing -Name 196ddf92afae40e4b20edc32dfb48a63-eastus-gw
$address1 = New-AzGatewayCustomBgpIpConfigurationObject -IpConfigurationId "Instance0" -CustomBgpIpAddress "169.254.22.1"
$address2 = New-AzGatewayCustomBgpIpConfigurationObject -IpConfigurationId "Instance1" -CustomBgpIpAddress "169.254.22.3"
```

The above will create a IpConfigurationBgpPeeringAddressObject.

## PARAMETERS

### -CustomBgpIpAddress
The virtual network gateway CustomBgpIpAddress for BgpPeeringAddresses used in connection.

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

### -IpConfigurationId
The virtual network gateway IpConfigurationId for BgpPeeringAddresses used in connection.

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayCustomBgpIpConfiguration

## NOTES

## RELATED LINKS
