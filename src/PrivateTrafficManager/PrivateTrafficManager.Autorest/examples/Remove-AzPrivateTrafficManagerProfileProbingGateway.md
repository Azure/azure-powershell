### Example 1: Remove a probing gateway association
```powershell
Remove-AzPrivateTrafficManagerProfileProbingGateway -Name "gateway-east" -PrivateTrafficManagerProfileName "basic-profile" -ResourceGroupName "demo-rg"
```

This command removes the association from the profile without deleting the probing gateway infrastructure.

