### Example 1: Get Cloud By Subscription Id
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-cloud      test-rg-01        00000000-1111-0000-0002-000000000000 Succeeded
test-cloud-02   test-rg-01        00000000-1111-0000-0011-000000000000 Succeeded
test-cloud-03   test-rg-01        00000000-1111-0000-0012-000000000000 Succeeded
test-cloud-04   test-rg-02        00000000-1111-0000-0013-000000000000 Succeeded
test-cloud-05   test-rg-02        00000000-1111-0000-0014-000000000000 Succeeded
test-cloud-06   test-rg-03        00000000-1111-0000-0015-000000000000 Succeeded
```

This command lists Cloud in provided subscription.

### Example 2: Get Cloud By ResourceGroup
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-cloud      test-rg-01        00000000-1111-0000-0002-000000000000 Succeeded
test-cloud-02   test-rg-01        00000000-1111-0000-0011-000000000000 Succeeded
test-cloud-03   test-rg-01        00000000-1111-0000-0012-000000000000 Succeeded
```

This command lists Cloud in provided Resource Group.

### Example 3: Get Cloud
```powershell
Get-AzScVmmCloud -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-cloud"
```

```output
CapacityCpuCount             : 10
CapacityMemoryMb             : 10240
CapacityVMCount              : 10
CloudName                    : test-cloud
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/clouds/test-cloud
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0002-000000000000
Location                     : eastus
Name                         : test-cloud
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
StorageQoSPolicy             : {}
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "key-1": "value-1"
                               }
Type                         : microsoft.scvmm/clouds
Uuid                         : 00000000-1111-0000-0002-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command gets the Cloud named `test-cloud` in the resource group named `test-rg-01`.
