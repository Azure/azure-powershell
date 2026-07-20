### Example 1: Attach a new Virtual Disk to the virtual machine
```powershell
Add-AzScVmmVMDisk -vmName "test-vm" -ResourceGroupName "test-rg-01" -DiskName 'test-disk-01' -diskSizeGB 20 -bus 0 -lun 0
```

```output
AvailabilitySet                            : {}
ExtendedLocationName                       : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType                       : customLocations
HardwareProfileCpuCount                    : 2
HardwareProfileDynamicMemoryEnabled        : false
HardwareProfileDynamicMemoryMaxMb          :
HardwareProfileDynamicMemoryMinMb          :
HardwareProfileIsHighlyAvailable           : false
HardwareProfileLimitCpuForMigration        : false
HardwareProfileMemoryMb                    : 2048
Id                                         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.HybridCompute/machines/test-vm/providers/Microsoft.ScVmm     
                                             /virtualMachineInstances/default
InfrastructureProfileBiosGuid              : 00000000-1111-0000-0001-000000000000
InfrastructureProfileCheckpoint            : {}
InfrastructureProfileCheckpointType        : Production
InfrastructureProfileCloudId               : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/Clouds/
                                             test-cloud
InfrastructureProfileGeneration            : 2
InfrastructureProfileInventoryItemId       :
InfrastructureProfileTemplateId            : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/Virtual
                                             MachineTemplates/test-template
InfrastructureProfileUuid                  : 00000000-1111-0000-0001-000000000000
InfrastructureProfileVMName                : test-vm
InfrastructureProfileVmmServerId           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServ
                                             ers/test-vmm
LastRestoredVMCheckpointDescription        :
LastRestoredVMCheckpointId                 :
LastRestoredVMCheckpointName               :
LastRestoredVMCheckpointParentCheckpointId :
Name                                       : default
NetworkProfileNetworkInterface             : {{
                                               "displayName": "Network Adapter 1",
                                               "macAddress": "00:00:00:00:00:00",
                                               "virtualNetworkId": "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualNetworks/test-vnet",
                                               "networkName": "00000000-1111-0000-0001-000000000000",
                                               "ipv4AddressType": "Dynamic",
                                               "ipv6AddressType": "Dynamic",
                                               "macAddressType": "Dynamic",
                                               "nicId": "00000000-1122-0000-0001-000000000000"
                                             }}
OSProfileAdminPassword                     :
OSProfileComputerName                      : ComputerName
OSProfileOssku                             : Windows Server
OSProfileOstype                            : Windows
OSProfileOsversion                         : 10.0.0
PowerState                                 : Running
ProvisioningState                          : Succeeded
ResourceGroupName                          : test-rg-01
StorageProfileDisk                         : {{
                                               "displayName": "WindowsServer.vhd",
                                               "diskId": "00000000-1111-0000-0001-000000000000",
                                               "diskSizeGB": 8,
                                               "maxDiskSizeGB": 40,
                                               "bus": 0,
                                               "lun": 0,
                                               "busType": "IDE",
                                               "vhdType": "Dynamic",
                                               "volumeType": "BootAndSystem",
                                               "vhdFormatType": "VHD",
                                               "createDiffDisk": "false"
                                             },
                                             {
                                               "name": "test-disk-01",
                                               "displayName": "test-vm_disk_1",
                                               "diskId": "00000000-1111-0000-0002-000000000000",
                                               "diskSizeGB": 0,
                                               "maxDiskSizeGB": 20,
                                               "bus": 0,
                                               "lun": 0,
                                               "busType": "SCSI",
                                               "vhdType": "Dynamic",
                                               "volumeType": "None",
                                               "vhdFormatType": "VHDX",
                                               "createDiffDisk": "false"
                                             }}
SystemDataCreatedAt                        : 08-01-2024 15:05:41
SystemDataCreatedBy                        : user@contoso.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 08-01-2024 15:14:34
SystemDataLastModifiedBy                   : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType               : Application
Type                                       : microsoft.scvmm/virtualmachineinstances
```

Attach a new Disk to the SCVMM Virtual Machine.
