### Example 1: Cancel a recovery job
```powershell
Stop-AzResiliencyRecoveryJob -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -Name contoso-recovery-job -OperationId (New-Guid).Guid -Description "Cancelled by operator."
```

Cancels a running recovery job. `-OperationId` is a client-generated GUID that identifies this long-running operation.
