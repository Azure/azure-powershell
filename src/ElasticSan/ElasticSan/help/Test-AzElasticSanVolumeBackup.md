---
external help file: Az.ElasticSan-help.xml
Module Name: Az.ElasticSan
online version: https://learn.microsoft.com/powershell/module/az.elasticsan/test-azelasticsanvolumebackup
schema: 2.0.0
---

# Test-AzElasticSanVolumeBackup

## SYNOPSIS
Validate whether a disk snapshot backup can be taken for list of volumes.

## SYNTAX

### BackupExpanded (Default)
```
Test-AzElasticSanVolumeBackup -ElasticSanName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VolumeGroupName <String> -VolumeName <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaJsonString
```
Test-AzElasticSanVolumeBackup -ElasticSanName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VolumeGroupName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaJsonFilePath
```
Test-AzElasticSanVolumeBackup -ElasticSanName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VolumeGroupName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Backup
```
Test-AzElasticSanVolumeBackup -ElasticSanName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VolumeGroupName <String> -Parameter <IVolumeNameList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaIdentityElasticSanExpanded
```
Test-AzElasticSanVolumeBackup -VolumeGroupName <String> -ElasticSanInputObject <IElasticSanIdentity>
 -VolumeName <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaIdentityElasticSan
```
Test-AzElasticSanVolumeBackup -VolumeGroupName <String> -ElasticSanInputObject <IElasticSanIdentity>
 -Parameter <IVolumeNameList> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaIdentityExpanded
```
Test-AzElasticSanVolumeBackup -InputObject <IElasticSanIdentity> -VolumeName <String[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BackupViaIdentity
```
Test-AzElasticSanVolumeBackup -InputObject <IElasticSanIdentity> -Parameter <IVolumeNameList>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Validate whether a disk snapshot backup can be taken for list of volumes.

## EXAMPLES

### Example 1: Validate whether a disk snapshot backup can be taken for list of volumes.
```powershell
Test-AzElasticSanVolumeBackup -ResourceGroupName myresourcegroup -ElasticSanName myelasticsan -VolumeGroupName myvolumegroup -VolumeName myvolume
```

```output
ValidationStatus
----------------
Success
```

This command validates whether a disk snapshot backup can be taken for list of volumes.

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

### -ElasticSanInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: BackupViaIdentityElasticSanExpanded, BackupViaIdentityElasticSan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaJsonString, BackupViaJsonFilePath, Backup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: BackupViaIdentityExpanded, BackupViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Backup operation

```yaml
Type: System.String
Parameter Sets: BackupViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Backup operation

```yaml
Type: System.String
Parameter Sets: BackupViaJsonString
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

### -Parameter
object to hold array of volume names

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVolumeNameList
Parameter Sets: Backup, BackupViaIdentityElasticSan, BackupViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaJsonString, BackupViaJsonFilePath, Backup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaJsonString, BackupViaJsonFilePath, Backup
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeGroupName
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaJsonString, BackupViaJsonFilePath, Backup, BackupViaIdentityElasticSanExpanded, BackupViaIdentityElasticSan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeName
array of volume names

```yaml
Type: System.String[]
Parameter Sets: BackupExpanded, BackupViaIdentityElasticSanExpanded, BackupViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IVolumeNameList

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IPreValidationResponse

## NOTES

## RELATED LINKS
