### Example 1: Remove an endpoint from a profile
```powershell
Remove-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-secondary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

This command removes the specified endpoint from the Private Traffic Manager profile.

### Example 2: Remove an endpoint with confirmation
```powershell
Remove-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-primary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Confirm
```

This command removes the specified endpoint after prompting for confirmation.

