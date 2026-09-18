### Example 1: Replace a recovery plan
```powershell
Set-AzResilienceRecoveryPlan `
  -Name 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -Description 'Default recovery group' `
  -GroupUniqueId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -OrderId 0 `
  -PlanDescription 'Regional recovery plan for the payments service' `
  -PlanType 'Regional'
```

Replaces the specified recovery plan. Properties that are not supplied are reset.
