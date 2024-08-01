### Example 1:Update Tag in Virtual Network Resource
```powershell
Update-AzScVmmVirtualNetwork -Name "test-vnet" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -Tag @{"key-1"="value-1"}
```

```output
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VirtualNetworks/test-vnet
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0001-000000000000
Location                     : eastus
Name                         : test-vnet
NetworkName                  : test-vnet
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 15:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "key-1": "value-1"
                               }
Type                         : microsoft.scvmm/virtualnetworks
Uuid                         : 00000000-1111-0000-0001-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

Updates the tag on the SCVMM Virtual Network resource on Azure.
