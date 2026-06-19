### Example 1: Remove a health policy from a profile
```powershell
Remove-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

This command removes the specified health policy from the Private Traffic Manager profile.

### Example 2: Remove a health policy with confirmation
```powershell
Remove-AzPrivateTrafficManagerHealthPolicy -Name "https-probe-policy" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Confirm
```

This command removes the specified health policy after prompting for confirmation.

