### Example 1: Finalize a recovery plan
```powershell
Invoke-AzResiliencyRecoveryPlanFinalize -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Finalizes the recovery plan after failover and reprotect are complete. `-OperationId` is a client-generated GUID that identifies this long-running operation.
