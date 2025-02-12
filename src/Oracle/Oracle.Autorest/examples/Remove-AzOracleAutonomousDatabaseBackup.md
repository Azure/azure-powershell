### Example 1: Delete a Backup for an Autonomous Database resource
```powershell
Remove-AzOracleAutonomousDatabaseBackup -Adbbackupid "testBackupId" -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

Delete a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Remove-AzOracleAutonomousDatabaseBackup`.