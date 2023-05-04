### Example 1: List the specific Azure Monitor workspace.
```powershell
Get-AzMonitorWorkspace
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

List the specific Azure Monitor workspace.

### Example 2: List the specific Azure Monitor workspace by Resource Groupy.
```powershell
Get-AzMonitorWorkspace -ResourceGroupName azps_test_group
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

List the specific Azure Monitor workspace by Resource Groupy.

### Example 3: Get the specific Azure Monitor workspace by monitor workspace name.
```powershell
Get-AzMonitorWorkspace -ResourceGroupName azps_test_group -Name azps-monitor-workspace
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Get the specific Azure Monitor workspace by monitor workspace name.