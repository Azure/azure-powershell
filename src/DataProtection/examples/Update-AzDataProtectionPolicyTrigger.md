### Example 1: Add Daily schedule to Azure Backup rule.
```powershell
PS C:\> $schedule = New-AzDataProtectionPolicyTriggerSchedule -ScheduleDays (get-date) -IntervalType Daily -IntervalCount 1
PS C:\> Update-AzDataProtectionPolicyTrigger -Policy $pol -Schedule $schedule

DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command updates backup schedule of given policy to daily backup.


