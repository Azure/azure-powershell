### Example 1: Run recovery plan failover
```powershell
Invoke-AzResilienceRecoveryPlanFailover `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -FailoverRequestPropertySourceLocation @('eastus')
```

Starts the recovery plan failover operation and returns the job that tracks it.
