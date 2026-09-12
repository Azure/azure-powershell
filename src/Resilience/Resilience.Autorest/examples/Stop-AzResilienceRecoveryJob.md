### Example 1: Stop a recovery job
```powershell
Stop-AzResilienceRecoveryJob `
  -Name '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Stops the running recovery job and records the attestation outcome.
