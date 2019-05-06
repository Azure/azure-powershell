---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 12F8A120-7282-4844-90E0-1C3393336E8A
online version: https://docs.microsoft.com/en-us/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupjob
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupJob

## SYNOPSIS
Gets Backup jobs.

## SYNTAX

```
Get-AzRecoveryServicesBackupJob [[-Status] <JobStatus>] [[-Operation] <JobOperation>] [[-From] <DateTime>]
 [[-To] <DateTime>] [[-JobId] <String>] [[-Job] <JobBase>] [-BackupManagementType <BackupManagementType>]
 [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzRecoveryServicesBackupJob** cmdlet gets Azure Backup jobs for a specific vault.
Set the vault context by using the Set-AzRecoveryServicesVaultContext cmdlet before you use the current cmdlet.

## EXAMPLES

### Example 1: Get all in-progress jobs
```
PS C:\>$Joblist = Get-AzRecoveryservicesBackupJob -Status Inprogress
PS C:\> $Joblist[0]
WorkloadName     Operation            Status               StartTime                 EndTime                                             
------------     ---------            ------               ---------                 -------                                             
V2VM             Backup               InProgress           4/23/2016 5:00:30 PM      1/1/2001 12:00:00
```

The first command gets status of an in-progress job as an array, and then stores it in the $Joblist variable.
The second command displays the first item in the $Joblist array.

### Example 2: Get all failed jobs in the last 7 days
```
PS C:\>Get-AzRecoveryServicesBackupJob -From (Get-Date).AddDays(-7).ToUniversalTime() -Status Failed
```

This command gets failed jobs from the last week in the vault.
The *From* parameter specifies a time seven days in the past specified in UTC.
The command does not specify a value for the *To* parameter.
Therefore, it uses the default value of the current time.

### Example 3: Get an in-progress job and wait for completion
```
PS C:\> 
$Jobs = Get-AzRecoveryServicesBackupJob -Status InProgress
$Job = $Jobs[0]
    while ( $Job.Status -ne Completed )
    {
       Write-Host "Waiting for completion..."
       Start-Sleep -Seconds 10
       $job = Get-AzBackAzureRmRecoveryServicesBackupJob  -Job $Job
    }
    Write-Host "Done!"
    Waiting for completion... 
    Waiting for completion... 
    Waiting for completion... 
    Done!
```

This script polls the first job that is currently in progress until the job has completed.

## PARAMETERS

### -BackupManagementType
Specifies the Backup management type.
Currently, only AzureVM, AzureStorage is supported.

```yaml
Type: BackupManagementType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, MARS, SCDPM, AzureBackupServer, AzureSQL, AzureStorage, AzureWorkload

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -From
Specifies the start, as a **DateTime** object, of a time range for the jobs that this cmdlet gets.
To obtain a **DateTime** object, use the Get-Date cmdlet.
For more information about **DateTime** objects, type `Get-Help Get-Date`.
Use UTC format for dates.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Job
Specifies the name of the Backup job to get.

```yaml
Type: JobBase
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobId
Specifies the ID of a job that this cmdlet gets.
The ID is the InstanceId property of an **AzureRmRecoveryServicesBackupJob** object.
To obtain an **AzureRmRecoveryServicesBackupJob** object, use Get-AzRecoveryServicesBackupJob.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Specifies an operation of the jobs that this cmdlet gets.
The acceptable values for this parameter are:
- Backup
- ConfigureBackup
- DeleteBackupData
- Register
- Restore
- UnProtect
- Unregister

```yaml
Type: JobOperation
Parameter Sets: (All)
Aliases:
Accepted values: Backup, Restore, ConfigureBackup, DisableBackup, DeleteBackupData

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Specifies a status of the jobs that this cmdlet gets.
The acceptable values for this parameter are:
- InProgress
- Failed
- Cancelled
- Cancelling
- Completed
- CompletedWithWarnings

```yaml
Type: JobStatus
Parameter Sets: (All)
Aliases:
Accepted values: InProgress, Cancelling, Cancelled, Completed, CompletedWithWarnings, Failed

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -To
Specifies the end, as a **DateTime** object, of a time range for the jobs that this cmdlet gets.
The default value is the current system time.
If you specify this parameter, you must also specify the *From* parameter.
Use UTC format for dates.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
ARM ID of the Recovery Services Vault.

```yaml
Type: String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.JobBase

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesBackupJobDetails](./Get-AzRecoveryServicesBackupJobDetails.md)

[Stop-AzRecoveryServicesBackupJob](./Stop-AzRecoveryServicesBackupJob.md)

[Wait-AzRecoveryServicesBackupJob](./Wait-AzRecoveryServicesBackupJob.md)


