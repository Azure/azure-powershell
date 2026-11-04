### Example 1: Run a test failover
```powershell
Invoke-AzResiliencyRecoveryPlanTestFailover -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FailoverRequestPropertySourceLocation eastus2-az2 -ExecutionConfigurationUserConsent Allowed
```

Runs a test failover of the recovery plan without affecting production. `-OperationId` is a client-generated GUID that identifies this long-running operation.
