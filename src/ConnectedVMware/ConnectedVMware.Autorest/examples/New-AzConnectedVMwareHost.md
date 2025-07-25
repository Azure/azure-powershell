### Example 1: Create Host
```powershell
New-AzConnectedVMwareHost -Name "test-host" -ResourceGroupName "test-rg" -Location "eastus" -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/host-1147412" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CpuMhz                       : 2194
CustomResourceName           : 6d40fd86-6f29-44ed-8e3a-fa7a11b5f1ac
DatastoreId                  : {/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-datastore}
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/hosts/test-host
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/host-1147412
Kind                         :
Location                     : eastus
MemorySizeGb                 : 127
MoName                       : 10.150.178.208
MoRefId                      : host-1147412
Name                         : test-host
NetworkId                    : {}
OverallCpuUsageMHz           : 17969
OverallMemoryUsageGb         : 118
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:54:23.2077585Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:54:23.2077585Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 10:54:13 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 10:54:13 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/hosts
Uuid                         : 6d40fd86-6f29-44ed-8e3a-fa7a11b5f1ac
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command create a Host named `test-host` in a resource group named `test-rg`.