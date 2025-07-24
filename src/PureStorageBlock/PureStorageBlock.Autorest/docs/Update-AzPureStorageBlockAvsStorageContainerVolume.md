---
external help file:
Module Name: Az.PureStorageBlock
online version: https://learn.microsoft.com/powershell/module/az.purestorageblock/update-azpurestorageblockavsstoragecontainervolume
schema: 2.0.0
---

# Update-AzPureStorageBlockAvsStorageContainerVolume

## SYNOPSIS
Update a volume in an AVS storage container

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPureStorageBlockAvsStorageContainerVolume -ResourceGroupName <String> -StorageContainerName <String>
 -StoragePoolName <String> -VolumeId <String> [-SubscriptionId <String>] [-SoftDeletionDestroyed]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAvsStorageContainerExpanded
```
Update-AzPureStorageBlockAvsStorageContainerVolume -AvsStorageContainerInputObject <IPureStorageBlockIdentity>
 -VolumeId <String> [-SoftDeletionDestroyed] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPureStorageBlockAvsStorageContainerVolume -InputObject <IPureStorageBlockIdentity>
 [-SoftDeletionDestroyed] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityStoragePoolExpanded
```
Update-AzPureStorageBlockAvsStorageContainerVolume -StorageContainerName <String>
 -StoragePoolInputObject <IPureStorageBlockIdentity> -VolumeId <String> [-SoftDeletionDestroyed]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPureStorageBlockAvsStorageContainerVolume -ResourceGroupName <String> -StorageContainerName <String>
 -StoragePoolName <String> -VolumeId <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPureStorageBlockAvsStorageContainerVolume -ResourceGroupName <String> -StorageContainerName <String>
 -StoragePoolName <String> -VolumeId <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a volume in an AVS storage container

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
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
```

### -AvsStorageContainerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: UpdateViaIdentityAvsStorageContainerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeletionDestroyed
If false, the resource is active; if true, the resource has been destroyed; resources can be soft-deleted by setting destroyed to true, and recovered by setting it to false

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityAvsStorageContainerExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityStoragePoolExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageContainerName
Name of the storage container

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityStoragePoolExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StoragePoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity
Parameter Sets: UpdateViaIdentityStoragePoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StoragePoolName
Name of the storage pool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeId
ID of the volume in the storage container

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityAvsStorageContainerExpanded, UpdateViaIdentityStoragePoolExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IPureStorageBlockIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PureStorageBlock.Models.IAvsStorageContainerVolume

## NOTES

## RELATED LINKS

