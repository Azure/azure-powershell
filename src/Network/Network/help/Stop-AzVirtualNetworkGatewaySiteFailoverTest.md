---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/stop-azvirtualnetworkgatewaysitefailovertest
schema: 2.0.0
---

# Stop-AzVirtualNetworkGatewaySiteFailoverTest

## SYNOPSIS
Stops the failover simulation on the virtual network gateway for the specified peering location.

## SYNTAX

```
Stop-AzVirtualNetworkGatewaySiteFailoverTest -ResourceGroupName <String> -VirtualNetworkGatewayName <String>
 -PeeringLocation <String> -WasSimulationSuccessful <Boolean>
 -Detail <System.Collections.Generic.List`1[Microsoft.Azure.Management.Network.Models.FailoverConnectionDetails]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The `Stop-AzVirtualNetworkGatewaySiteFailoverTest` cmdlet is used to stop a failover simulation that was previously initiated for the virtual network gateway. The test is identified by the **PeeringLocation** where the test was run.

When stopping the test, you must provide whether the simulation was successful using the `-WasSimulationSuccessful` parameter, and you must also supply detailed information about the failover simulation using the `-Detail` parameter. 

This cmdlet allows you to conclude the failover test and capture any important information about the simulation results, including whether the test was successful or not.

## EXAMPLES

### Example 1
```powershell
$detail = @(
    [Microsoft.Azure.Management.Network.Models.FailoverConnectionDetails]@{
        FailoverConnectionName = "test_failover_gateway_connection"
        FailoverLocation = "eastus2"
        IsVerified = $true
    }
)
Stop-AzVirtualNetworkGatewaySiteFailoverTest -ResourceGroupName "test_failover_rg" -VirtualNetworkGatewayName "test_failoverGw" -PeeringLocation "WestEurope" -Detail $detail -WasSimulationSuccessful $true
```

This example demonstrates how to stop a failover simulation for a virtual network gateway. The cmdlet Stop-AzVirtualNetworkGatewaySiteFailoverTest is used with the following parameters:

ResourceGroupName: Specifies the resource group ("test_failover_rg") that contains the virtual network gateway.

VirtualNetworkGatewayName: Specifies the virtual network gateway ("test_failoverGw") for which the failover test is being stopped.

PeeringLocation: Specifies the peering location ("WestEurope") where the failover test is being stopped.

Detail: The failover connection details are provided, including the name, location, and verification status.

WasSimulationSuccessful: Indicates that the failover simulation was successful ($true).

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

### -Detail
Details of the failover simulation.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Management.Network.Models.FailoverConnectionDetails]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringLocation
Peering location of the failover test to stop.

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

### -WasSimulationSuccessful
Whether the simulation was successful.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.Commands.Network.Models.PSExpressRouteFailoverTestDetails

## NOTES

## RELATED LINKS
