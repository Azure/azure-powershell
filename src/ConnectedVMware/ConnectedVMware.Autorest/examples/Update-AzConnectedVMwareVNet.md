### Example 1: Update Virtual Network Resource
```powershell
Update-AzConnectedVMwareVNet -Name "test-vnet" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -Tag @{"vnet"="test"}
```

```output
CustomResourceName           : 1c967ed8-79f5-4737-aae9-0978e1128da6
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualNetworks/test-vnet
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/network-563661
Kind                         :
Location                     : eastus
MoName                       : VM Network
MoRefId                      : network-563661
Name                         : test-vnet
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T11:07:38.9615735Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T11:07:38.9615735Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 11:07:19 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 2:34:53 PM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                                 "vnet": "test"
                               }
Type                         : microsoft.connectedvmwarevsphere/virtualnetworks
Uuid                         : 1c967ed8-79f5-4737-aae9-0978e1128da6
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command update tag of a Virtual Network named `test-vnet` in a resource group named `test-rg`.