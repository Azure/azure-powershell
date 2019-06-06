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
 -OSDiskOsstate <OperatingSystemStateTypes> -OSDiskOstype <OperatingSystemTypes>
 [-DataDisk <IImageDataDisk[]>] [-HyperVGeneration <HyperVGenerationTypes>] [-ManagedDiskId <String>]
 [-OSDiskBlobUri <String>] [-OSDiskCaching <CachingTypes>] [-OSDiskSizeGb <Int32>]
 [-OSDiskStorageAccountType <StorageAccountTypes>] [-SnapshotId <String>] [-SourceVirtualMachineId <String>]
 [-Tag <IUpdateResourceTags>] [-ZoneResilient] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzImage -InputObject <IComputeIdentity> -OSDiskOsstate <OperatingSystemStateTypes>
 -OSDiskOstype <OperatingSystemTypes> [-DataDisk <IImageDataDisk[]>]
 [-HyperVGeneration <HyperVGenerationTypes>] [-ManagedDiskId <String>] [-OSDiskBlobUri <String>]
 [-OSDiskCaching <CachingTypes>] [-OSDiskSizeGb <Int32>] [-OSDiskStorageAccountType <StorageAccountTypes>]
 [-SnapshotId <String>] [-SourceVirtualMachineId <String>] [-Tag <IUpdateResourceTags>] [-ZoneResilient]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DataDisk
Specifies the parameters that are used to add a data disk to a virtual machine.
  For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-about-disks-vhdstoc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json).

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
  Possible values are:    **None**    **ReadOnly**    **ReadWrite**    Default: **None for Standard storage.
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskOstype
This property allows you to specify the type of the OS that is included in the disk if creating a VM from a custom image.
  Possible values are:    **Windows**    **Linux**

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.OperatingSystemTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSDiskSizeGb
Specifies the size of empty data disks in gigabytes.
This element can be used to overwrite the name of the disk in a virtual machine image.
  This value cannot be larger than 1023 GB

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IUpdateResourceTags
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
Default value: False
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

## RELATED LINKS

