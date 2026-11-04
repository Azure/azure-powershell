### Example 1: Validate a test failover cleanup
```powershell
Test-AzResiliencyRecoveryPlanTestFailoverCleanupValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Validates that the test failover resources can be cleaned up. `-OperationId` is a client-generated GUID that identifies this long-running operation.
