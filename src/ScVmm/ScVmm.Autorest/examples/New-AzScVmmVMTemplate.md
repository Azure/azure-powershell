### Example 1: Create a SCVMM Virtual Machine Template resource
```powershell
New-AzScVmmVMTemplate -Name "test-vmt" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -Location "eastus" -ExtendedLocationType "customLocation" -ExtendedLocationName "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourcegroups/test-rg-01/providers/microsoft.extendedlocation/customlocations/test-cl" -InventoryItemId "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VMMServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0001-000000000000"
```

```output
ComputerName                 : *
CpuCount                     : 1
Disk                         : {{
                                 "name": "disk_1",
                                 "displayName": "disk.vhd",
                                 "diskId": "00000000-1133-0000-0001-000000000000",
                                 "diskSizeGB": 9,
                                 "maxDiskSizeGB": 40,
                                 "bus": 0,
                                 "lun": 0,
                                 "busType": "IDE",
                                 "vhdType": "Dynamic",
                                 "volumeType": "BootAndSystem",
                                 "vhdFormatType": "VHD",
                                 "createDiffDisk": "false"
                               }}
DynamicMemoryEnabled         : false
DynamicMemoryMaxMb           :
DynamicMemoryMinMb           :
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Generation                   : 1
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/VirtualNetworks/test-vmt
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0001-000000000000
IsCustomizable               : true
IsHighlyAvailable            : false
LimitCpuForMigration         : false
Location                     : eastus
MemoryMb                     : 1024
Name                         : test-vmt
NetworkInterface             : {{
                                 "name": "nic_1",
                                 "displayName": "Network Adapter 1",
                                 "virtualNetworkId": "/subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/provid
                               ers/Microsoft.SCVMM/VirtualNetworks/test-vnet",
                                 "networkName": "00000000-1111-0000-0001-000000000000",
                                 "ipv4AddressType": "Dynamic",
                                 "ipv6AddressType": "Dynamic",
                                 "macAddressType": "Dynamic",
                                 "nicId": "00000000-1122-0000-0001-000000000000"
                               }}
OSName                       : Windows Server
OSType                       : Windows
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 15:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/virtualnetworks
Uuid                         : 00000000-1111-0000-0001-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command creates a Virtual Machine Template resource named `test-vmt` in the resource group named `test-rg-01`.
