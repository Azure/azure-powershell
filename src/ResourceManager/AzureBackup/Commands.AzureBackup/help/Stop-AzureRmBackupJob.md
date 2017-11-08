---
external help file: Microsoft.Azure.Commands.AzureBackup.dll-Help.xml
Module Name: AzureRM.Backup
ms.assetid: 44C5AF58-ADC1-4BC6-9771-3FD8F0480106
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.backup/stop-azurermbackupjob
schema: 2.0.0
---

# Stop-AzureRmBackupJob

## SYNOPSIS
Cancels an existing Backup job.

## SYNTAX

### IdFiltersSet
```
Stop-AzureRmBackupJob -Vault <AzureRMBackupVault> -JobID <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### JobFiltersSet
```
Stop-AzureRmBackupJob -Job <AzureRMBackupJob> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Stop-AzureRmBackupJob** cmdlet cancels an existing Azure Backup job.
Use this parameter to stop a job that takes too long and blocks other activities.

You can cancel only the following types of jobs: 

- Backup
- Restore

## EXAMPLES

### Example 1: Stop a backup job by using a job ID
```
PS C:\>$Vault = Get-AzureRmBackupVault -Name "Vault03" 
PS C:\> $Job = Get-AzureRmBackupJob -Vault $Vault -Operation Backup
PS C:\> Stop-AzureRmBackupJob -Vault $Vault -JobID $Job.InstanceId
```

The first command gets the vault named Vault03 by using the **Get-AzureRmBackupVault** cmdlet.
The command stores that object in the $Vault variable.

The second command gets a backup job from the vault in $Vault by using the **Get-AzureRmBackupJob** cmdlet.
The command stores the job in the $Job variable.
In this example, there is only one backup operation in the specified vault.

The final command stops the job that has the specified ID.

### Example 2: Stop all Restore operations
```
PS C:\>Get-AzureRmBackupJob -Vault $Vault -Operation Restore | Stop-AzureRmBackupJob
```

This command gets all the restore operations in the vault in $Vault, and then passes them to the current cmdlet by using the pipeline operator.
The current cmdlet stops each job.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Job
Specifies a job that this cmdlet cancels.
To obtain an **AzureRmBackupJob** object, use the Get-AzureRmBackupJob cmdlet.

```yaml
Type: AzureRMBackupJob
Parameter Sets: JobFiltersSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobID
Specifies a job that this cmdlet cancels.
To obtain an **AzureRmBackupJob** object, use the Get-AzureRmBackupJob cmdlet.

```yaml
Type: String
Parameter Sets: IdFiltersSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Specifies the Backup vault in which this cmdlet cancels a job.
To obtain an **AzureRmBackupVault** object, use the Get-AzureRmBackupVault cmdlet.

```yaml
Type: AzureRMBackupVault
Parameter Sets: IdFiltersSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### AzureRmBackupJob

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Get-AzureRmBackupJob](./Get-AzureRmBackupJob.md)

[Get-AzureRmBackupVault](./Get-AzureRmBackupVault.md)

[Wait-AzureRmBackupJob](./Wait-AzureRmBackupJob.md)


