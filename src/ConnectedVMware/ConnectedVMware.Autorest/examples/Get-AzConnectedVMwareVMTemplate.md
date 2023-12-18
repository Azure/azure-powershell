### Example 1: List VM Templates in current subscription
```powershell
Get-AzConnectedVMwareVMTemplate -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location      Name                                             ResourceGroupName
----   --------      ----                                             -----------------
       eastus        test-vmtmpl1                                     test-rg1
       eastus        test-vmtmpl2                                     test-rg2
       eastus        test-vmtmpl3                                     test-rg3
       eastus        test-vmtmpl4                                     test-rg4
       eastus        test-vmtmpl5                                     test-rg5
       eastus        test-vmtmpl6                                     test-rg6
       eastus        test-vmtmpl7                                     test-rg7
       eastus        test-vmtmpl8                                     test-rg8
```

This command lists VM Templates in current subscription.

### Example 2: List VM Templates in a resource group
```powershell
Get-AzConnectedVMwareVMTemplate -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
Kind   Location Name         ResourceGroupName
----   -------- ----         -----------------
       eastus   test-vmtmpl1 test-rg
       eastus   test-vmtmpl2 test-rg
```

This command lists VM Templates in a resource group named `test-rg`.

### Example 3: Get a specific VM Template
```powershell
Get-AzConnectedVMwareVMTemplate -Name "test-vmtmpl" -ResourceGroupName "test-rg" -SubscriptionId "204898ee-cd13-4332-b9d4-55ca5c25496d"
```

```output
CustomResourceName           : 6da8abd3-8857-4599-bd6f-831846bbdd0d
Disk                         : {{
                                 "name": "disk_1",
                                 "label": "Hard disk 1",
                                 "diskObjectId": "3-2000",
                                 "diskSizeGB": 32,
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
Id                           : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualMachineTemplates/azurearcvmwareubuntu20template
InventoryItemId              : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vmtpl-vm-651995
Kind                         :
Location                     : westus3
MemorySizeMb                 : 8192
MoName                       : azurearcvmwareubuntu20template
MoRefId                      : vm-651995
Name                         : azurearcvmwareubuntu20template
NetworkInterface             : {{
                                 "ipSettings": {
                                   "allocationMethod": "unset"
                                 },
                                 "name": "nic_1",
                                 "label": "Network adapter 1",
                                 "macAddress": "00:50:56:95:a2:c6",
                                 "nicType": "vmxnet3",
                                 "powerOnBoot": "enabled",
                                 "networkMoRefId": "network-563661",
                                 "networkMoName": "VM Network",
                                 "deviceKey": 4000
                               }}
NumCoresPerSocket            : 1
NumCpUs                      : 4
OSName                       : Ubuntu Linux (64-bit)
OSType                       : Linux
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg
Statuses                     : {{
                                 "type": "Ready",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-16T06:43:49.8483078Z"
                               }, {
                                 "type": "Idle",
                                 "status": "True",
                                 "lastUpdatedAt": "2023-08-16T06:43:49.8483078Z"
                               }}
SystemDataCreatedAt          : 8/16/2023 6:43:21 AM
SystemDataCreatedBy          : xyz
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/16/2023 6:43:21 AM
SystemDataLastModifiedBy     : xyz
SystemDataLastModifiedByType : User
Tag                          : {
                               }
ToolsVersion                 : 11333
ToolsVersionStatus           : guestToolsSupportedNew
Type                         : microsoft.connectedvmwarevsphere/virtualmachinetemplates
Uuid                         : 6da8abd3-8857-4599-bd6f-831846bbdd0d
VCenterId                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
```

This command gets a VM Template named `test-vmtmpl` in a resource group named `test-rg`.