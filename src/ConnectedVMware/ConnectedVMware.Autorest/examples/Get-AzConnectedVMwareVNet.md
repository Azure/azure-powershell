### Example 1: List Virtual Networks in current subscription
```powershell
Get-AzConnectedVMwareVNet -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                                          ResourceGroupName
----   --------      ----                                                          -----------------
       eastus        test-vnet1                                                    test-rg1
       eastus        test-vnet2                                                    test-rg2
       eastus        test-vnet3                                                    test-rg3
       eastus        test-vnet4                                                    test-rg4
       eastus        test-vnet5                                                    test-rg5
       eastus        test-vnet6                                                    test-rg6
       eastus        test-vnet7                                                    test-rg7
       eastus        test-vnet8                                                    test-rg8
```

This command lists Virtual Networks in current subscription.

### Example 2: List Virtual Networks in a resource group
```powershell
Get-AzConnectedVMwareVNet -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-vnet1   test-rg
       eastus   test-vnet2   test-rg
```

This command lists Virtual Networks in a resource group named `test-rg`.

### Example 3: Get a specific Virtual Network
```powershell
Get-AzConnectedVMwareVNet -Name "test-vnet" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CustomResourceName           : a8feca6f-9d35-411d-a594-33fd28043966
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/VM-Network
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/network-563661
Kind                         :
Location                     : australiaeast
MoName                       : VM Network
MoRefId                      : network-563661
Name                         : VM-Network
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2022-06-30T07:00:45.0455281Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2022-06-30T07:00:45.0455281Z"
                               }}
SystemDataCreatedAt          : 6/30/2022 7:00:07 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/30/2022 7:00:07 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/virtualnetworks
Uuid                         : a8feca6f-9d35-411d-a594-33fd28043966
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a Virtual Network named `test-vnet` in a resource group named `test-rg`.