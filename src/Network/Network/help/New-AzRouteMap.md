---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azroutemap
schema: 2.0.0
---

# New-AzRouteMap

## SYNOPSIS
Create a route map to a VirtualHub.

## SYNTAX

### ByVirtualHubName (Default)
```
New-AzRouteMap [-ResourceGroupName <String>] [-VirtualHubName <String>] [-Name <String>]
 [-RouteMapRule <PSRouteMapRule[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubObject
```
New-AzRouteMap [-VirtualHubObject <PSVirtualHub>] [-Name <String>] [-RouteMapRule <PSRouteMapRule[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubResourceId
```
New-AzRouteMap [-VirtualHubResourceId <String>] [-Name <String>] [-RouteMapRule <PSRouteMapRule[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a route map to a VirtualHub.

## EXAMPLES

### Example 1 Create route map

```powershell
New-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan" -Location "westcentralus" -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
$virtualWan = Get-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan"

New-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub" -Location "westcentralus" -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
$virtualHub = Get-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub"

# creating new route map rules and a new route map resource and new routing configuration
$routeMapMatchCriterion1 = New-AzRouteMapRuleCriterion -MatchCondition "Contains" -RoutePrefix @("10.0.0.0/16")
$routeMapActionParameter1 = New-AzRouteMapRuleActionParameter -AsPath @("12345")
$routeMapAction1 = New-AzRouteMapRuleAction -Type "Add" -Parameter @($routeMapActionParameter1)
$routeMapRule1 = New-AzRouteMapRule -Name "rule1" -MatchCriteria @($routeMapMatchCriterion1) -RouteMapRuleAction @($routeMapAction1) -NextStepIfMatched "Continue"

$routeMapMatchCriterion2 = New-AzRouteMapRuleCriterion -MatchCondition "Equals" -AsPath @("12345")
$routeMapAction2 = New-AzRouteMapRuleAction -Type "Drop"
$routeMapRule2 = New-AzRouteMapRule -Name "rule2" -MatchCriteria @($routeMapMatchCriterion2) -RouteMapRuleAction @($routeMapAction2) -NextStepIfMatched "Terminate"

New-AzRouteMap -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRouteMap" -RouteMapRule @($routeMapRule1, $routeMapRule2)
```

```output
Name                          : testRouteMap
Id                            : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/routemap0419/providers/Microsoft.Network/virtualHubs/westcentralus_hub1/routeMaps/testRouteMap
ProvisioningState             : Succeeded
RouteMapRules                 : [
                                  {
                                    "Name": "rule1",
                                    "MatchCriteria": [
                                      {
                                        "MatchCondition": "Contains",
                                        "RoutePrefix": [
                                          "10.0.0.0/16"
                                        ],
                                        "Community": [],
                                        "AsPath": []
                                      }
                                    ],
                                    "Actions": [
                                      {
                                        "Type": "Add",
                                        "Parameters": [
                                          {
                                            "RoutePrefix": [],
                                            "Community": [],
                                            "AsPath": [
                                              "12345"
                                            ]
                                          }
                                        ]
                                      }
                                    ],
                                    "NextStepIfMatched": "Continue"
                                  },
                                  {
                                    "Name": "rule2",
                                    "MatchCriteria": [
                                      {
                                        "MatchCondition": "Equals",
                                        "RoutePrefix": [],
                                        "Community": [],
                                        "AsPath": [
                                          "12345"
                                        ]
                                      }
                                    ],
                                    "Actions": [
                                      {
                                        "Type": "Drop",
                                        "Parameters": []
                                      }
                                    ],
                                    "NextStepIfMatched": "Terminate"
                                  }
                                ]
AssociatedInboundConnections  : []
AssociatedOutboundConnections : []
```

### Example 2 Apply route map to connections

```powershell
$testRouteMap = Get-AzRouteMap -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRouteMap"
 
$rt1 = Get-AzVHubRouteTable -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "defaultRouteTable"
$rt2 = Get-AzVHubRouteTable -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "noneRouteTable"
$testRoutingConfiguration =New-AzRoutingConfiguration -AssociatedRouteTable $rt1.Id -Label @("testLabel") -Id @($rt2.Id) -InboundRouteMap @($testRouteMap.Id)

# creating virtual network and a virtual hub vnet connection resource
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.2.1.0/24"
$backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.2.2.0/24"
$remoteVirtualNetwork = New-AzVirtualNetwork -Name "MyVirtualNetwork" -ResourceGroupName "testRG" -Location "westcentralus" -AddressPrefix "10.2.0.0/16" -Subnet $frontendSubnet,$backendSubnet
New-AzVirtualHubVnetConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -Name "testvnetconnection" -RemoteVirtualNetwork $remoteVirtualNetwork -RoutingConfiguration $testRoutingConfiguration
```

```output
Name                 : testvnetconnection
Id                   : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub/hubVirtualNetworkConnections/testvnetconnection
RemoteVirtualNetwork : /subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualNetworks/MyVirtualNetwork
EnableInternetSecurity : False
ProvisioningState    : Succeeded
RoutingConfiguration : {
                            "AssociatedRouteTable": {
                                "Id": "/subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub/hubRouteTables/defaultRouteTable"
                            },
                            "PropagatedRouteTables": {
                                "Labels": [],
                                "Ids": [
                                    {
                                        "Id": "/subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub/hubRouteTables/defaultRouteTable"
                                    }
                                ]
                            },
                            "VnetRoutes": {
                                "StaticRoutes": []
                            },
                           "InboundRouteMap": {
                             "Id": "/subscriptions/{subscriptionId}/resourceGroups/testRG/providers/Microsoft.Network/virtualHubs/westushub/routeMaps/testRouteMap"
                           }
                        }
```

## PARAMETERS

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

### -Name
The route map name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, RouteMapName

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
Parameter Sets: ByVirtualHubName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteMapRule
List of route map rules in the route map. 

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteMapRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubName
The Virtual Hub name. 

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases: ParentVirtualHubName, ParentResourceName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHubObject
The Virtual Hub Object. 

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: VirtualHub, ParentVirtualHub

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubResourceId
The Virtual Hub Resource Id. 

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceId
Aliases: VirtualHubId, ParentVirtualHubId

Required: False
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSRouteMap

## NOTES

## RELATED LINKS

[Get-AzRouteMap](./Get-AzRouteMap.md)

[New-AzRouteMapRule](./New-AzRouteMapRule.md)

[Update-AzRouteMap](./Update-AzRouteMap.md)

[Remove-AzRouteMap](./Remove-AzRouteMap.md)