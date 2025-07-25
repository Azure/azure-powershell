---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/new-azconnectedvmwarevm
schema: 2.0.0
---

# New-AzConnectedVMwareVM

## SYNOPSIS
The operation to Create a virtual machine instance.
Please note some properties can be set only during virtual machine instance creation.

## SYNTAX

### CreateExpanded (Default)
```
New-AzConnectedVMwareVM -MachineId <String> [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-HardwareProfileMemorySizeMb <Int32>] [-HardwareProfileNumCoresPerSocket <Int32>]
 [-HardwareProfileNumCpus <Int32>] [-InfrastructureProfileFirmwareType <String>]
 [-InfrastructureProfileInventoryItemId <String>] [-InfrastructureProfileSmbiosUuid <String>]
 [-InfrastructureProfileTemplateId <String>] [-InfrastructureProfileVCenterId <String>]
 [-NetworkProfileNetworkInterface <INetworkInterface[]>] [-OSProfileAdminPassword <String>]
 [-OSProfileAdminUsername <String>] [-OSProfileComputerName <String>] [-OSProfileGuestId <String>]
 [-OSProfileOstype <String>] [-PlacementProfileClusterId <String>] [-PlacementProfileDatastoreId <String>]
 [-PlacementProfileHostId <String>] [-PlacementProfileResourcePoolId <String>]
 [-StorageProfileDisk <IVirtualDisk[]>] [-UefiSettingSecureBootEnabled] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConnectedVMwareVM -MachineId <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConnectedVMwareVM -MachineId <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to Create a virtual machine instance.
Please note some properties can be set only during virtual machine instance creation.

## EXAMPLES

### Example 1: Create Virtual Machine Instances on the given Resource Pool
```powershell
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileResourcePoolId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/resourcepools/test-rp" -MachineId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
                                            "nicType": "vmxnet3",
                                            "powerOnBoot": "enabled",
                                            "networkMoRefId": "network-563661",
                                            "networkMoName": "VM Network",
                                            "deviceKey": 4000
                                          }}
OSProfileAdminPassword                  :
OSProfileAdminUsername                  :
OSProfileComputerName                   :
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsNotRunning
OSProfileToolsVersion                   : 10304
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               : 
PlacementProfileDatastoreId             :
PlacementProfileHostId                  :
PlacementProfileResourcePoolId          : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/ResourcePools/test-rp
PowerState                              : poweredOn
ProvisioningState                       : Succeeded
ResourceGroupName                       : test-rg
ResourceUid                             : 4c9c3021-d32e-48f9-b8ac-9cb14ebf6d75
Statuses                                : {{
                                            "type": "CustomizationCompleted",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:36.0000000Z"
                                          }, {
                                            "type": "Ready",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }}
StorageProfileDisk                      : {{
                                            "name": "disk_1",
                                            "label": "Hard disk 1",
                                            "diskObjectId": "7435-2000",
                                            "diskSizeGB": 10,
                                            "deviceKey": 2000,
                                            "diskMode": "persistent",
                                            "controllerKey": 1000,
                                            "unitNumber": 0,
                                            "diskType": "flat"
                                          }}
StorageProfileScsiController            : {{
                                            "type": "lsilogic",
                                            "controllerKey": 1000,
                                            "scsiCtlrUnitNumber": 7,
                                            "sharing": "noSharing"
                                          }}
SystemDataCreatedAt                     : 10/6/2023 12:28:17 PM
SystemDataCreatedBy                     : xyz
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 12:28:17 PM
SystemDataLastModifiedBy                : xyz
SystemDataLastModifiedByType            : User
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command create a VM Instances of machine named `test-machine` in a resource group named `test-rg`.

### Example 2: Create Virtual Machine Instances on the given Cluster
```powershell
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileClusterId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/clusters/test-cluster" -MachineId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
                                            "nicType": "vmxnet3",
                                            "powerOnBoot": "enabled",
                                            "networkMoRefId": "network-563661",
                                            "networkMoName": "VM Network",
                                            "deviceKey": 4000
                                          }}
OSProfileAdminPassword                  :
OSProfileAdminUsername                  :
OSProfileComputerName                   :
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsNotRunning
OSProfileToolsVersion                   : 10304
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Clusters/test-cluster
PlacementProfileDatastoreId             :
PlacementProfileHostId                  :
PlacementProfileResourcePoolId          :
PowerState                              : poweredOn
ProvisioningState                       : Succeeded
ResourceGroupName                       : test-rg
ResourceUid                             : 4c9c3021-d32e-48f9-b8ac-9cb14ebf6d75
Statuses                                : {{
                                            "type": "CustomizationCompleted",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:36.0000000Z"
                                          }, {
                                            "type": "Ready",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }}
StorageProfileDisk                      : {{
                                            "name": "disk_1",
                                            "label": "Hard disk 1",
                                            "diskObjectId": "7435-2000",
                                            "diskSizeGB": 10,
                                            "deviceKey": 2000,
                                            "diskMode": "persistent",
                                            "controllerKey": 1000,
                                            "unitNumber": 0,
                                            "diskType": "flat"
                                          }}
StorageProfileScsiController            : {{
                                            "type": "lsilogic",
                                            "controllerKey": 1000,
                                            "scsiCtlrUnitNumber": 7,
                                            "sharing": "noSharing"
                                          }}
SystemDataCreatedAt                     : 10/6/2023 12:28:17 PM
SystemDataCreatedBy                     : xyz
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 12:28:17 PM
SystemDataLastModifiedBy                : xyz
SystemDataLastModifiedByType            : User
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command create a VM Instances of machine named `test-machine` in a resource group named `test-rg`.

### Example 3: Create Virtual Machine on the given Host
```powershell
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileHostId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/hosts/test-host" -MachineId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
                                            "nicType": "vmxnet3",
                                            "powerOnBoot": "enabled",
                                            "networkMoRefId": "network-563661",
                                            "networkMoName": "VM Network",
                                            "deviceKey": 4000
                                          }}
OSProfileAdminPassword                  :
OSProfileAdminUsername                  :
OSProfileComputerName                   :
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsNotRunning
OSProfileToolsVersion                   : 10304
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               : 
PlacementProfileDatastoreId             :
PlacementProfileHostId                  : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Hosts/test-host
PlacementProfileResourcePoolId          :
PowerState                              : poweredOn
ProvisioningState                       : Succeeded
ResourceGroupName                       : test-rg
ResourceUid                             : 4c9c3021-d32e-48f9-b8ac-9cb14ebf6d75
Statuses                                : {{
                                            "type": "CustomizationCompleted",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:36.0000000Z"
                                          }, {
                                            "type": "Ready",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }}
StorageProfileDisk                      : {{
                                            "name": "disk_1",
                                            "label": "Hard disk 1",
                                            "diskObjectId": "7435-2000",
                                            "diskSizeGB": 10,
                                            "deviceKey": 2000,
                                            "diskMode": "persistent",
                                            "controllerKey": 1000,
                                            "unitNumber": 0,
                                            "diskType": "flat"
                                          }}
StorageProfileScsiController            : {{
                                            "type": "lsilogic",
                                            "controllerKey": 1000,
                                            "scsiCtlrUnitNumber": 7,
                                            "sharing": "noSharing"
                                          }}
SystemDataCreatedAt                     : 10/6/2023 12:28:17 PM
SystemDataCreatedBy                     : xyz
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 12:28:17 PM
SystemDataLastModifiedBy                : xyz
SystemDataLastModifiedByType            : User
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command create a VM Instances of machine named `test-machine` in a resource group named `test-rg`.

### Example 4: Create Virtual Machine with a VM Inventory
```powershell
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileInventoryItemId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vm-1528583" -MachineId "/subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine-ps"
```

```output
ExtendedLocationName                    : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : False
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : False
HardwareProfileMemorySizeMb             : 8192
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 4
Id                                      : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine-ps/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : 9d8766c2-6e02-4553-8ae2-7c37a19cb45b
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67/test-folder
InfrastructureProfileInstanceUuid       : 5015d462-e12c-623f-45ad-ddfecc541d51
InfrastructureProfileInventoryItemId    : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vm-1528583
InfrastructureProfileMoName             : test-ps-vm
InfrastructureProfileMoRefId            : vm-1528583
InfrastructureProfileSmbiosUuid         : 421532ab-22b5-67b4-41fd-829f0e7355b9
InfrastructureProfileTemplateId         :
InfrastructureProfileVCenterId          : /subscriptions/00001111-aaaa-2222-bbbb-3333cccc4444/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset",
                                              "dnsServers": [ "10.50.50.50", "10.50.10.50" ],
                                              "gateway": [ "10.150.176.1", "fe80::201:11ff:fe11:1111" ],
                                              "ipAddress": "10.150.176.96",
                                              "subnetMask": "255.255.248.0",
                                              "ipAddressInfo": [
                                                {
                                                  "ipAddress": "10.150.176.96",
                                                  "subnetMask": "255.255.248.0"
                                                },
                                                {
                                                  "ipAddress": "2404:f801:4800:14:fcff:ae75:70f7:b9c4",
                                                  "subnetMask": "ffff:ffff:ffff:ffff:0000:0000:0000:0000"
                                                },
                                                {
                                                  "ipAddress": "2404:f801:4800:14:727f:c295:1b88:7c2e",
                                                  "subnetMask": "ffff:ffff:ffff:ffff:0000:0000:0000:0000"
                                                },
                                                {
                                                  "ipAddress": "fe80::de93:fcd0:8a22:2ff6",
                                                  "subnetMask": "ffff:ffff:ffff:ffff:0000:0000:0000:0000"
                                                }
                                              ]
                                            },
                                            "label": "Network adapter 1",
                                            "ipAddresses": [ "10.150.176.96", "2404:f801:4800:14:fcff:ae75:70f7:b9c4", "2404:f801:4800:14:727f:c295:1b88:7c2e", "fe80::de93:fcd0:8a22:2ff6" ],
                                            "macAddress": "00:50:56:95:5e:81",
                                            "nicType": "vmxnet3",
                                            "powerOnBoot": "enabled",
                                            "networkMoRefId": "network-563661",
                                            "networkMoName": "VM Network",
                                            "deviceKey": 4000
                                          }}
OSProfileAdminPassword                  :
OSProfileAdminUsername                  :
OSProfileComputerName                   : virtual-machine
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsRunning
OSProfileToolsVersion                   : 11360
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               :
PlacementProfileDatastoreId             :
PlacementProfileHostId                  :
PlacementProfileResourcePoolId          :
PowerState                              : poweredOn
ProvisioningState                       : Succeeded
ResourceGroupName                       : test-rg
ResourceUid                             : 18ccf2b0-438a-4267-8cd7-49f3564bc668
Statuses                                : {{
                                            "type": "Ready",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T10:11:40.5846310Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T10:11:40.5846310Z"
                                          }}
StorageProfileDisk                      : {{
                                            "label": "Hard disk 1",
                                            "diskObjectId": "7406-2000",
                                            "diskSizeGB": 32,
                                            "deviceKey": 2000,
                                            "diskMode": "persistent",
                                            "controllerKey": 1000,
                                            "unitNumber": 0,
                                            "diskType": "flat"
                                          }}
StorageProfileScsiController            : {{
                                            "type": "lsilogic",
                                            "controllerKey": 1000,
                                            "scsiCtlrUnitNumber": 7,
                                            "sharing": "noSharing"
                                          }}
SystemDataCreatedAt                     : 10/6/2023 10:11:11 AM
SystemDataCreatedBy                     : xyz
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 10:11:11 AM
SystemDataLastModifiedBy                : xyz
SystemDataLastModifiedByType            : User
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command enable a VM Instances of machine named `test-machine` from a invetory vm in a resource group named `test-rg`.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The extended location name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The extended location type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileMemorySizeMb
Gets or sets memory size in MBs for the vm.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileNumCoresPerSocket
Gets or sets the number of cores per socket for the vm.
Defaults to 1 if unspecified.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HardwareProfileNumCpus
Gets or sets the number of vCPUs for the vm.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileFirmwareType
Firmware type

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileInventoryItemId
Gets or sets the inventory Item ID for the virtual machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileSmbiosUuid
Gets or sets the SMBIOS UUID of the vm.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileTemplateId
Gets or sets the ARM Id of the template resource to deploy the virtual machine.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureProfileVCenterId
Gets or sets the ARM Id of the vCenter resource in which this resource pool resides.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineId
The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileNetworkInterface
Gets or sets the list of network interfaces associated with the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.INetworkInterface[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileAdminPassword
Sets administrator password.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileAdminUsername
Gets or sets administrator username.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileComputerName
Gets or sets computer name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileGuestId
Gets or sets the guestId.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSProfileOstype
Gets or sets the type of the os.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementProfileClusterId
Gets or sets the ARM Id of the cluster resource on which this virtual machine will deploy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementProfileDatastoreId
Gets or sets the ARM Id of the datastore resource on which the data for the virtual machine will be kept.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementProfileHostId
Gets or sets the ARM Id of the host resource on which this virtual machine will deploy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlacementProfileResourcePoolId
Gets or sets the ARM Id of the resourcePool resource on which this virtual machine will deploy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileDisk
Gets or sets the list of virtual disks associated with the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualDisk[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UefiSettingSecureBootEnabled
Specifies whether secure boot should be enabled on the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS
