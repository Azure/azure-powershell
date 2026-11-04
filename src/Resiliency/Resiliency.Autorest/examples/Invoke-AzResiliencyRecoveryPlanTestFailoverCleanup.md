### Example 1: Clean up a test failover
```powershell
Invoke-AzResiliencyRecoveryPlanTestFailoverCleanup -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -Comment "Test failover verified."
```

Cleans up the resources created by the test failover. `-OperationId` is a client-generated GUID that identifies this long-running operation.
