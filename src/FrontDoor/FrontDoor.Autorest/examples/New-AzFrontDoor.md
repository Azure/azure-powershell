### Example 1: Create a Front Door based on given parameters.
```powershell
New-AzFrontDoor -Name "frontDoor1" -ResourceGroupName "rg1" -RoutingRule $routingrule1 -BackendPool $backendpool1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
```

```output
BackendPool          : {backendpool1}
BackendPoolsSetting  : {backendPoolsSetting1}
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {frontendEndpoint1}
HealthProbeSetting   : {HealthProbeSetting1}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting1}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

Create a Front Door based on given parameters.