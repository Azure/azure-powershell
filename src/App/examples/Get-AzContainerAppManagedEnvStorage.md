### Example 1: Get storage for a managedEnvironment.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azpstest_gp
```

Get storage for a managedEnvironment.

### Example 2: Get storage for a managedEnvironment by StorageName.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azpstest_gp -StorageName azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azpstest_gp
```

Get storage for a managedEnvironment by StorageName.