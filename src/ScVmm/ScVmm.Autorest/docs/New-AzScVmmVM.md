---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/new-azscvmmvm
schema: 2.0.0
---

# New-AzScVmmVM

## SYNOPSIS
The operation to create a virtual machine.
Please note some properties can be set only during virtual machine creation.

## SYNTAX

### CreateExpandedByName (Default)
```
New-AzScVmmVM -Name <String> -ResourceGroupName <String> -Location <String> -VmmServerName <String>
 [-SubscriptionId <String>] [-AdminPassword <SecureString>] [-AvailabilitySetName <String[]>]
 [-CheckpointType <String>] [-CloudName <String>] [-ComputerName <String>] [-CpuCount <Int32>]
 [-Disk <IVirtualDisk[]>] [-DynamicMemoryEnabled] [-DynamicMemoryMaxMb <Int32>] [-DynamicMemoryMinMb <Int32>]
 [-Generation <Int32>] [-InventoryUuid <String>] [-LimitCpuForMigration] [-MemoryMb <Int32>]
 [-NetworkInterface <INetworkInterface[]>] [-Tag <Hashtable>] [-TemplateName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateByName
```
New-AzScVmmVM -Name <String> -ResourceGroupName <String> -Location <String> -VmmServerName <String>
 [-SubscriptionId <String>] [-CloudName <String>] [-InventoryUuid <String>] [-Tag <Hashtable>]
 [-TemplateName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpandedById
```
New-AzScVmmVM -Name <String> -ResourceGroupName <String> -CustomLocationId <String> -Location <String>
 -VmmServerId <String> [-SubscriptionId <String>] [-AdminPassword <SecureString>]
 [-AvailabilitySetId <String[]>] [-CheckpointType <String>] [-CloudId <String>] [-ComputerName <String>]
 [-CpuCount <Int32>] [-Disk <IVirtualDisk[]>] [-DynamicMemoryEnabled] [-DynamicMemoryMaxMb <Int32>]
 [-DynamicMemoryMinMb <Int32>] [-Generation <Int32>] [-InventoryId <String>] [-LimitCpuForMigration]
 [-MemoryMb <Int32>] [-NetworkInterface <INetworkInterface[]>] [-Tag <Hashtable>] [-TemplateId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzScVmmVM -Name <String> -ResourceGroupName <String> -JsonFilePath <String> -Location <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzScVmmVM -Name <String> -ResourceGroupName <String> -JsonString <String> -Location <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The operation to create a virtual machine.
Please note some properties can be set only during virtual machine creation.

To enable existing SCVMM virtual machine in Azure execute the command with `InventoryUuid` or `InventoryItemId`.
To create a new virtual machine execute the command with `CloudName` and `TemplateName` or equivalent Id parameters.

To enable resource in the same Resource Group as VMM Sever/Cloud/Virtual Network/VM Template resource resides execute the command with `CreateByName` or `CreateExpandedByName` Parameter Set.
To enable resource in a different Resource Group than the one where VMM Sever/Cloud/Virtual Network/VM Template resource resides execute the command with `CreateExpandedById` Parameter Set.

`InventoryUuid` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\>` (check Name(UUID format) for required InventoryItemName and InventoryType).
`InventoryItemId` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\> -Name \<uuid\>` (check for Id property in the response).
`VmmServerId` can be retrieved using `Get-AzScVmmServer` (check for `Id` property in the response).
`CloudId` can be retrieved using `Get-AzScVmmCloud` (check for `Id` property in the response).
`TemplateId` can be retrieved using `Get-AzScVmmVmTemplate` (check for `Id` property in the response).
`AvailabilitySetId` can be retrieved using `Get-AzScVmmAvailabilitySet` (check for `Id` property in the response).
`CustomLocationId` can be retrieved using `Get-AzScVmmServer` (check for `ExtendedLocationName` property in the response).

## EXAMPLES

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

## PARAMETERS

### -AdminPassword
Admin password of the virtual machine.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: CreateExpandedById
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
Parameter Sets: CreateExpandedByName
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
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudId
ARM Id of the cloud resource to use for deploying the vm.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudName
UUID of the cloud resource to use for deploying the vm.

```yaml
Type: System.String
Parameter Sets: CreateByName, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputerName
Sets computer name.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById, CreateExpandedByName
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
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomLocationId
ARM Id of the custom location.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById
Aliases:

Required: True
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

### -Disk
Gets or sets the list of virtual disks associated with the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualDisk[]
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

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
Parameter Sets: CreateExpandedById, CreateExpandedByName
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
Parameter Sets: CreateExpandedById, CreateExpandedByName
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
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Generation
Generation for the vm.

```yaml
Type: System.Int32
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InventoryId
ARM Id of the inventory virtual machine resource to enable in Azure.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InventoryUuid
UUID of the inventory virtual machine resource to enable in Azure.

```yaml
Type: System.String
Parameter Sets: CreateByName, CreateExpandedByName
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

### -LimitCpuForMigration
Whether to enable processor compatibility mode for live migration of VMs.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives.

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

### -MemoryMb
MemoryMB is the size of a virtual machine's memory, in MB.

```yaml
Type: System.Int32
Parameter Sets: CreateExpandedById, CreateExpandedByName
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

### -NetworkInterface
Gets or sets the list of network interfaces associated with the virtual machine.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.INetworkInterface[]
Parameter Sets: CreateExpandedById, CreateExpandedByName
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
Parameter Sets: CreateByName, CreateExpandedById, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateId
ARM Id of the template resource to use for deploying the vm.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateName
Name of the template resource to use for deploying the vm.

```yaml
Type: System.String
Parameter Sets: CreateByName, CreateExpandedByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmmServerId
ARM Id of the vmmServer resource in which this resource resides.

```yaml
Type: System.String
Parameter Sets: CreateExpandedById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmmServerName
Name of the vmmServer resource in which this resource resides.

```yaml
Type: System.String
Parameter Sets: CreateByName, CreateExpandedByName
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

