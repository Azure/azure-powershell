---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesvolumebackupstatus
schema: 2.0.0
---

# Get-AzNetAppFilesVolumeBackupStatus

## SYNOPSIS
Get volume's backup status

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesVolumeBackupStatus -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesVolumeBackupStatus -Name <String> -PoolObject <PSNetAppFilesPool>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesVolumeBackupStatus -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Get-AzNetAppFilesVolumeBackupStatus -InputObject <PSNetAppFilesVolume>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesVolumeBackupStatus** cmdLet gets the status of the backup for a volume

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesVolumeBackupStatus -ResourceGroupName MyGroup -AccountName MyAccount -PoolName MyPool -Name MyVolume
```

This command gets the status of a backup of volume named "MyVolume".

## PARAMETERS

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The volume object to get backup status for

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: VolumeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
The name of the ANF pool

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolObject
The pool object containing the volume to return

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesPool

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolumeBackupStatus

## NOTES

## RELATED LINKS

[New-AzNetAppFilesBackup](./New-AzNetAppFilesBackup.md)
[Remove-AzNetAppFilesBackup](./Remove-AzNetAppFilesBackup.md)
[Update-AzNetAppFilesBackup](./Update-AzNetAppFilesBackup.md)
[Get-AzNetAppFilesBackupPolicy](./Get-AzNetAppFilesBackupPolicy.md)
[New-AzNetAppFilesBackupPolicy](./New-AzNetAppFilesBackupPolicy.md)
[Update-AzNetAppFilesBackupPolicy](./Update-AzNetAppFilesBackupPolicy.md)
[Remove-AzNetAppFilesBackupPolicy](./Remove-AzNetAppFilesBackupPolicy.md)
[Set-AzNetAppFilesBackupPolicy](./Set-AzNetAppFilesBackupPolicy.md)
[Get-AzNetAppFilesVolume](./Get-AzNetAppFilesVolume.md)
[New-AzNetAppFilesVolume](./New-AzNetAppFilesVolume.md)
[Update-AzNetAppFilesVolume](./Update-AzNetAppFilesVolume.md)
[Remove-AzNetAppFilesVolume](./Remove-AzNetAppFilesVolume.md)
