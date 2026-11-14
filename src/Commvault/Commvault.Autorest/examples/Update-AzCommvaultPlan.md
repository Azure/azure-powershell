### Example 1: Update the retention of a backup plan
```powershell
Update-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily -RetentionNumberOfSnapshot 14
```

Changes the backup plan so that it keeps 14 snapshots.

### Example 2: Update the schedule of a backup plan
```powershell
$schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'daily'; RunsEvery = 1; Time = '23:30'; TimeZone = 'UTC' }
Update-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name plan-daily -Schedule $schedule
```

Changes the backup plan so that the daily incremental backup runs at 23:30 UTC.

