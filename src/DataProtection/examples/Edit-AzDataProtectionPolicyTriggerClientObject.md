### Example 1: Add Daily schedule to Azure Backup rule.
```powershell
$schedule = New-AzDataProtectionPolicyTriggerScheduleClientObject -ScheduleDays (Get-Date) -IntervalType Daily -IntervalCount 1
Edit-AzDataProtectionPolicyTriggerClientObject -Policy $pol -Schedule $schedule
```

```output
DatasourceType            ObjectType
--------------            ----------
{Microsoft.Compute/disks} BackupPolicy
```

This command updates backup schedule of given policy to daily backup.


