### Example 1: Update the traffic routing method of a profile
```powershell
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -TrafficRoutingMethod "Priority"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Priority             Enabled       Succeeded
```

This command updates the traffic routing method of the specified profile from Weighted to Priority.

### Example 2: Disable a Private Traffic Manager profile
```powershell
Update-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -ProfileStatus "Disabled"
```

```output
Name              Location TrafficRoutingMethod ProfileStatus ProvisioningState
----              -------- -------------------- ------------- -----------------
weighted-profile  global   Priority             Disabled      Succeeded
```

This command disables the specified Private Traffic Manager profile.

