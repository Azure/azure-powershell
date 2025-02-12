### Example 1: Get a list of the Autonomous Database Backups for an Autonomous Database resource
```powershell
Get-AzOracleAutonomousDatabaseBackup -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

```output
Name                                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
Jul 06, 2024 01:54:13 UTC                                                                                                                                                             PowerShellTestRg
Jul 05, 2024 15:26:01 UTC                                                                                                                                                             PowerShellTestRg
autonomousdatabasebackup20240705141147                                                                                                                                                PowerShellTestRg
autonomousdatabasebackup20240705135809                                                                                                                                                PowerShellTestRg
Jul 04, 2024 12:00:52 UTC                                                                                                                                                             PowerShellTestRg
```

Get a list of the Autonomous Database Backups for an Autonomous Database resource.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabaseBackup`