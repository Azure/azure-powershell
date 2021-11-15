### Example 1: Add Daily schedule to Azure Backup rule.
```powershell
PS C:\> $schedule = New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays (get-date) -IntervalType Daily -IntervalCount 1
PS C:\> Edit-AzDataProtectionPolicyTriggerClientObject -Policy $pol -Schedule $schedule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command updates backup schedule of given policy to daily backup.


