---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/new-aznetappfilesbackup
schema: 2.0.0
---

# New-AzNetAppFilesBackup

## SYNOPSIS
Creates a new Azure NetApp Files (ANF) backup.

## SYNTAX

### ByFieldsParameterSet (Default)
```
New-AzNetAppFilesBackup -ResourceGroupName <String> -AccountName <String> -BackupVaultName <String>
 -Name <String> -VolumeResourceId <String> [-Label <String>] [-UseExistingSnapshot] [-SnapshotName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByParentObjectParameterSet
```
New-AzNetAppFilesBackup -Name <String> -VolumeResourceId <String> [-Label <String>] [-UseExistingSnapshot]
 [-SnapshotName <String>] -BackupVaultObject <PSNetAppFilesBackupVault>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetAppFilesBackup** cmdlet creates a backup for an ANF volume.

## EXAMPLES

### Example 1
```powershell
$volumeResourceId = "/subscriptions/D633CC2E-722B-4AE1-B636-BBD9E4C60ED9/resourceGroups/myRG/providers/Microsoft.NetApp/netAppAccounts/MyAccount/capacityPools/MyPool/volumes/MyVolume"
New-AzNetAppFilesBackup -ResourceGroupName "MyRG" -AccountName "MyAccount" -BackupVaultName "MyVault" -Name "MyVolumeBackup" -Label "ALabel" -VolumeResourceId $volumeResourceId
```

This command creates the new ANF backup in vault MyVault for volume with resource Id $volumeResourceId.

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

### -BackupVaultName
The name of the ANF BackupVault

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

### -Label
Label for backup

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: BackupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the ANF account

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

### -SnapshotName
The name of the snapshot, use with UseExistingSnapshot

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseExistingSnapshot
Manual backup an already existing snapshot. This will always be false for scheduled backups and true/false for manual backups

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

### -VolumeResourceId
ResourceId used to identify the Volume

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

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackupVault

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBackup

## NOTES

## RELATED LINKS

[Get-AzNetAppFilesBackup](./Get-AzNetAppFilesBackup.md)
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
