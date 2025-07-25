### Example 1: List all app configuration stores under a subscription
```powershell
Get-AzAppConfigurationStore
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
eastus   azpstestappstore  azpstest-gp
```

This command lists all app configuration stores under a subscription.

### Example 2: List all app configuration stores under a resource group
```powershell
Get-AzAppConfigurationStore -ResourceGroupName azpstest_gp
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

This command lists all app configuration stores under a resource group.

### Example 3: Get an app configuration store by name
```powershell
Get-AzAppConfigurationStore -Name azpstest-appstore -ResourceGroupName azpstest_gp
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azpstest-appstore azpstest_gp
```

This command gets an app configuration store by name.