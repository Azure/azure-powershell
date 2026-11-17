### Example 1: Resume a recovery job
```powershell
Resume-AzResiliencyRecoveryJob -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -Name contoso-recovery-job -OperationId (New-Guid).Guid -Description "Manual step completed."
```

Resumes a paused recovery job. `-OperationId` is a client-generated GUID that identifies this long-running operation.
