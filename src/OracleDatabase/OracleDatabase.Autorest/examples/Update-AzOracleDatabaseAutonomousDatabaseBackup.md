### Example 1: Update a Backup for an Autonomous Database resource
```powershell
Update-AzOracleDatabaseAutonomousDatabaseBackup -Adbbackupid "testBackupId" -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -RetentionPeriodInDay 91
```

Update a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Update-AzOracleDatabaseAutonomousDatabaseBackup`.