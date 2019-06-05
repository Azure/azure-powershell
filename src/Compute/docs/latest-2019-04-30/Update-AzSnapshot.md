---
external help file:
Module Name: Az.Compute
online version: https://docs.microsoft.com/en-us/powershell/module/az.compute/update-azsnapshot
schema: 2.0.0
---

# Update-AzSnapshot

## SYNOPSIS
Updates (patches) a snapshot.

## SYNTAX

### Update (Default)
```
Update-AzSnapshot -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Snapshot <ISnapshotUpdate>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzSnapshot -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -EncryptionSettingCollectionEnabled [-DiskSizeGb <Int32>]
 [-EncryptionSettingCollectionEncryptionSetting <IEncryptionSettingsElement[]>]
 [-OSType <OperatingSystemTypes>] [-SkuName <SnapshotStorageAccountTypes>] [-Tag <ISnapshotUpdateTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSnapshot -InputObject <IComputeIdentity> -EncryptionSettingCollectionEnabled [-DiskSizeGb <Int32>]
 [-EncryptionSettingCollectionEncryptionSetting <IEncryptionSettingsElement[]>]
 [-OSType <OperatingSystemTypes>] [-SkuName <SnapshotStorageAccountTypes>] [-Tag <ISnapshotUpdateTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzSnapshot -InputObject <IComputeIdentity> [-Snapshot <ISnapshotUpdate>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates (patches) a snapshot.

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

### -DiskSizeGb
If creationData.createOption is Empty, this field is mandatory and it indicates the size of the VHD to create.
If this field is present for updates or creation with other options, it indicates a resize.
Resizes are only allowed if the disk is not attached to a running VM, and can only increase the disk's size.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
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

### -Name
The name of the snapshot that is being created.
The name can't be changed after the snapshot is created.
Supported characters for the name are a-z, A-Z, 0-9 and _.
The max name length is 80 characters.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: SnapshotName

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

### -SkuName
The sku name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.SnapshotStorageAccountTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Snapshot
Snapshot update resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.ISnapshotUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases: SnapshotUpdate

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.ISnapshotUpdateTags
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.ISnapshotUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20180930.ISnapshot

## ALIASES

## RELATED LINKS

