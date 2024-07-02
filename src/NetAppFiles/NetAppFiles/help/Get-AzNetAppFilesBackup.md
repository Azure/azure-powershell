---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/get-aznetappfilesbackup
schema: 2.0.0
---

# Get-AzNetAppFilesBackup

## SYNOPSIS
Gets details of an Azure NetApp Files (ANF) Backup.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Get-AzNetAppFilesBackup -ResourceGroupName <String> -AccountName <String> [-PoolName <String>]
 [-VolumeName <String>] [-BackupVaultName <String>] [-Name <String>] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByAccountBackupFieldsParameterSet
```
Get-AzNetAppFilesBackup -ResourceGroupName <String> -AccountName <String> [-AccountBackupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByParentObjectParameterSet
```
Get-AzNetAppFilesBackup [-Name <String>] [-AccountBackupName <String>] [-VolumeObject <PSNetAppFilesVolume>]
 -BackupVaultObject <PSNetAppFilesBackupVault> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Get-AzNetAppFilesBackup -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzNetAppFilesBackup** cmdlet gets details of an ANF backup.

## EXAMPLES

### Example 1
```powershell
Get-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -PoolName "MyPool" -VolumeName "MyVolume" -Name "MyBackup"
```

This command gets the backup named "MyAnfAccount" from the volume named "MyVolume".

### Example 2
```powershell
Get-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -AccountBackupName "MyBackup"
```

This command gets the backup named "MyAnfAccount" from the Account named "MyAccount".

## PARAMETERS

### -AccountBackupName
The name of the ANF backup

```yaml
Type: System.String
Parameter Sets: ByAccountBackupFieldsParameterSet, ByParentObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
The name of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByAccountBackupFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupVaultName
The name of the ANF BackupVault

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupVaultObject
The BackupVault object containing the backup to return

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupVault
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Filter
Filter list of backups, this filter accepts volumeResourceId

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF backup

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByParentObjectParameterSet
Aliases: BackupName

Required: False
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, ByAccountBackupFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the ANF Backup

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

### -VolumeName
The name of the ANF volume

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeObject
The volume object containing the backup to return

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume
Parameter Sets: ByParentObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesVolume

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupVault

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackup

## NOTES

## RELATED LINKS

[New-AzNetAppFilesBackup](./New-AzNetAppFilesBackup.md)
[Remove-AzNetAppFilesBackup](./Remove-AzNetAppFilesBackup.md)
[Update-AzNetAppFilesBackup](./Update-AzNetAppFilesBackup.md)
[Get-AzNetAppFilesBackupPolicy](./Get-AzNetAppFilesBackupPolicy.md)
[New-AzNetAppFilesBackupPolicy](./New-AzNetAppFilesBackupPolicy.md)
[Update-AzNetAppFilesBackupPolicy](./Update-AzNetAppFilesBackupPolicy.md)
[Remove-AzNetAppFilesBackupPolicy](./Remove-AzNetAppFilesBackupPolicy.md)
[Get-AzNetAppFilesVolume](./Get-AzNetAppFilesVolume.md)
[New-AzNetAppFilesVolume](./New-AzNetAppFilesVolume.md)
[Update-AzNetAppFilesVolume](./Update-AzNetAppFilesVolume.md)
[Remove-AzNetAppFilesVolume](./Remove-AzNetAppFilesVolume.md)
