### Example 1: Regenerate key of an app configuration store
```powershell
$keys = Get-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp
New-AzAppConfigurationStoreKey -Name azpstest-appstore -ResourceGroupName azpstest_gp -Id $keys[0].id
```

This command regenerate key of an app configuration store.