### Example 1: Update a managed environment storage.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]

Update-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Update a managed environment storage.

### Example 2: Update a managed environment storage.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]
$managedenvstorage = Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa

Update-AzContainerAppManagedEnvStorage -InputObject $managedenvstorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Update a managed environment storage.

### Example 3: Update a managed environment storage.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app

Update-AzContainerAppManagedEnvStorage -ManagedEnvironmentInputObject $managedenv -Name azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Update a managed environment storage.