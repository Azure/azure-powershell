---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azroutingconfiguration
schema: 2.0.0
---

# New-AzRoutingConfiguration

## SYNOPSIS
Creates a RoutingConfiguration object.

## SYNTAX

```
New-AzRoutingConfiguration -AssociatedRouteTable <String> -Label <String[]> -Id <String[]>
 [-StaticRoute <PSStaticRoute[]>] [-VnetLocalRouteOverrideCriteria <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates a RoutingConfiguration object.

## EXAMPLES

### Example 1
```powershell
$rgName = "testRg"
$virtualHubName = "testHub"
$rt1 = Get-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name "defaultRouteTable"
$rt2 = Get-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name "noneRouteTable"
$route1 = New-AzStaticRoute -Name "route1" -AddressPrefix @("10.20.0.0/16", "10.30.0.0/16")-NextHopIpAddress "10.90.0.5"
New-AzRoutingConfiguration -AssociatedRouteTable $rt1.Id -Label @("testLabel") -Id @($rt2.Id) -StaticRoute @($route1)
```

```output
AssociatedRouteTable  : "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubRouteTables/defaultRouteTable"
PropagatedRouteTables : {
                          "Labels": [
                            "testLabel"
                          ],
                          "Ids": [
                            {
                              "Id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubRouteTables/noneRouteTable"
                            }
                          ]
                        }
VnetRoutes            : {
                          "StaticRoutes": [
                            {
                              "Name": "route1",
                              "AddressPrefixes": [
                                "10.20.0.0/16",
                                "10.30.0.0/16"
                              ],
                              "NextHopIpAddress": "10.90.0.5"
                            }
                          ]
                        }
```

The above command will create a RoutingConfiguration object which can then be added to a connection resource. Static routes are only allowed with a HubVirtualNetworkConnection object. 

## PARAMETERS

### -AssociatedRouteTable
The hub route table associated with this routing configuration.

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

### -Id
The list of resource ids of all the hub route tables to advertise the routes to for the PropagatedRouteTables property.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
The list of labels for the PropagatedRouteTables property.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRoute
List of routes that control routing from VirtualHub into a virtual network connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSStaticRoute[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetLocalRouteOverrideCriteria
Should we bypass NVA for destinations in spoke vnet? 'Contains' for no, 'Equal' for yes. Default is 'Contains'.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSStaticRoute

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRoutingConfiguration

## NOTES

## RELATED LINKS

[New-AzStaticRoute](./New-AzStaticRoute.md)

[New-AzExpressRouteConnection](./New-AzExpressRouteConnection.md)

[Set-AzExpressRouteConnection](./Set-AzExpressRouteConnection.md)

[New-AzVirtualHubVnetConnection](./New-AzVpnConnection.md)

[Update-AzVirtualHubVnetConnection](./Update-AzVpnConnection.md)

[New-AzP2sVpnGateway](./New-AzP2sVpnGateway.md)

[Update-AzP2sVpnGateway](./Update-AzP2sVpnGateway.md)

[New-AzVpnConnection](./New-AzVpnConnection.md)

[Update-AzVpnConnection](./Update-AzVpnConnection.md)