### Example 1: Retry a recovery job
```powershell
Invoke-AzResilienceRecoveryJobRetry `
  -RecoveryJobName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Retries the recovery job for resources that failed in previous attempts.
