### Example 1: Create Datastore
```powershell
New-AzConnectedVMwareDatastore -Name "test-datastore" -ResourceGroupName "test-rg" -Location "eastus" -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/datastore-563660" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CapacityGb                   : 46079
CustomResourceName           : 9a2cb7ed-52a7-4fad-be88-6ff3794f80c7
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
FreeSpaceGb                  : 13778
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/datastores/test-datastore
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/datastore-563660
Kind                         :
Location                     : eastus
MoName                       : Shared 15TB
MoRefId                      : datastore-563660
Name                         : test-datastore
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:50:38.1524028Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T10:50:38.1524028Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 10:50:21 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 10:50:21 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/datastores
Uuid                         : 9a2cb7ed-52a7-4fad-be88-6ff3794f80c7
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command create a Datastore named `test-datastore` in a resource group named `test-rg`.