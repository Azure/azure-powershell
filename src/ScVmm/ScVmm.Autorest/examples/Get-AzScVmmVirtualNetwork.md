### Example 1: Get Virtual Network By Subscription Id
```powershell
Get-AzScVmmVirtualNetwork -SubscriptionId "00000000-abcd-0000-abcd-000000000000"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-vnet      test-rg-01        00000000-1111-0000-0102-000000000000 Succeeded
test-vnet-02   test-rg-01        00000000-1111-0000-0111-000000000000 Succeeded
test-vnet-03   test-rg-01        00000000-1111-0000-0112-000000000000 Succeeded
test-vnet-04   test-rg-02        00000000-1111-0000-0113-000000000000 Succeeded
test-vnet-05   test-rg-02        00000000-1111-0000-0114-000000000000 Succeeded
test-vnet-06   test-rg-03        00000000-1111-0000-0115-000000000000 Succeeded
```

This command lists Virtual Networks in provided subscription.

### Example 2: Get Virtual Network By Resource Group
```powershell
Get-AzScVmmVirtualNetwork -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01"
```

```output
Name            ResourceGroupName Uuid                                 ProvisioningState
----            ----------------- ----                                 -----------------
test-vnet      test-rg-01        00000000-1111-0000-0102-000000000000 Succeeded
test-vnet-02   test-rg-01        00000000-1111-0000-0111-000000000000 Succeeded
test-vnet-03   test-rg-01        00000000-1111-0000-0112-000000000000 Succeeded
```

This command lists Virtual Networks in provided Resource Group.

### Example 3: Get Virtual Network
```powershell
Get-AzScVmmVirtualNetwork -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -ResourceGroupName "test-rg-01" -Name "test-vnet"
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
                               }
Type                         : microsoft.scvmm/virtualnetworks
Uuid                         : 00000000-1111-0000-0001-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command gets the Virtual Network named `test-vnet` in the resource group named `test-rg-01`.
