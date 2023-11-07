### Example 1: List the properties of Container Apps Job by sub.
```powershell
Get-AzContainerAppJob
```

```output
Location Name         ProvisioningState ResourceGroupName
-------- ----         ----------------- -----------------
East US  azps-app-job Succeeded         azps_test_group_app
```

List the properties of Container Apps Job by sub.

### Example 2: List the properties of Container Apps Job by resource group name.
```powershell
Get-AzContainerAppJob -ResourceGroupName azps_test_group_app
```

```output
Location Name         ProvisioningState ResourceGroupName
-------- ----         ----------------- -----------------
East US  azps-app-job Succeeded         azps_test_group_app
```

List the properties of Container Apps Job by resource group name.

### Example 3: Get the properties of a Container Apps Job by name.
```powershell
Get-AzContainerAppJob -ResourceGroupName azps_test_group_app -Name azps-app-job
```

```output
Location Name         ProvisioningState ResourceGroupName
-------- ----         ----------------- -----------------
East US  azps-app-job Succeeded         azps_test_group_app
```

Get the properties of a Container Apps Job by name.