---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azimage
schema: 2.0.0
---

# Update-AzImage

## SYNOPSIS
Update an image.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzImage -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-DataDisk <IImageDataDisk[]>] [-HyperVGeneration <HyperVGenerationTypes>] [-ManagedDiskId <String>]
 [-OSDiskBlobUri <String>] [-OSDiskCaching <CachingTypes>] [-OSDiskOsstate <OperatingSystemStateTypes>]
 [-OSDiskOstype <OperatingSystemTypes>] [-OSDiskSizeInGb <Int32>]
 [-OSDiskStorageAccountType <StorageAccountTypes>] [-SnapshotId <String>] [-SourceVirtualMachineId <String>]
 [-Tag <Hashtable>] [-ZoneResilient] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzImage -InputObject <IComputeIdentity> [-DataDisk <IImageDataDisk[]>]
 [-HyperVGeneration <HyperVGenerationTypes>] [-ManagedDiskId <String>] [-OSDiskBlobUri <String>]
 [-OSDiskCaching <CachingTypes>] [-OSDiskOsstate <OperatingSystemStateTypes>]
 [-OSDiskOstype <OperatingSystemTypes>] [-OSDiskSizeInGb <Int32>]
 [-OSDiskStorageAccountType <StorageAccountTypes>] [-SnapshotId <String>] [-SourceVirtualMachineId <String>]
 [-Tag <Hashtable>] [-ZoneResilient] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an image.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
```

### -DataDisk
Specifies the parameters that are used to add a data disk to a virtual machine.


 For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
To construct, see NOTES section for DATADISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IImageDataDisk[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HyperVGeneration
Gets the HyperVGenerationType of the VirtualMachine created from the image

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HyperVGenerationTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ManagedDiskId
Resource Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the image.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases: ImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -OSDiskBlobUri
The Virtual Hard Disk.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskCaching
Specifies the caching requirements.


 Possible values are: 

 **None** 

 **ReadOnly** 

 **ReadWrite** 

 Default: **None for Standard storage.
ReadOnly for Premium storage**

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.CachingTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskOsstate
The OS State.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.OperatingSystemStateTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskOstype
This property allows you to specify the type of the OS that is included in the disk if creating a VM from a custom image.


 Possible values are: 

 **Windows** 

 **Linux**

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskSizeInGb
Specifies the size of empty data disks in gigabytes.
This element can be used to overwrite the name of the disk in a virtual machine image.


 This value cannot be larger than 1023 GB

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskStorageAccountType
Specifies the storage account type for the managed disk.
UltraSSD_LRS cannot be used with OS Disk.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SnapshotId
Resource Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceVirtualMachineId
Resource Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ZoneResilient
Specifies whether an image is zone resilient or not.
Default is false.
Zone resilient images can be created only in regions that provide Zone Redundant Storage (ZRS).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.IImage

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DATADISK <IImageDataDisk[]>: Specifies the parameters that are used to add a data disk to a virtual machine.    For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).
  - `Lun <Int32>`: Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
  - `[BlobUri <String>]`: The Virtual Hard Disk.
  - `[Caching <CachingTypes?>]`: Specifies the caching requirements.    Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage. ReadOnly for Premium storage**
  - `[ManagedId <String>]`: Resource Id
  - `[SizeInGb <Int32?>]`: Specifies the size of empty data disks in gigabytes. This element can be used to overwrite the name of the disk in a virtual machine image.    This value cannot be larger than 1023 GB
  - `[SnapshotId <String>]`: Resource Id
  - `[StorageAccountType <StorageAccountTypes?>]`: Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.

#### INPUTOBJECT <IComputeIdentity>: Identity Parameter
  - `[AvailabilitySetName <String>]`: The name of the availability set.
  - `[CommandId <String>]`: The command id.
  - `[DiskName <String>]`: The name of the managed disk that is being created. The name can't be changed after the disk is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The maximum name length is 80 characters.
  - `[GalleryImageDefinitionName <String>]`: The name of the gallery Image Definition to be created or updated. The allowed characters are alphabets and numbers with dots, dashes, and periods allowed in the middle. The maximum length is 80 characters.
  - `[GalleryImageVersionName <String>]`: The name of the gallery Image Version to be created. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: <MajorVersion>.<MinorVersion>.<Patch>
  - `[GalleryName <String>]`: The name of the Shared Image Gallery. The allowed characters are alphabets and numbers with dots and periods allowed in the middle. The maximum length is 80 characters.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[InstanceId <String>]`: The instance ID of the virtual machine.
  - `[Location <String>]`: The name of a supported Azure region.
  - `[Offer <String>]`: A valid image publisher offer.
  - `[ProximityPlacementGroupName <String>]`: The name of the proximity placement group.
  - `[PublisherName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[Sku <String>]`: A valid image SKU.
  - `[SnapshotName <String>]`: The name of the snapshot that is being created. The name can't be changed after the snapshot is created. Supported characters for the name are a-z, A-Z, 0-9 and _. The max name length is 80 characters.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[Type <String>]`: 
  - `[VMExtensionName <String>]`: The name of the virtual machine extension.
  - `[VMName <String>]`: The name of the virtual machine.
  - `[VMScaleSetName <String>]`: The name of the VM scale set.
  - `[Version <String>]`: 
  - `[VirtualMachineScaleSetName <String>]`: The name of the VM scale set.
  - `[VmssExtensionName <String>]`: The name of the VM scale set extension.

## RELATED LINKS

