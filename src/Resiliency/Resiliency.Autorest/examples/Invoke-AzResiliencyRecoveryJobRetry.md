### Example 1: Retry a failed recovery job
```powershell
Invoke-AzResiliencyRecoveryJobRetry -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -RecoveryJobName contoso-recovery-job -OperationId (New-Guid).Guid
```

Retries a failed recovery job. `-OperationId` is a client-generated GUID that identifies this long-running operation.
