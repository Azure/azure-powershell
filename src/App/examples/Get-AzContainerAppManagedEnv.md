### Example 1: List the properties of ManagedEnvironments.
```powershell
Get-AzContainerAppManagedEnv
```

```output
Location      Name      ResourceGroupName
--------      ----      -----------------
canadacentral azcli-env azcli_gp
canadacentral azps-env  azpstest_gp
```

List the properties of ManagedEnvironments.

### Example 2: Get the properties of ManagedEnvironments by Resource Group.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azpstest_gp
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
canadacentral azps-env azpstest_gp
```

Get the properties of ManagedEnvironments by Resource Group.

### Example 3: Get the properties of a ManagedEnvironment by name.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azpstest_gp -EnvName azps-env
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
canadacentral azps-env azpstest_gp
```

Get the properties of a ManagedEnvironment by name.