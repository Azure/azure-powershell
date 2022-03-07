### Example 1: List all app configuration stores under a subscription
```powershell
Get-AzAppConfigurationStore
```
```output
Location Name               Type
-------- ----               ----
eastus   appconfig-test01   Microsoft.AppConfiguration/configurationStores
eastus   contoso-app-config Microsoft.AppConfiguration/configurationStores
```

This command lists all app configuration stores under a subscription.

### Example 2: List all app configuration stores under a resource group
```powershell
Get-AzAppConfigurationStore -ResourceGroupName azpwsh-manual-test
```
```output
Location Name             Type
-------- ----             ----
eastus   appconfig-test01 Microsoft.AppConfiguration/configurationStores
eastus   appconfig-test02 Microsoft.AppConfiguration/configurationStores
```

This command lists all app configuration stores under a resource group.

### Example 3: Get an app configuration store by name
```powershell
Get-AzAppConfigurationStore -ResourceGroupName azpwsh-manual-test -Name appconfig-test01
```
```output
Location Name             Type
-------- ----             ----
eastus   appconfig-test01 Microsoft.AppConfiguration/configurationStores
```

This command gets an app configuration store by name.

### Example 4: Get an app configuration store by pipeline
```powershell
Get-AzAppConfigurationStore -ResourceGroupName azpwsh-manual-test -Name appconfig-test01 | Get-AzAppConfigurationStore
```
```output
Location Name             Type
-------- ----             ----
eastus   appconfig-test01 Microsoft.AppConfiguration/configurationStores
```

This command gets an app configuration store by pipeline.


