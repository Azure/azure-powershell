### Example 1: List all recovery job resources in a service group
```powershell
Get-AzResilienceRecoveryJobResource `
  -RecoveryJobName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing'
```

Lists every recovery job resource in the specified service group.
