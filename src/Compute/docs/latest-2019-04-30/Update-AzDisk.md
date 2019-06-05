---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azdisk
schema: 2.0.0
---

# Update-AzDisk

## SYNOPSIS
Updates (patches) a disk.

## SYNTAX

### Update (Default)
```
Update-AzDisk -Name <String> -ResourceGroupName <String> -SubscriptionId <String> [-Disk <IDiskUpdate>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzDisk -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -EncryptionSettingCollectionEnabled
 [-EncryptionSettingCollectionEncryptionSetting <IEncryptionSettingsElement[]>] [-IopsReadWrite <Int64>]
 [-MBpsReadWrite <Int32>] [-OSType <OperatingSystemTypes>] [-SizeGb <Int32>]
 [-SkuName <DiskStorageAccountTypes>] [-Tag <IDiskUpdateTags>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDisk -InputObject <IComputeIdentity> -EncryptionSettingCollectionEnabled
 [-EncryptionSettingCollectionEncryptionSetting <IEncryptionSettingsElement[]>] [-IopsReadWrite <Int64>]
 [-MBpsReadWrite <Int32>] [-OSType <OperatingSystemTypes>] [-SizeGb <Int32>]
 [-SkuName <DiskStorageAccountTypes>] [-Tag <IDiskUpdateTags>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzDisk -InputObject <IComputeIdentity> [-Disk <IDiskUpdate>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates (patches) a disk.

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

### -Disk
Disk update resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDiskUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases: DiskUpdate

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -EncryptionSettingCollectionEnabled
Set this flag to true and provide DiskEncryptionKey and optional KeyEncryptionKey to enable encryption.
Set this flag to false and remove DiskEncryptionKey and KeyEncryptionKey to disable encryption.
If EncryptionSettings is null in the request object, the existing settings remain unchanged.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptionSettingCollectionEncryptionSetting
A collection of encryption settings, one for each disk volume.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IEncryptionSettingsElement[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IopsReadWrite
The number of IOPS allowed for this disk; only settable for UltraSSD disks.
One operation can transfer between 4k and 256k bytes.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: DiskIopsReadWrite

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MBpsReadWrite
The bandwidth allowed for this disk; only settable for UltraSSD disks.
MBps means millions of bytes per second - MB here uses the ISO notation, of powers of 10.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: DiskMBpsReadWrite

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed disk that is being created.
The name can't be changed after the disk is created.
Supported characters for the name are a-z, A-Z, 0-9 and _.
The maximum name length is 80 characters.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: DiskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OSType
the Operating System type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.OperatingSystemTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SizeGb
If creationData.createOption is Empty, this field is mandatory and it indicates the size of the VHD to create.
If this field is present for updates or creation with other options, it indicates a resize.
Resizes are only allowed if the disk is not attached to a running VM, and can only increase the disk's size.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: DiskSizeGb

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The sku name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.DiskStorageAccountTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDiskUpdateTags
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDiskUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.IDisk

## ALIASES

## RELATED LINKS

