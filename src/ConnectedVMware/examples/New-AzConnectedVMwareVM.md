### Example 1: Create Virtual Machine Instances on the given Resource Pool
```powershell
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileResourcePoolId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/resourcepools/test-rp" -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
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
PlacementProfileResourcePoolId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/ResourcePools/test-rp
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
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileClusterId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/clusters/test-cluster" -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
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
PlacementProfileClusterId               : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Clusters/test-cluster
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
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileTemplateId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl" -InfrastructureProfileVCenterId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc" -PlacementProfileHostId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/hosts/test-host" -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 1
Id                                      : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-vmtmpl
InfrastructureProfileVCenterId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
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
PlacementProfileHostId                  : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Hosts/test-host
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
New-AzConnectedVMwareVM -ExtendedLocationName "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl" -ExtendedLocationType "CustomLocation" -InfrastructureProfileInventoryItemId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vm-1528583" -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine-ps"
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : False
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : False
HardwareProfileMemorySizeMb             : 8192
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpUs                  : 4
Id                                      : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine-ps/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : 9d8766c2-6e02-4553-8ae2-7c37a19cb45b
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67/test-folder
InfrastructureProfileInstanceUuid       : 5015d462-e12c-623f-45ad-ddfecc541d51
InfrastructureProfileInventoryItemId    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc/InventoryItems/vm-1528583
InfrastructureProfileMoName             : test-ps-vm
InfrastructureProfileMoRefId            : vm-1528583
InfrastructureProfileSmbiosUuid         : 421532ab-22b5-67b4-41fd-829f0e7355b9
InfrastructureProfileTemplateId         :
InfrastructureProfileVCenterId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VCenters/test-vc
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