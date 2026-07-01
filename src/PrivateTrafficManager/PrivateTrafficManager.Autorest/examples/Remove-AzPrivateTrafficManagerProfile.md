### Example 1: Remove a Private Traffic Manager profile
```powershell
Remove-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

This command removes the specified Private Traffic Manager profile and all its associated endpoints and health policies.

### Example 2: Remove a Private Traffic Manager profile with confirmation prompt
```powershell
Remove-AzPrivateTrafficManagerProfile -PrivateTrafficManagerProfileName "priority-profile" -ResourceGroupName "demo-rg" -Confirm
```

This command removes the specified Private Traffic Manager profile after prompting for confirmation.

