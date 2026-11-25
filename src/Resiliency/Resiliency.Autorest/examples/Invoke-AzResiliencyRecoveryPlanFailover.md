### Example 1: Fail over a recovery plan
```powershell
Invoke-AzResiliencyRecoveryPlanFailover -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -FailoverRequestPropertySourceLocation eastus2-az2 -ExecutionConfigurationUserConsent Allowed
```

Fails over the resources of the recovery plan away from zone 2 of East US 2. `-OperationId` is a client-generated GUID that identifies this long-running operation.
