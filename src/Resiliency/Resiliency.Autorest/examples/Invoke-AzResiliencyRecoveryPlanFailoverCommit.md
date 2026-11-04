### Example 1: Commit a failover
```powershell
Invoke-AzResiliencyRecoveryPlanFailoverCommit -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Commits the completed failover of the recovery plan. `-OperationId` is a client-generated GUID that identifies this long-running operation.
