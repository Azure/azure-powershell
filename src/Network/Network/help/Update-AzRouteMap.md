---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-azroutemap
schema: 2.0.0
---

# Update-AzRouteMap

## SYNOPSIS
Update a route map of a VirtualHub.

## SYNTAX

### ByRouteMapName (Default)
```
Update-AzRouteMap [-ResourceGroupName <String>] [-VirtualHubName <String>] [-Name <String>]
 [-RouteMapRule <PSRouteMapRule[]>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubObject
```
Update-AzRouteMap [-Name <String>] [-VirtualHubObject <PSVirtualHub>] [-RouteMapRule <PSRouteMapRule[]>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByRouteMapObject
```
Update-AzRouteMap [-InputObject <PSRouteMap>] [-RouteMapRule <PSRouteMapRule[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByRouteMapResourceId
```
Update-AzRouteMap [-ResourceId <String>] [-RouteMapRule <PSRouteMapRule[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a route map of a VirtualHub.

## EXAMPLES

### Example 1

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
Update-AzRouteMap -ResourceGroupName "testRg" -VirtualHubName "testHub" -Name "testRouteMap" -RouteMapRule @($routeMapRule2)
```

```output
Name                          : testRouteMap
Id                            : /subscriptions/62364504-2406-418e-971c-05822ff72fad/resourceGroups/routemap0419/providers/Microsoft.Network/virtualHubs/westcentralus_hub1/routeMaps/tes
                                tRouteMap
ProvisioningState             : Succeeded
RouteMapRules                 : [
                                  {
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
                                    "NextStepIfMatched": "Terminate",
                                    "Name": "rule2"
                                  }
                                ]
AssociatedInboundConnections  : []
AssociatedOutboundConnections : []
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

### -InputObject
The route map object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSRouteMap
Parameter Sets: ByRouteMapObject
Aliases: RouteMap

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The route map name.

```yaml
Type: System.String
Parameter Sets: ByRouteMapName, ByVirtualHubObject
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
Parameter Sets: ByRouteMapName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Route Map Resource Id. 

```yaml
Type: System.String
Parameter Sets: ByRouteMapResourceId
Aliases: RouteMapId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: ByRouteMapName
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
Accept pipeline input: False
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

[New-AzRouteMap](./New-AzRouteMap.md)

[New-AzRouteMapRule](./New-AzRouteMapRule.md)

[Get-AzRouteMap](./Get-AzRouteMap.md)

[Remove-AzRouteMap](./Remove-AzRouteMap.md)