### Example 1: Get a specific Private Traffic Manager profile
```powershell
Get-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Weighted             Enabled       Succeeded
```

This command gets the specified Private Traffic Manager profile by name and resource group.

### Example 2: List all Private Traffic Manager profiles in a resource group
```powershell
Get-AzPrivateTrafficManagerProfile -ResourceGroupName "demo-rg"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Weighted             Enabled       Succeeded
priority-profile  global   Priority             Enabled       Succeeded
```

This command lists all Private Traffic Manager profiles in the specified resource group.

