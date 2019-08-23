---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/set-azimage
schema: 2.0.0
---

# Set-AzImage

## SYNOPSIS
Create or update an image.

## SYNTAX

```
Set-AzImage -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -Location <String>
 [-DataDisk <IImageDataDisk[]>] [-HyperVGeneration <HyperVGenerationTypes>] [-ManagedDiskId <String>]
 [-OSDiskBlobUri <String>] [-OSDiskCaching <CachingTypes>] [-OSDiskOsstate <OperatingSystemStateTypes>]
 [-OSDiskOstype <OperatingSystemTypes>] [-OSDiskSizeInGb <Int32>]
 [-OSDiskStorageAccountType <StorageAccountTypes>] [-SnapshotId <String>] [-SourceVirtualMachineId <String>]
 [-Tag <Hashtable>] [-ZoneResilient] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update an image.

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

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## RELATED LINKS

