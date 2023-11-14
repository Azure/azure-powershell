### Example 1: List the properties of Managed Environment used to host container apps by sub.
```powershell
Get-AzContainerAppManagedEnv
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

List the properties of Managed Environment used to host container apps by sub.

### Example 2: List the properties of Managed Environment used to host container apps by resource group name.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

List the properties of Managed Environment used to host container apps by resource group name.

### Example 3: Get the properties of a Managed Environment used to host container apps by name.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

Get the properties of a Managed Environment used to host container apps by name.