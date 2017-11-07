---
external help file: Microsoft.Azure.Commands.AzureBackup.dll-Help.xml
Module Name: AzureRM.Backup
ms.assetid: 331F32CB-7777-401C-A42A-23098944CFBE
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.backup/get-azurermbackupjob
schema: 2.0.0
---

# Get-AzureRmBackupJob

## SYNOPSIS
Gets Backup jobs.

## SYNTAX

### FiltersSet (Default)
```
Get-AzureRmBackupJob -Vault <AzureRMBackupVault> [-JobId <String>] [-From <DateTime>] [-To <DateTime>]
 [-Status <String>] [-Type <String>] [-Operation <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### JobsListFilter
```
Get-AzureRmBackupJob -Job <AzureRMBackupJob> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmBackupJob** cmdlet gets Azure Backup jobs for a specific vault.

## EXAMPLES

### Example 1: Get all jobs in a Backup vault
```
PS C:\>$Vault = Get-AzureRmBackupVault -Name "Vault03"
PS C:\> Get-AzureRmBackupJob -Vault $Vault
WorkloadName    Operation       Status          StartTime              EndTime
------------    ---------       ------          ---------              -------
co03-vm         Backup          InProgress      26-Aug-15 12:24:01 PM  01-Jan-01 12:00:00 AM
co03-vm         ConfigureBackup Completed       26-Aug-15 12:19:49 PM  26-Aug-15 12:19:54 PM
co03-vm         Register        Completed       25-Aug-15 3:23:53 PM   25-Aug-15 3:25:00 PM
```

The first command gets the vault named Vault03 by using the **Get-AzureRmBackupVault** cmdlet.
The command stores that object in the $Vault variable.

The second command gets all the jobs for the vault in $Vault.

### Example 2: Get completed jobs
```
PS C:\>Get-AzureRmBackupJob -Vault $Vault -Status Completed
WorkloadName    Operation       Status          StartTime              EndTime
------------    ---------       ------          ---------              -------
co03-vm         Register        Completed       25-Aug-15 3:23:53 PM   25-Aug-15 3:25:00 PM
```

This command gets completed jobs from the vault in $Vault.

### Example 3: Get failed jobs for the last week
```
PS C:\>Get-AzureRmBackupJob -Vault $Vault -From (Get-Date).AddDays(-7) -Status Failed
```

This command gets failed jobs from the last week from the vault in $Vault.
The *From* parameter specifies a time seven days in the past.
The command does not specify a value for the *To* parameter.
Therefore, it uses the default value of the current time.

### Example 4: Poll Backup for an in progress job that finishes
```
PS C:\>$Jobs = Get-AzureRmBackupJob -Vault $Vault -Status InProgress
$Job = $Jobs[0] 
while ( $Job.Status -ne Completed ) 
{
   Write-Host "Waiting for completion..." 
   Start-Sleep -Seconds 10
   $job = Get-AzureRmBackupJob -Vault $Vault -Job $Job
}
Write-Host "Done!"
Waiting for completion... 
Waiting for completion... 
Waiting for completion... 
Done!
```

This script polls the first job that is currently in progress until the job has completed.

The first line of the script gets all the jobs in $Vault that are in progress, and then stores those jobs in the $Jobs array variable.

The second line stores the first job from the $Jobs array in the $Job variable.

The third line starts a **while** loop that checks the current status of the job until the job is completed.
For information about the **while** keyword, type `Get-Help about_While`.

The **while** loop writes a message to the console, sleeps for ten seconds, and then updates the $Job variable.
The script updates the $Job variable by using existing value of $Job and the current cmdlet to get the current status of the job.
For information about the Windows PowerShell cmdlets, type `Get-Help Write-Host` and `Get-Help Start-Sleep`.

The final line of the script tells you that the script has finished.

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

### -From
Specifies the start, as a **DateTime** object, of a time range for the jobs that this cmdlet gets.
To obtain a **DateTime** object, use the Get-Date cmdlet.
For more information about **DateTime** objects, type `Get-Help Get-Date`.

```yaml
Type: DateTime
Parameter Sets: FiltersSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Job
Specifies a job that this cmdlet gets.
To obtain an **AzureRmBackupJob** object, use the Get-AzureRmBackupJob cmdlet.

```yaml
Type: AzureRMBackupJob
Parameter Sets: JobsListFilter
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobId
Specifies the ID of a job that this cmdlet gets.
The ID is the **InstanceId** property of an **AzureRmBackupJob** object.
To obtain an **AzureRmBackupJob** object, use Get-AzureRmBackupJob.

```yaml
Type: String
Parameter Sets: FiltersSet
Aliases: 

Required: False
Position: Named
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
Type: String
Parameter Sets: FiltersSet
Aliases: 
Accepted values: Backup, ConfigureBackup, DeleteBackupData, Register, Restore, UnProtect, Unregister

Required: False
Position: Named
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

You can specify this parameter to find all in progress jobs or all failed jobs.

```yaml
Type: String
Parameter Sets: FiltersSet
Aliases: 
Accepted values: Cancelled, Cancelling, Completed, CompletedWithWarnings, Failed, InProgress

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -To
Specifies the end, as a **DateTime** object, of a time range for the jobs that this cmdlet gets.
The default value is the current system time.
If you specify this parameter, you must also specify the *From* parameter.

```yaml
Type: DateTime
Parameter Sets: FiltersSet
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Specifies the type of container for which this cmdlet gets backup jobs.
Currently, the only supported value is AzureVM.

```yaml
Type: String
Parameter Sets: FiltersSet
Aliases: 
Accepted values: AzureVM

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Specifies the Backup vault for which this cmdlet gets jobs.
To obtain an **AzureRmBackupVault** object, use the Get-AzureRmBackupVault cmdlet.

```yaml
Type: AzureRMBackupVault
Parameter Sets: FiltersSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### AzureRmBackupVault

## OUTPUTS

### AzureRmBackupJob[]
This cmdlet returns one or more Backup jobs.

## NOTES
* None

## RELATED LINKS

[Get-AzureRmBackupVault](./Get-AzureRmBackupVault.md)

[Stop-AzureRmBackupJob](./Stop-AzureRmBackupJob.md)

[Wait-AzureRmBackupJob](./Wait-AzureRmBackupJob.md)


