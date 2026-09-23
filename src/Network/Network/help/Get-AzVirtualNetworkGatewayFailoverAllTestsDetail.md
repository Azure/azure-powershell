---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azvirtualnetworkgatewayfailoveralltestsdetail
schema: 2.0.0
---

# Get-AzVirtualNetworkGatewayFailoverAllTestsDetail

## SYNOPSIS
Retrieves the details of all failover tests for a specified virtual network gateway.

## SYNTAX

### ByName (Default)
```
Get-AzVirtualNetworkGatewayFailoverAllTestsDetail [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzVirtualNetworkGatewayFailoverAllTestsDetail -ResourceGroupName <String>
 -VirtualNetworkGatewayName <String> -Type <String> -FetchLatest <Boolean>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The `Get-AzVirtualNetworkGatewayFailoverAllTestsDetail`cmdlet retrieves detailed information about the failover tests conducted on a specific virtual network gateway. These tests assess the resiliency of the gateway by simulating failovers to various peering locations.
This cmdlet requires the ResourceGroupName, VirtualNetworkGatewayName, and Type parameters to identify the virtual network gateway and the specific type of failover test you wish to inspect. The -Type parameter allows you to specify the type of failover test (e.g., "SingleSiteFailover").
The -FetchLatest parameter, when set to true, ensures that only the most recent failover tests for each peering location are retrieved.
Using this cmdlet, you can gain valuable insights into the status, start time, end time, and results of each failover test, helping you evaluate the gateway's resiliency and ensure its availability across different locations.

## EXAMPLES

### Example 1
```powershell
Get-AzVirtualNetworkGatewayFailoverAllTestsDetail -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -Type "SingleSiteFailover" -FetchLatest $true
```

This example retrieves the details of all failover tests of type SingleSiteFailover for the virtual network gateway "test_gateway" in the resource group "test_rg". The -FetchLatest parameter is set to $true, ensuring only the most recent failover tests for each peering location are returned.

### Example 2
```powershell
Get-AzVirtualNetworkGatewayFailoverAllTestsDetail -ResourceGroupName "test_rg" -VirtualNetworkGatewayName "test_gateway" -Type "MultiSiteFailover" -FetchLatest $false
```

This example retrieves all MultisiteFailover tests (not limited to the latest) for the virtual network gateway "test_gateway" in the resource group "test_rg". The -FetchLatest parameter is set to $false, so the cmdlet will return all available failover tests.

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

### -FetchLatest
Fetch only the latest tests for each peering location.

```yaml
Type: System.Boolean
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of failover test.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
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
Parameter Sets: GetByNameParameterSet
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
