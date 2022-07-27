---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig
schema: 2.0.0
---

# New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig

## SYNOPSIS
Creates a tunnel interface in a backend address pool of a load balancer.

## SYNTAX

### CreateByNameParameterSet
```
New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig [-Type <String>] [-Protocol <String>] [-Identifier <UInt32>] [-Port <UInt32>]
```

## DESCRIPTION
Creates a tunnel interface in a backend address pool of a load balancer. This is used for Gateway Load Balancer
## EXAMPLES

### Example 1: Add a tunnel interface to a backend address pool configuration to a load balancer
```powershell
## Get loadbalancer
$lb = Get-AzLoadBalancer -ResourceGroupName $resourceGroup -Name $loadBalancerName

## Create tunnel interface to backend address pool
$tunnelInterface1 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol Vxlan -Type Internal -Port 2000 -Identifier 800 -BackendAddressPool $pool
$tunnelInterface2 = New-AzLoadBalancerBackendAddressPoolTunnelInterfaceConfig -Protocol Vxlan -Type External -Port 2001 -Identifier 801 -BackendAddressPool $pool

## Set backend address pool
$pool = Set-AzLoadBalancerBackendAddressPool -Name "BackendAddressPool02" -TunnelInterface $tunnelInterface1, $tunnelInterface2
```
If the properties are not provided then they will be replaced with default values.

## PARAMETERS

### -Protocol
Specifies the protocol of tunnel interface.

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

### -Type
Specifies the type of tunnel interface.

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

### -Port
Specifies the port of tunnel interface.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identifier
Specifies the identifier of tunnel interface.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSTunnelInterface

## NOTES

## RELATED LINKS

[Add-AzLoadBalancerBackendAddressPoolConfig](./Add-AzLoadBalancerBackendAddressPoolConfig.md)

[Get-AzLoadBalancerBackendAddressPoolConfig](./Get-AzLoadBalancerBackendAddressPoolConfig.md)

[Remove-AzLoadBalancerBackendAddressPoolConfig](./Remove-AzLoadBalancerBackendAddressPoolConfig.md)
