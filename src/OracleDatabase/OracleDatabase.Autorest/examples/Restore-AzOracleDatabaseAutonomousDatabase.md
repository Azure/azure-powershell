### Example 1: Restore a Backup for an Autonomous Database resource
```powershell
$timeStampString = '01-Jan-24'
$timeStamp = [datetime]::parseexact($timeStampString, 'dd-MMM-yy', $null)
Restore-AzOracleDatabaseAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Timestamp $timeStamp
```

Restore a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Restore-AzOracleDatabaseAutonomousDatabase`.