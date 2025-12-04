### Example 1: Get all FrontDoors in the current subscription.
```powershell
Get-AzFrontDoor
```

```output
Location  Name                                                          ResourceGroupName
--------  ----                                                          -----------------
Global    {Name0}                                                       {rg0}
CentralUs {Name1}                                                       {rg1}
```

Get all FrontDoors in the current subscription.

### Example 2: Get all FrontDoors in resource group "rg1" in the current subscription.
```powershell
Get-AzFrontDoor -ResourceGroupName "rg1"
```

```output
Global   name1         rg1
Global   name2         rg1
```

Get all FrontDoors in resource group "rg1" in the current subscription.

### Example 3: Get the FrontDoors in resource group "rg1" with name "frontDoor1" in the current subscription.
```powershell
Get-AzFrontDoor -ResourceGroupName "rg1" -Name "frontDoor1"
```

```output
BackendPool          : {BackendPool0}
BackendPoolsSetting  : {
                         "enforceCertificateNameCheck": "Enabled",
                         "sendRecvTimeoutSeconds": 30
                       }
Cname                :
EnabledState         : Disabled
ExtendedProperty     : {
                         "MigratedTo": {link0}
                       }
FriendlyName         : frontDoor1
FrontdoorId          : {guid0}
FrontendEndpoint     : {Endpoint0}
HealthProbeSetting   : {HealthProbeSetting0}
Id                   : /subscriptions/{guid}/resourcegroups/rg1/providers/M
                        icrosoft.Network/frontdoors/frontdoor1
LoadBalancingSetting : {LoadBalancingSetting0}
Location             : Global
Name                 : frontDoor1
ProvisioningState    : Succeeded
ResourceGroupName    : {rg1}
ResourceState        : Migrated
RoutingRule          : {RoutingRule0,RoutingRule1}
RulesEngine          : {RulesEngine0,RulesEngine1}
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoors
```

Get the FrontDoors in resource group "rg1" with name "frontDoor1" in the current subscription.