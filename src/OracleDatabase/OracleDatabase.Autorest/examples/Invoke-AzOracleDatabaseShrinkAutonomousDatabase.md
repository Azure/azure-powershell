### Example 1: Shrinks the current allocated storage down to the current actual used data storage on an Autonomous Database resource
```powershell
Invoke-AzOracleDatabaseShrinkAutonomousDatabase -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

Shrinks the current allocated storage down to the current actual used data storage on an Autonomous Database resource.
For more information, execute `Get-Help Invoke-AzOracleDatabaseShrinkAutonomousDatabase`