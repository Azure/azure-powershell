### Example 1: Updates part of a workspace.
```powershell
Update-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group -Tag @{"123"="abc"}
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Updates part of a workspace.

### Example 2: Updates part of a workspace.
```powershell
Get-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group | Update-AzMonitorWorkspace -Tag @{"aaa"="bbb"}
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Updates part of a workspace.