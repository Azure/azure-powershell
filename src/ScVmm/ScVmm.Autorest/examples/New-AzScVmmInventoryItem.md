### Example 1: Create SCVMM Inventory Item resource
```powershell
New-AzScVmmInventoryItem -Name "00000000-1111-0000-0001-000000000000" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-aaaa-0000-bbbb-000000000000" -VmmServerName "test-vmmserver-01" -InventoryType "VirtualMachineTemplate"
```

```output
Id                           : /subscriptions/00000000-aaaa-0000-bbbb-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/inventoryItems/00000000-1111-0000-0001-000000000000
InventoryItemName            :
InventoryType                : VirtualMachineTemplate
Kind                         :
ManagedResourceId            :
Name                         : 00000000-1111-0000-0001-000000000000
Property                     : {
                                 "inventoryType": "VirtualMachineTemplate",
                                 "provisioningState": "Succeeded"
                               }
ResourceGroupName            : test-rg-01
StorageQoSPolicy             : {}
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.scvmm/vmmservers/inventoryitems
Uuid                         :
```

New Arc SCVMM Inventory Item of given type is created.
