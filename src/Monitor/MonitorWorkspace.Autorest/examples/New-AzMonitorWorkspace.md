### Example 1: Create or update a workspace.
```powershell
New-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group -Location eastus
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Create or update a workspace.