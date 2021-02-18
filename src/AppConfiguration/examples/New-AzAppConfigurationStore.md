### Example 1: Create an app configuration store
```powershell
PS C:\> New-AzAppConfigurationStore -Name appconfig-test03 -ResourceGroupName azpwsh-manual-test -Location eastus -Sku free

Location Name             Type
-------- ----             ----
eastus   appconfig-test03 Microsoft.AppConfiguration/configurationStores
```

This command creates an app configuration store.

### Example 2: Create an app configuration with the IdentityType set to "UserAssigned"
```powershell
PS C:\> $assignedIdentity = New-AzUserAssignedIdentity -ResourceGroupName azpwsh-manual-test -Name assignedIdentity
PS C:\> New-AzAppConfigurationStore -Name appconfig-test10 -ResourceGroupName azpwsh-manual-test -Location eastus -Sku standard -IdentityType "UserAssigned" -UserAssignedIdentity $assignedIdentity.Id

Location Name             Type
-------- ----             ----
eastus   appconfig-test03 Microsoft.AppConfiguration/configurationStores
```

This command creates an app configuration and assign a user-assigned managed identity to it.
See the example of `Update-AzAppConfigurationStore` for the following steps to enable CMK (cusomer managed key).

### Example 3: Create an app configuration with the IdentityType set to "SystemAssigned" 
```powershell
PS C:\> New-AzAppConfigurationStore -Name appconfig-test11 -ResourceGroupName azpwsh-manual-test -Location eastus -Sku standard -IdentityType "SystemAssigned"

Location Name             Type
-------- ----             ----
eastus   appconfig-test11 Microsoft.AppConfiguration/configurationStores
```

This command creates an app configuration and enables the system-assigned managed identity associated with the resource.
See the example of `Update-AzAppConfigurationStore` for the following steps to enable CMK (cusomer managed key).

### Example 4: Create an app configuration with the IdentityType set to "SystemAssigned, UserAssigned"
```powershell
PS C:\> $assignedIdentity = New-AzUserAssignedIdentity -ResourceGroupName azpwsh-manual-test -Name assignedIdentity
PS C:\> New-AzAppConfigurationStore -Name appconfig-test10 -ResourceGroupName azpwsh-manual-test -Location eastus -Sku standard -IdentityType "SystemAssigned, UserAssigned" -UserAssignedIdentity $assignedIdentity.Id

Location Name             Type
-------- ----             ----
eastus   appconfig-test10 Microsoft.AppConfiguration/configurationStores
```

You can enable system-assigned managed identity and give user-assigned identities at the same time.
See the example of `Update-AzAppConfigurationStore` for the following steps to enable CMK (cusomer managed key).