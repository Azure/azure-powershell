### Example 1: Validate a failover commit
```powershell
Test-AzResiliencyRecoveryPlanFailoverCommitValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Validates that the completed failover can be committed. `-OperationId` is a client-generated GUID that identifies this long-running operation.
