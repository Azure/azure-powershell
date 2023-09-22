### Example 1: List the properties of connectedEnvironment by sub.
```powershell
Get-AzContainerAppConnectedEnv
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-connectedenv azps_test_group_app
```

List the properties of connectedEnvironment by sub.

### Example 2: List the properties of connectedEnvironment by resource group name.
```powershell
Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-connectedenv azps_test_group_app
```

List the properties of connectedEnvironment by resource group name.

### Example 3: Get the properties of an connectedEnvironment by name.
```powershell
Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
```

```output
Location Name              ResourceGroupName
-------- ----              -----------------
eastus   azps-connectedenv azps_test_group_app
```

Get the properties of an connectedEnvironment by name.