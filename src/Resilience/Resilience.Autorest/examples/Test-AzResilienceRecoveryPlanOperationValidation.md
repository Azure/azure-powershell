### Example 1: Validate recovery plan operation validation
```powershell
Test-AzResilienceRecoveryPlanOperationValidation `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -OperationName 'Failover'
```

Checks whether the operation can proceed and reports qualified and unqualified resources.
