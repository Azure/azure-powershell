### Example 1: Resume a recovery job
```powershell
Resume-AzResilienceRecoveryJob `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Resumes a recovery job that is paused awaiting operator input.
