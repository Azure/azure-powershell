---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/update-azscvmmvm
schema: 2.0.0
---

# Update-AzScVmmVM

## SYNOPSIS
The operation to update a virtual machine (Use separate commands for NIC and Disk update on virtual Machine).

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzScVmmVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-CpuCount <Int32>]
 [-DynamicMemoryEnabled] [-DynamicMemoryMaxMb <Int32>] [-DynamicMemoryMinMb <Int32>] [-LimitCpuForMigration]
 [-MemoryMb <Int32>] [-CheckpointType <String>] [-AvailabilitySetName <String[]>]
 [-AvailabilitySetId <String[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzScVmmVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzScVmmVM -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a virtual machine (Use separate commands for NIC and Disk update on virtual Machine).

## EXAMPLES

### Example 1: Update Virtual Machine
```powershell
Update-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -CpuCount 4
```

```output
AvailabilitySet                            : {}
ExtendedLocationName                       : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType                       : customLocations
HardwareProfileCpuCount                    : 4
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
                                             }}
SystemDataCreatedAt                        : 08-01-2024 15:05:41
SystemDataCreatedBy                        : user@contoso.com
SystemDataCreatedByType                    : User
SystemDataLastModifiedAt                   : 08-01-2024 15:14:34
SystemDataLastModifiedBy                   : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType               : Application
Type                                       : microsoft.scvmm/virtualmachineinstances
```

Updates HardwareProfile properties for Virtual Machine.
For Disk and NIC related updates on the given Virtual Machine use `Update-AzScVmmVMVirtualDisk` and `Update-AzScVmmVMNetworkInterface` respectively.

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

### -AvailabilitySetId
Availability Sets in vm.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilitySetName
Availability Sets in vm.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckpointType
Type of checkpoint supported for the vm.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CpuCount
Gets or sets the number of vCPUs for the vm.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
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

### -DynamicMemoryEnabled
Whether to enable dynamic memory or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMemoryMaxMb
Gets or sets the max dynamic memory for the vm.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DynamicMemoryMinMb
Gets or sets the min dynamic memory for the vm.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitCpuForMigration
Whether to enable processor compatibility mode for live migration of VMs.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemoryMb
MemoryMB is the size of a virtual machine's memory, in MB.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VMName

Required: True
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

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS
