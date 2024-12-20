### Example 1: List Capacities by Resource Group
```powershell
Get-AzFabricCapacity -ResourceGroupName "testrg" -SubscriptionId "548B7FB7-3B2A-4F46-BB02-66473F1FC22C"
```

```output
Location Name               SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
West Central US  azsdktest                                                                                                                                                       testrg
West Central US  azsdktest2                                                                                                                                                      testrg
```

The above command lists all Fabric capacities within the resource group 'testrg' in the subscription '548B7FB7-3B2A-4F46-BB02-66473F1FC22C'

### Example 2: List Capacities by Subscription
```powershell
Get-AzFabricCapacity -SubscriptionId "548B7FB7-3B2A-4F46-BB02-66473F1FC22C"
```

```output
Location Name               SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
-------- ----               ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
West Central US  azsdktest                                                                                                                                                       testrg
West Central US  azsdktest2                                                                                                                                                      testrg
West Europe      azsdktest3                                                                                                                                                      testrg3
```

The above command lists all Fabric capacities in the subscription '548B7FB7-3B2A-4F46-BB02-66473F1FC22C'.


### Example 3: Get Capacity
```powershell
Get-AzFabricCapacity -ResourceGroupName "testrg" -SubscriptionId "548B7FB7-3B2A-4F46-BB02-66473F1FC22C" -CapacityName "azsdktest"
```

```output
AdministrationMember         : {azsdktest@microsoft.com}
Id                           : /subscriptions/548B7FB7-3B2A-4F46-BB02-66473F1FC22C/resourceGroups/testrg/providers/Microsoft.Fabric/capacities/azsdktest
Location                     : West Central US
Name                         : azsdktest
ProvisioningState            : Succeeded
ResourceGroupName            : testrg
SkuName                      : F2
SkuTier                      : Fabric
State                        : Active
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Fabric/capacities
```

The above command retrieves the Fabric capacity named 'azsdktest' within the resource group 'testrg' in the subscription '548B7FB7-3B2A-4F46-BB02-66473F1FC22C'.