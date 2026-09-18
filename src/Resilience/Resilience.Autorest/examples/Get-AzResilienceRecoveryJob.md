### Example 1: List all recovery jobs in a service group
```powershell
Get-AzResilienceRecoveryJob `
  -RecoveryPlanName 'rp-payments-regional' `
  -ServiceGroupName 'azcmdlet-testing'
```

Lists every recovery job in the specified service group.
