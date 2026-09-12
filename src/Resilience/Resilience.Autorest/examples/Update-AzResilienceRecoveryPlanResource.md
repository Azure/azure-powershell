### Example 1: Update a recovery plan resource
```powershell
Update-AzResilienceRecoveryPlanResource `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Updates the specified recovery plan resource, preserving properties that are not supplied.
