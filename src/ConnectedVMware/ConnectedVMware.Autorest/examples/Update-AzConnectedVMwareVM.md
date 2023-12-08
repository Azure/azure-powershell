### Example 1: Update Virtual Machine Instances Resource Memory Size
```powershell
Update-AzConnectedVMwareVM -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine" -HardwareProfileMemorySizeMb 2048
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 2048
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpus                  : 1
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
                                            "ipAddresses": [ "10.150.176.100", "fe80::250:56ff:fe95:ecbc", "2404:f801:4800:14:250:56ff:fe95:ecbc" ],
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
OSProfileComputerName                   : test-machine
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsRunning
OSProfileToolsVersion                   : 10304
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Clusters/test-cluster
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
                                            "lastUpdatedAt": "2023-10-06T14:09:12.3939694Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T14:09:12.3939694Z"
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
SystemDataCreatedBy                     : sanmishra@microsoft.com
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 2:09:19 PM
SystemDataLastModifiedBy                : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType            : Application
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command update Memory Size of a VM Instances of machine named `test-machine`.