### Example 1: Create Capacity
```powershell
New-AzFabricCapacity `
            -SubscriptionId "548B7FB7-3B2A-4F46-BB02-66473F1FC22C" `
            -ResourceGroupName "testrg" `
            -CapacityName "azsdktest"`
            -Location "westcentralus" `
            -AdministrationMember @("azsdktest@microsoft.com") `
            -SkuName "F2"
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

The above command creates a new Fabric capacity named 'azsdktest' within the resource group 'testrg' in the subscription '548B7FB7-3B2A-4F46-BB02-66473F1FC22C'

