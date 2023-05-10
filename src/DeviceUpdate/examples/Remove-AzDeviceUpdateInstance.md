### Example 1: Deletes instance.
```powershell
Remove-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-instance
```

Deletes instance.

### Example 2: Deletes instance.
```powershell
Get-AzDeviceUpdateInstance -AccountName azpstest-account -ResourceGroupName azpstest_gp -Name azpstest-instance | Remove-AzDeviceUpdateInstance
```

Deletes instance.