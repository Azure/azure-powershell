### Example 1: Create Resource Pool
```powershell
New-AzConnectedVMwareResourcePool -Name "test-rp" -ResourceGroupName "test-rg" -Location "eastus" -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/resgroup-724471" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CpuCapacityMHz               : 197132
CpuLimitMHz                  : -1
CpuOverallUsageMHz           : 964
CpuReservationMHz            :
CpuSharesLevel               : normal
CustomResourceName           : e296ddc2-ab72-4bba-9bf9-9fb18abaabf7
DatastoreId                  : {/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-datastore}
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/resourcePools/test-rp
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/resgroup-724471
Kind                         :
Location                     : eastus
MemCapacityGb                : 344
MemLimitMb                   : -1
MemOverallUsageGb            : 11
MemReservationMb             :
MemSharesLevel               : normal
MoName                       : test-rp
MoRefId                      : resgroup-724471
Name                         : test-rp
NetworkId                    : {}
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:58:30.1697443Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:58:30.1697443Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 10:58:11 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 10:58:11 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/resourcepools
Uuid                         : e296ddc2-ab72-4bba-9bf9-9fb18abaabf7
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command create a Resource Pool named `test-rp` in a resource group named `test-rg`.