---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azvirtualhub
schema: 2.0.0
---

# New-AzVirtualHub

## SYNOPSIS
Creates an Azure VirtualHub resource.

## SYNTAX

### ByVirtualWanObject (Default)
```
New-AzVirtualHub -ResourceGroupName <String> -Name <String> -VirtualWan <PSVirtualWan> -AddressPrefix <String>
 -Location <String> [-HubVnetConnection <PSHubVirtualNetworkConnection[]>]
 [-RouteTable <PSVirtualHubRouteTable[]>] [-Tag <Hashtable>] [-Sku <String>] [-PreferredRoutingGateway <String>]
 [-HubRoutingPreference <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualWanResourceId
```
New-AzVirtualHub -ResourceGroupName <String> -Name <String> -VirtualWanId <String> -AddressPrefix <String>
 -Location <String> [-HubVnetConnection <PSHubVirtualNetworkConnection[]>]
 [-RouteTable <PSVirtualHubRouteTable[]>] [-Tag <Hashtable>] [-Sku <String>] [-PreferredRoutingGateway <String>]
 [-HubRoutingPreference <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates an Azure VirtualHub resource.

## EXAMPLES

### Example 1

```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
New-AzVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.1.0/24"
```

```output
VirtualWan                : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualWans/myVirtualWAN
ResourceGroupName         : testRG
Name                      : westushub
Id                        : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub
AddressPrefix             : 10.0.1.0/24
RouteTable                : 
VirtualNetworkConnections : {}
RouteTables                           : {}
Location                  : West US
Sku                  : Standard
PreferredRoutingGateway   : ExpressRoute
HubRoutingPreference      : ExpressRoute
Type                      : Microsoft.Network/virtualHubs
ProvisioningState         : Succeeded
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have the address space "10.0.1.0/24".

### Example 2

```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
New-AzVirtualHub -VirtualWanId $virtualWan.Id -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.1.0/24" -Location "West US"
```

```output
VirtualWan                : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualWans/myVirtualWAN
ResourceGroupName         : testRG
Name                      : westushub
Id                        : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub
AddressPrefix             : 10.0.1.0/24
RouteTable                : 
VirtualNetworkConnections : {}
RouteTables                           : {}
Location                  : West US
Sku                  : Standard
PreferredRoutingGateway   : ExpressRoute
HubRoutingPreference      : ExpressRoute
Type                      : Microsoft.Network/virtualHubs
ProvisioningState         : Succeeded
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have the address space "10.0.1.0/24". 

This example is similar to Example 1, but uses a resource Id to reference the Virtual WAN that is required to create the virtual Hub.

### Example 3

```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
$route1 = New-AzVirtualHubRoute -AddressPrefix @("10.0.0.0/16", "11.0.0.0/16") -NextHopIpAddress "12.0.0.5"
$route2 = New-AzVirtualHubRoute -AddressPrefix @("13.0.0.0/16") -NextHopIpAddress "14.0.0.5"
$routeTable = New-AzVirtualHubRouteTable -Route @($route1, $route2)
New-AzVirtualHub -VirtualWanId $virtualWan.Id -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.1.0/24" -RouteTable $routeTable
```

```output
VirtualWan                : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualWans/myVirtualWAN
ResourceGroupName         : testRG
Name                      : westushub
Id                        : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub
AddressPrefix             : 10.0.1.0/24
RouteTable                : Microsoft.Azure.Commands.Network.Models.PSVirtualHubRouteTable
VirtualNetworkConnections : {}
RouteTables                           : {}
Location                  : West US
Sku                  : Standard
PreferredRoutingGateway   : ExpressRoute
HubRoutingPreference      : ExpressRoute
Type                      : Microsoft.Network/virtualHubs
ProvisioningState         : Succeeded
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have the address space "10.0.1.0/24" and a route table attached.

This example is similar to Example 2, but also attaches a route table to the virtual hub.

### Example 4

```powershell
New-AzResourceGroup -Location "West US" -Name "testRG"
$virtualWan = New-AzVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
New-AzVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name "westushub" -AddressPrefix "10.0.1.0/24" -HubRoutingPreference "VpnGateway"    
```


```output
VirtualWan                : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualWans/myVirtualWAN
ResourceGroupName         : testRG
Name                      : westushub
Id                        : /subscriptions/{subscriptionId}resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub
AddressPrefix             : 10.0.1.0/24
RouteTable                :
Location                  : West US
Sku                  : Standard 
HubRoutingPreference      : VpnGateway
VirtualNetworkConnections : {}
Location                  : West US
Type                      : Microsoft.Network/virtualHubs
ProvisioningState         : Succeeded
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have preferred routing gateway as VPNGateway.

## PARAMETERS

### -AddressPrefix
The address space string for this virtual hub.

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

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -HubVnetConnection
The hub virtual network connections associated with this Virtual Hub.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
location.

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, VirtualHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredRoutingGateway
Preferred Routing Gateway to Route On-Prem traffic from VNET (Deprecated, please use HubRoutingPreference)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: ExpressRoute, VpnGateway

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HubRoutingPreference
Virtual Hub Routing Preference to route traffic

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: ExpressRoute, VpnGateway, ASPath

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

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

### -RouteTable
The route table associated with this Virtual Hub.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHubRouteTable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The sku of the Virtual Hub.

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

### -Tag
A hashtable which represents resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualWan
The virtual wan object this hub is linked to.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualWan
Parameter Sets: ByVirtualWanObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualWanId
The id of virtual wan object this hub is linked to.

```yaml
Type: System.String
Parameter Sets: ByVirtualWanResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualWan

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

## NOTES

## RELATED LINKS

[Get-AzVirtualHub](./Get-AzVirtualHub.md)

[Remove-AzVirtualHub](./Remove-AzVirtualHub.md)

[Update-AzVirtualHub](./Update-AzVirtualHub.md)
