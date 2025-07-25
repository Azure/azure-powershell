### Example 1: List Datastores in current subscription
```powershell
Get-AzConnectedVMwareDatastore -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                  ResourceGroupName
----   --------      ----                                  -----------------
       eastus        test-datastore1                       test-rg1
       eastus        test-datastore2                       test-rg2
       eastus        test-datastore3                       test-rg3
       eastus        test-datastore4                       test-rg4
       eastus        test-datastore5                       test-rg5
       eastus        test-datastore6                       test-rg6
       eastus        test-datastore7                       test-rg7
       eastus        test-datastore8                       test-rg8
```

This command lists Datastores in current subscription.

### Example 2: List Datastores in a resource group
```powershell
Get-AzConnectedVMwareDatastore -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name            ResourceGroupName
----   -------- ----            -----------------
       eastus   test-datastore1 test-rg
       eastus   test-datastore2 test-rg
```

This command lists Datastores in a resource group named `test-rg`.

### Example 3: Get a specific Datastore
```powershell
Get-AzConnectedVMwareDatastore -Name "test-datastore" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CapacityGb                   : 439
CustomResourceName           : 178ef312-fb33-4a85-b513-d9d7f7f5034b
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
FreeSpaceGb                  : 408
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Datastores/test-datastore
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/datastore-713967
Kind                         :
Location                     : eastus
MoName                       : datastore
MoRefId                      : datastore-713967
Name                         : datastore
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-07-12T09:54:19.7224005Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-07-12T09:54:19.7224005Z"
                               }}
SystemDataCreatedAt          : 7/12/2023 9:53:52 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/12/2023 9:53:52 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.connectedvmwarevsphere/datastores
Uuid                         : 178ef312-fb33-4a85-b513-d9d7f7f5034b
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a Datastore named `test-datastore` in a resource group named `test-rg`.