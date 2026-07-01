### Example 1: Create a weighted endpoint with a health policy
```powershell
New-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-primary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Target "primary.contoso.internal." -MonitoringTarget "primary-health.contoso.internal." -EndpointStatus "Enabled" -Weight 60 -Priority 1 -AlwaysServe "Disabled" -HealthPolicyId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/demo-rg/providers/Microsoft.Network/PrivateTrafficManagerProfiles/weighted-profile/healthPolicies/hp1"
```

```output
Name                  Target                         EndpointStatus Weight Priority ProvisioningState
----                  ------                         -------------- ------ -------- -----------------
web-endpoint-primary  primary.contoso.internal.      Enabled        60     1        Succeeded
```

This command creates a new endpoint with weighted routing, a monitoring target for health probing, and an associated health policy.

### Example 2: Create a simple endpoint with always-serve enabled
```powershell
New-AzPrivateTrafficManagerEndpoint -Name "web-endpoint-secondary" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -Target "10.10.10.25" -EndpointStatus "Enabled" -Weight 40 -AlwaysServe "Enabled"
```

```output
Name                    Target       EndpointStatus Weight Priority ProvisioningState
----                    ------       -------------- ------ -------- -----------------
web-endpoint-secondary  10.10.10.25  Enabled        40              Succeeded
```

This command creates an endpoint that always serves traffic regardless of health status.

