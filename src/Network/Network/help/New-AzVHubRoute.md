---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvhubroute
schema: 2.0.0
---

# New-AzVHubRoute

## SYNOPSIS
Creates a VHubRoute object which can be passed as parameter to the New-AzVHubRouteTable command.

## SYNTAX

```powershell
New-AzVHubRoute -Name <String> -Destination <String[]> -DestinationType <String> -NextHop <String> -NextHopType <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

Creates a VHubRoute object.

## EXAMPLES

### Example 1

```powershell
$rgName = "testRg"
$firewallName = "testFirewall"
$firewall = Get-AzFirewall -Name $firewallName -ResourceGroupName $rgName
New-AzVHubRoute -Name "private-traffic" -Destination @("10.30.0.0/16", "10.40.0.0/16") -DestinationType "CIDR" -NextHop $firewall.Id -NextHopType "ResourceId"
```

```output
Name            : private-traffic
DestinationType : CIDR
Destinations    : {10.30.0.0/16, 10.40.0.0/16}
NextHopType     : ResourceId
NextHop         : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/azureFirewalls/testFirewall
```

The above command will create a VHubRoute object with nextHop as the specified Firewall which can then be added to a VHubRouteTable resource.

### Example 2

```powershell
$rgName = "testRg"
$hubName = "testHub"
$hubVnetConnName = "testHubVnetConn"
$hubVnetConnection = Get-AzVirtualHubVnetConnection -Name $hubVnetConnName -ParentResourceName $hubName -ResourceGroupName $rgName
New-AzVHubRoute -Name "nva-traffic" -Destination @("10.20.0.0/16", "10.50.0.0/16") -DestinationType "CIDR" -NextHop $hubVnetConnection.Id -NextHopType "ResourceId"
```

```output
Name            : private-traffic
DestinationType : CIDR
Destinations    : {10.30.0.0/16, 10.40.0.0/16}
NextHopType     : ResourceId
NextHop         : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/hubVirtualNetworkConnections/testHubVnetConn
```

The above command will create a VHubRoute object with nextHop as the specified hubVnetConnection which can then be added to a VHubRouteTable resource.


### Example 3
```powershell
$hub = Get-AzVirtualHub -ResourceGroupName "rgname" -Name "virtual-hub-name"
$hubVnetConn = Get-AzVirtualHubVnetConnection -ParentObject $hub -Name "connection-name"
$hubVnetConn

Name                   : conn_2
Id                     : /subscriptions/{subscriptionID}/resourceGroups/{rgname}/providers/Microsoft.Network/virtualHubs/{virtual-hub-name}/hubVirtualNetworkConnections/conn_2
RemoteVirtualNetwork   : /subscriptions/{subscriptionID}/resourceGroups/{rgname}/providers/Microsoft.Network/virtualNetworks/rVnet_2
EnableInternetSecurity : True
ProvisioningState      : Succeeded
RoutingConfiguration   : {
                           "AssociatedRouteTable": {
                             "Id": "/subscriptions/{subscriptionID}/resourceGroups/{rgname}/providers/Microsoft.Network/virtualHubs/{virtual-hub-name}/hubRouteTables/defaultRouteTable"
                           },
                           "PropagatedRouteTables": {
                             "Labels": [
                               "default"
                             ],
                             "Ids": [
                               {
                                 "Id":
                         "/subscriptions/{subscriptionID}/resourceGroups/{rgname}/providers/Microsoft.Network/virtualHubs/{virtual-hub-name}/hubRouteTables/defaultRouteTable"
                               }
                             ]
                           },
                           "VnetRoutes": {
                             "StaticRoutes": []
                           }
                         }
                         
$staticRoute1 = New-AzStaticRoute -Name "static_route1" -AddressPrefix @("10.2.1.0/24", "10.2.3.0/24") -NextHopIpAddress "10.2.0.5"
$routingConfig = $hubVnetConn.RoutingConfiguration
$routingConfig.VnetRoutes.StaticRoutes = @($staticRoute1)
$routingConfig
AssociatedRouteTable  : Microsoft.Azure.Commands.Network.Models.PSResourceId
PropagatedRouteTables : {
                          "Labels": [
                            "default"
                          ],
                          "Ids": [
                            {
                              "Id":
                        "/subscriptions/{subscriptionID}/resourceGroups/{rgname}/providers/Microsoft.Network/virtualHubs/rTestHub1/hubRouteTables/defaultRouteTable"
                            }
                          ]
                        }
VnetRoutes            : {
                          "StaticRoutes": [
                            {
                              "Name": "static_route1",
                              "AddressPrefixes": [
                                "10.2.1.0/24",
                                "10.2.3.0/24"
                              ],
                              "NextHopIpAddress": "10.2.0.5"
                            }
                          ]
                        }

Update-AzVirtualHubVnetConnection -InputObject $hubVnetConn -RoutingConfiguration $routingConfig
```
The above commands will get the RoutingConfiguration of an already existing AzVHubRoute and then add a static route on the connection. Alternatively, if you hope to create a new connection with the static route within it, please see Example 1 [here.](New-AzRoutingConfiguration.md)
## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
List of Destinations.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationType
Type of Destinations.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The route name.

```yaml
Type: String
Parameter Sets: (all)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextHop
The next hop.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextHopType
The Next Hop type.

```yaml
Type: String
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVHubRoute

## NOTES

## RELATED LINKS

[Get-AzVHubRouteTable](./Get-AzVHubRouteTable.md)

[New-AzVHubRouteTable](./New-AzVHubRouteTable.md)

[Remove-AzVHubRouteTable](./Remove-AzVHubRouteTable.md)

[Update-AzVHubRouteTable](./Update-AzVHubRouteTable.md)