### Example 1: Creates a Backup for an Autonomous Database resource
```powershell
New-AzOracleDatabaseAutonomousDatabaseBackup -Adbbackupid "testBackupId" -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -RetentionPeriodInDay 90
```

Creates a Backup for an Autonomous Database resource.
For more information, execute `Get-Help New-AzOracleDatabaseAutonomousDatabase`