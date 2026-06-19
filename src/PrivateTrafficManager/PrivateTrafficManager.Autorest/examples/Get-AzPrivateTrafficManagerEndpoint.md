### Example 1: Get a specific endpoint from a profile
```powershell
Get-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-primary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name                  Target                     EndpointStatus Weight Priority ProvisioningState
----                  ------                     -------------- ------ -------- -----------------
web-endpoint-primary  primary.contoso.internal.  Enabled        60     1        Succeeded
```

This command gets the specified endpoint from the Private Traffic Manager profile.

### Example 2: List all endpoints in a profile
```powershell
Get-AzPrivateTrafficManagerEndpoint -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg"
```

```output
Name                    Target                     EndpointStatus Weight Priority ProvisioningState
----                    ------                     -------------- ------ -------- -----------------
web-endpoint-primary    primary.contoso.internal.  Enabled        60     1        Succeeded
web-endpoint-secondary  10.10.10.25                Enabled        40              Succeeded
```

This command lists all endpoints in the specified Private Traffic Manager profile.

