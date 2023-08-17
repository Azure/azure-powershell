### Example 1: Deletes account.
```powershell
Remove-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp
```

Deletes account.

### Example 2: Deletes account.
```powershell
Get-AzDeviceUpdateAccount -Name azpstest-account -ResourceGroupName azpstest_gp | Remove-AzDeviceUpdateAccount
```

Deletes account.