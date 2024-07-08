### Example 1: Deletes a Backup for an Autonomous Database resource
```powershell
Remove-AzOracleDatabaseAutonomousDatabaseBackup -Adbbackupid "testBackupId" -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

Deletes a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Remove-AzOracleDatabaseAutonomousDatabaseBackup`