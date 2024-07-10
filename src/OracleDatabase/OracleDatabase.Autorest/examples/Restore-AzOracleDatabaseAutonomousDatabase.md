### Example 1: Restore an Autonomous Database resource
```powershell
$timeStampString = '01-Jul-16'
$timeStamp = [datetime]::parseexact($timeStampString, 'dd-MMM-yy', $null)
Restore-AzOracleDatabaseAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Timestamp $timeStamp
```

Restore an Autonomous Database resource.
For more information, execute `Get-Help Restore-AzOracleDatabaseAutonomousDatabase`.