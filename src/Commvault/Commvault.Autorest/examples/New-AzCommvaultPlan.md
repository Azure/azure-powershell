### Example 1: Create a backup plan
```powershell
$storagePlan = @{ Name = 'primary'; StoragePoolId = 'storage-hot'; CopyName = 'primary-copy'; CopyPrecedence = 1; RetentionPeriod = 30; RetentionTime = 'monthly'; BackupRuleType = 'ALL_JOBS' }
$schedule = @{ BackupType = 'INCREMENTAL'; Frequency = 'daily'; RunsEvery = 1; Time = '22:00'; TimeZone = 'UTC' }
New-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -PlanName plan-daily -Location eastus -StoragePlan $storagePlan -Schedule $schedule -RetentionNumberOfSnapshot 7
```

Creates a backup plan that runs an incremental backup every day and keeps seven snapshots.

### Example 2: Create a backup plan by using a JSON file
```powershell
New-AzCommvaultPlan -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -PlanName plan-daily -JsonFilePath '.\plan.json'
```

Creates a backup plan from the request body in the JSON file.

