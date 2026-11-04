### Example 1: Validate a test failover
```powershell
Test-AzResiliencyRecoveryPlanTestFailoverValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FailoverRequestPropertySourceLocation eastus2-az2
```

Validates a test failover of the recovery plan. `-OperationId` is a client-generated GUID that identifies this long-running operation.
