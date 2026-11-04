### Example 1: Validate a recovery operation
```powershell
Test-AzResiliencyRecoveryPlanOperationValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -OperationName Failover
```

Validates that the failover operation can run on the recovery plan. `-OperationId` is a client-generated GUID that identifies this long-running operation.
