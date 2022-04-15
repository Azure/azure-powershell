---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: E247C6DF-B53D-487E-AAA2-551FCBFD77E7
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupschedulepolicyobject
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupSchedulePolicyObject

## SYNOPSIS
Gets a base schedule policy object.

## SYNTAX

```
Get-AzRecoveryServicesBackupSchedulePolicyObject [-WorkloadType] <WorkloadType>
 [[-BackupManagementType] <BackupManagementType>] [-DefaultProfile <IAzureContextContainer>]
 [[-ScheduleRunFrequency] <ScheduleRunType>] [[-PolicySubType] <PSPolicyType>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzRecoveryServicesBackupSchedulePolicyObject** cmdlet gets a base **AzureRMRecoveryServicesSchedulePolicyObject**.
This object is not persisted in the system.
It is temporary object that you can manipulate and use with the New-AzRecoveryServicesBackupProtectionPolicy cmdlet to create a new backup protection policy.

## EXAMPLES

### Example 1: Set the schedule frequency to weekly
```powershell
$RetPol = Get-AzRecoveryServicesBackupRetentionPolicyObject -WorkloadType "AzureVM" 
$SchPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM" 
$SchPol.ScheduleRunFrequency = "Weekly"
New-AzRecoveryServicesBackupProtectionPolicy -Name "NewPolicy" -WorkloadType AzureVM -RetentionPolicy $RetPol -SchedulePolicy $SchPol
```

The first command gets the retention policy object, and then stores it in the $RetPol variable.
The second command gets the schedule policy object, and then stores it in the $SchPol variable.
The third command changes the frequency for the schedule policy to weekly.
The last command creates a backup protection policy with the updated schedule.

### Example 2: Set the backup time
```powershell
$SchPol = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType "AzureVM" 
$SchPol.ScheduleRunTimes.RemoveAll()
$DT = Get-Date
$SchPol.ScheduleRunTimes.Add($DT.ToUniversalTime())
New-AzRecoveryServicesBackupProtectionPolicy -Name "NewPolicy" -WorkloadType AzureVM -RetentionPolicy $RetPol -SchedulePolicy $SchPol
```

The first command gets the schedule policy object, and then stores it in the $SchPol variable.
The second command removes all scheduled run times from $SchPol.
The third command gets the current date and time, and then stores it in the $DT variable.
The fourth command replaces the scheduled run times with the current time.
You can only backup AzureVM once per day, so to reset the backup time you must replace the original schedule.
The last command creates a backup protection policy using the new schedule.

### Example 3: Get hourly schedule for fileshare policy
```powershell
$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureFiles -BackupManagementType AzureStorage -ScheduleRunFrequency Hourly
$timeZone = Get-TimeZone
$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id
$startTime = Get-Date -Date "2021-12-22T06:00:00.00+00:00"
$schedulePolicy.ScheduleWindowStartTime = $startTime.ToUniversalTime()
$schedulePolicy.ScheduleInterval = 6
$schedulePolicy.ScheduleWindowDuration = 14
```

The first command gets a base hourly **SchedulePolicyObject**, and then stores it in the $schedulePolicy variable.
The second and third command fetches the timezone and updates the timezone in the $schedulePolicy.
The fourth and fifth command initializes the schedule window start time and updates the $schedulePolicy. Please note the start time must be in UTC even if the timezone is not UTC. 
The sixth and seventh command updates the interval (in hours) after which the backup will be retriggered on the same day, duration (in hours) for which the schedule will run.

### Example 4: Get enhanced hourly schedule for AzureVM policy
```powershell
$schedulePolicy = Get-AzRecoveryServicesBackupSchedulePolicyObject -WorkloadType AzureVM -BackupManagementType AzureVM -PolicySubType Enhanced -ScheduleRunFrequency Hourly
$timeZone = Get-TimeZone -ListAvailable | Where-Object { $_.Id -match "India" }
$schedulePolicy.ScheduleRunTimeZone = $timeZone.Id
$windowStartTime = (Get-Date -Date "2022-04-14T08:00:00.00+00:00").ToUniversalTime()
$schPol.HourlySchedule.WindowStartTime = $windowStartTime
$schedulePolicy.HourlySchedule.ScheduleInterval = 4
$schedulePolicy.HourlySchedule.ScheduleWindowDuration = 23
```

The first command gets a base enhanced hourly **SchedulePolicyObject** for WorkloadType AzureVM, and then stores it in the $schedulePolicy variable.
The second and third command fetches the India timezone and updates the timezone in the $schedulePolicy.
The fourth and fifth command initializes the schedule window start time and updates the $schedulePolicy. Please note that the start time must be in UTC even if the timezone is not UTC. 
The sixth and seventh command updates the interval (in hours) after which the backup will be retriggered on the same day, duration (in hours) for which the schedule will run.

## PARAMETERS

### -BackupManagementType
The class of resources being protected. The acceptable values for this parameter are:
- AzureVM 
- AzureStorage
- AzureWorkload

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType]
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, AzureStorage, AzureWorkload

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -PolicySubType
Type of schedule policy to be fetched: Standard, Enhanced

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.PSPolicyType
Parameter Sets: (All)
Aliases:
Accepted values: Standard, Enhanced

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleRunFrequency
Schedule run frequency for the policy schedule.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ScheduleRunType
Parameter Sets: (All)
Aliases:
Accepted values: Daily, Hourly, Weekly

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadType
Workload type of the resource. The acceptable values for this parameter are:
- AzureVM 
- AzureFiles
- MSSQL


```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, AzureFiles, MSSQL

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.SchedulePolicyBase

## NOTES

## RELATED LINKS

[New-AzRecoveryServicesBackupProtectionPolicy](./New-AzRecoveryServicesBackupProtectionPolicy.md)

[Set-AzRecoveryServicesBackupProtectionPolicy](./Set-AzRecoveryServicesBackupProtectionPolicy.md)


