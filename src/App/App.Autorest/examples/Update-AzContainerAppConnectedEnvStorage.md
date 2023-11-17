### Example 1: Create storage for a connectedEnvironment.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]

Update-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Create storage for a connectedEnvironment.

### Example 2: Create storage for a connectedEnvironment.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv

Update-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject $connectedenv -Name azpstestsa -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Create storage for a connectedEnvironment.

### Example 3: Create storage for a connectedEnvironment.
```powershell
$storageAccountKey = (Get-AzStorageAccountKey -ResourceGroupName azps_test_group_app -AccountName azpstestsa).Value[0]
$connectedenvstorage = Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa

Update-AzContainerAppConnectedEnvStorage -InputObject $connectedenvstorage -AzureFileAccessMode 'ReadWrite' -AzureFileAccountKey $storageAccountKey -AzureFileAccountName azpstestsa -AzureFileShareName azps-rw-sharename
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Create storage for a connectedEnvironment.