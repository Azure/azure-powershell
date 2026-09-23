### Example 1: Enable existing Virtual Machine in Azure
```powershell
New-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -VmmServerName "test-vmm" -InventoryUuid "00000000-1111-0000-0001-000000000000" -Location "eastus"
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
InfrastructureProfileCloudId               :
InfrastructureProfileGeneration            : 1
InfrastructureProfileInventoryItemId       : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmm/InventoryItems/00000000-1111-0000-0001-000000000000
InfrastructureProfileTemplateId            :
InfrastructureProfileUuid                  : 00000000-1111-0000-0001-000000000000
InfrastructureProfileVMName                : test-vm
InfrastructureProfileVmmServerId           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmm
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
                                             }}
SystemDataCreatedAt                        : 08-01-2024 15:05:41
SystemDataCreatedBy                        : user@contoso.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 08-01-2024 15:14:34
SystemDataLastModifiedBy                   : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType               : Application
Type                                       : microsoft.scvmm/virtualmachineinstances
```

Enable existing SCVMM Virtual Machine in Azure

### Example 2: Create new virtual machine using VM Template
```powershell
New-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -VmmServerName "test-vmm" -Location 'eastus' -CloudName 'test-cloud' -TemplateName 'test-template'
```

```output
Virtual Machine resource is returned similar to Example 1
```


Create new virtual machine on on-prem SCVMM

### Example 3: Create new virtual machine using VM Template and customizing few properties
```powershell
$securePassword = ConvertTo-SecureString "******" -AsPlainText -Force
New-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -VmmServerName "test-vmm" -Location 'eastus' -CloudName 'test-cloud' -TemplateName 'test-template' -CpuCount 4 -AdminPassword $securePassword -Generation 2 -Tag @{"key-1"="value-1234"}
```

```output
Virtual Machine resource is returned similar to Example 1
```

Create new virtual machine on on-prem SCVMM

### Example 4: Enable existing Virtual Machine in Azure
```powershell
New-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -VmmServerId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmm" -CustomLocationId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl" -Location "eastus"
```

```output
Virtual Machine resource is returned similar to Example 1. This is useful when we want to enable VM in a different ResourceGroup.
```

Enable existing SCVMM Virtual Machine in Azure

### Example 5: Create new virtual machine using VM Template
```powershell
New-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -Location "eastus" -CustomLocationId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl" -VmmServerId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmm" -CloudId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/Clouds/test-cloud"  -TemplateId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.SCVMM/VirtualMachineTemplates/test-template" 
```

```output
Virtual Machine resource is returned similar to Example 1. This is useful when we want to create VM in a different ResourceGroup.
```

Enable existing SCVMM Virtual Machine in Azure
