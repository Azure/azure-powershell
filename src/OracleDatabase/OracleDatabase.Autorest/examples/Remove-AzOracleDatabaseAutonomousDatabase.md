### Example 1: Deletes an Autonomous Database resource
```powershell
Remove-AzOracleDatabaseAutonomousDatabase -NoWait -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
```

```output
Target                                                                                                                  
------                                                                                                                  
https://management.azure.com/subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/providers/Oracle.Database/locations/EASTUS/operationStatuses/e6c5d63d-1c35-427e-8183-aa8c3bb8d8cc*EB99FC0E7CF00BAC9CF0656749107E4121167A81B99F4498184E967E11671798?api-vers…
```

Deletes an Autonomous Database resource.
For more information, execute `Get-Help Remove-AzOracleDatabaseAutonomousDatabase`