### Example 1: List storage by connected env name.
```powershell
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

List storage by connected env name.

### Example 2: Get storage for a connectedEnvironment by name.
```powershell
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a connectedEnvironment by name.

### Example 3: Get storage for a connectedEnvironment.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject $connectedenv -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a connectedEnvironment.