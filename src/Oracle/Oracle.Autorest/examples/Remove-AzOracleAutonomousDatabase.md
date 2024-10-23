### Example 1: Delete an Autonomous Database resource
```powershell
Remove-AzOracleAutonomousDatabase -NoWait -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

```output
Target                                                                                                                  
------                                                                                                                  
https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/providers/Oracle.Database/locations/EASTUS/operationStatuses/e6c5d63d-1c35-427e-8183-aa8c3bb8d8cc*EB99FC0E7CF00BAC9CF0656749107E4121167A81B99F4498184E967E11671798?api-vers…
```

Delete an Autonomous Database resource.
For more information, execute `Get-Help Remove-AzOracleAutonomousDatabase`.