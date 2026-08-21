### Example 1: Create or update a workspace
```powershell
Set-AzMonitorWorkspace -Name azps-monitor-workspace -ResourceGroupName azps_test_group -Location eastus -EnableSystemAssignedIdentity $true -Tag @{environment="test"}
```

```output
Name                   Location ProvisioningState PublicNetworkAccess ResourceGroupName
----                   -------- ----------------- ------------------- -----------------
azps-monitor-workspace eastus   Succeeded         Enabled             azps_test_group
```

Creates or updates the workspace.
