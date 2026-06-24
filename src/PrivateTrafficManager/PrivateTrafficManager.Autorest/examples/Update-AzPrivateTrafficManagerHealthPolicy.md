### Example 1: Update a health policy by identity
```powershell
Update-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command updates the health policy. Note that this cmdlet currently has no updatable body parameters; it only accepts identity parameters.

### Example 2: Update a health policy using pipeline input
```powershell
Get-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" | Update-AzPrivateTrafficManagerHealthPolicy
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command retrieves a health policy and pipes it to the update cmdlet.

