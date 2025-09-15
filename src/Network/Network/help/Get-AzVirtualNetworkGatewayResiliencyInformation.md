---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkgatewayresiliencyinformation
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayResiliencyInformation

## SYNOPSIS
Retrieves the resiliency information for an ExpressRoute Gateway, including its current resiliency score and recommendations for improvement.

## SYNTAX

```
Get-AzVirtualNetworkGatewayResiliencyInformation -ResourceGroupName <String>
 -VirtualNetworkGatewayName <String> [-AttemptRefresh <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzVirtualNetworkGatewayResiliencyInformation` cmdlet retrieves the resiliency information for a specific virtual network gateway, including the gateway's current resiliency score. This score indicates the gateway's performance in terms of availability, redundancy, and failover capabilities. Additionally, the cmdlet provides recommendations for improving the gateway’s resiliency score, ensuring better business continuity.

By default, the cmdlet retrieves the existing resiliency information. If you want to refresh and recalculate the resiliency metrics to get the most up-to-date data, you can use the `-AttemptRefresh` parameter, which triggers a recalculation of the resiliency information.

This cmdlet is essential for evaluating the robustness of your virtual network gateway, helping you identify areas where improvements can be made to enhance its availability and overall performance.


## EXAMPLES

### Example 1
```powershell
Get-AzVirtualNetworkGatewayResiliencyInformation -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway"
```

This example retrieves the resiliency information for the virtual network gateway "test_gateway" in the resource group "test_rg". It does not attempt to refresh the data, providing the latest available information.

### Example 2
```powershell
Get-AzVirtualNetworkGatewayResiliencyInformation -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -AttemptRefresh $true
```

This example retrieves the resiliency information for the virtual network gateway "test_gateway" in the resource group "test_rg", and forces the system to recalculate the resiliency metrics by using the -AttemptRefresh parameter set to $true.

## PARAMETERS

### -AttemptRefresh
Attempt to recalculate the Resiliency Information for the gateway.

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

### Microsoft.Azure.Commands.Network.Models.PSGatewayResiliencyInformation

## NOTES

## RELATED LINKS
