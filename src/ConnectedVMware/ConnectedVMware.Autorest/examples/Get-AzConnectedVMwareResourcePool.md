### Example 1: List Resource Pools in current subscription
```powershell
Get-AzConnectedVMwareResourcePool -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                          ResourceGroupName
----   --------      ----                                          -----------------
       eastus        test-rp1                                      test-rg1
       eastus        test-rp2                                      test-rg2
       eastus        test-rp3                                      test-rg3
       eastus        test-rp4                                      test-rg4
       eastus        test-rp5                                      test-rg5
       eastus        test-rp6                                      test-rg6
       eastus        test-rp7                                      test-rg7
       eastus        test-rp8                                      test-rg8
```

This command lists Resource Pools in current subscription.

### Example 2: List Resource Pools in a resource group
```powershell
Get-AzConnectedVMwareResourcePool -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-rp1     test-rg
       eastus   test-rp2     test-rg
```

This command lists Resource Pools in a resource group named `test-rg`.

### Example 3: Get a specific Resource Pool
```powershell
Get-AzConnectedVMwareResourcePool -Name "test-rp" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CpuCapacityMHz               : 197132
CpuLimitMHz                  : -1
CpuOverallUsageMHz           : 105
CpuReservationMHz            :
CpuSharesLevel               : normal
CustomResourceName           : c0d495b2-ff38-4131-ab85-061bc3b1700a
DatastoreId                  : {/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-ds1,
                               /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-ds2,
                               /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-ds3
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/ResourcePools/subbart
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/resgroup-1045861
Kind                         :
Location                     : westus3
MemCapacityGb                : 342
MemLimitMb                   : -1
MemOverallUsageGb            : 5
MemReservationMb             :
MemSharesLevel               : normal
MoName                       : subbart
MoRefId                      : resgroup-1045861
Name                         : subbart
NetworkId                    : {}
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-07-27T05:57:35.4692495Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-07-27T05:57:35.4692495Z"
                               }}
SystemDataCreatedAt          : 7/27/2023 5:56:46 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/18/2023 4:35:27 AM
SystemDataLastModifiedBy     : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/resourcepools
Uuid                         : c0d495b2-ff38-4131-ab85-061bc3b1700a
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a Resource Pool named `test-rp` in a resource group named `test-rg`.