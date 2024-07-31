### Example 1: Restore a Backup for an Autonomous Database resource
```powershell
$timeStamp = Get-Date
Restore-AzOracleAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Timestamp $timeStamp
```

Restore a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Restore-AzOracleAutonomousDatabase`.