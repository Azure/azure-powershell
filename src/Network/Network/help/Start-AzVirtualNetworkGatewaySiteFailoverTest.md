---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/start-azvirtualnetworkgatewaysitefailovertest
schema: 2.0.0
---

# Start-AzVirtualNetworkGatewaySiteFailoverTest

## SYNOPSIS
Starts a failover simulation on the virtual network gateway for the specified peering location.

## SYNTAX

```
Start-AzVirtualNetworkGatewaySiteFailoverTest -ResourceGroupName <String> -VirtualNetworkGatewayName <String>
 -PeeringLocation <String> [-Type <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Start-AzVirtualNetworkGatewaySiteFailoverTest` cmdlet initiates a failover simulation on the virtual network gateway, specifically for the given **PeeringLocation**. This is useful for testing the gateway’s ability to failover and ensure network resiliency.

You can specify the **Type** of the failover test, either:
- `SingleSiteFailover`: A test to simulate a failover for a single site.
- `MultiSiteFailover`: A test to simulate a failover for multiple sites.

By default, the test will be performed using the `SingleSiteFailover` type unless specified otherwise. The failover test helps ensure that the virtual network gateway can handle failovers correctly and that any issues are identified proactively.


## EXAMPLES

### Example 1
```powershell
Start-AzVirtualNetworkGatewaySiteFailoverTest -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -PeeringLocation "EastUS"
```

This example starts a failover simulation for the virtual network gateway "test_gateway" in the "test_rg" resource group for the peering location EastUS. By default, a SingleSiteFailover test will be performed.

### Example 2
```powershell
Start-AzVirtualNetworkGatewaySiteFailoverTest -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -PeeringLocation "EastUS" -Type "MultiSiteFailover"
```

This example starts a failover simulation for the virtual network gateway "test_gateway" in the "test_rg" resource group for the EastUS peering location. The test type is set to MultiSiteFailover, meaning the test will simulate failover for multiple sites.

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

### -PeeringLocation
Peering location to run the test for.

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

### -ResourceGroupName
The resource group name of the virtual network gateway.

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

### -Type
Test type: SingleSiteFailover or MultiSiteFailover.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: SingleSiteFailover, MultiSiteFailover

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkGatewayName
The name of the virtual network gateway.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSExpressRouteFailoverTestDetails, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=7.17.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
