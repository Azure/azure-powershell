### Example 1: Get a specific health policy
```powershell
Get-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command gets the specified health policy from the Private Traffic Manager profile.

### Example 2: List all health policies in a profile
```powershell
Get-AzPrivateTrafficManagerHealthPolicy -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name                Kind   ProvisioningState
----                ----   -----------------
hp1                 Probe  Succeeded
https-probe-policy  Probe  Succeeded
```

This command lists all health policies configured for the specified profile.

