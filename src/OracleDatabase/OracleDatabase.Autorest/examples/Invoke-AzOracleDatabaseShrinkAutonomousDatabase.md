### Example 1: Shrink the current allocated storage down to the current actual used data storage on an Autonomous Database resource
```powershell
Invoke-AzOracleDatabaseShrinkAutonomousDatabase -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

Shrink the current allocated storage down to the current actual used data storage on an Autonomous Database resource.
For more information, execute `Get-Help Invoke-AzOracleDatabaseShrinkAutonomousDatabase`.