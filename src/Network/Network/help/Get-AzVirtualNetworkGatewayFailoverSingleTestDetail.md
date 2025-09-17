---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkgatewayfailoversingletestdetail
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayFailoverSingleTestDetail

## SYNOPSIS
Retrieves detailed information about a specific failover test for a virtual network gateway.

## SYNTAX

```
Get-AzVirtualNetworkGatewayFailoverSingleTestDetail -ResourceGroupName <String>
 -VirtualNetworkGatewayName <String> -PeeringLocation <String> -FailoverTestId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzVirtualNetworkGatewayFailoverSingleTestDetail` cmdlet retrieves detailed information about a specific failover test performed on a virtual network gateway. This cmdlet allows you to identify a particular test using the FailoverTestId (a unique GUID), the PeeringLocation where the test was performed, and the ResourceGroupName and VirtualNetworkGatewayName to locate the specific gateway.

You can obtain the FailoverTestId (or TestGuid) from the output of the Get-AzVirtualNetworkGatewayFailoverAllTestsDetail cmdlet, which provides a list of all failover tests conducted on the virtual network gateway.

This cmdlet is especially useful when you need to examine the results of a single failover test, such as the start time, end time, status, and other related test details. You can specify the failover test to retrieve by using the FailoverTestId and PeeringLocation.


## EXAMPLES

### Example 1
```powershell
Get-AzVirtualNetworkGatewayFailoverSingleTestDetail -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -PeeringLocation "West US" -FailoverTestId "00000000-0000-0000-0000-000000000000"
```

This example retrieves the details of a specific failover test with the FailoverTestId of 00000000-0000-0000-0000-000000000000 that was performed in the East US peering location on the virtual network gateway "test_gateway" in the resource group "test_rg".

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

### -FailoverTestId
The unique Guid value which identifies the test.

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

### -PeeringLocation
Peering location of the test.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSExpressRouteFailoverSingleTestDetails, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=7.17.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
