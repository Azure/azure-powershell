### Example 1: Create SCVMM Cloud resource
```powershell
New-AzScVmmCloud -Name "test-cloud" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -Location "eastus" -ExtendedLocationType "customLocation" -ExtendedLocationName "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourcegroups/test-rg-01/providers/microsoft.extendedlocation/customlocations/test-cl" -InventoryItemId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VMMServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0002-000000000000"
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
                               }
Type                         : microsoft.scvmm/clouds
Uuid                         : 00000000-1111-0000-0002-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command creates a Cloud named `test-cloud` in the resource group named `test-rg-01`.
