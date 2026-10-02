### Example 1: List all recovery resources in a service group
```powershell
Get-AzResilienceRecoveryResource `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing'
```

Lists every recovery resource in the specified service group.
