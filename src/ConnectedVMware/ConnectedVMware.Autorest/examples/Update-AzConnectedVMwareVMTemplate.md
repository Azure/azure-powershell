### Example 1: Update VM Template Resource
```powershell
Update-AzConnectedVMwareVMTemplate -Name "test-vmtmpl" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d" -Tag @{"vmtmpl"="test"}
```

```output
CustomResourceName           : b0d6ffc9-26a0-4099-b117-b7d8241c6243
Disk                         : {{
                                 "name": "disk_1",
                                 "label": "Hard disk 1",
                                 "diskObjectId": "1-2000",
                                 "diskSizeGB": 10,
                                 "deviceKey": 2000,
                                 "diskMode": "persistent",
                                 "controllerKey": 1000,
                                 "unitNumber": 0,
                                 "diskType": "flat"
                               }}
ExtendedLocationName         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType         : CustomLocation
FirmwareType                 :
FolderPath                   : ArcPrivateClouds-67/Templates
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vmtpl-vm-651858
Kind                         :
Location                     : eastus
MemorySizeMb                 : 1024
MoName                       : azurevmwarecloudtestubuntu
MoRefId                      : vm-651858
Name                         : test-vmtmpl
NetworkInterface             : {{
                                 "ipSettings": {
                                   "allocationMethod": "unset"
                                 },
                                 "name": "nic_1",
                                 "label": "Network adapter 1",
                                 "macAddress": "00:50:56:95:c7:08",
                                 "networkId": "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
                                 "nicType": "vmxnet3",
                                 "powerOnBoot": "enabled",
                                 "networkMoRefId": "network-563661",
                                 "networkMoName": "VM Network",
                                 "deviceKey": 4000
                               }}
NumCoresPerSocket            : 1
NumCpUs                      : 1
OSName                       : Ubuntu Linux (64-bit)
OSType                       : Linux
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T11:02:11.5393195Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-10-06T11:02:11.5393195Z"
                               }}
SystemDataCreatedAt          : 10/6/2023 11:01:59 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 10/6/2023 2:33:08 PM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                                 "vmtmpl": "test"
                               }
ToolsVersion                 : 10304
ToolsVersionStatus           : guestToolsSupportedOld
Type                         : microsoft.connectedvmwarevsphere/virtualmachinetemplates
Uuid                         : b0d6ffc9-26a0-4099-b117-b7d8241c6243
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command update tag of a VM Template named `test-vmtmpl` in a resource group named `test-rg`.