### Example 1: Switchover an Autonomous Database resource
```powershell
Invoke-AzOracleSwitchoverAutonomousDatabase -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -PeerDbId "PeerDbId"
```

Switchover an Autonomous Database resource.
For more information, execute `Get-Help Invoke-AzOracleSwitchoverAutonomousDatabase`.