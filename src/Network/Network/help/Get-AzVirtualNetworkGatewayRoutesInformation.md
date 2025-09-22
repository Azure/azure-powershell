---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkgatewayroutesinformation
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayRoutesInformation

## SYNOPSIS
Retrieves the route set information for an ExpressRoute Gateway, based on its resiliency.

## SYNTAX

```
Get-AzVirtualNetworkGatewayRoutesInformation -ResourceGroupName <String> -VirtualNetworkGatewayName <String>
 [-AttemptRefresh <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzVirtualNetworkGatewayRoutesInformation` cmdlet retrieves detailed route set information for an ExpressRoute Gateway. This operation provides insights into the routes configured for the gateway, including the associated resiliency metrics and their status.

By default, the cmdlet retrieves the current route set information for the gateway. If you wish to refresh the data and recalculate the route set information (for example, after making changes to the gateway), you can use the `-AttemptRefresh` parameter. This triggers the recalculation of the routes information and ensures that the most up-to-date data is retrieved.

The route set information can help evaluate the gateway's resiliency, availability, and its ability to handle different network traffic conditions.

## EXAMPLES

### Example 1
```powershell
Get-AzVirtualNetworkGatewayRoutesInformation -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway"
```

This example retrieves the route set information for the virtual network gateway named "test_gateway" in the resource group "test_rg". The command provides the current routing information, including details about the gateway’s resiliency and routes configuration.

### Example 2
```powershell
Get-AzVirtualNetworkGatewayRoutesInformation -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -AttemptRefresh $true
```

This example retrieves the route set information for the "test_gateway" in the "test_rg" resource group. The -AttemptRefresh parameter is used to recalculate the route sets, ensuring that the most recent data is returned after any potential configuration changes or updates to the gateway’s routing information.

## PARAMETERS

### -AttemptRefresh
Attempt to recalculate the Route Sets Information for the gateway.

```yaml
Type: System.Boolean
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSGatewayRouteSetsInformation

## NOTES

## RELATED LINKS
