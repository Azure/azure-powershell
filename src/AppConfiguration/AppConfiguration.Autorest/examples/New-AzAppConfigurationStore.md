### Example 1: Creates a configuration store with the specified parameters.
```powershell
New-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp -Location eastus -Sku Standard
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

Creates a configuration store with the specified parameters.