### Example 1: Create a PSRoutingRuleObject for Front Door creation with a forwarding rule
```powershell
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
```

```output
AcceptedProtocol                   : {Http, Https}
EnabledState                       : Enabled
FrontendEndpoint                   : {{
                                       "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/FrontendEndpoints/frontendEndpoint1"
                                     }}
Id                                 :
Name                               :
PatternsToMatch                    : {/*}
ResourceState                      :
RouteConfiguration                 : {
                                       "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration",
                                       "backendPool": {
                                         "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/BackendPools/backendPool1"
                                       },
                                       "forwardingProtocol": "MatchRequest"
                                     }
RuleEngineId                       :
Type                               :
WebApplicationFirewallPolicyLinkId :
```

Create a PSRoutingRuleObject for Front Door creation with a forwarding rule

### Example 2: Create a PSRoutingRuleObject for Front Door creation with a redirect rule
```powershell
$customHost = "www.contoso.com"
$customPath = "/images/contoso.png"
$queryString = "field1=value1&field2=value2"
$destinationFragment = "section-header-2"
New-AzFrontDoorRoutingRuleObject -Name $routingRuleName -FrontDoorName $frontDoorName -ResourceGroupName $rgname -FrontendEndpointName "frontendEndpoint1" -CustomHost $customHost -CustomPath $customPath -CustomQueryString $queryString -CustomFragment $destinationFragment
```

```output
AcceptedProtocol                   : {Http, Https}
EnabledState                       : Enabled
FrontendEndpoint                   : {{
                                       "id": "/subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.Network/frontDoors/{fname}/FrontendEndpoints/frontendEndpoint1"
                                     }}
Id                                 :
Name                               :
PatternsToMatch                    : {/*}
ResourceState                      :
RouteConfiguration                 : {
                                       "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorRedirectConfiguration",
                                       "redirectType": "Moved",
                                       "redirectProtocol": "MatchRequest",
                                       "customHost": "www.contoso.com",
                                       "customPath": "/images/contoso.png",
                                       "customFragment": "section-header-2",
                                       "customQueryString": "field1=value1\u0026field2=value2"
                                     }
RuleEngineId                       :
Type                               :
WebApplicationFirewallPolicyLinkId :
```

Create a PSRoutingRuleObject for Front Door creation