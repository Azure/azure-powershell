### Example 1: Update the weight of an endpoint
```powershell
Update-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-primary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Weight 80
```

```output
Name                  Target                     EndpointStatus Weight Priority ProvisioningState
----                  ------                     -------------- ------ -------- -----------------
web-endpoint-primary  primary.contoso.internal.  Enabled        80     1        Succeeded
```

This command updates the weight of the specified endpoint to 80.

### Example 2: Disable an endpoint
```powershell
Update-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-secondary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -EndpointStatus "Disabled"
```

```output
Name                    Target       EndpointStatus Weight Priority ProvisioningState
----                    ------       -------------- ------ -------- -----------------
web-endpoint-secondary  10.10.10.25  Disabled       40              Succeeded
```

This command disables the specified endpoint so it no longer receives traffic.

