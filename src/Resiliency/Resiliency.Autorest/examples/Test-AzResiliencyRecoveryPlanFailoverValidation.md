### Example 1: Validate a failover
```powershell
Test-AzResiliencyRecoveryPlanFailoverValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FailoverRequestPropertySourceLocation eastus2-az2
```

Validates a failover of the recovery plan away from zone 2 of East US 2. `-OperationId` is a client-generated GUID that identifies this long-running operation.
