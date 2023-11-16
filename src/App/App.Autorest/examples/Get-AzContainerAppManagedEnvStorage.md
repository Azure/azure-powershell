### Example 1: List storage for a managedEnvironment.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

List storage for a managedEnvironment.

### Example 2: Get storage for a managedEnvironment by name.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a managedEnvironment by name.

### Example 3: Get storage for a managedEnvironment.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app
Get-AzContainerAppManagedEnvStorage -ManagedEnvironmentInputObject $managedenv -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a managedEnvironment.