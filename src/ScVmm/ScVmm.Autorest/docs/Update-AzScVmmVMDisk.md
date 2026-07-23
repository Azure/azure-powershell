---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/update-azscvmmvmdisk
schema: 2.0.0
---

# Update-AzScVmmVMDisk

## SYNOPSIS
The operation to Update a virtual machine virtual disk.

## SYNTAX

```
Update-AzScVmmVMDisk -ResourceGroupName <String> -vmName <String> [-bus <Int32>] [-busType <String>]
 [-DiskId <String>] [-DiskName <String>] [-diskSizeGB <Int32>] [-lun <Int32>] [-QosId <String>]
 [-QosName <String>] [-SubscriptionId <String>] [-vhdType <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to Update a virtual machine virtual disk.

## EXAMPLES

### Example 1: Update Virtual Disk of the virtual machine
```powershell
Update-AzScVmmVMDisk -vmName "test-vm" -ResourceGroupName "test-rg-01" -DiskName 'test-disk-01' -diskSizeGB 40
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
                                               "maxDiskSizeGB": 40,
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

Update Virtual Disk of the SCVMM Virtual Machine.

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

### -bus
Bus Number for the disk.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -busType


```yaml
Type: System.String
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

### -DiskId
The UUID of Virtual Disk

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskName
The name of Virtual Disk

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -diskSizeGB
Size of the disk in GB

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -lun
Lun Number for the disk.

```yaml
Type: System.Int32
Parameter Sets: (All)
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

### -QosId
UUID of the Storage QoS Policy to be applied on the disk.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QosName
Name of the Storage QoS Policy to be applied on the disk.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -vhdType


```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -vmName
The name of the virtual machine.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS

