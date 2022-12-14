---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 67AD15B0-94EB-486F-8C17-606EA5F702D3
online version: https://docs.microsoft.com/powershell/module/az.network/new-azloadbalancerbackendaddresspoolconfig
schema: 2.0.0
---

# New-AzLoadBalancerBackendAddressPoolConfig

## SYNOPSIS
Creates a backend address pool configuration for a load balancer.

## SYNTAX

```
New-AzLoadBalancerBackendAddressPoolConfig -Name <String> [-TunnelInterface <PSTunnelInterface[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzLoadBalancerBackendAddressPoolConfig** cmdlet creates a backend address pool configuration for an Azure load balancer.

## EXAMPLES

### Example 1: Create a backend address pool configuration for a load balancer
```powershell
New-AzLoadBalancerBackendAddressPoolConfig -Name "BackendAddressPool02"
```

This command creates a backend address pool configuration named BackendAddressPool02 for a load balancer.

### Example 2: Create a backend address pool configuration with tunnel interface for a load balancer
```powershell
## create with Gateway LoadBalancer TunnelInterface configuration
$tunnelInterface1 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol 'Vxlan' -Type 'Internal' -Port 2000 -Identifier 800
$tunnelInterface2 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol 'Vxlan' -Type 'External' -Port 2001 -Identifier 801
New-AzLoadBalancerBackendAddressPool -ResourceGroupName $resourceGroup -LoadBalancerName $loadBalancerName -Name $backendPool3 -TunnelInterface $tunnelInterface1, $tunnelInterface2
```

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

### -Name
Specifies the name of the address pool configuration to create.

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

### -TunnelInterface
The configuration of Gateway LoadBalancer Provider.

```yaml
Type: PSTunnelInterface[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBackendAddressPool

## NOTES

## RELATED LINKS

[Add-AzLoadBalancerBackendAddressPoolConfig](./Add-AzLoadBalancerBackendAddressPoolConfig.md)

[Get-AzLoadBalancerBackendAddressPoolConfig](./Get-AzLoadBalancerBackendAddressPoolConfig.md)

[Remove-AzLoadBalancerBackendAddressPoolConfig](./Remove-AzLoadBalancerBackendAddressPoolConfig.md)


