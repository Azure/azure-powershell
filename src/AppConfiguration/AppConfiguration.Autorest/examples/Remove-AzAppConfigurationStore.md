### Example 1: Remove an app configuration store
```powershell
Remove-AzAppConfigurationStore -Name azpstestappstore -ResourceGroupName azpstest-gp
```

This command removes an app configuration store.

### Example 2: Remove an app configuration store
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp | Remove-AzAppConfigurationStore
```

This command removes an app configuration store.